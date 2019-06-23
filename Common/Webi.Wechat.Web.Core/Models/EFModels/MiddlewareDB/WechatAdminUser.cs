using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAdminUser
    {
        public int Id { get; set; }
        public int WechatId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastLogonIp { get; set; }
        public string LastLogonTime { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
