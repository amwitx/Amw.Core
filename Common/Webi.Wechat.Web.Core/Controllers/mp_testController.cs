using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.Web.Core.Models.AppSettings;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Controllers
{
    public class mp_testController : MvcControllerBase
    {
        private readonly IOptions<DomainsSetting> _settings;

        public mp_testController(IOptions<DomainsSetting> settings)
        {
            _settings = settings;
        }

        public IActionResult mp_jssdk_demo()
        {
            return View();
        }

        public async Task<IActionResult> mp_ajax_jssdk_config(int mid, string url)
        {
            var result = await ApplicationContext.Http.GetJsonAsync<ServiceResult<WxMP_JssdkConfigOutput>>($"{_settings.Value.WechatDomain}/api/mp_jsapi/config?mid={mid}&url={url}");
            if (result.code == StatusCodes.Status200OK)
            {
                return Json(result);
            }
            return Content("数据异常，请检查代码");
        }
    }
}