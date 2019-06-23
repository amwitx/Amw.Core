using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [WikiController("企业微信授权")]
    [ApiController]
    public class ee_userController : ControllerBase
    {
        private readonly IWxEE_UserService _ee_user;

        public ee_userController(IWxEE_UserService ee_user)
        {
            _ee_user = ee_user;
        }

        [WikiAction("获取用户信息")]
        [HttpPost]
        public ServiceResult<WXEE_UserGetOutput> get(WXEE_UserGetInput input)
        {
            var result = _ee_user.GetUser(input);
            Response.StatusCode = result.code;
            return result;
        }
    }
}