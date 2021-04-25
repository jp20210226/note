using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            Program a = new Program();

            a.deadlock(1);

            Console.ReadKey();
        }
        int num = 0;
        void deadlock(int index)
        {

            for (int i = 0; i < 5; i++)
            {
                this.num++;
                int k = i;

                lock (this)
                {
                    Console.WriteLine($"This is {i}  {k} Strat{index}...{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(500);
                    Console.WriteLine($"This is {i}  {k} End{index}...{Thread.CurrentThread.ManagedThreadId}");
                    if (this.num < 5)
                    {
                       
                        deadlock(index);
                    }
                    else
                    {
                        break;
                    }
                }

            }

            Console.WriteLine("over");
        }

        void forCirleMutiThreadPro()
        {
            Console.WriteLine();
            Console.WriteLine("线程启动  start {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                int k = i;
                Task.Run(() =>
                {
                    Console.WriteLine($"This is {i}  {k} Strat...{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"This is {i}  {k} End...{Thread.CurrentThread.ManagedThreadId}");
                });
            }

            Console.WriteLine("线程停止  end {0}", Thread.CurrentThread.ManagedThreadId);
        }


        //多线程安全问题:一段代码,单线程执行和多线程执行结果不一致,就表明有线程安全问题
        void ThreadSafe()
        {
            //多线程去访问同一个集合,有问题吗?一般是没问题的线程安全问题都是出在修改一个对象的 
            List<int> intList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                Task.Run(() =>//多线程之后,结果就变成小 于10000—就是有的数据丢失了
                {
                    intList.Add(i);
                });
            }
            Thread.Sleep(5000);
            Console.WriteLine(intList.Count);
        }

        //解决线程安全问题:1、加锁（就是单线程化，lock就是保证方法块内的内容任意时刻只有一个线程在执行，其他线程排队）
        void SloveThreadSafe()
        {
            //多线程去访问同一个集合,有问题吗?一般是没问题的线程安全问题都是出在修改一个对象的 
            List<int> intList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                Task.Run(() =>//多线程之后,结果就变成小于10000—就是有的数据丢失了
                {
                    //Monitor.Enter(LOCK); 
                    //intList.Add(i); 
                    //Monitor.Exit(LOCK);
                    //Lock原理： 
                    //lock是一个语法糖，编译时候编译成Monitor.Enter，Monitor.Exit的形式  
                    //Lock是锁定一个内存引用地址---所以不能是值类型lock(123)，不能为null lock(null) 
                    //private static readonly object LOCK = new object()是默认写法，作为传入值，相当于一个状态标识，标识当前有线程占用
                    //如果主方法和子方法共用一个锁，会出现相互阻塞，因此，锁不同变量才能并发 
                    //泛型类，在类型参数相同时，是同一个类，因此，泛型类的类型参数不同会导致其内部的静态变量产生一个副本，即.出的静态变量不是一个
                    lock (LOCK)
                    {
                        intList.Add(i);
                    }
                });
            }
            Thread.Sleep(5000);
            Console.WriteLine(intList.Count);
        }
        //微软默认推荐锁传入值
        private static readonly object LOCK = new object();

    }
}
