using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class CrmParameters
    {
        public int Id { get; set; }
        public int ApiDebugConfigId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterInfo { get; set; }
        public string ParameterType { get; set; }
        public bool? IsNecessary { get; set; }
        public bool? IsMd5 { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
