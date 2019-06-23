using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Wiki.Models
{
    public class WikiParameterTypeView
    {
        public WikiParameterTypeView()
        {
            Parameters = new List<WikiParameterView>();
        }
        /// <summary>
        /// 参数类型的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参数类型的类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Annotation { get; set; }

        /// <summary>
        /// 参数格式
        /// </summary>
        public WikiParameterFormat ParameterFormat { get; set; }
        /// <summary>
        /// 当前参数是不是实体类 = true
        /// </summary>
        public bool IsClass { get; set; } = true;
        /// <summary>
        /// 参数集合
        /// </summary>
        public List<WikiParameterView> Parameters { get; set; }
    }
}