using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WorkFlowUserExecute
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OpenId { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Status { get; set; }
    }
}
