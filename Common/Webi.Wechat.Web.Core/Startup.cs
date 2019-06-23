using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Filters;
using Webi.Wechat.Web.Core.Models.AppSettings;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;

namespace Webi.Wechat.Web.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 运行时调用此方法。使用此方法向容器中添加服务
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/zh-cn/aspnet/core/security/gdpr?view=aspnetcore-2.2
                //这个条例把cookie限制为用户隐私数据,如果要使用的话,必须征得用户同意.
                options.CheckConsentNeeded = context => false;//true表示支持
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //添加内存缓存
            services.AddMemoryCache();

            services.AddMvc(option =>
            {
                //自定义异常过滤器
                option.Filters.Add<WX_ExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //添加数据库上下文
            services.AddDbContext<OLS_MiddlewareDBContext>(options =>
            {
                //使用配置文件的sql链接字符串
                options.UseSqlServer(Configuration.GetConnectionString("MiddlewareDB"));
            });
            //依赖注入
            DependencyInjection.RegisterTypes(services);

            //配置文件-站点配置
            services.Configure<SiteConfig>(Configuration.GetSection("SiteConfig"));
            //域名配置
            services.Configure<DomainsSetting>(Configuration.GetSection("Domains"));
        }

        /// <summary>
        /// 运行时调用此方法。使用此方法配置HTTP请求管道。
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //开发环境（打印详细异常页）
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(ex => ex.Run(async context => await ErrorEvent(context)));
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}"
                );
            });
        }

        private async Task ErrorEvent(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            var result = ServiceResult<string>.Exception(error.Message);
            await context.Response.WriteAsync(ApplicationContext.Json.ObjectToJson(result));
        }
    }
}