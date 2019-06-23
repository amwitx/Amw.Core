using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，视频消息
    /// </summary>
    public class WxMP_KfVideoMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfVideoMessage()
        {
            base.msgtype = WxMP_KFMessageType.video.ToString();
            video = new WxMP_KfVideoMessageItem();
        }

        public WxMP_KfVideoMessageItem video { get; set; }
    }

    public class WxMP_KfVideoMessageItem
    {
        /// <summary>
        /// 发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID
        /// </summary>
        public string media_id { get; set; }

        /// <summary>
        /// 缩略图的媒体ID
        /// </summary>
        public string thumb_media_id { get; set; }

        /// <summary>
        /// 图文消息/视频消息/音乐消息的标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 图文消息/视频消息/音乐消息的描述
        /// </summary>
        public string description { get; set; }
    }
}