using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Filters
{
    /// <summary>
    /// 权限过滤器
    /// </summary>
    public class WX_ApiAuthFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                //描述器
                var descriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
                //匿名特性
                var allowAnonymous = descriptor.MethodInfo.CustomAttributes.FirstOrDefault(w => w.AttributeType == typeof(AllowAnonymousAttribute));
                if (allowAnonymous != null)
                {
                    base.OnActionExecuting(context);
                    return;
                }

                var paramsList = context.ActionArguments;
            }
            catch (Exception ex) {
                throw ex;
            }
            base.OnActionExecuting(context);
        }
    }
}
