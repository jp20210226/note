using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace 自定义类实现Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            person<bool> a = new person<bool>();
            a.sex231 = true;
            a.name = true;
            a.age = false;
            a.age23 = true;
            a.name21 = false;
            a.sex = false;
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


            List<string> a1 = new List<string> {"a","vb","awq" };
            IEnumerator<string> ietor = a1.GetEnumerator();
            while(ietor.MoveNext())
            {
                Console.WriteLine(ietor.Current);
            }
        }
    }
    public class person<T> : IEnumerable<T>
    {
        private static person<T> p;
        public person()
        {
            p = this;
        }
        public T name { get; set; }
        public T age { get; set; }
        public T sex { get; set; }
        public T name21 { get; set; }
        public T age23 { get; set; }
        public T sex231 { get; set; }
        public IEnumerator GetEnumerator()
        {
            Type t = p.GetType();

            TypeInfo ti =t.GetTypeInfo();
            PropertyInfo[] pis = ti.GetProperties();
            foreach (PropertyInfo pi in pis)
            {

                T a = (T)pi.GetValue(p, null);
                yield return a;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class bird:IEnumerable 
    {
        public IEnumerator GetEnumerator()
        {
            
            return  null;
        }
    }
}
