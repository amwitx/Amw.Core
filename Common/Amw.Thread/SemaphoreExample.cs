using System;
using System.Threading;

namespace Amw.Thread
{
    public class SemaphoreExample
    {
        static Semaphore sema = new Semaphore(5, 5);
        const int cycleNum = 9;
        static void Main(string[] args)
        {
            for (int i = 0; i < cycleNum; i++)
            {
                Thread td = new Thread(new ParameterizedThreadStart(testFun));
                td.Name = string.Format("编号{0}", i.ToString());
                td.Start(td.Name);
            }
            Console.ReadKey();
        }
        public static void testFun(object obj)
        {
            sema.WaitOne();
            Console.WriteLine(obj.ToString() + "进洗手间：" + DateTime.Now.ToString());
            Thread.Sleep(2000);
            Console.WriteLine(obj.ToString() + "出洗手间：" + DateTime.Now.ToString());
            sema.Release();
        }
    }
}
