using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.IService.WxMP
{
    public interface IWxMP_JssdkService
    {
        /// <summary>
        /// 获取jssdk配置
        /// </summary>
        /// <param name="mp_id"></param>
        /// <returns></returns>
        ServiceResult<WxMP_JssdkJsapiTicketOutput> GetJsapiTicket(WxMP_JssdkJsapiTicketInput input);

        /// <summary>
        /// 获取Jssdk配置
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        ServiceResult<WxMP_JssdkConfigOutput> GetConfig(WxMP_JssdkConfigInput input);
    }
}