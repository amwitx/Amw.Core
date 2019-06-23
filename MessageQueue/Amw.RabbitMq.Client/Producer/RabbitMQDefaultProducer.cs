using Amw.RabbitMq.Client.Enums;
using Amw.RabbitMq.Client.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace Amw.RabbitMq.Client.Producer
{
    public class RabbitMQDefaultProducer : BaseProducer
    {
        public RabbitMQDefaultProducer(RabbitMQConnectionModel server, RabbitMQChannelModel queue) : base(ExchangeTypes.defult, server, queue)
        {
        }
    }
}