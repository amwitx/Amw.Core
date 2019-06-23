using Microsoft.Extensions.DependencyInjection;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Service.WxEE;
using Webi.Wechat.Web.Core.Service.WxMP;

namespace Webi.Wechat.Web.Core
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public class DependencyInjection
    {
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterTypes(IServiceCollection services)
        {
            //公众号
            services.AddScoped<IWxMP_AuthorizeService, WxMP_AuthorizeService>();
            services.AddScoped<IWxMP_JssdkService, WxMP_JssdkService>();
            services.AddScoped<IWxMP_QrcodeService, WxMP_QrcodeService>();
            services.AddScoped<IWxMP_KfMsgService, WxMP_KfMsgService>();
            services.AddScoped<IWxMP_TmplMsgService, WxMP_TmplMsgService>();
            //企业微信
            services.AddScoped<IWxEE_AuthorizeService, WxEE_AuthorizeService>();
            services.AddScoped<IWxEE_JssdkService, WxEE_JssdkService>();
            services.AddScoped<IWxEE_AppMsgService, WxEE_AppMsgService>();
            services.AddScoped<IWxEE_UserService, WxEE_UserService>();
        }
    }
}