using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amw.Web.BlogApi.IServices;
using Amw.Web.BlogApi.Models.AmwDB;
using Microsoft.AspNetCore.Mvc;

namespace Amw.Web.BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IIdentityUserService _identityUserService;

        public ValuesController(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }
        // GET api/values
        [HttpGet]
        public IList<IdentityUser> Get()
        {
            return _identityUserService.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
