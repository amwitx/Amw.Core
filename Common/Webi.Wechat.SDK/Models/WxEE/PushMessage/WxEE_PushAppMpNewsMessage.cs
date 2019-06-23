using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 图文消息（mpnews）
    /// mpnews类型的图文消息，跟普通的图文消息一致，唯一的差异是图文内容存储在企业微信。
    /// 多次发送mpnews，会被认为是不同的图文，阅读、点赞的统计会被分开计算。
    /// </summary>
    public class WxEE_PushAppMpNewsMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppMpNewsMessage()
        {
            base.msgtype = WxEE_PushMessageType.mpnews.ToString();
            news = new WxEE_PushAppMpNewsMessageItem();
        }

        public WxEE_PushAppMpNewsMessageItem news { get; set; }
    }
    public class WxEE_PushAppMpNewsMessageItem
    {
        public WxEE_PushAppMpNewsMessageItem()
        {
            articles = new List<WxEE_PushMpNewsMessageItemArticle>();
        }
        /// <summary>
        /// 图文消息，一个图文消息支持1到8条图文
        /// </summary>
        public List<WxEE_PushMpNewsMessageItemArticle> articles { get; set; }
    }
    public class WxEE_PushMpNewsMessageItemArticle
    {
        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图文消息缩略图的media_id, 可以通过素材管理接口获得。此处thumb_media_id即上传接口返回的media_id
        /// 上传素材 https://work.weixin.qq.com/api/doc#90000/90135/90253
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 图文消息的作者，不超过64个字节
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息点击“阅读原文”之后的页面链接
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 图文消息的内容，支持html标签，不超过666 K个字节
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 图文消息的描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string digest { get; set; }
    }
}