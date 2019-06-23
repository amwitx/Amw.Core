using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.IService.WxMP
{
    /// <summary>
    /// 凭据服务
    /// </summary>
    public interface IWxMP_AuthorizeService
    {
        /// <summary>
        /// 获取微信AccessToken
        /// </summary>
        ServiceResult<WxMP_AuthorizeAccessTokenOutput> GetAccessToken(WxMP_AuthorizeAccessTokenInput input);
    }
}