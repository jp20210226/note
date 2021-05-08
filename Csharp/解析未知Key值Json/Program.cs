using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace 解析未知Key值Json
{
    class Program
    {
        static void Main(string[] args)
        {   //类型到json
            var product = new Product
            {
                //id = "1",
                //name = "This is the name",
                fields = new Dictionary<string, string> {
                    {"field1","test"},
                    {"field2","test2"}
                }
            };

            var json = JsonConvert.SerializeObject(product);

            Console.WriteLine(json);

            json= File.ReadAllText(@"C:\Users\jp\Desktop\3D取到的数据.json");
            //json到类型
            var product2 = JsonConvert.DeserializeObject<Product>(json);
            Console.ReadKey();
        }
    }

    [JsonConverter(typeof(ProductConverter))]
    public class Product
    {
        public Product()
        {
            fields = new Dictionary<string, string>();
        }

        //public string id { get; set; }
        //public string name { get; set; }
        public Dictionary<string, string> fields { get; set; }
    }

    public class ProductConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Product);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var product = value as Product;
            if (product != null)
            {
                //writer.WriteStartObject();
                //writer.WritePropertyName("id");
                // writer.WriteValue(product.id);
                //writer.WritePropertyName("name");   
                //writer.WriteValue(product.name);

                foreach (var item in product.fields)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteValue(item.Value);
                }
            }

            //writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var product = existingValue as Product ?? new Product();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject) continue;

                var value = reader.Value.ToString();
                switch (value)
                {
                    //case "id":
                    //    product.id = reader.ReadAsString();
                    //    break;
                    //case "name":
                    //    product.name = reader.ReadAsString();
                    //    break;
                    default:
                        product.fields.Add(value, reader.ReadAsString());
                        break;
                }

            }

            return product;
        }
    }
}
