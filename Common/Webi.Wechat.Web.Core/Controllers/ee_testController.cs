using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.Web.Core.Models.AppSettings;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Controllers
{
    public class ee_testController : MvcControllerBase
    {
        private readonly IOptions<DomainsSetting> _settings;

        public ee_testController(IOptions<DomainsSetting> settings)
        {
            _settings = settings;
        }

        public IActionResult ee_jssdk_demo()
        {
            return View();
        }

        public IActionResult ee_auth(string eeid) {
            ViewBag.EEUserid = eeid;
            return View();
        }
    }
}