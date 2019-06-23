using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amw.ApiGateway.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500")))
            {
                var services = consulClient.Agent.Services().Result.Response;
                foreach (var service in services.Values)
                {
                    Console.WriteLine($"id={service.ID},name={service.Service},ip={service.Address},port={service.Port}");
                }

                var orderApi = services.Values.Where(w => w.Service.Equals("Amw.OrderApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (orderApi == null)
                {
                    Console.WriteLine("找不到服务的实例");
                    return;
                }
                var http = new HttpClient();
                http.GetStringAsync($"{orderApi.Address}:{orderApi.Port}");
            }
            Console.ReadLine();
        }
    }
}
