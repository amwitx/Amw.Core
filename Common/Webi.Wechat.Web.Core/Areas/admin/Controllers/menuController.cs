using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webi.Wechat.Web.Core.Areas.admin.Controllers
{
    public class menuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}