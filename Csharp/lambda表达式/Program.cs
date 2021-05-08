using System;
using System.Threading;

namespace lambda表达式
{

    #region lambda表达式定义
    //Lambda表达式其实就是一个用来代替委托实例的未命名的方法
    //编译器会把Lambda表达式转化为以下二者之一：
    //一个委托实例
    //一个表达式树(expression tree),类型是Expression<TDelegate>, 它表示
    //可遍历的对象模型中Lambda表达式里面的代码。它允许lambda表达式延迟到运行时再被解释。
    //声明的委托
    //delegate int Transformer(int i);
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        Transformer sqr = x => x * x;
    //        Console.WriteLine(sqr(3));
    //    }

    //    static int aas(int x) => x * x; //方法简写体，不是lambda表达式
    //}
    #endregion

    #region Lambda表达式的形式\Lambda表达式与委托\Func和Action
    ////Lambda表达式的形式
    ////(parameters) => expression - or - statement - block
    ////(参数)=>表达式或语句块
    ////其中如果只有一个参数并且类型可推断的话, 那么参数的小括号可以省略

    ////Lambda表达式与委托
    ////每个Lambda表达式的参数对应委托的参数
    ////表达式的类型对应委托的返回类型
    ////x => x*x
    ////delegate int Transformer(int 1);

    ////Lambda表达式的代码也可以是语句块
    ////x => {return x * x;}

    ////Lambda表达式通常与Func和 Action委托一起使用
    //class Program
    //{
    //    private Action sqr1 = () => Console.WriteLine(1);
    //    private Func<int, int> sqr = x => x * x;
    //    private static Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
    //    int total = totalLength("hello", "world");
    //}
    #endregion

    #region 显式指定Lambda表达式的参数类型
    //class Program
    //{
    //    void Foo<T>(T x)
    //    {
    //    }
    //    void Bar<T>(Action<T> a)
    //    {
    //    }

    //    void MyMethod()
    //    {
    //        //Bar(x=>Foo(x)); //x类型在这推测不出来
    //        Bar<int>(x => Foo(x));
    //        Bar<int>(Foo);//方法组
    //        Bar((int x) => Foo(x));
    //    }
    //}
    #endregion

    #region 捕获外部变量
    //Lambda表达式可以引用本地的变量和所在方法的参数
    //被Lambda表达式引用的外部变量叫做被捕获的变量(capturedvariables)
    //捕获了外部变量的Lambda表达式叫做闭包。

    //class Program
    //{
    //    //static void Main()
    //    //{
    //    //    int factor = 2;
    //    //    Func<int, int> multiplier = n => n * factor;
    //    //    Console.WriteLine(multiplier(3));//6
    //    //}

    //    //被捕获的变量是在委托被实际调用的时候才被计算,而不是在捕获的时候
    //    static void ces1()
    //    {
    //        int factor = 2;
    //        Func<int, int> multiplier = n => n * factor;//此时只捕获不计算
    //        factor = 10;
    //        Console.WriteLine(multiplier(3));//用新赋的值进行计算30
    //    }
    //    //Lambda表达式本身也可以更新被捕获的变量
    //    static void ces2()
    //    {
    //        int seed = 0;
    //        Func<int> naturl = () => seed++;
    //        Console.WriteLine(naturl());//0
    //        Console.WriteLine(naturl());//1
    //        Console.WriteLine(seed);//2
    //    }
    //    //被捕获的变量的生命周期会被延长到和委托一样
    //    static  int  ces3()
    //    {
    //        int seed = 0;
    //        return  seed++;
    //    }

    //    static Func<int> ces4()
    //    {
    //        int seed = 0;
    //        return () => seed++;
    //    }

    //    static void Main()
    //    {
    //        Func<int> naturlces3 = ces3 ;
    //        Console.WriteLine(naturlces3());//0
    //        Console.WriteLine(naturlces3());//0

