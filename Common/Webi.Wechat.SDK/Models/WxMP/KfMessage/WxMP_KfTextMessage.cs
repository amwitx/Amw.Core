using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    public class WxMP_KfTextMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfTextMessage() {
            base.msgtype = WxMP_KFMessageType.text.ToString();
            text = new WxMP_KfTextMessageItem();
        }
        /// <summary>
        /// 客服文本消息
        /// </summary>
        public WxMP_KfTextMessageItem text { get; set; }
    }

    /// <summary>
    /// 客服消息-发送文本消息Item
    /// </summary>
    public class WxMP_KfTextMessageItem
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string content { get; set; }
    }
}
