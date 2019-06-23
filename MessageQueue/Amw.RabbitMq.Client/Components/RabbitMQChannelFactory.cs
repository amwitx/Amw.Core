using Amw.RabbitMq.Client.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Components
{
    /// <summary>
    /// 默认队列模型
    /// </summary>
    public class RabbitMQChannelFactory
    {
        /// <summary>
        /// 默认模式
        /// </summary>
        public static RabbitMQChannelModel CreateDefaultQueue(string queueName, bool durable = false, bool Exclusive = false, bool autoDelete = false)
        {
            return new RabbitMQChannelModel("", queueName, durable, Exclusive, autoDelete);
        }
        /// <summary>
        /// direct模式
        /// </summary>
        public static RabbitMQChannelModel CreateDirectQueue(string exchangeName, string queueName, bool durable = false, bool Exclusive = false, bool autoDelete = false)
        {
            return new RabbitMQChannelModel(exchangeName, queueName, durable, Exclusive, autoDelete);
        }
    }
}
