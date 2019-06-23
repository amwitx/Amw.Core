using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Amw.Identity.Server.Areas.oauth.Controllers
{
    public class connectController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
    }
}