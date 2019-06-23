using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class WxEE_PushAppImageMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppImageMessage()
        {
            base.msgtype = WxEE_PushMessageType.image.ToString();
            image = new WxEE_PushAppImageMessageItem();
        }

        public WxEE_PushAppImageMessageItem image { get; set; }
    }

    public class WxEE_PushAppImageMessageItem
    {
        /// <summary>
        /// 图片媒体文件id，可以调用上传临时素材接口获取
        /// 上传素材 https://work.weixin.qq.com/api/doc#90000/90135/90253
        /// </summary>
        public string media_id { get; set; }
    }
}
