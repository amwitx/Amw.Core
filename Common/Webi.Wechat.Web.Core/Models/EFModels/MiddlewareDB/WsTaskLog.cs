using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WsTaskLog
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public int? TaskResult { get; set; }
        public string TaskLog { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public DateTime? TaskTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
