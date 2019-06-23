using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_JssdkJsapiTicketInput
    {
        [WikiRequired]
        [Description("公众号唯一ID")]
        public string guid { get; set; }

        [WikiRequired]
        [Description("公众号访问令牌")]
        public string access_token { get; set; }
    }
}
