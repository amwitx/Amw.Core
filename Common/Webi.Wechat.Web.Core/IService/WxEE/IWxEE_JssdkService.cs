using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxEE;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.IService.WxEE
{
    public interface IWxEE_JssdkService
    {
        /// <summary>
        /// 获取jssdk配置
        /// </summary>
        /// <param name="mp_id"></param>
        /// <returns></returns>
        ServiceResult<WxEE_JssdkJsapiTicketOutput> GetJsapiTicket(WxEE_JssdkJsapiTicketInput input);

        /// <summary>
        /// 获取Jssdk配置
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        ServiceResult<WxEE_JssdkConfigOutput> GetConfig(WxEE_JssdkConfigInput input);
    }
}