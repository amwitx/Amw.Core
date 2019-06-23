using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Wiki.Models
{
    public class WikiParameterView
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参数注释
        /// </summary>
        public string Annotation { get; set; }
        /// <summary>
        /// 参数类型对象
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// 是否必填项
        /// </summary>
        public bool Required { get; set; }
    }
}