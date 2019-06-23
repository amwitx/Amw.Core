using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class StatsRedirectLog
    {
        public int Id { get; set; }
        public int? RedirectId { get; set; }
        public string OpenId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
