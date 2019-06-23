using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatMaterial
    {
        public int Id { get; set; }
        public int? WechatId { get; set; }
        public string Title { get; set; }
        public string ThumbMediaId { get; set; }
        public string Author { get; set; }
        public string Digest { get; set; }
        public string ShowCoverPic { get; set; }
        public string Content { get; set; }
        public string ContentSourceUrl { get; set; }
        public string MediaId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
