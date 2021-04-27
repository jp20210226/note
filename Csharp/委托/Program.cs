using System;
using Microsoft.VisualBasic.CompilerServices;

namespace 委托
{
    //所有的委托类型都派生于 System. MulticastDelegate,
    //而它又派生于 System.Delegate
    //C#会把作用于委托的+,-,+=,=操作编译成使用System.Delegate
    //的Combine和Removel两个静态方法。

    #region 声明调用
    //class Program
    //{
    //    //定义了委托类型
    //    delegate int Transformer(int t);

    //    static int Square (int x) => x * x;
    //    static void Main(string[] args)
    //    {
    //        //声明委托变量，创建委托实例完整写法 Transformer t = new Transformer(Square);
    //        Transformer t = Square;
    //        //调用委托的完整写法 t.Invoke(3);
    //        Console.WriteLine(t(3));
    //    }   
    //}
    #endregion

    #region 用委托写一个插件式的方法
    //public delegate int Transformer(int t);

    //class Util
    //{
    //    public static void Transform(int[] values, Transformer t)
    //    {
    //        for (int i = 0; i < values.Length; i++)
    //        {
    //            values[i] = t(values[i]);
    //        }
    //    }
    //}
    //class Program
    //{
    //    static int Square(int x) => x * x;
    //    static void Main()
    //    {
    //        int[] values = { 1, 2, 3 };
    //        Util.Transform(values, Square);
    //        foreach (var value in values)
    //        {
    //            Console.WriteLine(value);
    //        }
    //    }
    //}
    #endregion

    #region 委托多播

    //public delegate int Transformer(int t);

    //class Program
    //{
    //    //委托是不可变的
    //    //使用+=或-=操作符时,实际上是创建了新的委托实例,并把它赋给当前的委托变量。
    //    //如果多播委托的返回类型不是void,那么调用者从最后一个被调用的方法来接收返回值。
    //    //前面的方法仍然会被调用,但是其返回值就被弃了
    //    static int Square(int x)
    //    {
    //        var result = x * x;
    //        Console.WriteLine(result);
    //        return result;
    //    }

    //    static int Cube(int x)
    //    {
    //        var result = x * x * x;
    //        Console.WriteLine(result);
    //        return result;
    //    }

    //    static void Main()
    //    {
    //        Transformer t = null;
    //        t += Square;
    //        t += Cube;
    //        t(3);
    //        Console.WriteLine();

    //        t -= Cube;
    //        t(3);
    //    }
    //}
    #endregion

    #region 例子

    //public delegate void ProgressReporter(int percentComplete);

    //public class Util
    //{
    //    public static void HardWork(ProgressReporter p)
    //    {
    //        for (int i = 0; i < 10; i++)
    //        {
    //            p(i * 10);
    //            System.Threading.Thread.Sleep(100);
    //        }
    //    }
    //}

    //class  Program
    //{
    //    static void Main()
    //    {
    //        ProgressReporter p = WriteProgressToConsole;
    //        p += WriteProgressToFile;
    //        Util.HardWork(p);
    //    }

    //    static void WriteProgressToConsole(int percentComplete)
    //        => Console.WriteLine(percentComplete);

    //    static void WriteProgressToFile(int percentComplete)
    //        => System.IO.File.WriteAllText("Progress.txt", percentComplete.ToString());
    //}
    #endregion

    #region 实例方法目标和静态方法目标
    //当一个实例方法被赋值给委托对象的时候,这个委托对象不仅要保留
    //着对方法的引用, 还要保留着方法所属实例的引用。
    //System.Delegate的Target属性就代表着这个实例。
    //如果引用的是静态方法,那么 Target属性的值就是null。

    //public delegate void ProgressReporter(int percentComplete);
    //class X
    //{
    //    public void InstanceProgress(int percentComplete)
    //        => Console.WriteLine(percentComplete);
    //}

    //class Y
    //{
    //    public static void InstanceProgress(int percentComplete)
    //        => Console.WriteLine(percentComplete);
    //}

    //public class Program
    //{
    //    static void Main()
    //    {
    //        X x = new X();
    //        ProgressReporter p1 = x.InstanceProgress;
    //        p1(99);
    //        Console.WriteLine(p1.Target==x);//True   p.Target = 委托.X
    //        Console.WriteLine(p1.Method);//Void InstanceProgress(Int32)

    //        ProgressReporter p2 = Y.InstanceProgress; 
    //        p2(99);
    //        Console.WriteLine(p2.Target);//p.Target = null
    //        Console.WriteLine(p2.Method);//Void InstanceProgress(Int32)

    //    }
    //}

    #endregion

    #region 泛型委托

    //public delegate T Transformer<T>(T arg);

    //public class Util
    //{
    //    public static void Transform<T>(T[] values, Transformer<T> t)
    //    {
    //        for (int i = 0; i < values.Length; i++)
    //        {
    //            values[i] = t(values[i]);
    //        }
    //    }
    //}

