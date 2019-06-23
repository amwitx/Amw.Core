/*/
自定义微信JSSDK类
作者：Zero 2019-1-21
*/

var WXMP_SDK = {};
//微信JSAPI列表
//分享
WXMP_SDK.JSAPIList_Share = [
    //新版分享
    "updateAppMessageShareData",//分享给朋友”及“分享到QQ
    "updateTimelineShareData",//分享到朋友圈”及“分享到QQ空间
    "onMenuShareTimeline",//分享到朋友圈(即将废弃)
    "onMenuShareAppMessage",//分享给朋友(即将废弃)
    "onMenuShareQQ",//分享到QQ(即将废弃)
    "onMenuShareWeibo",//分享到腾讯微博
    "onMenuShareQZone"//分享到QQ空间
];
WXMP_SDK.JSAPIList_Image = [
    "chooseImage",//拍照或从手机相册中选图接口
    "previewImage",//预览图片接口
    "uploadImage",//上传图片接口
    "downloadImage",//下载图片接口 
    "getLocalImgData"//获取本地图片接口 
];
WXMP_SDK.JSAPIList_Voice = [
    "startRecord",//开始录音接口
    "stopRecord",//停止录音接口
    "onVoiceRecordEnd",//监听录音自动停止接口
    "playVoice",//播放语音接口
    "pauseVoice",//暂停播放接口
    "stopVoice",//停止播放接口
    "onVoicePlayEnd",//监听语音播放完毕接口
    "uploadVoice",//上传语音接口
    "downloadVoice",//下载语音接口
    "translateVoice"//识别音频并返回识别结果接口
];
WXMP_SDK.JSAPIList_System = [
    "getNetworkType",//获取网络状态接口
    "openLocation",//使用微信内置地图查看位置接口
    "getLocation"//获取地理位置接口
];
WXMP_SDK.JSAPIList_Beacons = [
    "startSearchBeacons",//开启查找周边ibeacon设备接口
    "stopSearchBeacons",//关闭查找周边ibeacon设备接口
    "onSearchBeacons"//监听周边ibeacon设备接口
];
WXMP_SDK.JSAPIList_Menus = [
    "hideMenuItems",//批量隐藏功能按钮接口
    "showMenuItems",//批量显示功能按钮接口
    "hideAllNonBaseMenuItem",//隐藏所有非基础按钮接口
    "showAllNonBaseMenuItem",//显示所有功能按钮接口

    "hideOptionMenu",//隐藏右上角菜单接口
    "showOptionMenu"//显示右上角菜单接口
];
WXMP_SDK.JSAPIList_Base = [
    "closeWindow",//关闭当前网页窗口接口
    "scanQRCode",//调起微信扫一扫接口
    "openProductSpecificView",//跳转微信商品页接口

    "chooseCard",//拉取适用卡券列表并获取用户选择信息
    "addCard",//批量添加卡券接口
    "openCard",//查看微信卡包中的卡券接口

    "chooseWXPay"//微信支付接口
];
////////////////////////////////基础方法//////////////////////////////////////
//检测是否微信打开
WXMP_SDK.IsWeixinOpen = function () {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.match(/MicroMessenger/i) == "micromessenger") {
        return true;
    } else {
        return false;
    }
};
//通过config接口注入权限验证配置
//所有需要使用JS-SDK的页面必须先注入配置信息，否则将无法调用
//https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141115
WXMP_SDK.Config = function (debug, config, jsAPIList, readyCall, errorCall) {
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: config.app_id, // 必填，公众号的唯一标识
        timestamp: config.time_stamp, // 必填，生成签名的时间戳
        nonceStr: config.nonce_str, // 必填，生成签名的随机串
        signature: config.signature,// 必填，签名
        jsApiList: jsAPIList // 必填，需要使用的JS接口列表
    });
    wx.ready(function () {
    // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
        console.log('ready');
        if (readyCall)
            readyCall();
    });
    wx.error(function (res) {
    // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
        console.log('error:' + res.errMsg);
        if (errorCall)
            errorCall(res);
    });
};

