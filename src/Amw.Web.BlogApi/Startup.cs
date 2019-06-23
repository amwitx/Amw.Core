using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amw.Web.BlogApi.IServices;
using Amw.Web.BlogApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace Amw.Web.BlogApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IIdentityUserService, IdentityUserService>();

            //初始化Serilog
            var elasticUri = Configuration["ElasticConfiguration:Uri"];
            Log.Logger = new LoggerConfiguration()
                                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                //控制台输出Debug以上级别
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                //.WriteTo.File()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    LevelSwitch = new Serilog.Core.LoggingLevelSwitch
                    {
                        MinimumLevel = Serilog.Events.LogEventLevel.Warning
                    },

                    AutoRegisterTemplate = true,
                    TemplateName = "bloglog-template",
                    IndexFormat = "bloglog-index-{0:yyyy.MM.dd}",
                    CustomFormatter = new ElasticsearchJsonFormatter(),
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                })
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddSerilog();

            app.UseMvc();
        }

    }
}
