using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amw.WebTest.Empty.Controllers
{
    [Route("v2/[controller]/[action]")]
    public class aboutController
    {
        public string me()
        {
            return "黄靖洆";
        }
        public string company()
        {
            return "no company";
        }
    }
}
