using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WorkFlow
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int Delay { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Sort { get; set; }
    }
}
