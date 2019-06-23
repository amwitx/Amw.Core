using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wiki.Models;
using Microsoft.AspNetCore.Mvc;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[WikiController("企业微信授权")]
    public class ee_authController : ControllerBase
    {
        private readonly IWxEE_AuthorizeService _ee_auth;

        public ee_authController(IWxEE_AuthorizeService ee_auth)
        {
            _ee_auth = ee_auth;
        }

        /*
        [WikiAction("获取访问令牌")]
        [HttpPost]
        public ServiceResult<WxEE_AuthorizeAccessTokenOutput> access_token(WxEE_AuthorizeAccessTokenInput input)
        {
            var result = _ee_auth.GetAccessToken(input);
            Response.StatusCode = result.code;
            return result;
        }*/
    }
}