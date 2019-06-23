using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 微信API
    /// </summary>
    public class Wechat_BaseAPI
    {
        /// <summary>
        /// 获取微信access_token
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140183
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public WxMP_AccessTokenResult GetAccessToken(string appid, string appSecret)
        {
            //生成URL
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", "client_credential", appid, appSecret);
            //请求
            return ApplicationContext.Http.GetJson<WxMP_AccessTokenResult>(url);
        }

        /// <summary>
        /// 获取微信服务器IP地址列表（暂时没有用到）
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140187
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private async Task<WxMP_GetCallbackIpResult> GetIpList_Async(string access_token)
        {
            //生成URL
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", access_token);
            //发送请求
            return await ApplicationContext.Http.GetJsonAsync<WxMP_GetCallbackIpResult>(url);
        }
    }
}