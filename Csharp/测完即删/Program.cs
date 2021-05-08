using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
namespace 测完即删
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            int? a = 5;
            int b = 109;
            var c = a + b;
            string JsonTest = File.ReadAllText(@"C:\Users\jp\Desktop\3D取到的数据.json");
            var product = new Product();
            var data = JObject.Parse(JsonTest);
            foreach (var item in data)
            {
                product.SetProperty(item.Key, item.Value.ToString());
            }
        }
    
    }

    public class Product
    {
        private Type _type;

        public Product()
        {
            fields = new Dictionary<string, string>();
            _type = GetType();
        }

        public string id { get; set; }
        public string name { get; set; }
        public Dictionary<string, string> fields { get; set; }

        public void SetProperty(string key, string value)
        {
            var propertyInfo = _type.GetProperty(key);
            if (null == propertyInfo)
            {
                fields.Add(key, value);
                return;
            }
            propertyInfo.SetValue(this, value.ToString());
        }
    }


}
