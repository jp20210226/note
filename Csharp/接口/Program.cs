using System;

namespace 接口
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo a = new Foo();
            a.test();
 
            IFoo b = new Foo();//调用显示实现的接口方法,调用显示实现的接口方法,显示实现方法只能这么调用
            b.test();
            
        }
    }


    interface IFoo
    {
        void test();
    }
    class  Foo:IFoo
    {
      
        public void test()
        {
            Console.WriteLine("test");
        }

        void IFoo.test()
        {
            Console.WriteLine("IFoo.test");
        }
    }
}
