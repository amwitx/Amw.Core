using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Webi.Core.SDK;

namespace Webi.Wechat.Web.Core.Filters
{
    /// <summary>
    /// 全局日志过滤器
    /// </summary>
    public class WX_ExceptionFilter : IExceptionFilter, IAsyncExceptionFilter, IFilterMetadata
    {
        /// <summary>
        /// 异常
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                var ex = context.Exception;
                var result = new ServiceResult<string>
                {
                    //异常代码
                    code = GetExceptionCode(context.Exception),
                    msg = ex.Message
                };
                //TODO:保存文本日志
                context.HttpContext.Response.StatusCode = result.code;
                context.Result = new JsonResult(result);
            }
            //异常已处理了
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 异步异常
        /// </summary>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 异常代码
        /// </summary>
        private int GetExceptionCode(Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;
            if (exception is NotImplementedException)
            {
                code = StatusCodes.Status501NotImplemented;
            }
            else if (exception is TimeoutException)
            {
                code = StatusCodes.Status408RequestTimeout;
            }
            else if (exception is ArgumentException || exception is ArgumentNullException)
            {
                code = StatusCodes.Status400BadRequest;
            }
            return code;
        }
    }
}