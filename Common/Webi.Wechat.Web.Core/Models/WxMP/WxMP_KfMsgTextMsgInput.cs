using API.Wiki.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_KfMsgTextMsgInput
    {
        [WikiRequired]
        [Description("公众号配置唯一ID")]
        public string guid { get; set; }

        [WikiRequired]
        [Description("公众号用户唯一OpenId")]
        public string openid { get; set; }

        [WikiRequired]
        [Description("客服消息文本内容")]
        public string content { get; set; }
    }
}