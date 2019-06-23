using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using Webi.Core.SDK;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models.WxEE;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [WikiController("微信JSAPI接口")]
    public class ee_jssdkController : ApiControllerBase
    {
        private readonly IWxEE_JssdkService _ee_jssdk;

        public ee_jssdkController(IWxEE_JssdkService mp_jssdk)
        {
            _ee_jssdk = mp_jssdk;
        }

        [WikiAction("获取JSSDK配置")]
        [HttpPost]
        public ServiceResult<WxEE_JssdkConfigOutput> config(WxEE_JssdkConfigInput input)
        {
            var result = _ee_jssdk.GetConfig(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}