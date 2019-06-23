using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// 文本消息
    /// 其中text参数的content字段可以支持换行、以及A标签，即可打开自定义的网页（可参考以上示例代码）(注意：换行符请用转义过的\n)
    /// </summary>
    public class WxEE_PushAppTextMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppTextMessage()
        {
            base.msgtype = WxEE_PushMessageType.text.ToString();
            text = new WxEE_PushAppTextMessageItem();
        }

        public WxEE_PushAppTextMessageItem text { get; set; }
    }

    public class WxEE_PushAppTextMessageItem
    {
        /// <summary>
        /// 消息内容，最长不超过2048个字节，超过将截断
        /// </summary>
        public string content { get; set; }
    }
}
