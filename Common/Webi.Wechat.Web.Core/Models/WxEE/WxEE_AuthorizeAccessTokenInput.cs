using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_AuthorizeAccessTokenInput
    {
        [WikiRequired]
        [Description("企业微信应用自增ID，内部代码使用")]
        public int aid { get; set; } = 0;
        [WikiRequired]
        [Description("企业微信应用唯一ID，所有外部调用")]
        public string guid { get; set; }
    }
}
