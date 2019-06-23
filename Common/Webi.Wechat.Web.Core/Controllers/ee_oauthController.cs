using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Webi.Core.SDK.BaseClass;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Enums;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;

namespace Webi.Wechat.Web.Core.Controllers
{
    public class ee_oauthController : MvcControllerBase
    {
        private readonly IWxEE_AuthorizeService _authorize;

        public ee_oauthController(IWxEE_AuthorizeService authorize)
        {
            _authorize = authorize;
        }

        /// <summary>
        /// 跳转授权
        /// https://wechat.webi.com.cn/ee_oauth/redirect?weid=2&url=https://wechat.webi.com.cn/ols/h5/wechat_coupon/sharelist.html
        /// </summary>
        public IActionResult redirect(int weid, string url)
        {
            var result = _authorize.GetAuthUrl(weid, url);
            if (result.code != StatusCodes.Status200OK)
            {
                Response.StatusCode = result.code;
                return Content(result.msg);
            }
            return Redirect(result.data);
        }

        /// <summary>
        /// 获取授权
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<IActionResult> authorize(string code = "", string state = "")
        {
            var result = await _authorize.AuthorizeUserinfo(code, state);
            if (result.code != StatusCodes.Status200OK)
            {
                Response.StatusCode = result.code;
                return Content(result.msg);
            }
            return Redirect(result.data);
        }
    }
}