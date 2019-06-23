using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace API.Wiki.Models
{
    /// <summary>
    /// 控制器注释
    /// </summary>
    public class WikiControllerView : Attribute
    {
        public WikiControllerView()
        {
        }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Annotation { get; set; }
        /// <summary>
        /// 控制器类型
        /// </summary>
        public Type ClassType { get; internal set; }
        /// <summary>
        /// 方法集合
        /// </summary>
        public List<WikiActionView> Actions
        {
            get
            {
                //读取方法列表
                return GetActions(this.ClassType, this.Namespace);
            }
        }

        /// <summary>
        /// 读取动作集合
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        private List<WikiActionView> GetActions(Type controller, string path)
        {
            var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var list = new List<WikiActionView>();
            //公共方法
            foreach (var action in methods)
            {
                //包含自定义属性
                var methodAttribute = action.GetCustomAttribute(typeof(WikiActionAttribute));
                if (methodAttribute != null)
                {
                    //动作
                    if (!action.IsAbstract && !action.IsConstructor && !action.IsFinal)
                    {
                        var attribute = ((WikiActionAttribute)methodAttribute);
                        var actionItem = new WikiActionView
                        {
                            Path = path,
                            Name = action.Name,
                            Annotation = attribute.Name,
                            ParameterFormat = attribute.ParameterFormat,
                            Method = action
                        };
                        //actionItem.ParameterTypes = GetParameterTypes(action);
                        actionItem.ReturnResults = new List<WikiResultView>();
                        foreach (var item in attribute.ResultTypes)
                        {
                            actionItem.ReturnResults.AddRange(GetResult(item));
                        }
                        list.Add(actionItem);
                    }

                }
            }
            return list;
        }
        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="resultType"></param>
        /// <returns></returns>
        private List<WikiResultView> GetResult(Type resultType)
        {
            if (resultType == null)
            {
                return new List<WikiResultView>();
            }
            var list = new List<WikiResultView>();
            foreach (var parameter in resultType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                //包含属性
                var desAttribute = parameter.GetCustomAttribute(typeof(DescriptionAttribute));

                var itemType = parameter.PropertyType.Name;
                if (itemType == "Nullable`1")
                {
                    itemType = parameter.PropertyType.GetGenericArguments()[0].Name + "(可空)";
                }
                var resultItem = new WikiResultView
                {
                    Name = parameter.Name,
                    Type = itemType,
                    Annotation = desAttribute == null ? "" : ((DescriptionAttribute)desAttribute).Description
                };
                list.Add(resultItem);
            }
            return list;
        }
    }
}