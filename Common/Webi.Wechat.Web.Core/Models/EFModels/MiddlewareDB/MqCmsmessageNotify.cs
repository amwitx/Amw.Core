using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class MqCmsmessageNotify
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string MessageType { get; set; }
        public string BusinessUnitName { get; set; }
        public string BusinessUnitId { get; set; }
        public string FromAppUserId { get; set; }
        public string ToModuleType { get; set; }
        public string ToAppType { get; set; }
        public string KeyId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool? IsSend { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
