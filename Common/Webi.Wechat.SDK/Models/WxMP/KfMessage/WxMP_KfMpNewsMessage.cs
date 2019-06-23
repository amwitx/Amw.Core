using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，（点击跳转到图文消息页面） 图文消息条数限制在1条以内，注意，如果图文数超过1，则将会返回错误码45008。
    /// </summary>
    public class WxMP_KfMpNewsMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfMpNewsMessage()
        {
            base.msgtype = WxMP_KFMessageType.image.ToString();
            mpnews = new WxMP_KfMpNewsMessageItem();
        }

        public WxMP_KfMpNewsMessageItem mpnews { get; set; }
    }

    public class WxMP_KfMpNewsMessageItem
    {
        /// <summary>
        /// 发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID
        /// </summary>
        public string media_id { get; set; }
    }
}