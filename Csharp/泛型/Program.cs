using System;
using System.Collections;
using System.Collections.Generic;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            FAction();
        }
        //如果某个返回的类型可以由其子类型替换，那么这个类型就是支持协变的
        //如果某个参数类型可以由其父类替换，那么这个类型就是支持逆变的。
        //variance 只能用在接口或委托里
        public void FIEnumerable()
        {   //协变  有输出
            //子转父
            // public interface IEnumerable<out T> : IEnumerable  
            IEnumerable<string> strings = new List<string>() { "a", "b", "c" };
            IEnumerable<object> objects = strings;

        }
        public void FIList()
        {
            //不变 有输入有输出
            // T this[int index] { get; set; } 这个T作为返回类型使用， 
            // int IndexOf(T item);  这个T作为参数输入使用，
            //所以下面代码危险，IList<string>不能转化为IList<object> 
            //IList<string> strings = new List<string>() { "a", "b", "c" };
            //IList<object> objects = strings;
            //objects.add(new object());
            //string element = string[3];
        }

        public static void FAction()
        {
            //逆变 有输入
            //public delegate void Action<in T>
            //父转子
            Action<object> objectAction = obj =>Console.WriteLine(obj);
            Action<string> stringAction = objectAction;
            stringAction("print me");
        }
    }
 

}
