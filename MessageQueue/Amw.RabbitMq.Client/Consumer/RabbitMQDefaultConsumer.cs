using Amw.RabbitMq.Client.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Consumer
{
    public class RabbitMQDefaultConsumer : BaseConsumer
    {
        public EventingBasicConsumer Consumer { get; set; }

        public RabbitMQDefaultConsumer(RabbitMQConnectionModel server, RabbitMQChannelModel queue)
        {
            //创建连接
            Connection = server.Factory.CreateConnection();
            //创建通道
            Channel = Connection.CreateModel();
            //队列配置
            Queue = queue;
            //事件基本消费者
            Consumer = new EventingBasicConsumer(Channel);
        }
    }
}
