using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_QrcodeStreamInput
    {
        [WikiRequired]
        [Description("公众号自增ID")]
        public int wid { get; set; } = 0;
        [WikiRequired]
        [Description("公众号二维码业务ID")]
        public string business_id { get; set; }
        [WikiRequired]
        [Description("公众号二维码模块类型")]
        public string module_type { get; set; }
        [WikiRequired]
        [Description("是否每次都生成新的二维码")]
        public bool is_new { get; set; } = false;
    }
}
