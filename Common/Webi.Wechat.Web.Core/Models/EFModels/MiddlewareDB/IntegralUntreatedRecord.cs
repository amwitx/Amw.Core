using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class IntegralUntreatedRecord
    {
        public Guid Guid { get; set; }
        public string AppUserId { get; set; }
        public string CrmcontractGuid { get; set; }
        public string CrmleadGuid { get; set; }
        public string BehaviorType { get; set; }
        public string UserType { get; set; }
        public Guid? CrmplanClassDetailGuid { get; set; }
        public string ContractActualMoney { get; set; }
        public int? ChangeAmount { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
