using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amw.OrderApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class testController : ControllerBase
    {
        public string test() {
            return "test";
        }
    }
}