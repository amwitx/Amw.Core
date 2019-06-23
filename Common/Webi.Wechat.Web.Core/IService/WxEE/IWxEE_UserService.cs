using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.IService.WxEE
{
    public interface IWxEE_UserService
    {
        ServiceResult<WXEE_UserGetOutput> GetUser(WXEE_UserGetInput input);
    }
}
