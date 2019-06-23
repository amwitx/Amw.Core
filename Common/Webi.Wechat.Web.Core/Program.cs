using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Webi.Wechat.Web.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 实现源码位置
        /// https://github.com/aspnet/AspNetCore/blob/3c09d644cccdb21801f7a79e1188a1a1212de5d9/src/DefaultBuilder/src/WebHost.cs
        /// https://github.com/aspnet/AspNetCore/tree/3c09d644cccdb21801f7a79e1188a1a1212de5d9
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}