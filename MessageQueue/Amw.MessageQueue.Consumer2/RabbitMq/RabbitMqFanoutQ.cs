using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;

namespace Amw.MessageQueue.Consumer2.RabbitMq
{
    public class RabbitMqFanoutQ
    {
        public static void Execute()
        {
            var factory = new ConnectionFactory
            {
                UserName = "zero",
                Password = "123456",
                HostName = "192.168.1.101"
            };

            var queueName = "testq_fanout2";
            try
            {
                //创建连接
                using (var connection = factory.CreateConnection())
                {
                    //创建通道
                    using (var channel = connection.CreateModel())
                    {
                        //事件基本消费者
                        var consumer = new EventingBasicConsumer(channel);

                        //接收到消息事件
                        consumer.Received += (sender, e) =>
                        {
                            var message = Encoding.UTF8.GetString(e.Body);
                            Console.WriteLine($"收到消息： {message}_{e.DeliveryTag}");
                            channel.BasicAck(e.DeliveryTag, false);
                            Console.WriteLine($"已发送回执[{e.DeliveryTag}]");
                        };
                        channel.BasicConsume(queueName, false, consumer);
                        Console.WriteLine($"消费者已启动{queueName}");
                    }
                }
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