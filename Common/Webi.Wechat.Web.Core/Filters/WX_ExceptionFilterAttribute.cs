using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webi.Core.SDK;

namespace Webi.Wechat.Web.Core.Filters
{
    /// <summary>
    /// 局部日志过滤器
    /// </summary>
    public class WX_ExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            new WX_ExceptionFilter().OnException(context);
        }

        /// <summary>
        /// 异步异常
        /// </summary>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            new WX_ExceptionFilter().OnException(context);
            return Task.CompletedTask;
        }
    }
}
