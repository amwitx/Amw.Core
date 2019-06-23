using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_AuthorizeAccessTokenOutput
    {
        [Description("企业微信访问令牌")]
        public string access_token { get; set; }

        [Description("过期时间时间戳，毫秒")]
        public long expire_stamp { get; set; }
    }
}