////////////////////////////////分享接口//////////////////////////////////////
//分享到朋友圈-old
//title, link, imgUrl, success, cancel, fail, complete
WXMP_SDK.ShareTimeLineOld = function (data) {
    wx.onMenuShareTimeline({
        title: data.title,// 分享标题
        link: data.link,// 分享链接
        imgUrl: data.imgUrl,// 分享图标
        success: data.success,// 用户确认分享后执行的回调函数
        cancel: data.cancel,// 用户取消分享后执行的回调函数
        fail: data.fail,
        complete: data.complete
    });
};
//分享给朋友-old
//title, desc, link, imgUrl, success, cancel, fail, complete
WXMP_SDK.ShareAppMessageOld = function (data) {
    wx.onMenuShareAppMessage({
        title: data.title,// 分享标题
        desc: data.desc,//分享描述
        link: data.link,// 分享链接
        imgUrl: data.imgUrl,// 分享图标
        type: 'link',// 分享类型,music、video或link，不填默认为link
        dataUrl: '',// 如果type是music或video，则要提供数据链接，默认为空
        success: data.success,// 用户确认分享后执行的回调函数
        cancel: data.cancel,// 用户取消分享后执行的回调函数
        fail: data.fail,
        complete: data.complete
    });
};
//分享给朋友
WXMP_SDK.ShareAppMessage = function (data) {
    wx.updateAppMessageShareData({
        title: data.title, // 分享标题
        desc: data.desc, // 分享描述
        link: data.link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
        imgUrl: data.imgUrl, // 分享图标
        success: data.success,//接口调用成功时执行的回调函数。//调用成功时："xxx:ok" ，其中xxx为调用的接口名
        cancel: data.cancel,//用户点击取消时的回调函数，仅部分有用户取消操作的api才会用到。//用户取消时："xxx:cancel"，其中xxx为调用的接口名
        fail: data.fail,//接口调用失败时执行的回调函数。//调用失败时：其值为具体错误信息
        complete: data.complete,//接口调用完成时执行的回调函数，无论成功或失败都会执行。
        //监听Menu中的按钮点击时触发的方法，该方法仅支持Menu中的相关接口。
        //备注：不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回。
        trigger: data.trigger
    });
};
//分享到朋友圈
WXMP_SDK.ShareTimeLine = function (data) {
    wx.updateTimelineShareData({
        title: data.title, // 分享标题
        desc: data.desc, // 分享描述
        link: data.link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
        imgUrl: data.imgUrl, // 分享图标
        success: data.success,//接口调用成功时执行的回调函数。//调用成功时："xxx:ok" ，其中xxx为调用的接口名
        cancel: data.cancel,//用户点击取消时的回调函数，仅部分有用户取消操作的api才会用到。//用户取消时："xxx:cancel"，其中xxx为调用的接口名
        fail: data.fail,//接口调用失败时执行的回调函数。//调用失败时：其值为具体错误信息
        complete: data.complete,//接口调用完成时执行的回调函数，无论成功或失败都会执行。
        //监听Menu中的按钮点击时触发的方法，该方法仅支持Menu中的相关接口。
        //备注：不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回。
        trigger: data.trigger
    });
};

////////////////////////////////地理位置//////////////////////////////////////
//使用微信内置地图查看位置接口
WXMP_SDK.OpenLocation = function (latitude, longitude, name, address, scale, infoUrl) {
    wx.openLocation({
        latitude: latitude, // 纬度，浮点数，范围为90 ~ -90
        longitude: longitude, // 经度，浮点数，范围为180 ~ -180。
        name: name, // 位置名
        address: address, // 地址详情说明
        scale: scale, // 地图缩放级别,整形值,范围从1~28。默认为最大
        infoUrl: infoUrl // 在查看位置界面底部显示的超链接,可点击跳转
    });
};
//获取当前地理位置接口
WXMP_SDK.GetLocation = function (successCall, cancelCall) {
    wx.getLocation({
        type: 'wgs84', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
        success: function (res) {
            //res.latitude; // 纬度，浮点数，范围为90 ~ -90
            //res.longitude; // 经度，浮点数，范围为180 ~ -180。
            //res.speed; // 速度，以米/每秒计
            //res.accuracy; // 位置精度
            successCall(res);
        },
        cancel: function (data) {
            console.log('cancel:' + JSON.stringify(data));
            if (cancelCall)
                cancelCall();
        }
    });
};

////////////////////////////////界面操作//////////////////////////////////////
//隐藏右上角菜单
WXMP_SDK.HideOptionMenu = function () {
    wx.hideOptionMenu();
};
//显示右上角菜单
WXMP_SDK.ShowOptionMenu = function () {
    wx.showOptionMenu();
};
//关闭当前网页窗口
WXMP_SDK.CloseWindow = function () {
    wx.closeWindow();
};
//显示传播类按钮接口
WXMP_SDK.ShowTransmissionMenuItems = function () {
    var items = ["menuItem:share:appMessage", "menuItem:share:timeline", "menuItem:share:qq", "menuItem:share:weiboApp", "menuItem:favorite", "menuItem:share:facebook", "menuItem:share:QZone"];
    wx.showMenuItems({
        menuList: items // 要显示的菜单项，所有menu项见附录3
    });
};
//显示链接类按钮接口
WXMP_SDK.ShowLinkMenuItems = function () {
    var items = ["menuItem:copyUrl", "menuItem:openWithQQBrowser", "menuItem:openWithSafari"];
    wx.showMenuItems({
        menuList: items // 要显示的菜单项，所有menu项见附录3
    });
};
//隐藏所有非基础按钮
WXMP_SDK.HideAllNonBaseMenuItems = function () {
    wx.hideAllNonBaseMenuItem();
};
//显示所有功能按钮接口
WXMP_SDK.ShowAllNonBaseMenuItem = function () {
    wx.showAllNonBaseMenuItem();
};

/*
附录3-所有菜单项列表
基本类
举报: "menuItem:exposeArticle"
调整字体: "menuItem:setFont"
日间模式: "menuItem:dayMode"
夜间模式: "menuItem:nightMode"
刷新: "menuItem:refresh"
查看公众号（已添加）: "menuItem:profile"
查看公众号（未添加）: "menuItem:addContact"
传播类
发送给朋友: "menuItem:share:appMessage"
分享到朋友圈: "menuItem:share:timeline"
分享到QQ: "menuItem:share:qq"
分享到Weibo: "menuItem:share:weiboApp"
收藏: "menuItem:favorite"
分享到FB: "menuItem:share:facebook"
分享到 QQ 空间: "menuItem:share:QZone"
保护类
编辑标签: "menuItem:editTag"
删除: "menuItem:delete"
复制链接: "menuItem:copyUrl"
原网页: "menuItem:originPage"
阅读模式: "menuItem:readMode"
在QQ浏览器中打开: "menuItem:openWithQQBrowser"
在Safari中打开: "menuItem:openWithSafari"
邮件: "menuItem:share:email"
一些特殊公众号: "menuItem:share:brand"
*/