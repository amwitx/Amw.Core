using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAuthorization
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? OrderBy { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
