using System;
using System.Numerics;

namespace 事件
{
    #region 事件构成
    ////广播和订阅
    ////使用委托的时候, 通常会出现两个角色, 一个广播者, 一个订阅者
    ////广播者这个/*类型*/包含一个/*委托字段*/,广播者通过调用委托来决定什么时候进行广播。
    ////订阅者是方法目标的接收者,订阅者可以决定何时开始或结束监听方式是通过在委托上调用+=和-=。
    ////一个订阅者不知道和不干扰其它的订阅者。

    ////事件就是将上述模式正式化的一个语言特性。
    ////事件是一种结构,为了实现广播者/订阅者模型,
    ////它只暴露了所需的委托特性的部分子集（事件和委托的区别）。
    ////事件的主要目的就是防止订阅者之间互相干扰。

    ////内外区别对待
    //public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    //class Broadcaster
    //{
    //    //Event 定义 
    //    //在Broadercaster类型里面的代码拥有对PriceChanged的完全访问权,在这里就可以把它当作委托。
    //    //而 Broadercaster类型之外的代码只能对PriceChanged这个event执行+=或-=操作
    //    public event PriceChangedHandler PriceChange;

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!zl ");
    //    }
    //}

    ////事件在内部是如何工作的?
    ////add和remove关键字代表着显式的事件访问器,有点像属性访器
    ////然后编译器会查看 Broadcaster内部对PriceChanged的引用,
    ////如果不是+=或=的操作,那就直接把它们定向到底层的委托字段pricechanged
    ////第三点,编译器把作用在event的+=和-=操作翻译成调用add或remove访问器。
    //class WorkPrinciple
    //{
    //    //首先,编译器把事件的声明翻译成类似下面的代码
    //    PriceChangedHandler priceChanged; // private delegate

    //    public event PriceChangedHandler PriceChanged
    //    {
    //        add { priceChanged += value; }
    //        remove { priceChanged -= value; }
    //    }
    //}

    ////标准的事件模式
    ////为编写事件,, NET定义了一个标准的模式
    ////System.EventArgs,一个预定义的框架类,除了静态的 Empty属性之外,它没有其它成员。
    ////EventArgs是为事件传递信息的类的基类。
    ////通常是根据所含有的信息进行命名,而不是所使用的事件
    ////通常通过属性或只读字段来暴露数据
    //public class PriceChangedEventArgs : System.EventArgs
    //{
    //    public readonly decimal LastPrice;
    //    public readonly decimal NewPrice;

    //    public PriceChangedEventArgs(decimal LastPrice, decimal newPrice)
    //    {
    //        LastPrice = LastPrice;
    //        NewPrice = newPrice;
    //    }

    //}

    ////为事件选择或定义委托

    ////返回类型是void
    ////接收两个参数,第一个参数类型是 object,第二参数类型是EventArgs的子类。
    ////第一个参数表示事件的广播者,第二个参数包含需要传递的信息;
    ////名称必须以 EventHandler结尾

    ////Framework定义了一个泛型委托 System EventHandler<T>,它满足上述规则。
    //public delegate void EvenHandler<TEventArgs>(object source, TEventArgs e) where TEventArgs : EventArgs;


    //public class Stock
    //{
    //    //针对选择的委托定义事件
    //    public event EventHandler<PriceChangedEventArgs> PriceChanged;
    //    //可触发事件的protected virtual方法
    //    //方法名必须和事件一致,前面再加上On,接收一个EventArgs参数或者其子类
    //    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    //    {
    //        //PriceChanged?.Invoke(this, e);
    //        if (PriceChanged != null)
    //        {
    //            PriceChanged(this, e);
    //        }
    //    }

    //}
    #endregion

    #region 事件例子

    #region 事件的定义
    //传递信息的类，通过只读字段传递、暴漏数据
    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }
    //股票类
    public class Stock
    {
        private string symbol;
        private decimal price;

        public Stock(string symbol)
        {
            this.symbol = symbol;
        }

        //这个事件用的委托用的预定义的泛型委托,如果不用这个得自己写一个委托
        //public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        //这个方法是可以触发上面事件的方法
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {   //事件触发处，到此处说明事件已经触发
            PriceChanged?.Invoke(this, e);//事件的触发实际上相当于调用委托的目标方法
        }


        //事件触发来源与价格的改变，每当价格改变时都会传递一个新的信息类， 触发事件发生 
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }
    #endregion

    #region 事件的使用
    class Program
    {
        static void Main()
        {
            Stock stock = new Stock("南天股");
            stock.Price = 120;
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 130;
        }

        private static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
           if((e.NewPrice -e.LastPrice)/e.LastPrice >0.1M)
           {
                Console.WriteLine("股票涨了10%");
           }
        }
    }

    #endregion


    #endregion

    #region 非泛型的EventHandler
    //当事件不携带多余信息的时候,可以使用非范型的 EventHandler委托。
    //但是也得给触发事件的方法传递一个参数，就可以把EventArgs Empty属性 传递过去
    public class Stock1
    {
        private string symbol;
        private decimal price;

        public Stock1(string symbol)
        {
            this.symbol = symbol;
        }

        public event EventHandler priceChanged;

        protected virtual void OnpriceChanged(EventArgs e)
        {
            priceChanged?.Invoke(this,e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if(price ==value) return;
                price = value;
                OnpriceChanged(EventArgs.Empty);
            }
        }
    }


    #endregion

    #region 事件访问器
    //事件访问器是事件的+=和-=函数的实现。
    //public event EventHandler PriceChanged;隐式定义的事件访问器，系统的

    //编译器会把它转化为:
    //一个私有的委托字段
    //一对公共的事件访问器函数(add_Price Changed和 remove_Price Changed)
    //这两个函数的实现会把+和-=操作交给私有的委托字段

    //也可以显式的定义事件访问器
    class eventcs
    {
        //显式的定义事件访问器
        private  EventHandler priceChanged; // private delegate
        public event EventHandler PriceChanged
        {
            add { priceChanged += value; }
            remove { priceChanged -= value; }
        }
    }
    //当事件访问器仅仅是另一个广播事件的类的中继。
    //当类暴露大量 event,但是大部分时候都只有少数的订阅者存在。
    //显式实现一个声明了事件的接口
    #endregion

    #region 事件修饰符
    //virtual,可以被重写; abstract, sealed, static 
    public class Foo
    {
        public static event EventHandler<EventArgs> StaticEvent;
        public virtual event EventHandler<EventArgs> virtualEvent;
    }

    #endregion
}

