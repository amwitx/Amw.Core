using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;

namespace Amw.MessageQueue.Consumer2.RabbitMq
{
    public class RabbitMqTopicQ
    {
        public static void Execute()
        {
            var factory = new ConnectionFactory
            {
                UserName = "zero",
                Password = "123456",
                HostName = "192.168.1.101"
            };

            var exchangeName = "testq_ex_topic";
            //符号“#”匹配一个或多个词，符号“*”匹配不多不少一个词
            var routeKey = "testq_ex_topic";//testq_ex_topic.*
            try
            {
                //创建连接
                using (var connection = factory.CreateConnection())
                {
                    //创建通道
                    using (var channel = connection.CreateModel())
                    {
                        //声明一个交换机
                        channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false);
                        //声明一个队列
                        var queueName = channel.QueueDeclare().QueueName;
                        //将队列绑定到交换机
                        channel.QueueBind(queueName, exchangeName, routeKey);

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