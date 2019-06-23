using System;
using System.Web;
using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.WxEEApi
{
    public class WxEE_AuthAPI
    {
        /// <summary>
        /// 生成授权链接，获取code
        /// 如果企业需要在打开的网页里面携带用户的身份信息，第一步需要构造如下的链接来获取code参数
        /// code:通过成员授权获取到的code，最大为512字节。每次成员授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。
        /// https://work.weixin.qq.com/api/doc#90000/90135/91022
        /// </summary>
        /// <param name="corpId">企业的CorpID</param>
        /// <param name="redirect_uri">授权后重定向的回调链接地址，请使用urlencode对链接进行处理</param>
        /// <param name="response_type">返回类型，此时固定为：code</param>
        /// <param name="scope">应用授权作用域。企业自建应用固定填写：snsapi_base
        /// snsapi_base：静默授权，可获取成员的基本信息；
        /// snsapi_userinfo：静默授权，可 获取成员的敏感信息，但不包含手机、邮箱；
        /// snsapi_privateinfo：手动授权，可获取成员的敏感信息，包含手机、邮箱</param>
        /// <param name="agentid">企业应用的id。当scope是snsapi_userinfo或snsapi_privateinfo时，该参数必填 注意redirect_uri的域名必须与该应用的可信域名一致。</param>
        /// <param name="state">重定向后会带上state参数，企业可以填写a-zA-Z0-9的参数值，长度不可超过128个字节</param>
        /// <param name="#wechat_redirect">终端使用此参数判断是否需要带上身份信息</param>
        /// <returns></returns>
        public string GenerateAuthorizeLink(string corpId, string redirect_uri, WxEE_OAuthScopeType scope, int agentid, string state, string response_type = "code")
        {
            return string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&agentid={4}&state={5}#wechat_redirect", corpId, HttpUtility.UrlEncode(redirect_uri), response_type, scope.ToString(), agentid, state);
        }
    }
}