    //        //seek的生命周期和其方法内lambda表达式的一样
    //        Func<int> naturlces4 = ces4();
    //        Console.WriteLine(naturlces4());//0
    //        Console.WriteLine(naturlces4());//1
    //    }
    //}
    #endregion

    #region Lambda表达式内的本地变量
    //在 Lambda表达式内实例化的本地变量对于委托实例的每次调用来说
    //都是唯一的。
    //class  Program
    //{
    //    static Func<int> Natural()
    //    {
    //        //int seed = 0;seed放此处结果就不一样了
    //        return () =>
    //        {
    //            int seed = 0;
    //            return seed++;
    //        };
    //    }

    //    static void Main()
    //    {
    //        Func<int> natural = Natural();
    //        Console.WriteLine(natural());//0
    //        Console.WriteLine(natural());//0
    //    }

    //}


    #endregion

    #region 捕获迭代变量
    //当捕获for循环的迭代变量时,C#会把这个变量当作是在循环外部定
    //义的变量, 这就意味着每次迭代捕获的都是同一个变量
    //class  Program
    //{
    //    static void Main()
    //    { 
    //        Action[] actions = new Action[3];
    //        for (int i = 0; i < 3; i++)
    //        {
    //            actions[i] = () => Console.WriteLine(i);
    //        }

    //        foreach (var action in actions)
    //        {
    //            action();//此处调用的时候i全都等于3,输出为333
    //        }

    //        ces1();
    //    }

    //    static void ces1()
    //    {
    //        Action[] actions = new Action[3];
    //        for (int i = 0; i < 3; i++)
    //        {
    //            int temp = i;
    //            actions[i] = () => Console.WriteLine(temp);
    //        }

    //        foreach (var action in actions)
    //        {
    //            action();//012
    //        }

    //    }
    //}
    #endregion

    #region foreach
    //C#4和C#5+的区别
    //class Program
    //{
    //    static void Main()
    //    {
    //        Action[] actions = new Action[3];
    //        int i = 0;
    //        foreach (char c in "abc")
    //        {
    //            actions[i++] = () => Console.WriteLine(c);
    //        }

    //        foreach (Action a in actions)
    //        {
    //            a();//C#4.0输出ccc，C#5.0+输出abc
    //        }
    //    }
    //}
    #endregion

    #region Lambda表达式vs本地方法
    //本地方法是C#7的一个新特性。它和Lambda表达式在功能上有很多重
    //复之处, 但它有三个优点：
    //1.可以简单明了的进行递归
    //2.无需指定委托类型(那一堆代码)
    //3.性能开销略低一点
    //本地方法效率更高是因为它避免了委托的间接调用(需要CP∪周期
    //内存分配)。本地方法也可以访问所在方法的本地变量,而且无需编
    //译器把被捕获的变量hoist到隐藏的类。
    #endregion

    #region 匿名方法 vs Lambda表达式
    //匿名方法和 Lambda表达式很像, 但是缺少以下三个特性:
    //1.隐式类型参数
    //2.表达式语法(只能是语句块)
    //3.编译表达式树的能力,通过赋值给Expression<T>
    delegate int Transformer(int i);

    class Program
    {
        static void Main()
        {
            //匿名方法
            Transformer sqr = delegate (int x) { return x * x; };

            //Lambda表达式
            Transformer sqr1 = (int x) => { return x * x; };
            Transformer sqr2 = x => x * x;
            Console.WriteLine(sqr(3));
        }
        #region  匿名方法·其它
        //捕获外部变量的规则和Lambda表达式是一样的。
        //但匿名方法可以完全省略参数声明,尽管委托需要参数
        public event EventHandler Clicked = delegate { };
        //这就避免了触发事件前的null检查
        ///Notice that we omit the parameters:
        void ces1()
        {
            Clicked += delegate { Console.WriteLine("clicked"); };
        }
        #endregion


    }



    #endregion
}
