using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，语音消息
    /// </summary>
    public class WxMP_KfVoiceMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfVoiceMessage()
        {
            base.msgtype = WxMP_KFMessageType.voice.ToString();
            voice = new WxMP_KfVoiceMessageItem();
        }

        public WxMP_KfVoiceMessageItem voice { get; set; }
    }

    public class WxMP_KfVoiceMessageItem
    {
        /// <summary>
        /// 发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID
        /// </summary>
        public string media_id { get; set; }
    }
}