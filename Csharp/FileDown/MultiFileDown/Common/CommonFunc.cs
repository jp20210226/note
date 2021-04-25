using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public class CommonFunc
    {
        public static Thread CreateThread(ThreadStart pt, int pSleep = 0)
        {
            Thread t1 = new Thread(pt);
            t1.IsBackground = true;
            t1.Start();
            if (pSleep > 0)
                Thread.Sleep(pSleep);
            return t1;
        }

        public static Thread CreateThreadParam(ParameterizedThreadStart pt, object pobj, int pSleep = 0)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(pt));
            t1.IsBackground = true;
            t1.Start(pobj);
            if (pSleep > 0)
                Thread.Sleep(pSleep);
            return t1;
        }

        public static string SecondsToTimeStr(long pSeconds)
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0, 0).AddSeconds(pSeconds);
            long iday = pSeconds / 86400;
            if (iday > 0)
            {
                return iday+" "+ dt.ToString("HH:mm:ss");
            }
            else
                return dt.ToString("HH:mm:ss");
        }

        public static string GetNewFileName(string pFile)
        {
            string directory = Path.GetDirectoryName(pFile);
            string filename = Path.GetFileNameWithoutExtension(pFile);
            string extension = Path.GetExtension(pFile);
            int counter = 1;
            string newFilename;
            do
            {
                newFilename = string.Format("{0}({1}){2}", filename, counter, extension);
                //newFullPath = Path.Combine(directory, newFilename);
                counter++;
            } while (System.IO.File.Exists(Path.Combine(directory, newFilename)));
            return newFilename;
        }
        public static byte[] GetFileBytes(string pfilename)
        {
            try
            {
                FileStream stream2 = File.Open(pfilename, FileMode.Open);
                byte[] buffer = new byte[stream2.Length];
                stream2.Read(buffer, 0, (int)stream2.Length);
                stream2.Close();
                return buffer;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static bool WriteFileBytes(string pfilename,byte[] pbuffer)
        {
            try
            {
                FileStream stream3 = File.Open(pfilename, FileMode.Create);
                stream3.Write(pbuffer, 0, pbuffer.Length);
                stream3.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            //Regex rx = new Regex(pattern);
            return Regex.IsMatch(s, pattern); // rx.IsMatch(s);
        }
    }
}
