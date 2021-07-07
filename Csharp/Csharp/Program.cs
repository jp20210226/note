using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
namespace Csharp
{
    struct Personstruct
    {
        public static void M1() { }
        public void M2() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OpenFileDialog
            //string path = @"C:\Users\jp\Desktop\new.txt";
            #region 文件流读取
            ////FileStream读取
            //using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    //每次读取5M数据
            //    byte[] buffer = new byte[1024 * 1024 * 5];
            //    //表示本次实际读取到的有效字节数
            //    int r = fsRead.Read(buffer, 0, buffer.Length);

            //    string s = Encoding.Default.GetString(buffer, 0, r);

            //    Console.WriteLine(s);
            //}
            ////FileStream写入
            //using (FileStream fsWritr = new FileStream(path, FileMode.Append, FileAccess.Write))
            //{
            //    string s = "谁你麻痹，起来嗨";
            //    //每次读取5M数据
            //    byte[] buffer = Encoding.Default.GetBytes(s);
            //    //表示本次实际读取到的有效字节数
            //    fsWritr.Write(buffer, 0, buffer.Length);
            //    Console.WriteLine("写入成功");
            //}

            ////StreamReader读取
            //using (StreamReader sr = new StreamReader(path, Encoding.Default))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        Console.WriteLine(sr.ReadLine());
            //    }
            //}
            ////StreamReader写入
            //byte[] buffer = new byte[1024 * 1024];
            //using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default, buffer.Length))
            //{
            //    sw.WriteLine("hahah");
            //}

            ////脑残式写法
            //using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    using (StreamReader sr = new StreamReader(fsRead, Encoding.Default))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            Console.WriteLine(sr.ReadLine());
            //        }
            //    }
            //}



            ////使用Fi1e类来读取数据
            //byte[] buffer = File.ReadAllBytes(@"C:\Users\SpringRain\Desktop\1.txt");
            //string str = Encoding.Default.GetString(buffer, 0, buffer.Length);
            //Console.WriteLine(str);
            ////编码:把字符串以怎样形式存储为二进制 ASCII GBK GB2312 UTF-8
            //Console.ReadKey();
            #endregion

            #region 序列化反序列化
            ////序列化
            //Person p = new Person() { age = 1, name = "王八", sex = "公" };
            //using (FileStream fsWrite =new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fsWrite, p);
            //}
            //Console.WriteLine("序列化成功");
            ////反序列化
            //Person p1;
            //using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    p1 = (Person)bf.Deserialize(fsRead);

            //}
            //Console.WriteLine("{0},{1},{2}",p1.name,p1.sex,p1.age);
            #endregion

            #region 其他
            ////索引器示例
            //Person p = new Person();
            //p["小明"] = new Bird();
            ////单例模式
            //DanLi li = DanLi.GetSingle();
            #endregion

            #region 创建普通的Xml文档
            ////通过代码来创建XML文档
            ////1、引入命名空间System.Xml
            ////2、创建Xml文档对象
            //XmlDocument doc = new XmlDocument();
            ////创建第一个行描述信息<?xml version="1.0" encoding="utf-8" ?>，并添加到doc文档中
            //XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //doc.AppendChild(dec);
            ////创建根节点
            //XmlElement books = doc.CreateElement("Books");
            //doc.AppendChild(books);
            ////给根节点Books创建子节点
            //XmlElement book1 = doc.CreateElement("Book1");
            //XmlElement book2 = doc.CreateElement("Book2");
            ////将book1添加进根节点
            //books.AppendChild(book1);
            //books.AppendChild(book2);


            ////给book1添加子节点
            //XmlElement name1 = doc.CreateElement("Name");
            //name1.InnerText = "书1";
            //book1.AppendChild(name1);
            //XmlElement price1 = doc.CreateElement("Price");
            //price1.InnerText = "19";
            //book1.AppendChild(price1);
            //XmlElement des1 = doc.CreateElement("des");
            //des1.InnerText = "好看";
            //book1.AppendChild(des1);

            ////给book2添加子节点
            //XmlElement name2 = doc.CreateElement("Name");
            //name2.InnerText = "书2";
            //book2.AppendChild(name2);
            //XmlElement price2 = doc.CreateElement("Price");
            //price2.InnerText = "10";
            //book2.AppendChild(price2);
            //XmlElement des2 = doc.CreateElement("des");
            //des2.InnerText = "不好看";
            //book2.AppendChild(des2);

            //doc.Save("Books.xml");
            #endregion

