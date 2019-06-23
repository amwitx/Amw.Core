using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAppMaterial
    {
        public int Id { get; set; }
        public int WechatAppId { get; set; }
        public string Title { get; set; }
        public string MediaId { get; set; }
        public string Type { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
