using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace task
{
    #region Task<TResult>
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //求质数
    //        Task<int> primeNumberTask = Task.Run(() => 
    //            Enumerable.Range(1, 3000000).Count(
    //                n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i=>n % i > 0)
    //        ));
    //        //primeNumberTask.Result如果没有结果，则会阻塞当前线程等待task完成并输出
    //        int count = primeNumberTask.Result;
    //        Console.WriteLine(count);
    //    }
    //}
    #endregion
    #region Task异常

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //???直接报错，没进try
    //        Task task = Task.Run(() => { throw   null;});
    //        try
    //        {
    //            task.Wait();
    //        }
    //        catch (AggregateException aex)
    //        {
    //            if (aex.InnerExceptions is NullReferenceException)
    //            {
    //                Console.WriteLine("Null");
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //    }
    //}
    #endregion
    #region continuation
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //求质数
    //        Task<int> primeNumberTask = Task.Run(() =>
    //            Enumerable.Range(1, 3000000).Count(
    //                n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
    //        ));

    //       var awater = primeNumberTask.GetAwaiter();
    //       //  var awater = primeNumberTask.ConfigureAwait(false).GetAwaiter();
    //        awater.OnCompleted(() =>
    //        {
    //            int result = awater.GetResult();
    //            Console.WriteLine(result);
    //        });
    //        //如果不用readline，主线程为前台线程，走完不会等后台线程，直接结束，就没有输出了
    //        Console.ReadLine();
    //    }
    //}
    #endregion
    #region continueWith
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //求质数
    //        Task<int> primeNumberTask = Task.Run(() =>
    //            Enumerable.Range(1, 3000000).Count(
    //                n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
    //            ));

    //        primeNumberTask.ContinueWith(task =>
    //        {
    //            int result = task.Result;
    //            Console.WriteLine(result);
    //        });

    //        Console.ReadLine();
    //    }
    //}
    #endregion
    #region TaskCompletionSource
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var tcs = new TaskCompletionSource<int>();
    //        new Thread(() =>
    //        {
    //            Thread.Sleep(5000);
    //            tcs.SetResult(42);
    //        })
    //        {
    //            IsBackground = true
    //        }.Start();
    //        Task<int> task = tcs.Task;
    //        Console.WriteLine(task.Result);

    //     //调用自己写的run
    //     Task<int> taskrun = Run(() =>
    //     {
    //         Thread.Sleep(500);
    //         return 42;
    //     });
    //    }
    //    //通过TaskCompletionSource实现Task.run
    //    //调用此方法相当于调用7ask.Factory.StartNew,
    //    //并使用TaskcreationOptions.LongRunning选项来创建非线程池的线程
    //    static  Task<TResult> Run<TResult>(Func<TResult> function)
    //    {
    //        var tcs =new TaskCompletionSource<TResult>();
    //        new  Thread(() =>
    //        {
    //            try
    //            {
    //                tcs.SetResult(function());
    //            }
    //            catch (Exception ex)
    //            {
    //                tcs.SetException(ex);
    //            }
    //        }).Start();
    //        return tcs.Task;
    //    }
    //}
    #endregion
    #region timer

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var awaiter = GetAnswerToLife().GetAwaiter();
    //        awaiter.OnCompleted(()=>
    //        {
    //            Console.WriteLine(awaiter.GetResult());
    //        });
    //    }

    //    static Task<int> GetAnswerToLife()
    //    {
    //        var tcs = new TaskCompletionSource<int>();
    //        var timer = new System.Timers.Timer(5000) {AutoReset = false};
    //        timer.Elapsed += delegate
    //        {
    //            timer.Dispose(); 
    //            tcs.SetResult(42);
    //        };
    //        timer.Start();
    //        return tcs.Task;
    //    }

    //}

    #endregion
    #region delay

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        delay(5000).GetAwaiter().OnCompleted(()=>Console.WriteLine(42));

    //        //Task.Delay相当于异步版本的 Thread.Sleep
    //        Task.Delay(5000).GetAwaiter().OnCompleted(()=>Console.WriteLine(42));
    //        Task.Delay(5000).ContinueWith(ant => Console.WriteLine(42));
    //        Console.ReadLine();
    //    }

    //    static Task  delay(int milliseconds)
    //    {
    //        //目前（20210514）没有TaskCompletionSource泛型方法
    //        var tcs = new TaskCompletionSource<object>();
    //        var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };
    //        timer.Elapsed += delegate
    //        {
    //            timer.Dispose();
    //            tcs.SetResult(null);
    //        };
    //        timer.Start();
    //        return tcs.Task;
    //    }

    //}

    #endregion
}
