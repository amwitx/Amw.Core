using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webi.Core.SDK.BaseClass;

namespace Webi.Wechat.Web.Core.Controllers
{
    public class homeController : MvcControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}