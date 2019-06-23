using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatQrscene
    {
        public int SceneId { get; set; }
        public string BusinessId { get; set; }
        public int WechatId { get; set; }
        public string ModuleType { get; set; }
        public string ActionName { get; set; }
        public string Ticket { get; set; }
        public int? ExpireSeconds { get; set; }
        public string Url { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
