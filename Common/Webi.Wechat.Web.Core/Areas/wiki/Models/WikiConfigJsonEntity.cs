using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Wiki.Models
{
    public class WikiConfigJsonEntity
    {
        public WikiSettingJsonEntity settings { get; set; }
        public List<WikiJsonUserEntity> users { get; set; }
        public List<WikiJsonRoleEntity> roles { get; set; }
        public List<Dictionary<int, string>> apis { get; set; }
    }

    public class WikiSettingJsonEntity
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public List<string> @namespace { get; set; }
    }
    public class WikiJsonUserEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public string appid { get; set; }
        public string appsecret { get; set; }
        public List<string> role { get; set; }
    }
    public class WikiJsonRoleEntity
    {
        public string name { get; set; }
        public List<int> url { get; set; }
    }
}