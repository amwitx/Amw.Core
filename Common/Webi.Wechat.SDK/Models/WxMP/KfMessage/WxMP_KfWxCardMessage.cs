using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，卡券。特别注意客服消息接口投放卡券仅支持非自定义Code码和导入code模式的卡券的卡券
    /// </summary>
    public class WxMP_KfWxCardMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfWxCardMessage()
        {
            base.msgtype = WxMP_KFMessageType.wxcard.ToString();
            wxcard = new WxMP_KfWxCardMessageItem();
        }

        public WxMP_KfWxCardMessageItem wxcard { get; set; }
    }

    public class WxMP_KfWxCardMessageItem
    {
        /// <summary>
        /// 卡券ID
        /// </summary>
        public string card_id { get; set; }
    }
}