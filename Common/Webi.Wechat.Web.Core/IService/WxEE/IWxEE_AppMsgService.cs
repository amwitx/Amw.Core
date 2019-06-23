using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.IService.WxEE
{
    public interface IWxEE_AppMsgService
    {
        /// <summary>
        /// 发送应用文本消息
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> PushTextMessage(WxEE_AppMsgTextMsgInput input);

        /// <summary>
        /// 发送应用文本卡片消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> PushTextCardMessage(WxEE_AppMsgTextCardMsgInput input);
    }
}