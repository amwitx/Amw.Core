﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_JssdkJsapiTicketOutput
    {
        [Description("微信JS接口的临时票据")]
        public string jsapi_ticket { get; set; }
    }
}
