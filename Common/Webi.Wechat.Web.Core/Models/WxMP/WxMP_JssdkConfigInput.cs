using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_JssdkConfigInput
    {
        [WikiRequired]
        [Description("公众号唯一ID")]
        public string guid { get; set; }
        [WikiRequired]
        [Description("需要调用JSSDK的当前网页的URL")]
        public string url { get; set; }
    }
}
