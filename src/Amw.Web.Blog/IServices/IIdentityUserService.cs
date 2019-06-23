using Amw.Web.Blog.Models.AmwDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amw.Web.Blog.IServices
{
    public interface IIdentityUserService
    {
        IList<IdentityUser> GetUsers();

        IdentityUser GetUserById(int id);
    }
}
