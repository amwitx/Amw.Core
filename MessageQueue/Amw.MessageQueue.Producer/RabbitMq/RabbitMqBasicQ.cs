using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;

namespace Amw.MessageQueue.Producer.RabbitMq
{
    public class RabbitMqBasicQ
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
            var queueName = "testq";
            try
            {
                //创建连接
                var connection = factory.CreateConnection();
                //创建通道
                var channel = connection.CreateModel();

                //声明一个队列
                channel.QueueDeclare(queueName, false, false, false);

                Console.WriteLine("RabbitMQ连接成功，请输入消息，输入exit退出！");

                var input = string.Empty;
                do
                {
                    input = Console.ReadLine();
                    var sendBytes = Encoding.UTF8.GetBytes(input);
                    channel.BasicPublish("", queueName, null, sendBytes);
                }
                while (input.Trim().ToLower() != "exit");

                channel.Dispose();
                connection.Close();
            }
            catch (OperationInterruptedException ex)
            {
                switch (ex.ShutdownReason.ReplyCode)
                {
                    case 404:
                        Console.WriteLine("队列未找到，请先启动生产者");
                        break;

                    default:
                        Console.WriteLine(ex.ShutdownReason.ReplyText);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}