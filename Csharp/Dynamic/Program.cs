using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dynamic
{
    #region 动态绑定
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        dynamic d = new Duck();
    //        //如果是用动态绑定的类继承了DynamicObject,即相当于实现了IDynamicMetaObjectProvider接口，并且实现了类似TryInvokeMember等方法，则动态调用该类的方法时候不会报错，而是执行该实现的方法
    //        d.Quack();//Quack Method was called
    //        d.Waddle();//Waddle Method was called
    //    }
    //}
    public class Duck : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            System.Console.WriteLine(binder.Name + " Method was called");
            result = null;
            return true;
        }
    }
    #endregion



    //class Program 
    //{
    //    static dynamic Mean(dynamic x, dynamic y) => (x + y) / 2;
    //    static void Main(string[] args)
    //    {
    //        int x = 3, y = 4;
    //        Console.WriteLine(Mean(x, y));
    //    }
    //}

    #region 可以把object对象转化为dynamic类型,来执行“动态”的操作
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        object o = new System.Text.StringBuilder();
    //        dynamic d = o;
    //        d.Append("hello");
    //        d.Append("wa");
    //        Console.WriteLine(o);
    //    }
    //}

    #endregion

    #region dynamic静态转换
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        dynamic x1 = 3;
    //        var y1 = x1 * 2;
    //        Console.WriteLine(y1);

    //        dynamic x2 = 3;
    //        var y2 = (int)x2;//x2被强转为静态类型int
    //        Console.WriteLine(y2);

    //        dynamic capacity = 10;
    //        var x = new System.Text.StringBuilder(capacity);//调用构造函数总会得到静态表达式，哪怕是使用了dynamic类型的参数

    //    }
    //}

    //class Program
    //{
    //    static void Foo(int x)
    //    {
    //        Console.WriteLine("1");
    //    }
    //    static void Foo(string x)
    //    {
    //        Console.WriteLine("2");
    //    }
    //    static void Main(string[] args)
    //    {
    //        dynamic x =getvalue();

    //        Foo(x);

    //    }

    //   static  dynamic getvalue()//在不知道输入类型时候，可以用Dynamic根据不同输入去找不同方法
    //   {
    //       //return 1;
    //       return "1";
    //   }
    //}


    #endregion

    #region object和dynamic
    //class Program
    //{
    //    static  void Foo(object x,object y){Console.WriteLine("oo");}
    //    static void Foo(object x, string y) { Console.WriteLine("os"); }
    //    static void Foo(string x, object y) { Console.WriteLine("so"); }
    //    static void Foo(string x, string y) { Console.WriteLine("ss"); }

    //    static void Main(string[] args)
    //    {

    //        object o = "hello";//o无法隐式转换为string类型，后两个方法过滤掉
    //        dynamic d = "goodbye";//找更具体的类型
    //        Foo(o,d);//os 动态绑定 

    //    }
    //
    #endregion

    #region 无法动态调用的函数    扩展方法
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        dynamic d = 5;
    //        //d.Hello();//报错，因为编译的时候发现没用到IntHelper这个类，导致给IntHelper编译没了，就找不到方法了
    //        IntHelper.Hello(d);//可以以静态方式进行调用

    //        int x = 5;
    //        x.Hello();//被编译成下面语句
    //        //IntHelper.Hello(d);
    //    }
    //}
    //public static class IntHelper
    //{
    //    public static void Hello(this int args)
    //    {
    //        Console.WriteLine(args);
    //    }
    //}
    #endregion

    #region  无法动态调用的函数    接口成员以及隐藏的父类成员

    interface IFoo
    {
        void Test();
    }

    class Foo:IFoo
    {
        void IFoo.Test()//显示实现的接口，需要将new Foo()这个对象，转化成IFoo f 这个对象之后，再调用
        {
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IFoo f = new Foo();
    //        f.Test();
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            IFoo f = new Foo();
            dynamic d = f;//这样会是d指向new Foo(),而不不知道还有IFoo，导致丢失IFoo接口视野，找不到方法
            d.Test();//报错
        }
    }
    #endregion

    //若在一个提供了公共 dynamic成员的类型上使用反射,就可以看到这些成员以标记的对象的形式进行的表示
    public class Test1
    {
        public dynamic Foo;
    }
    //等同于，不知道为什么不行
    public class Test
    {
        //[System.Runtime.CompilerServices.DynamicAttribute]
        public object Foo;
    }

  
    
}
