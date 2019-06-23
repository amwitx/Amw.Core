using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxEE;

namespace Webi.Wechat.SDK.WxEEApi
{
    public class WxEE_JsAPI
    {
        /// <summary>
        /// 获取企业的jsapi_ticket
        /// jsapi_ticket的有效期为7200秒，开发者必须在自己的服务全局缓存jsapi_ticket。
        /// https://work.weixin.qq.com/api/doc#90000/90136/90506
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public WxEE_GetJsapiTicketResult GetTicket(string access_token)
        {
            //生成URL
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", access_token);
            //请求
            return ApplicationContext.Http.GetJson<WxEE_GetJsapiTicketResult>(url);
        }

        /// <summary>
        /// 生成微信配置签名
        /// </summary>
        /// <returns></returns>
        public string GenerateSignature(string timestamp, string noncestr, string jsapi_ticket, string url)
        {
            var parameter = "jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}";
            var value = string.Format(parameter, jsapi_ticket, noncestr, timestamp, url);
            return ApplicationContext.Encrypt.SHA1(value);
        }
    }
}