using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amw.MessageQueue.Producer.RabbitMq
{
    public class RabbitMqFanoutQ
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

            var exchangeName = "testq_ex_fanout";
            var queueName1 = "testq_fanout1";
            var queueName2 = "testq_fanout2";
            var routeKey = "testq_route_fanout";
            try
            {
                //创建连接
                using (var connection = factory.CreateConnection())
                {
                    //创建通道
                    using (var channel = connection.CreateModel())
                    {
                        //声明一个交换机
                        channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, false, false);
                        //声明一个队列
                        channel.QueueDeclare(queueName1, false, false, false);
                        //声明一个队列
                        channel.QueueDeclare(queueName2, false, false, false);
                        //将队列绑定到交换机
                        channel.QueueBind(queueName1, exchangeName, routeKey, null);
                        channel.QueueBind(queueName2, exchangeName, routeKey, null);

                        Console.WriteLine("RabbitMQ连接成功，请输入消息，输入exit退出！");

                        var input = string.Empty;
                        do
                        {
                            input = Console.ReadLine();
                            var sendBytes = Encoding.UTF8.GetBytes(input);
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
