using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_AppMsgTextCardMsgInput
    {
        [WikiRequired]
        [Description("企业微信配置GUID")]
        public string guid { get; set; }

        [WikiRequired]
        [Description("消息接收者，多个接收者用‘|’分隔，最多支持1000个（域账号）")]
        public string userid { get; set; }

        [WikiRequired]
        [Description("标题，不超过128个字节，超过会自动截断")]
        public string title { get; set; }
        [WikiRequired]
        [Description("描述，不超过512个字节，超过会自动截断")]
        public string description { get; set; }
        [WikiRequired]
        [Description("点击后跳转的链接")]
        public string url { get; set; }
        [WikiRequired]
        [Description("按钮文字。 默认为“详情”， 不超过4个文字，超过自动截断")]
        public string btn_text { get; set; }
    }
}
