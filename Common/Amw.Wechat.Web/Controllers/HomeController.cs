using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amw.Wechat.Web.Models;
using Microsoft.Extensions.Logging;

namespace Amw.Wechat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogTrace(Guid.NewGuid().ToString());
            _logger.LogDebug(Guid.NewGuid().ToString());
            _logger.LogInformation(Guid.NewGuid().ToString());
            _logger.LogWarning(Guid.NewGuid().ToString());
            _logger.LogError(Guid.NewGuid().ToString());
            _logger.LogCritical(Guid.NewGuid().ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