    //class  Test
    //{
    //    static void Main()
    //    {
    //        int[] values = {1, 2, 3};
    //        //Util.Transform<int>(values, Square);
    //        //通过values推断出泛型类型为int，所以其传入方法必须也匹配泛型委托（int）
    //        Util.Transform(values, Square);
    //        foreach (var value in values)
    //        {
    //            Console.WriteLine(value+" ");
    //        }
    //    }

    //    static int Square(int x) => x * x;
    //}
    #endregion

    #region Func和Action委托
    //使用泛型委托,就可以写出这样一组委托类型,它们可调用的方法可以拥有任意的返
    //回类型和任意(合理)数量的参数
    //public class Util
    //{
    //上一个委托方法可用Func实现
    //public delegate TResult FunTest<in TX,out TResult>(TX a);

    //public static void Transform<T>(T[] values, Func<T,T> t)
    //{
    //    for (int i = 0; i < values.Length; i++)
    //    {
    //        values[i] = t(values[i]);
    //    }
    //}
    //}
    #endregion

    #region 委托可以解决的问题,接口都可以解决
    //什么情况下更适合使用委托而不是接口呢? 当下列条件之一满足时
    //接口只能定义一个方法
    //需要多播能力
    //订阅者需要多次实现接口
    #region 接口实现
    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] values = {1, 2, 3};
    //        Util.TransformAll(values,new Cuber());
    //        foreach (var value in values)
    //        {
    //            Console.WriteLine(value);
    //        }
    //    }
    //}

    //class Util
    //{
    //    public static void TransformAll(int[] values, ITransformer It) 
    //    {
    //        for (int i = 0; i < values.Length; i++)
    //        {
    //            values[i] = It.Transform(values[i]);
    //        }
    //    }
    //}

    //class Squarer : ITransformer
    //{
    //    public int Transform(int x) => x * x;

    //}

    //class Cuber : ITransformer
    //{
    //    public int Transform(int x) => x * x * x;

    //    public void ceshi()
    //    {
    //        Console.WriteLine("牛逼");
    //    }
    //}

    //interface ITransformer
    //{
    //    int Transform(int x);
    //}
    #endregion

    #region 委托实现

    //public delegate int Transformer(int x);

    //public class Program
    //{
    //    static void Main()
    //    {
    //        int[] values = {1, 2, 3};
    //        Util.Tranform(values,cuber);
    //        foreach (var value in values)
    //        {
    //            Console.WriteLine(value);
    //        }
    //    }

    //    static int cuber(int x) => x * x * x;
    //    static int Squarer(int x) => x * x;
    //}

    //class  Util
    //{
    //    public static void Tranform(int[] values,Transformer t)
    //    {
    //        for (int i = 0; i < values.Length; i++)
    //        {
    //            values[i] = t(values[i]);
    //        }
    //    }
    //}

    #endregion

    #endregion

    #region 委托的兼容性

    #region 委托类型的兼容性
    //class Program
    //{
    //    delegate void D1();
    //    delegate void D2();
    //    static void Main()
    //    {
    //        //委托类型之间互不相容，即使方法签名一样
    //        //D1 d1 = ceshi;
    //        //D2 d2 = d1;  报错
    //        //如果委托实例拥有相同的方法目标，那么委托实例就认为是相等的
    //         D1 d11 = ceshi;
    //         D1 d12 = ceshi;
    //         D1 d13;
    //         d13 = d11;
    //         Console.WriteLine(d11 == d12 &&  d12 == d13);//true
    //    }

    //    static void ceshi()
    //    {
    //        Console.WriteLine("ceshi");
    //    }
    //}
    #endregion

    #region 委托参数的兼容性
    //你调用一个方法时,你提供的参数(argument)可以比方法的参数(parameter)定义更具体,也就是说argument类型可以为parameter的子类。
    //委托可以接受比它的方法目标更具体的参数类型,这个叫contravariance 委托逆变
    //和泛型类型参数一样,委托的 variance仅支持引用转换,不支持数值转换（如int => long）,也不支持装箱操作（如int => object）
    //delegate void StringAction(string s);

    //class  Program
    //{
    //    static void Main()
    //    {
    //        StringAction sa = new StringAction(ActOnObject);
    //        sa("hello");
    //    }

    //    static void ActOnObject(object o) => Console.WriteLine(o.ToString());
    //}

    #endregion

    #region 返回类型的兼容性
    //调用方法时,你可以得到一个比请求的类型更具体的类型的返回结果
    //委托的目标方法可以返回比委托描述里更具体的类型的返回结果Covariance，协变
    //delegate object ObjectRetriever();

    //class  Program
    //{
    //    static void Main()
    //    {
    //        ObjectRetriever o = new ObjectRetriever(RetrieveString);
    //        object result = o();//委托有返回结果，结果从string =>object ,有个隐式的向上转换
    //        Console.WriteLine(result);
    //    }

    //    static string RetrieveString() => "hello";
    //}

    #endregion

    #endregion

    //泛型委托类型参数的 variance 例子看Func,Action
    //Covariance out
    //Contravariance in
}
