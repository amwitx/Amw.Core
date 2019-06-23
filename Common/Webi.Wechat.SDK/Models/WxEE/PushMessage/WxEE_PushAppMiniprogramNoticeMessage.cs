using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 小程序通知消息
    /// 小程序通知消息只允许小程序应用发送，消息会通过【小程序通知】发送给用户。
    /// 小程序应用仅支持发送小程序通知消息，暂不支持文本、图片、语音、视频、图文等其他类型的消息。
    /// 不支持 @all全员发送
    /// </summary>
    public class WxEE_PushAppMiniprogramNoticeMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppMiniprogramNoticeMessage()
        {
            base.msgtype = WxEE_PushMessageType.miniprogram_notice.ToString();
            miniprogram_notice = new WxEE_PushAppMiniprogramNoticeMessageItem();
        }
        public WxEE_PushAppMiniprogramNoticeMessageItem miniprogram_notice { get; set; }
    }
    public class WxEE_PushAppMiniprogramNoticeMessageItem
    {
        /// <summary>
        /// 小程序appid，必须是与当前小程序应用关联的小程序
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 点击消息卡片后的小程序页面，仅限本小程序内的页面。该字段不填则消息点击后不跳转。
        /// </summary>
        public string page { get; set; }
        /// <summary>
        /// 消息标题，长度限制4-12个汉字
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息描述，长度限制4-12个汉字
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 是否放大第一个content_item
        /// </summary>
        public string emphasis_first_item { get; set; }
        /// <summary>
        /// 消息内容键值对，最多允许10个item
        /// </summary>
        public KeyValuePair<string, string> content_item { get; set; }
    }
}