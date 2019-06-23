using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Amw.Wechat.Web.Areas.api.Controllers
{
    [Route("api/{Controller}")]
    [Authorize]
    [ApiController]
    public class mp_kf_msgController : ControllerBase
    {
        private readonly ILogger<mp_kf_msgController> _logger;

        public mp_kf_msgController(ILogger<mp_kf_msgController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(Guid.NewGuid().ToString());
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}