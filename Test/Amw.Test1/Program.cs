using Amw.RabbitMq.Client.Components;
using Amw.RabbitMq.Client.Enums;
using Amw.RabbitMq.Client.Model;
using System;

namespace Amw.Test1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var conn = new RabbitMQConnectionModel("192.168.1.101", "zero", "123456");
            var queue = RabbitMQChannelFactory.CreateDefaultQueue("testq");
            //事件基本生产者
            var producer = RabbitMQProducerFactory.CreateProducer(
                ExchangeTypes.defult, conn, queue
            );
            Console.WriteLine("RabbitMQ连接成功，请输入消息，输入exit退出！");
            var input = string.Empty;
            do
            {
                input = Console.ReadLine();
                producer.Publish(input);
            }
            while (input.Trim().ToLower() != "exit");

            producer.Dispose();
            Console.ReadLine();
        }

        /*public string GetMessage(string queueName) {
            var message = "";
            var connection = MQHelper.CreateMQConnectionInPoolNew();

            MQHelper.ConsumeMsgSingle(connection, queueName, false, (msg) => {
                message = msg;
                return ConsumeAction.ACCEPT;
            });

            return message;
        }

        public string SendMessage(string queueName, string msg) {
            var result = "";
            var connection = MQHelper.CreateMQConnectionInPoolNew();
            result = MQHelper.SendMsg(connection, queueName, msg);
            return result;
        }*/
    }
}