using Webi.Wechat.SDK.Apis.WxEE;
using Webi.Wechat.SDK.WxEEApi;

namespace Webi.Wechat.SDK
{
    public class WxEEContext
    {
        private static WxEE_BaseAPI _BaseAPI = new WxEE_BaseAPI();

        /// <summary>
        /// 基础接口
        /// </summary>
        public static WxEE_BaseAPI BaseAPI { get { return _BaseAPI; } }

        private static WxEE_AuthAPI _AuthAPI = new WxEE_AuthAPI();

        /// <summary>
        /// 网页开发-企业微信授权
        /// </summary>
        public static WxEE_AuthAPI AuthAPI { get { return _AuthAPI; } }

        private static WxEE_UserAPI _UserApi = new WxEE_UserAPI();
        public static WxEE_UserAPI UserApi { get { return _UserApi; } }

        /// <summary>
        /// 企业微信的ticket和signature
        /// </summary>
        private static WxEE_JsAPI _JsApi = new WxEE_JsAPI();

        public static WxEE_JsAPI JsApi { get { return _JsApi; } }

        /// <summary>
        /// 发送应用消息
        /// </summary>
        private static WxEE_PushAppMessageAPI _PushAppMessageAPI = new WxEE_PushAppMessageAPI();

        public static WxEE_PushAppMessageAPI PushAppMessageAPI { get { return _PushAppMessageAPI; } }
    }
}