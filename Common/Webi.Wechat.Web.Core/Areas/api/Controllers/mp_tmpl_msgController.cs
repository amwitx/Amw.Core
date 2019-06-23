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
    public class mp_tmpl_msgController : ApiControllerBase
    {
        private readonly IWxMP_TmplMsgService _mp_tmpl;

        public mp_tmpl_msgController(IWxMP_TmplMsgService mp_tmpl)
        {
            _mp_tmpl = mp_tmpl;
        }

        [WikiAction("发送", WikiParameterFormat.json, typeof(CommonResultStateOutput))]
        [HttpPost]
        public async Task<ServiceResult<CommonResultStateOutput>> send(WxMP_TmplMsgInput input)
        {
            //逻辑
            var result = await _mp_tmpl.Send(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}