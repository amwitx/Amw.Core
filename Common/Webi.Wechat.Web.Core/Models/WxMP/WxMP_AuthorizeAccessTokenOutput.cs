using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_AuthorizeAccessTokenOutput
    {
        [Description("公众号访问令牌")]
        public string access_token { get; set; }
    }
}
