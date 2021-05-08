using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CallerInfoAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo 啊 = new Foo();
            Console.WriteLine("卧槽1"+ 啊.CustomerName);
            啊.CustomerName = "a";
            Console.WriteLine("卧槽2" + 啊.CustomerName);
            啊.CustomerName = "a";
            Console.WriteLine("卧槽3" + 啊.CustomerName);
            啊.CustomerName = "b";
            Console.WriteLine("卧槽4" + 啊.CustomerName);
        }
    }

    public class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged= delegate { };

        void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));//propertyName = CustomerName 调用成员名字，此处为那个方法名字
            Console.WriteLine("卧槽了");
        }

        string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if(value ==customerName) return;
                customerName = value;
                RaisePropertyChanged();
            }
        }

    }
}
