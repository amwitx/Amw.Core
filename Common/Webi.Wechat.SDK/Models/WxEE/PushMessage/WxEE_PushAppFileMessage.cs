using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 文件消息
    /// </summary>
    public class WxEE_PushAppFileMessage:WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppFileMessage() {
            base.msgtype = WxEE_PushMessageType.file.ToString();
            file = new WxEE_PushAppFileMessageItem();
        }
        public WxEE_PushAppFileMessageItem file { get; set; }
    }

    public class WxEE_PushAppFileMessageItem
    {
        /// <summary>
        /// 文件id，可以调用上传临时素材接口获取
        /// 上传素材 https://work.weixin.qq.com/api/doc#90000/90135/90253
        /// </summary>
        public string media_id { get; set; }
    }
}
