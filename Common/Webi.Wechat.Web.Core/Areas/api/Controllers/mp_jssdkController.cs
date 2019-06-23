using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using Webi.Core.SDK;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [WikiController("微信JSAPI接口")]
    public class mp_jssdkController : ApiControllerBase
    {
        private readonly IWxMP_JssdkService _mp_jssdk;

        public mp_jssdkController(IWxMP_JssdkService mp_jssdk)
        {
            _mp_jssdk = mp_jssdk;
        }

        [WikiAction("获取JSSDK配置")]
        [HttpPost]
        public ServiceResult<WxMP_JssdkConfigOutput> config(WxMP_JssdkConfigInput input)
        {
            var result = _mp_jssdk.GetConfig(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}