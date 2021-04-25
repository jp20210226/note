 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程await和async
{
    class AwaitAsyncClass
    {
        //await/async是一个新语法，C#5.0以上，.net Framework 4.5以上，CLR4.0
        //是一个语法糖，不是新异步多线程的使用方法
        //语法糖：编译器提供的新功能 
        //本身不会产生新线程，依托于Task而存在，所以程序执行时有多线程
        //
        //await出现在Task前面，但是必须在方法声明中加async
        //Task.continueWith()是task任务的一个回调。
        //await就等同于将await后面的代码，包装成一个回调，并将原线程释放
        public async Task Dosomething()
        { 
             
            await Task.Run(() =>
            {
                Console.WriteLine("");
            });
        }

        public void show()
        {
            Console.WriteLine($"This Main Start{Thread.CurrentThread.ManagedThreadId}");
            this.NoReturn();
            Console.WriteLine($"This Main End{Thread.CurrentThread.ManagedThreadId}");
        }
        public void NoReturn()
        {
            Console.WriteLine($"This NoReturn Start{Thread.CurrentThread.ManagedThreadId}");
            Task.Run(() =>
            {
                Console.WriteLine($"This NoReturn Task Start{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"This NoReturn Task End{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"This NoReturn End{Thread.CurrentThread.ManagedThreadId}");
        }
        public async Task ReturnTask()
        {
            Console.WriteLine($"This ReturnTask Start{Thread.CurrentThread.ManagedThreadId}");
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This ReturnTask Task Start{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"This ReturnTask Task End{Thread.CurrentThread.ManagedThreadId}");
            });
            await task;
            Console.WriteLine($"This ReturnTask End{Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task<long> ReturnLongAwait()
        {
            long result = 0;
            Console.WriteLine($"This ReturnLongAwait Start{Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Console.WriteLine($"This ReturnLongAwait Task Start{Thread.CurrentThread.ManagedThreadId}");
                
                for (int i = 0; i < 100000000; i++)
                {
                    result += i; 
                }
                
                Console.WriteLine($"This ReturnLongAwait Task End{Thread.CurrentThread.ManagedThreadId}");
                return result;
            });
            
            Console.WriteLine($"This ReturnLongAwait End{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
    }
}
