using System;

namespace API.Wiki.Models
{
    /// <summary>
    /// 控制器注释
    /// </summary>
    public class WikiControllerAttribute : Attribute
    {
        /// <summary>
        /// 注释名称
        /// </summary>
        public string Name { get; set; }

        public WikiControllerAttribute(string name)
        {
            this.Name = name;
        }
    }
}