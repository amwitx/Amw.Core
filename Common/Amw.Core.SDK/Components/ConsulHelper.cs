using Consul;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace Amw.Core.SDK.Components
{
    public class ConsulConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public string Address { get; set; }
        public string DataCenter { get; set; }
    }

    public class ConsulHelper
    {
        internal ConsulHelper() { }

        public async Task ServiceRegisterAsync(ConsulConfig config)
        {
            using (var client = new ConsulClient(options =>
            {
                options.Address = new Uri(config.Address);
                options.Datacenter = config.DataCenter;
            }))
            {
                //注册服务到 Consul ServiceRegister是一个异步方法
                //Consult 客户端的所有方法几乎都是异步方法，但是都没按照规范加上Async 后缀
                //所以容易误导。记得调用后要 Wait()或者 await
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = config.ServiceId,//服务编号，不能重复(Guid)
                    Name = config.ServiceName,
                    Address = config.IP,//源站ip地址(内网)
                    Port = config.Port,//源站端口
                    Check = new AgentServiceCheck
                    {
                        //服务停止多久后反注册(注销)
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                        //健康检查时间间隔，或者称为心跳间隔
                        Interval = TimeSpan.FromSeconds(10),
                        //健康检查地址
                        HTTP = $"http://{config.IP}:{config.Port}/api/health",
                        Timeout = TimeSpan.FromSeconds(5)
                    }
                });
            }
        }
        /// <summary>
        /// 程序正常退出的时候从 Consul 注销服务
        /// 要通过方法参数注入 IApplicationLifetime 
        /// 程序结束的时候会调用这个方法
        /// </summary>
        /// <param name="lifetime"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task ServiceDeregisterAsync(ConsulConfig config)
        {
            using (var client = new ConsulClient(options =>
            {
                options.Address = new Uri(config.Address);
                options.Datacenter = config.DataCenter;
            }))
            {
                await client.Agent.ServiceDeregister(config.ServiceId);
            }
        }
    }
}