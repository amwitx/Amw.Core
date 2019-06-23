using Amw.RabbitMq.Client.Enums;
using Amw.RabbitMq.Client.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;

namespace Amw.RabbitMq.Client.Producer
{
    public class BaseProducer : IDisposable
    {
        /// <summary>
        /// 连接设置
        /// </summary>
        private IConnection _connection { get; set; }

        /// <summary>
        /// 通道设置
        /// </summary>
        private IModel _channel { get; set; }

        /// <summary>
        /// 队列设置
        /// </summary>
        private RabbitMQChannelModel _queue { get; set; }

        public BaseProducer(ExchangeTypes type, RabbitMQConnectionModel server, RabbitMQChannelModel queue)
        {
            //1.创建连接
            _connection = server.Factory.CreateConnection();
            //2.创建通道
            _channel = _connection.CreateModel();
            //队列配置
            _queue = queue;

            switch (type)
            {
                case ExchangeTypes.direct:
                    //3.声明一个交换机
                    _channel.ExchangeDeclare(queue.ExchangeName, ExchangeType.Direct, true, false);
                    break;
                case ExchangeTypes.topic:
                    break;
            }
            if (type != ExchangeTypes.topic) {
                //4.声明一个队列
                _channel.QueueDeclare(_queue.QueueName,
                    queue.Durable, _queue.Exclusive,
                    queue.AutoDelete);
                //5.将队列绑定到交换机
                _channel.QueueBind(queue.QueueName, queue.ExchangeName, queue.ExchangeName, null);
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="payload">数据包</param>
        /// <param name="channel">通道</param>
        /// <param name="queue">队列</param>
        public void Publish(string payload)
        {
            var sendBytes = Encoding.UTF8.GetBytes(payload);
            _channel.BasicPublish(_queue.ExchangeName, _queue.QueueName, null, sendBytes);
        }
    }
}