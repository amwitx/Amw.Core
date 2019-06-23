using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_QrcodeStreamOutput
    {
        [Description("二维码图片流")]
        public MemoryStream stream { get; set; }
    }
}
