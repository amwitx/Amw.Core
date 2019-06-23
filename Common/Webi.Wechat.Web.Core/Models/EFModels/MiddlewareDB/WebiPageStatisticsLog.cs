using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WebiPageStatisticsLog
    {
        public Guid Id { get; set; }
        public string RequestUrl { get; set; }
        public string Ip { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
