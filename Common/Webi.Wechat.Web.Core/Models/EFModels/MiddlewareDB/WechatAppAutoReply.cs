using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAppAutoReply
    {
        public int Id { get; set; }
        public int WechatAppId { get; set; }
        public string Type { get; set; }
        public string Keywords { get; set; }
        public int? OrderBy { get; set; }
        public string ReplyType { get; set; }
        public string Contents { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
