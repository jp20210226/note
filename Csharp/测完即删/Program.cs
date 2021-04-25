using System;
using System.Diagnostics;
using System.Reflection;
namespace 测完即删
{
    using System.Reflection;

    public class PTtemplate
    {
        public string Fanshefangfa(int a)
        {
            return Execute("Factory", "classff", "abc", a.ToString());
        }

        //参数分别是：命名空间、类名、方法名、参数列表(多个参数可用,分隔)
        public string Execute(string name_space, string className, string MethodName, string pstr)
        {
            //先从程序集中查找所需要的类并使用系统激活器创建实例
            object instance = Assembly.Load(name_space).CreateInstance(name_space + "." + className);
            Type type = instance.GetType();
            object[] parameters = null;
            if (pstr != "")
            {
                string[] pa = pstr.Split(',');
                parameters = new object[pa.Length];
                for (int i = 0; i < pa.Length; i++)
                {
                    try 
                    { 
                        parameters[i] = int.Parse(pa[i]);
                    }
                    catch { parameters[i] = pa[i]; }


                }
            }
            //查找指定的方法，然后返回结果
            MethodInfo methodinfo = type.GetMethod(MethodName);
            return methodinfo.Invoke(instance, parameters).ToString();
        }
 
    }
    class Program
    {
        static void Main(string[] args)
        {
            string a = "awd";
            Console.WriteLine(a);
        }
    
    }

    class ReflectionTest
    {
        //public static string StaticProperty { get; set; }

        private static string _StaticField;

        public static string _StaticField1;

        //public void Method1()
        //{
        //    Console.WriteLine("Method1无参无返回");
        //}
        [Conditional("a")]
        public void Method1(string a)
        {
            Console.WriteLine("Method1有参无返回");
        }
        //[Conditional("a")]
        //public void Method2(string a)
        //{
        //    Console.WriteLine("Method2有参无返回");

        //}

        //public string Method3(string a)
        //{
        //    Console.WriteLine("Method3有参有返回");
        //    return a;
        //}
        private string _field;
        //public string Property
        //{ 
        //    get { return _field; }
        //    set { _field = value; }
        //}
    }


}
