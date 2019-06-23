using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WebShortUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? Hit { get; set; }
        public DateTime? ExpTime { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
