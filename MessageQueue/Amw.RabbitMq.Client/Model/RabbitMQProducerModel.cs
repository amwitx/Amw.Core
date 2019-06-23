using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Model
{
    public class RabbitMQProducerModel
    {
        public IConnection Connection { get; set; }

        public IModel Channel { get; set; }

        public RabbitMQChannelModel Queue { get; set; }
    }
}
