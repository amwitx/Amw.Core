using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WsTaskConfig
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TaskSpace { get; set; }
        public string TaskName { get; set; }
        public string Summary { get; set; }
        public int? TaskModel { get; set; }
        public int? CycleMinute { get; set; }
        public int? Record { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? LastTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
