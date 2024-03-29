﻿using System.ComponentModel;

namespace Webi.Wechat.SDK.Enums
{
    /// <summary>
    /// 请注意，3到8的所有事件，仅支持微信iPhone5.4.1以上版本，和Android5.4以上版本的微信用户，旧版本微信用户点击后将没有回应，开发者也不能正常接收到事件推送。
    /// 9和10，是专门给第三方平台旗下未微信认证（具体而言，是资质认证未通过）的订阅号准备的事件类型，它们是没有事件推送的，能力相对受限，其他类型的公众号不必使用
    /// </summary>
    public enum WxMP_SelfMenuButttonType
    {
        /// <summary>
        /// 未设置
        /// </summary>
        [Description("未设置")]
        none,

        /// <summary>
        /// click：点击推事件用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互。
        /// </summary>
        [Description("点击推事件")]
        click,

        /// <summary>
        /// view：跳转URL用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
        /// </summary>
        [Description("跳转URL")]
        view,

        /// <summary>
        /// scancode_push：扫码推事件用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
        /// </summary>
        [Description("扫码推事件")]
        scancode_push,

        /// <summary>
        /// scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
        /// </summary>
        [Description("扫码推事件且弹出“消息接收中”提示框")]
        scancode_waitmsg,

        /// <summary>
        /// pic_sysphoto：弹出系统拍照发图用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
        /// </summary>
        [Description("弹出系统拍照")]
        pic_sysphoto,

        /// <summary>
        /// pic_photo_or_album：弹出拍照或者相册发图用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。
        /// 用户选择后即走其他两种流程。
        /// </summary>
        [Description("弹出拍照或者相册发图")]
        pic_photo_or_album,

        /// <summary>
        /// pic_weixin：弹出微信相册发图器用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
        /// </summary>
        [Description("弹出微信相册发图器")]
        pic_weixin,

        /// <summary>
        /// location_select：弹出地理位置选择器用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。
        /// </summary>
        [Description("弹出地理位置选择器")]
        location_select,

        /// <summary>
        /// media_id：下发消息（除文本消息）用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。
        /// 请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        [Description("下发消息（除文本消息）")]
        media_id,

        /// <summary>
        /// view_limited：跳转图文消息URL用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。
        /// 请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        [Description("跳转图文消息URL")]
        view_limited
    }
}