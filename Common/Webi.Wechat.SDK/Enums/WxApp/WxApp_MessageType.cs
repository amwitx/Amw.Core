namespace Webi.Wechat.SDK.Enums
{
    public enum WechatApp_MsgType
    {
        /// <summary>
        /// 不需要处理的类型
        /// </summary>
        none,

        /// <summary>
        /// 事件消息
        /// </summary>
        @event,

        /// <summary>
        /// 文本消息
        /// </summary>
        text,

        /// <summary>
        /// 图片消息
        /// </summary>
        image,

        /// <summary>
        /// 客服会话
        /// </summary>
        user_enter_tempsession,

        /// <summary>
        /// 小程序卡片
        /// </summary>
        miniprogrampage
    }
}