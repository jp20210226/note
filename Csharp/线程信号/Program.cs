using System;
using System.Threading;

namespace 线程信号
{
    class Program
    {
        static void Main(string[] args)
        {
            var signal = new ManualResetEvent(false);
            new   Thread(() =>
            {
                Console.WriteLine(("waiting for signal..."));
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal");
            }).Start();

            Thread.Sleep(3000);
            signal.Set();
        }
    }
}
