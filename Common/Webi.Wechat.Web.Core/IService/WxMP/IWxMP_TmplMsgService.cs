using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.SDK.Models.WxMP;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.IService.WxMP
{
    public interface IWxMP_TmplMsgService
    {
        /// <summary>
        /// 发送客服文本消息
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="openid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<ServiceResult<CommonResultStateOutput>> Send(WxMP_TmplMsgInput input);
    }
}