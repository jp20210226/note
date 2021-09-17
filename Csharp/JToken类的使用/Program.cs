using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dynamic
{
    class Program
    {
        public void ceshi()
        {
            //    string path = @"C:\Users\jp\Desktop\response_1629352238605.json";
            //    string json = File.ReadAllText(path);
            //    JObject Oproject = JObject.Parse(json);
            //    JToken Tdata = Oproject["data"];
            //    JObject j = Tdata.ToObject<JObject>();
            //    JArray jDisPlay = new JArray();
            //    JArray SubData = new JArray();
            //        foreach (var jd in j)
            //        {
            //            if (jd.Key == "不展示组")
            //            {
            //                continue;
            //            }
            //            else if (jd.Key == "子设备")
            //            {

            //                SubData = (JArray) jd.Value;

            //}
            //            else
            //            {

            //                JObject temp = new JObject();
            //temp[jd.Key] = jd.Value;
            //                jDisPlay.Add(temp);
            //            }
            //        }
            //       Console.WriteLine(SubData.First);
        }
        static void Main(string[] args)
        {
            //dynamic d = new ExpandoObject(); 

            //(d as ICollection<KeyValuePair<string, object>>).Add(new KeyValuePair<string, object>("www", 1));

            //            string jsonStr = @"{ 'ROOT': {
            //    'TOKEN': 'aa',
            //    'SERVICE': 'bb',
            //    'DATAPARAM': 'cc'
            //  }
            //}";
            string jsonStr = File.ReadAllText(@"C:\Users\jp\Desktop\get到的.json");
            //解析
            var json = ReadJSON(jsonStr);
            //获取值
            string Token = JSON_SeleteNode(json, "TOKEN");
            Console.Write(Token);
            //设置值
            JSON_SetChildNodes(ref json, "SERVICE", "hello world");
            Console.Write(json.ToString());
            Console.ReadLine();

        }
        public static JToken ReadJSON(string jsonStr)
        {
            JObject jobj = JObject.Parse(jsonStr);
            JToken result = jobj as JToken;
            return result;
        }
        /// <summary>
        /// 遍历所以节点，替换其中某个节点的值
        /// </summary>
        /// <param name="jobj">json数据</param>
        /// <param name="nodeName">节点名</param>
        /// <param name="value">新值</param>
        private static void JSON_SetChildNodes(ref JToken jobj, string nodeName, string value)
        {
            try
            {
                JToken result = jobj as JToken;//转换为JToken
                JToken result2 = result.DeepClone();//复制一个返回值，由于遍历的时候JToken的修改回终止遍历，因此需要复制一个新的返回json
                                                    //遍历
                var reader = result.CreateReader();
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.String || reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float)
                        {
                            Regex reg = new Regex(@"" + nodeName + "$");
                            //SelectToken(Path)方法可查找某路径下的节点，在Newtonsoft.Json 4.5 版本中不可使用正则匹配，在6.0版本中可用使用，会方便很多，6.0版本下替换值会更方便，这个需要特别注意的
                            if (reg.IsMatch(reader.Path))
                            {
                                result2.SelectToken(reader.Path).Replace(value);
                            }
                        }
                    }
                }
                jobj = result2;
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获取相应子节点的值
        /// </summary>
        /// <param name="childnodelist"></param>
        private static string JSON_SeleteNode(JToken json, string ReName)
        {
            try
            {
                string result = "";
                //这里6.0版块可以用正则匹配
                var node = json.SelectToken("$.." + ReName);
                if (node != null)
                {
                    //判断节点类型
                    if (node.Type == JTokenType.String || node.Type == JTokenType.Integer || node.Type == JTokenType.Float)
                    {
                        //返回string值
                        result = node.Value<object>().ToString();
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    class student
    {

    }
}
