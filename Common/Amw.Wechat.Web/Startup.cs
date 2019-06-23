using Amw.Core.SDK.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Amw.Wechat.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //cookie策略
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/zh-cn/aspnet/core/security/gdpr?view=aspnetcore-2.2
                //这个条例把cookie限制为用户隐私数据,如果要使用的话,必须征得用户同意.
                options.CheckConsentNeeded = context => false;//true表示支持
                //相同站点策略
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //配置验证
            services.AddAuthentication(IdentityAuthenticationTypes.Bearer.ToString())
                .AddJwtBearer(IdentityAuthenticationTypes.Bearer.ToString(), options =>
            {
                //验证服务器
                options.Authority = "http://localhost:5000/";
#if DEBUG
                //是否需要HTTPS，开发环境
                options.RequireHttpsMetadata = false;
#endif
                //支持权限
                options.Audience = "wechat";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //自动扫描 nlog.config 配置文件
            loggerFactory.AddNLog();

            //静态文件
            app.UseStaticFiles();
            //使用Cookie策略
            app.UseCookiePolicy();
            //使用验证
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}