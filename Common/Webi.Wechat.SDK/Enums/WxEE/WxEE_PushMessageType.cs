using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Webi.Wechat.SDK.Enums.WxEE
{
    public enum WxEE_PushMessageType
    {
        [Description("图片消息")]
        text,
        [Description("图片消息")]
        image,
        [Description("语音消息")]
        voice,
        [Description("视频消息")]
        video,
        [Description("文件消息")]
        file,
        [Description("文本卡片消息")]
        textcard,
        [Description("图文消息（自定义）")]
        news,
        [Description("图文消息（图文内容存储在企业微信。)")]
        mpnews,
        [Description("markdown消息")]
        markdown,
        [Description("小程序通知消息")]
        miniprogram_notice
    }
}
