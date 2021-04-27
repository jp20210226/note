using System;
using System.Threading;

namespace lambda表达式
{
    //Lambda表达式其实就是一个用来代替委托实例的未命名的方法
    //编译器会把 Lambda表达式转化为以下二者之一：
    //一个委托实例
    //一个表达式树(expression tree),类型是Expression<TDelegate>, 它表示
    //可遍历的对象模型中Lambda表达式里面的代码。它允许lambda表达式延迟到运行时再被解释。
    delegate int Transformer(int i);
    class Program
    {
        static void Main(string[] args)
        {
            Transformer sqr = x => x * x;
            Console.WriteLine(sqr(3));
        }
    }

    //Lambda表达式的形式
    //(parameters) => expression - or - statement - block
    //(参数)=>表达式或语句块
    //其中如果只有一个参数并且类型可推断的话, 那么参数的小括号可以省略

    //Lambda表达式与委托
    //每个Lambda表达式的参数对应委托的参数
    //表达式的类型对应委托的返回类型
    //x => x*x
    //delegate int Transformer(int 1);

    //Lambda表达式的代码也可以是语句块
    //x => {return x * x;}

    //Lambda表达式通常与Func和 Action委托一起使用
    class Func和Action
    {
        private Func<int, int> sqr = x => x * x;
        private  static Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
        int total=  totalLength("hello", "world");
    }

     

    class 显式指定Lambda表达式的参数类型
    {
        void Foo<T>(T x)
        {
        }

        void Bar<T>(Action<T> a)
        {
        }

        void MyMethod()
        {
            //Bar(x=>Foo(x)); //x类型在这推测不出来
            Bar<int>(x => Foo(x));
            Bar<int>(Foo);//方法组
            Bar((int x) => Foo(x));
        }
       

    }

}
