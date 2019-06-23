using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，发送小程序卡片（要求小程序与公众号已关联）
    /// </summary>
    public class WxMP_KfMiniProgrampageMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfMiniProgrampageMessage()
        {
            base.msgtype = WxMP_KFMessageType.miniprogrampage.ToString();
            miniprogrampage = new WxMP_MiniProgrampageMessageItem();
        }

        public WxMP_MiniProgrampageMessageItem miniprogrampage { get; set; }
    }

    public class WxMP_MiniProgrampageMessageItem
    {
        /// <summary>
        /// 图文消息/视频消息/音乐消息/小程序卡片的标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 小程序的appid，要求小程序的appid需要与公众号有关联关系
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 小程序的页面路径，跟app.json对齐，支持参数，比如pages/index/index?foo=bar
        /// </summary>
        public string pagepath { get; set; }

        /// <summary>
        /// 缩略图/小程序卡片图片的媒体ID，小程序卡片图片建议大小为520*416
        /// </summary>
        public string thumb_media_id { get; set; }
    }
}