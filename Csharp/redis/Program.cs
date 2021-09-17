

using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace redis
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] = "id=1";
            //args[1] = "minute=16";
            conectRedis();
        }
        public  static void conectRedis()
        {
            using (RedisClient client = new RedisClient("192.168.85.130", 6379, "jiapei", 0))
            {
                #region string
                //client.Set<string>("daw", "我擦"); 
                //Console.WriteLine(client.Get<string>("daw"));//我擦
                //Console.WriteLine(client.GetValue("daw"));  //"我擦"
                //Console.WriteLine(JsonConvert.DeserializeObject(client.GetValue("daw")));//我擦

                //批量设置KEY VALUE
                //client.SetAll(new Dictionary<string, string>() { { "id", "001" }, { "name", "jp" } });
                //var get = client.GetAll<string>(new string[] {"id","name","num" });
                //foreach (var item in get)
                //{
                //    Console.WriteLine(item);
                //}

                //设置值的过期时间
                //client.Set<string>("guoqi", "123", TimeSpan.FromSeconds(10));//等多少秒后过期
                //client.Set<string>("guoqi", "123", DateTime.Now.AddYears(1));//一年后过期
                //Task.Delay(1000).Wait();
                //Console.WriteLine(client.Get<string>("guoqi"));

                //自增自减1，并返回自增后的值
                //如果没有该key，则初始值默认为0
                //Console.WriteLine(client.Incr("sid"));
                //Console.WriteLine(client.Incr("sid"));
                //Console.WriteLine(client.Incr("sid"));

                //自增自减2
                //Console.WriteLine(client.IncrBy("sid",2));
                //Console.WriteLine(client.DecrBy("sid", 2));

                //在原有KEY的value值后追加
                //client.AppendToValue("name", "p");
                //client.Append("name",new byte[2] {1,2});//追加十六进制数

                //add和set区别
                //Console.WriteLine(client.Add("ceshi", "没有该值key返回值为true，设置成功"));
                //Console.WriteLine(client.Add("ceshi", "有该值key返回值为false，设置失败，原值不变"));

                //Console.WriteLine(client.Set("ceshi", "覆盖值key并且返回值true"));

                //判断如果存在这个key,则就写进去,如果没有存在,则返回false
                //分布式锁
                //Console.WriteLine(client.SetValueIfExists("name1", "这是锁"));
                #endregion

                #region hash
                //string hashId = "用户实例ID";
                //client.SetEntryInHash(hashId, "商品实例ID1", "商品数量2个");
                //Console.WriteLine(client.GetValueFromHash(hashId, "商品实例ID1"));

                //Dictionary<string, string> gouwuche = new Dictionary<string, string>();
                //gouwuche.Add("商品实例ID2", "商品数量1个");
                //gouwuche.Add("商品实例ID3", "商品数量55个");
                //client.SetRangeInHash(hashId, gouwuche);

                //Console.WriteLine(client.GetValueFromHash(hashId, "商品实例ID2"));
                //Console.WriteLine(client.GetValueFromHash(hashId, "商品实例ID3"));

                //var lists = client.GetValuesFromHash(hashId, new string[3] { "商品实例ID1", "商品实例ID2", "商品实例ID3" });
                //foreach (var item in lists)
                //{
                //    Console.WriteLine(item);
                //}
                #endregion
                #region 存储对象T到hash中
                //client.StoreAsHash<UserInfo>(new UserInfo() { Id = 2, Name = "jiapei", Number = 1 });
                //client.StoreAsHash<UserInfo>(new UserInfo() { Id = 2, Name = "jiapei被覆盖" });

                //Console.WriteLine(client.GetFromHash<UserInfo>(2).Number);

                //var userinfo = client.GetFromHash<UserInfo>(2);
                //userinfo.Number = 123;
                //client.StoreAsHash<UserInfo>(userinfo);
                //Console.WriteLine(client.GetFromHash<UserInfo>(2).Number);
                #endregion
                #region 获取所有HashId数据集的key/value数据集合
                 string hashId = "用户信息";
                //Dictionary<string, string> pairs = new Dictionary<string, string>();
                //pairs.Add("id","001");
                //pairs.Add("name", "jiapei");
                //client.SetRangeInHash(hashId, pairs);
                //var dics = client.GetAllEntriesFromHash(hashId);
                //var count = client.GetHashCount(hashId);//获取大Key下字段数量
                //var keys = client.GetHashKeys(hashId);//获取大Key下字段key
                //var values = client.GetHashValues(hashId);//获取大Key下字段value
                //client.RemoveEntryFromHash(hashId, "del");//移除大Key下指定字段
                //client.HashContainsEntry(hashId, "del");//判断大Key下是否包含指定字段
                //client.IncrementValueInHash(hashId, "id",1);//给指定字段自加值并返回自加后的值
                //client.IncrementValueInHash(hashId, "id",-1);
                //foreach (var dic in dics)
                //{
                //    Console.WriteLine(dic.Key +"/"+ dic.Value) ;
                //}
                #endregion
            }
        }

 
    }
}
