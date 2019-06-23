using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webi.Core.SDK.BaseClass;

namespace API.Wiki.Controllers
{
    [Area("wiki")]
    public class userController : MvcControllerBase
    {
        // GET: wiki/user
        public IActionResult login()
        {
            return Redirect("/wiki/controller/list");
        }

        [HttpPost]
        public IActionResult login(string username, string password)
        {
            return Redirect("/wiki/controller/list");
        }
    }
}