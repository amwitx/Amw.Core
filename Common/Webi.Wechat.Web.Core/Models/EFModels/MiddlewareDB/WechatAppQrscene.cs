using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAppQrscene
    {
        public int Id { get; set; }
        public int WxAppId { get; set; }
        public string Scene { get; set; }
        public string Page { get; set; }
        public int? Width { get; set; }
        public bool? AutoColor { get; set; }
        public string LineColor { get; set; }
        public string QrcodeUrl { get; set; }
        public string ModuleType { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CouponId { get; set; }
    }
}
