using System;
using System.Threading;

namespace Amw.ThreadExample
{
    /// <summary>
    /// https://www.cnblogs.com/yifengjianbai/p/5468449.html
    /// </summary>
    public class SemaphoreExample
    {
        static Semaphore sema = new Semaphore(5, 5);
        const int cycleNum = 9;
        public static void Execute()
        {
            for (int i = 0; i < cycleNum; i++)
            {
                //带参线程委托
                Thread td = new Thread(new ParameterizedThreadStart(testFun));
                td.Name = string.Format("编号{0}", i.ToString());
                td.Start(td.Name);
            }
            Console.ReadLine();
        }
        public static void testFun(object obj)
        {
            sema.WaitOne();
            Console.WriteLine(obj.ToString() + "进洗手间→→→→：" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            Thread.Sleep(200);
            Console.WriteLine(obj.ToString() + "出洗手间：" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            sema.Release();
        }
    }
}
