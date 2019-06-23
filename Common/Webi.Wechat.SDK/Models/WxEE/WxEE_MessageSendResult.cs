using System;
using System.Collections.Generic;
using System.Text;

namespace Webi.Wechat.SDK.Models.WxEE
{
    /// <summary>
    /// 如果部分接收人无权限或不存在，发送仍然执行，但会返回无效的部分（即invaliduser或invalidparty或invalidtag），常见的原因是接收人不在应用的可见范围内。
    /// </summary>
    public class WxEE_MessageSendResult : WxEE_BaseResult
    {
        /// <summary>
        /// 无效的成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。
        /// </summary>
        public string invaliduser { get; set; }
        /// <summary>
        /// 无效的部门ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// </summary>
        public string invalidparty { get; set; }
        /// <summary>
        /// 无效的标签ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// </summary>
        public string invalidtag { get; set; }
     }
}
