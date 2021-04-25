using System;
using System.Threading;
namespace 线程加锁
{
    class Program
    {
        public void PrintEven()
        {   //所住当前线程直到该线程执行完，防止数据出错
            lock (this)
            {
                for (int i = 0; i <= 10; i = i + 2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
                }
            }
        }
        public void PrintOdd()
        {
            lock (this)
            {
                for (int i = 1; i <= 10; i = i + 2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ThreadStart ts1 = new ThreadStart(program.PrintOdd);
            Thread t1 = new Thread(ts1);
            t1.Name = "打印奇数的线程";
            t1.Start();
            ThreadStart ts2 = new ThreadStart(program.PrintEven);
            Thread t2 = new Thread(ts2);
            t2.Name = "打印偶数的线程";
            t2.Start();
        }
    }
}
