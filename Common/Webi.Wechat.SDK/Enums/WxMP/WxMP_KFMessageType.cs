using System.ComponentModel;

namespace Webi.Wechat.SDK.Enums
{
    /// <summary>
    /// 客服消息类型
    /// </summary>
    public enum WxMP_KFMessageType
    {
        [Description("文本消息")]
        text,
        [Description("图片消息")]
        image,
        [Description("语音消息")]
        voice,
        [Description("视频消息")]
        video,
        [Description("音乐消息")]
        music,
        [Description("自定义图文（点击跳转到外链）")]
        news,
        [Description("图文消息（点击跳转到图文消息页面）")]
        mpnews,
        [Description("卡券")]
        wxcard,
        [Description("发送菜单消息")]
        msgmenu,
        [Description("发送小程序卡片（要求小程序与公众号已关联）")]
        miniprogrampage
    }
}