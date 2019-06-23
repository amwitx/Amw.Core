using API.Wiki.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_AppMsgTextMsgInput
    {
        [WikiRequired]
        [Description("企业微信配置GUID")]
        public string guid { get; set; }

        [WikiRequired]
        [Description("消息接收者，多个接收者用‘|’分隔，最多支持1000个（域账号）")]
        public string userid { get; set; }

        [WikiRequired]
        [Description("发送的内容")]
        public string content { get; set; }
    }
}