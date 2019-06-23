using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class MqAppPushNotify1
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string MessageType { get; set; }
        public string AppUserId { get; set; }
        public string DeviceToken { get; set; }
        public string Ostype { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime? PlanTime { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? SendTime { get; set; }
        public string SendResult { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
