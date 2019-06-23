using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class SsoWechatConfig
    {
        public int Id { get; set; }
        public string OriginalId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string ServerUrl { get; set; }
        public string Token { get; set; }
        public string EncodingAeskey { get; set; }
        public string Domain { get; set; }
        public string AccessToken { get; set; }
        public DateTime? TokenUpdateTime { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
