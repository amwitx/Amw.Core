using Amw.MessageQueue.Producer.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amw.MessageQueue.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1-Defult");
            Console.WriteLine("2-Direct");
            Console.WriteLine("3-Fanout");
            Console.WriteLine("4-Topic");
            var input = Console.ReadLine();
            switch (input)
            {
                case "2":
                    RabbitMqDirectQ.Execute();
                    break;
                case "3":
                    RabbitMqFanoutQ.Execute();
                    break;
                case "4":
                    RabbitMqTopicQ.Execute();
                    break;
                case "1":
                default:
                    RabbitMqBasicQ.Execute();
                    break;
            }
        }
    }
}
