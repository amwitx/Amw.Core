using System.Collections.Generic;

namespace Webi.Wechat.SDK.Models.WxMP
{
    public class WxMP_GetCallbackIpResult
    {
        /// <summary>
        /// json消息体
        /// </summary>
        public string json { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        public List<string> ip_list { get; set; }
    }
}