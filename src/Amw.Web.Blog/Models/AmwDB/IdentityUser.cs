using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amw.Web.Blog.Models.AmwDB
{
    public class IdentityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
