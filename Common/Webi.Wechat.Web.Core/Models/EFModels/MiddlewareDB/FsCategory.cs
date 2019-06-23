using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class FsCategory
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
