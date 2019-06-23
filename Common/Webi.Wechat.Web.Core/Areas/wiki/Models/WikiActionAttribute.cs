using System;

namespace API.Wiki.Models
{
    /// <summary>
    /// 动作注释
    /// </summary>
    public class WikiActionAttribute : Attribute
    {
        /// <summary>
        /// 注释名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参数格式
        /// </summary>
        public WikiParameterFormat ParameterFormat { get; set; }

        /// <summary>
        /// 返回类型
        /// </summary>
        public Type[] ResultTypes { get; set; }

        public WikiActionAttribute(string name, WikiParameterFormat format = WikiParameterFormat.form, params Type[] resultType)
        {
            this.Name = name;
            this.ResultTypes = resultType;
            this.ParameterFormat = format;
        }
    }
}