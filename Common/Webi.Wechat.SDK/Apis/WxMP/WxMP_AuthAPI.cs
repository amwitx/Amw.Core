using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 网页授权
    /// </summary>
    public class Wechat_AuthAPI
    {
        /// <summary>
        /// 第二步：通过code换取网页授权access_token
        /// 首先请注意，这里通过code换取的是一个特殊的网页授权access_token,与基础支持中的access_token（该access_token用于调用其他接口）不同。公众号可通过下述接口来获取网页授权access_token。如果网页授权的作用域为snsapi_base，则本步骤中获取到网页授权access_token的同时，也获取到了openid，snsapi_base式的网页授权流程即到此为止。
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="appsecret">公众号的appsecret</param>
        /// <param name="code">填写第一步获取的code参数</param>
        /// <returns></returns>
        public async Task<WxMP_AuthAccessTokenResult> GetAuthAccessToken(string appid, string appSecret, string code)
        {
            var authUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}", appid, appSecret, code, "authorization_code");
            return await ApplicationContext.Http.GetJsonAsync<WxMP_AuthAccessTokenResult>(authUrl);
        }

        /// <summary>
        /// 第三步：刷新access_token（如果需要）//暂时不用
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="refresh_token">填写通过access_token获取到的refresh_token参数  </param>
        /// <returns></returns>
        private async Task<WxMP_AuthAccessTokenResult> GetRefreshAccessToken(string appid, string refresh_token)
        {
            //刷新access_token
            var refreshUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type={1}&refresh_token={2}", appid, "refresh_token", refresh_token);
            return await ApplicationContext.Http.GetJsonAsync<WxMP_AuthAccessTokenResult>(refreshUrl);
        }

        /// <summary>
        /// 第四步：拉取用户信息(需scope为 snsapi_userinfo)如果网页授权作用域为snsapi_userinfo，则此时开发者可以通过access_token和openid拉取用户信息了。
        /// </summary>
        /// <param name="token">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openid">用户的唯一标识</param>
        /// <returns></returns>
        public async Task<WxMP_AuthUserinfoResult> GetAuthUserinfo(string access_token, string openid)
        {
            var authUrl = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}", access_token, openid, "zh_CN");
            return await ApplicationContext.Http.GetJsonAsync<WxMP_AuthUserinfoResult>(authUrl);
        }
    }
}