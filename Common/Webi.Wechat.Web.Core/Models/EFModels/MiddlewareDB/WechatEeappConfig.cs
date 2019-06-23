using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatEeappConfig
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string CorpId { get; set; }
        public int AgentId { get; set; }
        public string Secret { get; set; }
        public string AccessToken { get; set; }
        public DateTime? TokenExpireTime { get; set; }
        public string MessageDomain { get; set; }
        public string AuthDomain { get; set; }
        public string JssdkDomain { get; set; }
        public string HomePage { get; set; }
        public string JssdkTicket { get; set; }
        public DateTime? JssdkTicketExpireTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
