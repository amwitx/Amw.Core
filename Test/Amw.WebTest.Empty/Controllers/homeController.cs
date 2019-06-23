using Microsoft.AspNetCore.Mvc;

namespace Amw.WebTest.Empty.Controllers
{
    public class homeController : Controller
    {
        public homeController()
        {
        }

        public IActionResult index()
        {
            //this.ControllerContext.ActionDescriptor.ControllerName;
            //this.HttpContext.Request;
            //this.HttpContext.Response;
            //this.Ok();
            return View();
            //return Ok("hello index");
        }
    }
}