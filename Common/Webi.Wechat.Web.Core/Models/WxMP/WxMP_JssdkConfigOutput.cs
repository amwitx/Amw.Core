using API.Wiki.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_JssdkConfigOutput
    {
        [WikiRequired]
        [Description("公众号AppId")]
        public string app_id { get; set; }

        [WikiRequired]
        [Description("时间戳")]
        public string time_stamp { get; set; }

        [WikiRequired]
        [Description("随机字符串")]
        public string nonce_str { get; set; }

        [WikiRequired]
        [Description("签名")]
        public string signature { get; set; }
    }
}