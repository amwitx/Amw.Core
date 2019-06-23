using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Amw.WebTest.Empty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //开发异常错误页
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //异常处理
                //app.UseExceptionHandler();
            }

            //中间件
            //app.Use(RouterTest(logger));

            //welcome
            //app.UseWelcomePage(new WelcomePageOptions { Path = "/welcome" });

            //默认文件配置
            //app.UseDefaultFiles();
            //静态文件启用
            app.UseStaticFiles();
            //UseDefaultFiles + UseStaticFiles + 目录访问，全包含在内
            //app.UseFileServer();

            app.UseMvc(builder=> {
                builder.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static Func<RequestDelegate, RequestDelegate> RouterTest(ILogger<Startup> logger)
        {
            return next =>
            {
                logger.LogInformation("app.Use()......");
                return async context =>
                {
                    logger.LogInformation("---async context");
                    if (context.Request.Path.StartsWithSegments("/first"))
                    {
                        logger.LogInformation("---first!!!");
                        await context.Response.WriteAsync("first!!!");
                    }
                    else
                    {
                        logger.LogInformation("---next(context)");
                        await next(context);
                    }
                };
            };
        }
    }
}
