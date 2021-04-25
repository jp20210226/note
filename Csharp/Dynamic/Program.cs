using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dynamic
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main1(string[] args)
        {
            Person p = new Person();
            p.Id = 1;
            p.Name = "刘备";
            //C#对象转Json
            string json = JsonConvert.SerializeObject(p);
            Console.WriteLine(json);    //{"Id":1,"Name":"刘备"}

            //此处模拟在不建实体类的情况下，反转将json返回dynamic对象
            var DynamicObject = JsonConvert.DeserializeObject<dynamic>(json);
            Console.WriteLine(DynamicObject.Name);  //刘备
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"C:\Users\jp\Desktop\get到的.json");
            //此处模拟在不建实体类的情况下，反转将json返回回dynamic对象
            dynamic DynamicObject = JsonConvert.DeserializeObject<dynamic>(json);
            DealDynamicObject(DynamicObject);
            Console.ReadKey();
        }

        static void DealDynamicObject(dynamic obj)
        {
            Console.WriteLine(obj);
        }
    }
}
