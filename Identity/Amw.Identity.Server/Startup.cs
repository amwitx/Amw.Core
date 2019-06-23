using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Amw.Identity.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(ConfigOpenIdPassword.GetIdentityResources())
                .AddInMemoryApiResources(ConfigOpenIdPassword.GetApis())
                .AddInMemoryClients(ConfigOpenIdPassword.GetClients())
                .AddTestUsers(ConfigOpenIdPassword.GetUsers())
                .AddDeveloperSigningCredential(); 

            /*services.AddIdentityServer()
                .AddInMemoryIdentityResources(ConfigOpenId.GetIdentityResources())
                .AddInMemoryApiResources(ConfigOpenId.GetApis())
                .AddInMemoryClients(ConfigOpenId.GetClients())
                .AddDeveloperSigningCredential();

            services.AddIdentityServer()
                .AddInMemoryApiResources(ConfigPassword.GetApis())
                .AddInMemoryClients(ConfigPassword.GetClients())
                .AddTestUsers(ConfigPassword.GetUsers())
                .AddDeveloperSigningCredential();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<a href=\"/.well-known/openid-configuration\">well-known</a>");
            });
        }
    }
}
