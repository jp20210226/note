using System;
using System.Diagnostics;
using System.Reflection;
namespace 测完即删
{
    
    class Program
    {
        static void Main(string[] args)
        {
            hhh a = new hhh();
            string aa = a.ToString();
            Console.WriteLine(a);
        }
    
    }

      class  hhh
    {
        public   override  string  ToString()
        {
            return "啊啊";
        }
    }
 
}
