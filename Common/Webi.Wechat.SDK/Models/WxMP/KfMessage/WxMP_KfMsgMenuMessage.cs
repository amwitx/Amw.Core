using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 发送问答消息
    /// </summary>
    public class WxMP_KfMsgMenuMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfMsgMenuMessage()
        {
            base.msgtype = WxMP_KFMessageType.msgmenu.ToString();
            list = new WxMP_MsgMenuMessageItem();
        }

        public string head_content { get; set; }
        public WxMP_MsgMenuMessageItem list { get; set; }
        public string tail_content { get; set; }
    }

    public class WxMP_MsgMenuMessageItem
    {
        public string id { get; set; }

        /// <summary>
        /// 点击的菜单名
        /// </summary>
        public string content { get; set; }
    }
}