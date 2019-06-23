using Amw.RabbitMq.Client.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Consumer
{
    public abstract class BaseConsumer : IDisposable
    {
        public IConnection Connection { get; set; }

        public RabbitMQChannelModel Queue { get; set; }

        public IModel Channel { get; set; }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Channel.Close();
            Connection.Close();
        }
    }
}
