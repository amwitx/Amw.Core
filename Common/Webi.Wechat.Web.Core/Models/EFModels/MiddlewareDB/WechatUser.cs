using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatUser
    {
        public int Id { get; set; }
        public int WechatId { get; set; }
        public string OpenId { get; set; }
        public string Mobile { get; set; }
        public int? Subscribe { get; set; }
        public string Nickname { get; set; }
        public int? Sex { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string HeadImgUrl { get; set; }
        public string Privilege { get; set; }
        public DateTime? SubscribeTime { get; set; }
        public string Remark { get; set; }
        public int? GroupId { get; set; }
        public string UnionId { get; set; }
        public string AppUserId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
