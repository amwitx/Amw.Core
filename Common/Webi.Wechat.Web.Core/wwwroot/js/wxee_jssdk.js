/*/
自定义企业微信JSSDK类
作者：Zero 2019-2-28
*/

var WXEE_SDK = {};
//通讯录，会话
WXEE_SDK.JSAPIList_Contact = [
    "selectEnterpriseContact",//通讯录选人接口
    "selectExternalContact",//外部联系人选人接口
    "openUserProfile",//打开个人信息页接口
    "getCurExternalContact",//获取当前外部联系人userid
    "openEnterpriseChat"//创建会话接口
];
//界面==================
//分享接口
WXEE_SDK.JSAPIList_Share = [
    //分享接口
    "onMenuShareAppMessage",//获取“转发”按钮点击状态及自定义分享内容接口
    "onMenuShareWechat",//获取“微信”按钮点击状态及自定义分享内容接口
    "onMenuShareTimeline",//获取“分享到朋友圈”按钮点击状态及自定义分享内容接口
    "shareAppMessage",//自定义转发到会话
    "shareWechatMessage"//自定义转发到微信
];
//界面操作
WXEE_SDK.JSAPIList_View = [
    "onHistoryBack",//监听页面返回事件
    "hideOptionMenu",//隐藏右上角菜单接口
    "showOptionMenu",//显示右上角菜单接口
    "closeWindow",//关闭当前网页窗口接口
    "hideMenuItems", //批量隐藏功能按钮接口
    "showMenuItems",//批量显示功能按钮接口
    "hideAllNonBaseMenuItem",//隐藏所有非基础按钮接口
    "showAllNonBaseMenuItem",//显示所有功能按钮接口
    "openDefaultBrowser",//打开系统默认浏览器
    "onUserCaptureScreen",//用户截屏事件
    "scanQRCode",//调起企业微信扫一扫接口
    "chooseInvoice"//拉起电子发票列表
];
//媒体==================
//图像接口
WXEE_SDK.JSAPIList_Image = [
    "getLocalImgData",//获取本地图片接口
    "chooseImage",//拍照或从手机相册中选图接口
    "previewImage",//预览图片接口
    "uploadImage",//上传图片接口
    "downloadImage"//下载图片接口
];
//音频接口
WXEE_SDK.JSAPIList_Voice = [
    "startRecord",//开始录音接口
    "stopRecord",//停止录音接口
    "onVoiceRecordEnd",//监听录音自动停止接口
    "playVoice",//播放语音接口
    "pauseVoice",//暂停播放接口
    "stopVoice",//停止播放接口
    "onVoicePlayEnd",//监听语音播放完毕接口
    "uploadVoice",//上传语音接口
    "downloadVoice",//下载语音接口
    //文件接口
    "previewFile"//预览文件接口
];
//设备==================
//Wi-Fi
WXEE_SDK.JSAPIList_Wi_Fi = [
    "startWifi",//初始化 Wi-Fi 模块
    "stopWifi",//关闭 Wi-Fi 模块
    "connectWifi",//连接 Wi-Fi
    "getWifiList",//请求获取 Wi-Fi 列表
    "onGetWifiList",//监听获取到 Wi-Fi 列表事件
    "onWifiConnected",//监听连接上 Wi-Fi 的事件
    "getConnectedWifi"//获取已连接中的 Wi-Fi 信息
];
//蓝牙：https://work.weixin.qq.com/api/doc#90000/90136/90500
//iBeacon：https://work.weixin.qq.com/api/doc#90000/90136/90501
WXEE_SDK.JSAPIList_Device = [
    //剪贴板
    "setClipboardData",//设置系统剪贴板的内容
    "getClipboardData",//获取系统剪贴板内容
    //网络状态
    "getNetworkType",//获取网络状态接口
    "onNetworkStatusChange"//监听网络状态变化
];
//地理位置
WXEE_SDK.JSAPIList_Location = [
    "openLocation",//使用企业微信内置地图查看位置接口
    "getLocation",//获取地理位置接口
    "startAutoLBS",//打开持续定位接口
    "stopAutoLBS",//停止持续定位接口
    "onLocationChange"//监听地理位置变化
];
////////////////////////////////基础方法//////////////////////////////////////
//检测是否微信打开
WXEE_SDK.IsWorkWeixinOpen = function () {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.match(/MicroMessenger/i) == "micromessenger") {
        return true;
    } else {
        return false;
    }
};
//判断当前客户端版本是否支持指定JS接口
WXEE_SDK.checkJsApi = function (apiName) {
    wx.checkJsApi({
        jsApiList: [apiName], // 需要检测的JS接口列表
        success: function (res) {
            // 以键值对的形式返回，可用的api值true，不可用为false
            // 如：{"checkResult":{"chooseImage":true},"errMsg":"checkJsApi:ok"}
            console.log(res);
        }
    });
};
//通过config接口注入权限验证配置
//所有需要使用JS - SDK的页面必须先注入配置信息，否则将无法调用
//配置：https://work.weixin.qq.com/api/doc#90000/90136/90514
WXEE_SDK.Config = function (debug, config, jsAPIList, readyCall, errorCall) {
    wx.config({
        beta: true,// 必须这么写，否则wx.invoke调用形式的jsapi会有问题
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: config.corpid, // 必填，企业微信的corpID
        timestamp: config.time_stamp, // 必填，生成签名的时间戳
        nonceStr: config.nonce_str, // 必填，生成签名的随机串
        signature: config.signature,// 必填，签名，见附录1
        jsApiList: jsAPIList //必填，需要使用的JS接口列表    
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
//第三方使用：https://work.weixin.qq.com/api/doc#90000/90136/90515
WXEE_SDK.AgentConfig = function (config, jsAPIList, readyCall, failCall) {
    wx.agentConfig({
        corpid: config.corpid, // 必填，企业微信的corpid，必须与当前登录的企业一致
        agentid: config.agentid, // 必填，企业微信的应用id
        timestamp: config.time_stamp, // 必填，生成签名的时间戳
        nonceStr: config.nonce_str, // 必填，生成签名的随机串
        signature: config.signature,// 必填，签名，见附录1
        jsApiList: jsAPIList, //必填，需要使用的JS接口列表
        //成功回调
        success: function (res) {
            console.log('ready');
            if (readyCall)
                readyCall(res);
        },
        //失败回调
        fail: function (res) {
            console.log('fail:' + res.errMsg);
            if (failCall)
                failCall(res);
        }
    });
};
////////////////////////////////分享接口//////////////////////////////////////
//获取“转发”按钮点击状态及自定义分享内容接口
WXEE_SDK.onMenuShareAppMessage = function (data) {
    wx.onMenuShareAppMessage({
        title: data.title,// 分享标题
        desc: data.desc,//分享描述
        link: data.link,// 分享链接
        imgUrl: data.imgUrl,// 分享图标
        success: data.success,// 用户确认分享后执行的回调函数
        cancel: data.cancel// 用户取消分享后执行的回调函数
    });
};
//获取“微信”按钮点击状态及自定义分享内容接口
//此接口在企业微信支持，微信侧不支持
WXEE_SDK.onMenuShareWechat = function (data) {
    wx.onMenuShareWechat({
        title: data.title,// 分享标题
        desc: data.desc,//分享描述
        link: data.link,// 分享链接
        imgUrl: data.imgUrl,// 分享图标
        success: data.success,// 用户确认分享后执行的回调函数
        cancel: data.cancel// 用户取消分享后执行的回调函数
    });
};
//获取“分享到朋友圈”按钮点击状态及自定义分享内容接口
WXEE_SDK.onMenuShareTimeline = function (data) {
    wx.onMenuShareTimeline({
        title: data.title, // 分享标题
        link: data.link, // 分享链接
        imgUrl: data.imgUrl, // 分享图标
        success: data.success,// 用户确认分享后执行的回调函数
        cancel: data.cancel// 用户取消分享后执行的回调函数
    });
};
//隐藏右上角菜单接口
WXEE_SDK.hideOptionMenu = function () {
    wx.hideOptionMenu();
};
//显示右上角菜单接口
WXEE_SDK.showOptionMenu = function () {
    wx.showOptionMenu();
};
//隐藏所有非基础按钮接口
WXEE_SDK.hideAllNonBaseMenuItem = function () {
    wx.hideAllNonBaseMenuItem();
};
//显示所有功能按钮接口
WXEE_SDK.showAllNonBaseMenuItem = function () {
    wx.showAllNonBaseMenuItem();
};
//批量隐藏功能按钮接口
WXEE_SDK.hideMenuItems = function (menus) {
    wx.hideMenuItems({
        menuList: menus // 要隐藏的菜单项，所有menu项见附录3
    });
};
//批量显示功能按钮接口
WXEE_SDK.showMenuItems = function (menus) {
    wx.showMenuItems({
        menuList: menus // 要显示的菜单项，所有menu项见附录3
    });
};
//关闭当前网页窗口接口
WXEE_SDK.closeWindow = function () {
    wx.closeWindow();
};