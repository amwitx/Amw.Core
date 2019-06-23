using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 微信JS-SDK API
    /// </summary>
    public class WxMP_JsAPI
    {
        /// <summary>
        /// GET方式请求获得jsapi_ticket（有效期7200秒，开发者必须在自己的服务全局缓存jsapi_ticket）
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141115 附录
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public WxMP_JsapiTicketResult GetTicket(string access_token)
        {
            //生成URL
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}", access_token, "jsapi");
            //请求
            return ApplicationContext.Http.GetJson<WxMP_JsapiTicketResult>(url);
        }
    }
}