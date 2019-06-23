using System.Collections.Generic;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class WxEE_PushAppNewsMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppNewsMessage()
        {
            base.msgtype = WxEE_PushMessageType.news.ToString();
            news = new WxEE_PushNewsMessageItem();
        }

        public WxEE_PushNewsMessageItem news { get; set; }
    }

    public class WxEE_PushNewsMessageItem
    {
        public WxEE_PushNewsMessageItem() {
            articles = new List<WxEE_PushAppNewsMessageItemArticle>();
        }
        /// <summary>
        /// 图文消息，一个图文消息支持1到8条图文
        /// </summary>
        public List<WxEE_PushAppNewsMessageItemArticle> articles { get; set; }
    }

    public class WxEE_PushAppNewsMessageItemArticle
    {
        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。
        /// </summary>
        public string picurl { get; set; }
    }
}