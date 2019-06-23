using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class WxEE_PushAppVoiceMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppVoiceMessage()
        {
            base.msgtype = WxEE_PushMessageType.voice.ToString();
            voice = new WxEE_PushAppVoiceMessageItem();
        }

        public WxEE_PushAppVoiceMessageItem voice { get; set; }
    }

    public class WxEE_PushAppVoiceMessageItem
    {
        /// <summary>
        /// 语音文件id，可以调用上传临时素材接口获取
        /// 上传素材 https://work.weixin.qq.com/api/doc#90000/90135/90253
        /// </summary>
        public string media_id { get; set; }
    }
}