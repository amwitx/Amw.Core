using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class CrmConfig
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
