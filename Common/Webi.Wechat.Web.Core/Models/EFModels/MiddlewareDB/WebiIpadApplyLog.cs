using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WebiIpadApplyLog
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
