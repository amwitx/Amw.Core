using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WorkFlowUser
    {
        public int Id { get; set; }
        public string OpenId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
