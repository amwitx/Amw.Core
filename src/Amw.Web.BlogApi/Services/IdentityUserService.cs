using Amw.Web.BlogApi.IServices;
using Amw.Web.BlogApi.Models.AmwDB;
using System;
using System.Collections.Generic;

namespace Amw.Web.BlogApi.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        public IList<IdentityUser> GetUsers()
        {
            var list = new List<IdentityUser>();
            list.Add(new IdentityUser { Id = 1, Username = "jonny", Password = "123456", CreateTime = DateTime.Now });
            list.Add(new IdentityUser { Id = 2, Username = "jonny2", Password = "1234567", CreateTime = DateTime.Now });
            return list;
        }

        public IdentityUser GetUserById(int id)
        {
            return new IdentityUser { Id = 1, Username = "jonny", Password = "123456", CreateTime = DateTime.Now };
        }
    }
}