using System;
using System.Collections.Generic;
using System.Text;

namespace Webi.Wechat.SDK.Models.WxEE
{
    public class WxEE_UserIdToOpenId : WxEE_BaseResult
    {
        /// <summary>
        /// 企业微信成员userid对应的openid
        /// </summary>
        public string openid { get; set; }
    }
}
