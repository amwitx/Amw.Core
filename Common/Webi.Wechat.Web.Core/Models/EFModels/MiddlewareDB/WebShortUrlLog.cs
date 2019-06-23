using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WebShortUrlLog
    {
        public int Id { get; set; }
        public int UrlId { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
