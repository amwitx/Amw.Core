using Amw.RabbitMq.Client.Enums;
using Amw.RabbitMq.Client.Model;
using Amw.RabbitMq.Client.Producer;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Components
{
    public class RabbitMQProducerFactory
    {
        /// <summary>
        /// 创建生产者
        /// </summary>
        /// <param name="type"></param>
        /// <param name="server"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static BaseProducer CreateProducer(ExchangeTypes type, RabbitMQConnectionModel server, RabbitMQChannelModel queue)
        {
            return new RabbitMQDefaultProducer(server, queue);

            /*var producer = new RabbitMQProducerModel();
            //创建连接
            producer.Connection = server.Factory.CreateConnection();
            //创建通道
            producer.Channel = producer.Connection.CreateModel();
            //队列配置
            producer.Queue = queue;
            switch (type)
            {
                case ExchangeTypes.topic:
                    //声明一个队列
                    producer.Channel.QueueDeclare(queue.QueueName, queue.Durable, queue.Exclusive, queue.AutoDelete);
                    break;
            }
            return producer;*/
        }
    }
}