            #region 创建带属性的Xml文档
            //XmlDocument doc = new XmlDocument();
            //XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //doc.AppendChild(dec);
            //XmlElement order = doc.CreateElement("Order");
            //doc.AppendChild(order);
            //XmlElement customerName = doc.CreateElement("CustomerName");
            //customerName.InnerText = "刘洋";
            //order.AppendChild(customerName);

            //XmlElement customerNumber = doc.CreateElement("CustomerName");
            //customerNumber.InnerText = "1000001";
            //order.AppendChild(customerNumber);

            //XmlElement Items = doc.CreateElement("CustomerName");
            //order.AppendChild(Items);

            //XmlElement orderItem1 = doc.CreateElement("OrderItem1");
            ////给节点添加属性
            //orderItem1.SetAttribute("Name", "c1");
            //orderItem1.SetAttribute("Count", "2");
            //Items.AppendChild(orderItem1);

            //XmlElement orderItem2 = doc.CreateElement("OrderItem1");
            //orderItem2.SetAttribute("Name", "c2");
            //orderItem2.SetAttribute("Count", "3");
            //Items.AppendChild(orderItem2);

            //XmlElement orderItem3 = doc.CreateElement("OrderItem1");
            //orderItem3.SetAttribute("Name", "c3");
            //orderItem3.SetAttribute("Count", "4");
            //Items.AppendChild(orderItem3);

            //doc.Save("PropertyXml.xml");
            #endregion

            #region 追加XmL文档
            //XmlDocument doc = new XmlDocument();
            //doc.Load("Books.xml");
            ////获取文档根节点
            //XmlElement books = doc.DocumentElement;

            ////给根节点Books创建子节点
            //XmlElement book1 = doc.CreateElement("Book1");

            ////将book1添加进根节点
            //books.AppendChild(book1);
            ////给book1添加子节点
            //XmlElement name1 = doc.CreateElement("Name");
            //name1.InnerText = "C#";
            //book1.AppendChild(name1);
            //XmlElement price1 = doc.CreateElement("Price");
            //price1.InnerText = "129";
            //book1.AppendChild(price1);
            //XmlElement des1 = doc.CreateElement("des");
            //des1.InnerText = "aa好看";
            //book1.AppendChild(des1);

            //doc.Save("Books.xml");
            #endregion

            #region 读取普通Xml文档
            //XmlDocument doc = new XmlDocument();
            //doc.Load("Books.xml");
            ////获得根节点
            //XmlElement books = doc.DocumentElement;
            ////根据根节点获取子节点
            //XmlNodeList xnl = books.ChildNodes;
            //foreach (XmlNode item in xnl)
            //{
            //    Console.WriteLine(item.InnerText);
            //}
            #endregion

            #region Xpath读取带属性的Xml文档
            //XmlDocument doc = new XmlDocument();
            //doc.Load("PropertyXml.xml");
            //XmlNodeList xnl =  doc.SelectNodes("/Order/CustomerName/OrderItem1");
            //foreach (XmlNode node in xnl)
            //{
            //    Console.WriteLine(node.Attributes["Name"].Value);
            //    Console.WriteLine(node.Attributes["Count"].Value);
            //}
            #endregion

            #region 删除Xml文档节点
            XmlDocument doc = new XmlDocument();
            doc.Load("PropertyXml.xml");
            XmlNode xn = doc.SelectSingleNode("/Order/CustomerName");
            xn.RemoveAll();
            doc.Save("PropertyXml.xml");
            #endregion
        }
    }
}


//单例
public class DanLi
{
    public static DanLi danli = null;

    private DanLi()
    {

    }
    public static DanLi GetSingle()
    {
        if (danli != null)
        { danli = new DanLi(); }
        return danli;
    }
}
public class Maque : Bird, IFlyable
{
    //<summary>
    ///这个函数是父类的?还是子类自己的?还实现接口的?
    //</summary>
    public void Fly()//子类自己的方法
    {
        Console.WriteLine("鸟会飞");
    }
    void IFlyable.F1y()//显式实现接口
    {
        Console.WriteLine("实现的接口的飞方法");
    }
}
public interface IFlyable
{
    public void F1y();
}
public class Bird
{

}

[Serializable]
public class Person
{
    Dictionary<string, object> dicInfo = null;
    public object this[string name]  //在名字位置是关键字this
    {
        get { return dicInfo.ContainsKey(name) ? dicInfo[name] : null; }
        set { dicInfo[name] = value; }
    }
    private string _name;
    public string name
    {
        get { return name = _name; }
        set { _name = value; }
    }
    public int age { get; set; }
    public string sex { get; set; }

}

