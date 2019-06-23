using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;

namespace Amw.MessageQueue.Consumer1.RabbitMq
{
    public static class RabbitMqBasicQ
    {
        public static void Execute()
        {
            var factory = new ConnectionFactory
            {
                UserName = "zero",
                Password = "123456",
                HostName = "192.168.1.101",
                //AutomaticRecoveryEnabled = true
            };

            var queueName = "testq";
            try
            {
                //创建连接
                var connection = factory.CreateConnection();
                //创建通道
                var channel = connection.CreateModel();
                //消费者同一时间没有能力处理太多的业务，导致分配过来的队列消息不能及时处理完成，这个时候，我们可以设置BasicQos属性，告诉Broker同一时间将未处理完成的消息分配其他消费者
                //告诉broker同一时间只处理一个消息
                //channel.BasicQos(0, 1, false);
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

                Console.ReadLine();
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