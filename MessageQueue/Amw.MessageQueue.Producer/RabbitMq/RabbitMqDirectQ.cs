using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amw.MessageQueue.Producer.RabbitMq
{
    public class RabbitMqDirectQ
    {
        public static void Execute()
        {
            var factory = new ConnectionFactory
            {
                UserName = "zero",
                Password = "123456",
                HostName = "192.168.1.101",
                Port = AmqpTcpEndpoint.UseDefaultPort,
                VirtualHost = "/",
                Protocol = Protocols.DefaultProtocol,
                //启用自动恢复
                AutomaticRecoveryEnabled = true,
                TopologyRecoveryEnabled = true
            };

            var exchangeName = "testq_ex_direct";
            var queueName = "testq_direct";
            var routeKey = "testq_route_direct";
            try
            {
                //创建连接
                using (var connection = factory.CreateConnection())
                {
                    //创建通道
                    using (var channel = connection.CreateModel())
                    {
                        //声明一个交换机
                        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true, false);
                        //声明一个队列
                        channel.QueueDeclare(queueName, true, false, false);
                        //将队列绑定到交换机
                        channel.QueueBind(queueName, exchangeName, routeKey, null);

                        Console.WriteLine("RabbitMQ连接成功，请输入消息，输入exit退出！");

                        var input = string.Empty;
                        do
                        {
                            input = Console.ReadLine();
                            var sendBytes = Encoding.UTF8.GetBytes(input);
                            //消息持久化
                            var properties = channel.CreateBasicProperties();
                            properties.DeliveryMode = 2;
                            properties.Persistent = true;
                            channel.BasicPublish(exchangeName, routeKey, null, sendBytes);
                        }
                        while (input.Trim().ToLower() != "exit");
                    }
                }
            }
            catch (OperationInterruptedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
