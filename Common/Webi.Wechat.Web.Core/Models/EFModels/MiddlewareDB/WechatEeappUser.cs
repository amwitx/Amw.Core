using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatEeappUser
    {
        public Guid Guid { get; set; }
        public int WxeeId { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string Openid { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string QrCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
