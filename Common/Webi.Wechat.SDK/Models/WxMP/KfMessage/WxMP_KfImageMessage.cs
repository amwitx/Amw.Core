using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，图片消息
    /// </summary>
    public class WxMP_KfImageMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfImageMessage()
        {
            base.msgtype = WxMP_KFMessageType.image.ToString();
            image = new WxMP_KfImageMessageItem();
        }

        public WxMP_KfImageMessageItem image { get; set; }
    }

    public class WxMP_KfImageMessageItem
    {
        /// <summary>
        /// 发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID
        /// </summary>
        public string media_id { get; set; }
    }
}