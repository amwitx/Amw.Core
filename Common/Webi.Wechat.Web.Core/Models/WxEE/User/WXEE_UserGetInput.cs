using API.Wiki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxEE
{

    public class WXEE_UserGetInput
    {
        [WikiRequired]
        [Description("成员UserID。与Guid之间必须保证其中一个有值")]
        public string userid { get; set; }

        [WikiRequired]
        [Description("成员Guid。与UserId之间必须保证其中一个有值")]
        public string guid { get; set; }
    }
}
