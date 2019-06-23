using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class FsResources
    {
        public string ResourceId { get; set; }
        public string HashMd5 { get; set; }
        public int? Category { get; set; }
        public string ResourceType { get; set; }
        public string ModuleType { get; set; }
        public string KeyId { get; set; }
        public string FilePath { get; set; }
        public int? SmallHeight { get; set; }
        public int? SmallWidth { get; set; }
        public string SmallPath { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
