using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatFocusReply
    {
        public int Id { get; set; }
        public int? WechatId { get; set; }
        public string Name { get; set; }
        public string EventKey { get; set; }
        public string ReplyType { get; set; }
        public string Contents { get; set; }
        public string ImageMediaId { get; set; }
        public string VoiceMediaId { get; set; }
        public string VideoMediaId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string MusicTitle { get; set; }
        public string MusicDescription { get; set; }
        public string MusicUrl { get; set; }
        public string HqmusicUrl { get; set; }
        public string ThumbMediaId { get; set; }
        public string ArticleCount { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
