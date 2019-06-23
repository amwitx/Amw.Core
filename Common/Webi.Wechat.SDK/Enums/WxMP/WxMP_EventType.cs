﻿namespace Webi.Wechat.SDK.Enums
{
    /// <summary>
    /// 微信服务器在五秒内收不到响应会断掉连接，并且重新发起请求，总共重试三次。
    /// 关于重试的消息排重，推荐使用FromUserName + CreateTime 排重。
    /// 假如服务器无法保证在五秒内处理并回复，可以直接回复空串，微信服务器不会对此作任何处理，并且不会发起重试。
    /// </summary>
    public enum WxMP_EventType
    {
        /// <summary>
        /// 不需要处理的类型
        /// </summary>
        none,

        /// <summary>
        /// 关注
        /// 用户在关注与取消关注公众号时，微信会把这个事件推送到开发者填写的URL。
        /// 方便开发者给用户下发欢迎消息或者做帐号的解绑。
        /// 如果用户扫描带场景值二维码时
        /// 如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
        /// </summary>
        subscribe,

        /// <summary>
        /// 取消关注
        /// </summary>
        unsubscribe,

        /// <summary>
        /// 扫码
        /// 如果用户扫描带场景值二维码时
        /// 如果用户已经关注公众号，则微信会将带场景值扫描事件推送给开发者。
        /// </summary>
        SCAN,

        /// <summary>
        /// 上报地理位置
        /// 用户同意上报地理位置后，每次进入公众号会话时，都会在进入时上报地理位置，或在进入会话后每5秒上报一次地理位置，公众号可以在公众平台网站中修改以上设置。上报地理位置时，微信会将上报地理位置事件推送到开发者填写的URL。
        /// </summary>
        LOCATION,

        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// 用户点击自定义菜单后，微信会把点击事件推送给开发者，请注意，点击菜单弹出子菜单，不会产生上报。
        /// </summary>
        CLICK,

        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        VIEW
    }
}