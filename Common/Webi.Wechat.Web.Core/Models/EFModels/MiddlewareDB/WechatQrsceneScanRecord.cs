using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatQrsceneScanRecord
    {
        public int Id { get; set; }
        public int? SceneId { get; set; }
        public int? WechatId { get; set; }
        public string ModuleType { get; set; }
        public string OpenId { get; set; }
        public string EventType { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
