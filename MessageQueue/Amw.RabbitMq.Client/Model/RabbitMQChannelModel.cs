using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Model
{
    public class RabbitMQChannelModel
    {
        /// <summary>
        /// 适配器
        /// </summary>
        public string ExchangeName { get; set; }
        /// <summary>
        /// 队列
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// 持久化
        /// </summary>
        public bool Durable { get; set; } = false;
        /// <summary>
        /// 专用的，排他性
        /// </summary>
        public bool Exclusive { get; set; } = false;
        /// <summary>
        /// 自动删除
        /// </summary>
        public bool AutoDelete { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchangeName">适配器</param>
        /// <param name="queueName">队列</param>
        /// <param name="durable">持久化</param>
        /// <param name="Exclusive">专用的，排他性</param>
        /// <param name="autoDelete">自动删除</param>
        public RabbitMQChannelModel(string exchangeName, string queueName, bool durable, bool Exclusive, bool autoDelete)
        {
            ExchangeName = exchangeName;
            QueueName = queueName;
            Durable = durable;
            Exclusive = durable;
            AutoDelete = autoDelete;
        }
    }
}
