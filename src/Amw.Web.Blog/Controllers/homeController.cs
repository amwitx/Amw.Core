using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amw.Web.Blog.Models;
using Microsoft.Extensions.Logging;
using Amw.Web.Blog.IServices;

namespace Amw.Web.Blog.Controllers
{
    public class homeController : Controller
    {
        private readonly ILogger<homeController> _logger;
        private readonly IIdentityUserService _identityUserService;

        public homeController(ILogger<homeController> logger, IIdentityUserService identityUserService)
        {
            _logger = logger;
            _identityUserService = identityUserService;
        }

        public IActionResult index()
        {
            var model = _identityUserService.GetUsers();
            return View(model);
        }

        public IActionResult privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
