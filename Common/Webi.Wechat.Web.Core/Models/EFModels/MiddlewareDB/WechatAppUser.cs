using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatAppUser
    {
        public int Id { get; set; }
        public int WxAppId { get; set; }
        public string Unionid { get; set; }
        public string OpenId { get; set; }
        public string Sessionkey { get; set; }
        public string Nickname { get; set; }
        public string AvatarUrl { get; set; }
        public bool? Gender { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Language { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
