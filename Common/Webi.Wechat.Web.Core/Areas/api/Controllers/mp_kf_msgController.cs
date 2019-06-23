using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [WikiController("微信客服消息接口")]
    public class mp_kf_msgController : ApiControllerBase
    {
        private readonly IWxMP_KfMsgService _mp_push;

        public mp_kf_msgController(IWxMP_KfMsgService mp_push)
        {
            _mp_push = mp_push;
        }

        [WikiAction("文本消息")]
        [HttpPost]
        public async Task<ServiceResult<CommonResultStateOutput>> send_text(WxMP_KfMsgTextMsgInput input)
        {   
            //逻辑
            var result = await _mp_push.SendText(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}