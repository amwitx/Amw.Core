using System.Collections.Generic;
using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，发送图文消息（点击跳转到外链） 图文消息条数限制在1条以内，注意，如果图文数超过1，则将会返回错误码45008。
    /// 完全自定义
    /// </summary>
    public class WxMP_KfNewsMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfNewsMessage()
        {
            base.msgtype = WxMP_KFMessageType.news.ToString();
            news = new WxMP_KfNewsMessageItem();
        }

        /// <summary>
        /// 图文列表
        /// </summary>
        public WxMP_KfNewsMessageItem news { get; set; }
    }

    public class WxMP_KfNewsMessageItem
    {
        public WxMP_KfNewsMessageItem()
        {
            articles = new List<WxMP_KfNewsMessageItemArticle>();
        }

        public List<WxMP_KfNewsMessageItemArticle> articles { get; set; }
    }

    public class WxMP_KfNewsMessageItemArticle
    {
        /// <summary>
        /// 图文消息/视频消息/音乐消息的标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 图文消息/视频消息/音乐消息的描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 图文消息被点击后跳转的链接
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80
        /// </summary>
        public string picurl { get; set; }
    }
}