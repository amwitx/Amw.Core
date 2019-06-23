namespace Webi.Wechat.SDK.Enums
{
    public enum WxMP_ReceiveMessageType
    {
        /// <summary>
        /// 不需要处理的类型
        /// </summary>
        none,

        /// <summary>
        /// 文本消息
        /// </summary>
        text,

        /// <summary>
        /// 图片消息
        /// </summary>
        image,

        /// <summary>
        /// 语音消息
        /// 请注意，开通语音识别后，用户每次发送语音给公众号时，微信会在推送的语音消息XML数据包中，增加一个Recongnition字段
        ///  （注：由于客户端缓存，开发者开启或者关闭语音识别功能，对新关注者立刻生效，对已关注用户需要24小时生效。开发者可以重新关注此帐号进行测试）
        /// </summary>
        voice,

        /// <summary>
        /// 视频消息
        /// </summary>
        video,

        /// <summary>
        /// 小视频消息
        /// </summary>
        shortvideo,

        /// <summary>
        /// 地理位置消息
        /// </summary>
        location,

        /// <summary>
        /// 链接消息
        /// </summary>
        link,

        /// <summary>
        /// 事件消息
        /// </summary>
        @event
    }
}