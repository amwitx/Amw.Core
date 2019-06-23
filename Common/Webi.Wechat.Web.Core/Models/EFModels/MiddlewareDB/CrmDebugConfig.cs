using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class CrmDebugConfig
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ApiUrl { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
