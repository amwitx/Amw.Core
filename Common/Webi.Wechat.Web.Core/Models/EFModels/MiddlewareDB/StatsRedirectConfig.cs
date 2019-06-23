using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class StatsRedirectConfig
    {
        public int Id { get; set; }
        public string RedirectUrl { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
