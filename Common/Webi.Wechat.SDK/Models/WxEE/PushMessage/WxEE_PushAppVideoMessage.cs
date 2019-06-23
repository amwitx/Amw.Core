using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class WxEE_PushAppVideoMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppVideoMessage()
        {
            base.msgtype = WxEE_PushMessageType.video.ToString();
            video = new WxEE_PushAppVideoMessageItem();
        }

        public WxEE_PushAppVideoMessageItem video { get; set; }
    }

    public class WxEE_PushAppVideoMessageItem
    {
        /// <summary>
        /// 视频消息的标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 视频媒体文件id，可以调用上传临时素材接口获取
        /// 上传素材 https://work.weixin.qq.com/api/doc#90000/90135/90253
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 视频消息的描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string description { get; set; }
    }
}
