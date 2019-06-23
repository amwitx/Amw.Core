using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatPrivateTemplate
    {
        public int Id { get; set; }
        public string TemplateId { get; set; }
        public string Title { get; set; }
        public string PrimaryIndustry { get; set; }
        public string DeputyIndustry { get; set; }
        public string Content { get; set; }
        public string Example { get; set; }
        public DateTime Createtime { get; set; }
    }
}
