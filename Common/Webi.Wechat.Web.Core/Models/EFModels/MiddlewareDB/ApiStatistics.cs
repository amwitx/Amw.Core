using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class ApiStatistics
    {
        public int Id { get; set; }
        public string Apiurl { get; set; }
        public string Parameter { get; set; }
        public string KeyId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
