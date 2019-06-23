using Amw.RabbitMq.Client.Components;
using Amw.RabbitMq.Client.Consumer;
using Amw.RabbitMq.Client.Model;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Amw.Test2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var conn = new RabbitMQConnectionModel("192.168.1.101", "zero", "123456");
            var queue = RabbitMQChannelFactory.CreateDefaultQueue("testq");
            //事件基本消费者
            var defaultMQ = new RabbitMQDefaultConsumer(conn, queue);


            //接收到消息事件
            defaultMQ.Consumer.Received += (sender, msg) =>
            {
                var message = Encoding.UTF8.GetString(msg.Body);
                Console.WriteLine($"收到消息：{message}_{msg.DeliveryTag}");
                defaultMQ.Channel.BasicAck(msg.DeliveryTag, false);
            };
            defaultMQ.Channel.BasicConsume(queue.QueueName, false, defaultMQ.Consumer);


            Console.WriteLine($"消费者已启动{queue.QueueName}");

            Console.ReadLine();
            defaultMQ.Dispose();
        }
    }
}