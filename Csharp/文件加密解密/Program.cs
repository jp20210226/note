using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 文件加密解密
{
    class Program
    {
        //byte key = (byte)8;
        public static Program Pj = new Program();
        static void Main(string[] args)
        {
            string path = @"C:\Users\jp\Desktop\0d2a8e63-b5be-4a81-9771-9de94cf3cb67\0d2a8e63-b5be-4a81-9771-9de94cf3cb67.ntrd.chena";
            Encryption(path);
            //string path = @"C:\Users\jp\Desktop\123.txt";
            //加密
            //Pj.FileReadAndDecrypt(path);
            //解密
            // Pj.FileReadAndDecrypt(path);
            // Console.WriteLine(Pj.FileRead(path));
            //Decrypt.EncodingFile(path, path);
        }
        //public string FileRead(string path)
        //{
        //    string readData;
        //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        byte[] readBuffer = new byte[5 * 1024 * 1024];
        //        fs.Read(readBuffer);
        //        readData = Encoding.UTF8.GetString(readBuffer);
        //    }
        //    return readData;
        //}
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="path"></param>
        public void FileReadAndEnorDecrypt(string path, byte key = (byte)8)
        {
            byte[] dataByte;
            using (FileStream fr = new FileStream(path, FileMode.Truncate, FileAccess.Read))
            {
                byte[] fread = new byte[fr.Length];
                fr.Read(fread);

                for (int i = 0; i < fread.Length; i++)
                {
                    //if (i <= 255)0001 0000  
                    //{
                    fread[i] = (byte)(fread[i] + key);
                    //}
                }
                dataByte = fread;
            }
            using (FileStream fr = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                fr.Write(dataByte);
            }
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="path"></param>
        public void FileReadAndDecrypt(string path,byte key = (byte)8)
        {

            byte[] dataByte;
            using (FileStream fr = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] fread = new byte[fr.Length];
                fr.Read(fread);

                for (int i = 0; i < fread.Length; i++)
                {
  
                        fread[i] = (byte)(fread[i] - key);
                        fread[i] = fread[i];
 

                }
                dataByte = fread;
            }
            using (FileStream fr = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                fr.Write(dataByte);
            }
        }
        public static void Encryption(string path)
        {
            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);// 读取方式打开，得到流
            if (fs.Length < 512)
            { return; }
            fs.Seek(0, SeekOrigin.Begin);//定位到第0个字节
            byte[] datas = new byte[512];
            byte[] ndatas = new byte[512];// 要读取的内容会放到这个数组里
            fs.Read(datas, 0, datas.Length);// 开始读取，读取的内容放到datas数组里，0是从第一个开始放，datas.length是最多允许放多少个
            for (int i = 0; i < datas.Length; i++)
            {
                ndatas[i] = Convert.ToByte(Convert.ToString(datas[i] ^ 170, 16), 16);
            }
            fs.Seek(0, SeekOrigin.Begin);// 定位，在第0个字节处写入
            fs.Write(ndatas, 0, ndatas.Length);// 将准备好的数组写入文件。newData是包含要写入文件的byte类型数组；0是数组中的从零开始的字节偏移量，从此处开始将字节复制到该流；newData.Length是要写入的字节数。这句话的意思是从44个字节开始把数组内容从头到尾写进去，修改下参数如writeStream.Write(newData, 1, newData.Length-1)是把数组从第二个到倒数第一个写进去
            fs.Close();// 关闭文件
        }

        //public void FileOverrideWrite(string path, string WriteData)
        //{
        //    byte[] writeBuffer = Encoding.UTF8.GetBytes(WriteData);
        //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {

        //        fs.Write(writeBuffer);
        //    }
        //}

        //public void FileAppendWrite(string path, string WriteData)
        //{
        //    byte[] writeBuffer = Encoding.UTF8.GetBytes(WriteData);
        //    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
        //    {

        //        fs.Write(writeBuffer);
        //    }
        //}
    }
}
