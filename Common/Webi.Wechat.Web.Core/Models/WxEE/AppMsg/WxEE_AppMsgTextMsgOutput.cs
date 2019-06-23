using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WxEE_AppMsgTextMsgOutput
    {
        /// <summary>
        /// 无效的成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。
        /// </summary>
        public string invaliduser { get; set; }
    }
}
