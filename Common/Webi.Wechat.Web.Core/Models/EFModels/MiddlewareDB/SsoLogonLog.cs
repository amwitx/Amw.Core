using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class SsoLogonLog
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string OpenId { get; set; }
        public string AppUserId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
