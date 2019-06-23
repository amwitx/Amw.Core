using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [WikiController("企业微信应用消息")]
    public class ee_app_msgController : ControllerBase
    {
        private readonly IWxEE_AppMsgService _ee_push;

        public ee_app_msgController(IWxEE_AppMsgService ee_push)
        {
            _ee_push = ee_push;
        }

        [WikiAction("文本消息")]
        [HttpPost]
        public async Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> push_text(WxEE_AppMsgTextMsgInput input)
        {
            var result = await _ee_push.PushTextMessage(input);
            Response.StatusCode = result.code;
            return result;
        }

        [WikiAction("文本卡片消息")]
        [HttpPost]
        public async Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> push_text_card(WxEE_AppMsgTextCardMsgInput input)
        {
            var result = await _ee_push.PushTextCardMessage(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}