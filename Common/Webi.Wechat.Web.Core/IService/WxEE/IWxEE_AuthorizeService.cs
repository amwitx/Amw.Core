using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.IService.WxEE
{
    public interface IWxEE_AuthorizeService
    {
        /// <summary>
        /// 获取企业微信授权URL
        /// </summary>
        /// <param name="weid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        ServiceResult<string> GetAuthUrl(int weid, string url);

        /// <summary>
        /// 授权用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> AuthorizeUserinfo(string code, string state);

        /// <summary>
        /// 获取企业微信应用AccessToken
        /// </summary>
        ServiceResult<WxEE_AuthorizeAccessTokenOutput> GetAccessToken(WxEE_AuthorizeAccessTokenInput input);
    }
}