using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAutoReplyItems
    {
        public int Id { get; set; }
        public int? ReplyId { get; set; }
        public int? OrderBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
