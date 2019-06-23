using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace API.Wiki.Models
{
    public class WikiActionView
    {
        public WikiActionView()
        {
        }

        /// <summary>
        /// api 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Annotation { get; set; }

        /// <summary>
        /// 参数格式
        /// </summary>
        public WikiParameterFormat ParameterFormat { get; set; }

        public MethodInfo Method { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public List<WikiParameterTypeView> ParameterTypes
        {
            get
            {
                return GetParameterTypes(this.Method);
            }
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public List<WikiResultView> ReturnResults { get; set; }

        /// <summary>
        /// 获取方法参数类型
        /// </summary>
        /// <returns></returns>
        private List<WikiParameterTypeView> GetParameterTypes(MethodInfo action)
        {
            var list = new List<WikiParameterTypeView>();
            foreach (var parameterType in action.GetParameters())
            {
                //包含属性
                var desAttribute = parameterType.ParameterType.GetCustomAttribute(typeof(DescriptionAttribute));
                var parameterTypes = new WikiParameterTypeView
                {
                    Name = parameterType.Name,
                    Type = parameterType.ParameterType,
                    Annotation = desAttribute == null ? "" : ((DescriptionAttribute)desAttribute).Description,
                    ParameterFormat = ParameterFormat
                };

                if (new string[] { "System.String", "System.Int32" }.Contains(parameterType.ParameterType.FullName))
                {
                    parameterTypes.IsClass = false;
                }
                else
                {
                    parameterTypes.Parameters = GetParameters(parameterType.ParameterType);
                }
                list.Add(parameterTypes);
            }
            return list;
        }

        /// <summary>
        /// 获取参数集合
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        private List<WikiParameterView> GetParameters(Type parameterType)
        {
            var list = new List<WikiParameterView>();
            foreach (var parameter in parameterType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                //包含属性
                var desAttribute = parameter.GetCustomAttribute(typeof(DescriptionAttribute));
                var requiredAttribute = parameter.GetCustomAttribute(typeof(WikiRequiredAttribute));

                var itemType = parameter.PropertyType.Name;
                if (itemType == "Nullable`1")
                {
                    itemType = parameter.PropertyType.GetGenericArguments()[0].Name + "(可空)";
                }
                var parameterItem = new WikiParameterView
                {
                    Name = parameter.Name,
                    Type = itemType,
                    Required = requiredAttribute != null,// ? false : !((RequiredAttribute)requiredAttribute).AllowEmptyStrings,
                    Annotation = desAttribute == null ? "" : ((DescriptionAttribute)desAttribute).Description
                };
                list.Add(parameterItem);
            }
            return list;
        }
    }
}