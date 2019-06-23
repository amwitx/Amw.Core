using Amw.Web.BlogApi.Models.AmwDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amw.Web.BlogApi.IServices
{
    public interface IIdentityUserService
    {
        IList<IdentityUser> GetUsers();

        IdentityUser GetUserById(int id);
    }
}
