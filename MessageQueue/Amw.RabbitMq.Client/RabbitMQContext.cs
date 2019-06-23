using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client
{
    public class RabbitMQContext
    {
        //private static DefultProducer _Default = new DefultProducer();
        //public static DefultProducer Default { get { return _Default; } }

        //private static TopicConsumer _Direct = new TopicConsumer();
        //public static TopicConsumer Direct { get { return _Direct; } }

        //private static FanoutProducer _Fanout = new FanoutProducer();
        //public static FanoutProducer Fanout { get { return _Fanout; } }

        //private static TopicProducer _Topic = new TopicProducer();
        //public static TopicProducer Topic { get { return _Topic; } }

        private static ExceptionHandler _Exception = new ExceptionHandler();
        public static ExceptionHandler Exception { get { return _Exception; } }
    }
}
