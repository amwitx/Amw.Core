using API.Wiki.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_JssdkConfigOutput
    {
        [WikiRequired]
        [Description("企业微信的corpID")]
        public string corpid { get; set; }

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