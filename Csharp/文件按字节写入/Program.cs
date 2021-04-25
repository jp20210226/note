using System;
using System.IO;

namespace 文件按字节写入
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Program a = new Program();
            for (int i = 0; i < 1000; i++)
            {
                a.SymmetricEncryption();
            }
             
        }

        /// <summary>
        /// 
        /// </summary>
        public void SymmetricEncryption()
        {
            int key = 170;
            string path = @"C:\Users\jp\Desktop\1231.txt";// 要读取的文件
            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);// 读取方式打开，得到流
            if (fs.Length < 512)
            { return; }
            fs.Seek(0, SeekOrigin.Begin);// 定位到第0个字节
            byte[] datas = new byte[512];
            byte[] ndatas = new byte[512];// 要读取的内容会放到这个数组里
            fs.Read(datas, 0, datas.Length);// 开始读取，读取的内容放到datas数组里，0是从第一个开始放，datas.length是最多允许放多少个

            for (int i = 0; i < datas.Length; i++)
            {
                ndatas[i] = Convert.ToByte(Convert.ToString(datas[i] ^ key, 16), 16); 
            }
            #region 16进制补位处理
            ////16进制补位处理
            //int a = datas[2];//10进制
            //string strA = Convert.ToString(a, 16);//转换成16进制
            //if (strA.Equals(""))
            //{
            //    strA = "00";
            //}
            //if (strA.Length == 1)
            //{
            //    strA = "0" + strA;
            //}
            //int point = Convert.ToInt32(strA, 16);// 十六进制转十进制
            //System.Console.WriteLine("value=" + point);// 这里输出value=123456，也就是上面写入程序写进去的值
            #endregion

            fs.Seek(0, SeekOrigin.Begin);// 定位，在第0个字节处写入
            fs.Write(ndatas, 0, ndatas.Length);// 将准备好的数组写入文件。newData是包含要写入文件的byte类型数组；0是数组中的从零开始的字节偏移量，从此处开始将字节复制到该流；newData.Length是要写入的字节数。这句话的意思是从44个字节开始把数组内容从头到尾写进去，修改下参数如writeStream.Write(newData, 1, newData.Length-1)是把数组从第二个到倒数第一个写进去
            fs.Close();// 关闭文件
        }
    }
}
