using Webi.Wechat.SDK.Apis.WxMP;

namespace Webi.Wechat.SDK
{
    public class WxMPContext
    {
        private static Wechat_BaseAPI _BaseAPI = new Wechat_BaseAPI();

        /// <summary>
        /// 基础接口
        /// </summary>
        public static Wechat_BaseAPI BaseAPI
        {
            get { return _BaseAPI; }
        }

        private static WxMP_JsAPI _JsAPI = new WxMP_JsAPI();

        /// <summary>
        /// 网页开发-js api
        /// </summary>
        public static WxMP_JsAPI JsAPI
        {
            get { return _JsAPI; }
        }

        private static WxMP_AcountAPI _AcountAPI = new WxMP_AcountAPI();

        /// <summary>
        /// 帐号管理
        /// </summary>
        public static WxMP_AcountAPI AcountAPI
        {
            get { return _AcountAPI; }
        }

        private static WxMP_MessageAPI _MessageAPI = new WxMP_MessageAPI();

        /// <summary>
        /// 消息管理
        /// </summary>
        public static WxMP_MessageAPI MessageAPI
        {
            get { return _MessageAPI; }
        }
        private static WxMP_KfMessageAPI _KfMessageAPI = new WxMP_KfMessageAPI();

        /// <summary>
        /// 客服消息管理
        /// </summary>
        public static WxMP_KfMessageAPI KfMessageAPI
        {
            get { return _KfMessageAPI; }
        }
        
    }
}