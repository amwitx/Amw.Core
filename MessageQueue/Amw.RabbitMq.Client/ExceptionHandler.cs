using RabbitMQ.Client.Exceptions;

namespace Amw.RabbitMq.Client
{
    public class ExceptionHandler
    {
        internal ExceptionHandler()
        {
        }

        /// <summary>
        /// 显示异常
        /// </summary>
        public string Show(OperationInterruptedException ex)
        {
            switch (ex.ShutdownReason.ReplyCode)
            {
                case 404:
                    return "队列未找到，请先启动生产者";

                default:
                    return ex.ShutdownReason.ReplyText;
            }
        }
    }
}