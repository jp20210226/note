using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
namespace Assets.文件下载
{
    class _7zL:MonoBehaviour
    {   
        //7z程序的程序目录
        private string _7zExeUrl;

        void Start()
        {
            _7zExeUrl = @"C:\Users\jp\Desktop\7za.exe"; 
            string zipPath = @"C:\Users\jp\Desktop\AB_Catalyst_6500_E(14U)(1).7z";
            string dirPath = Application.streamingAssetsPath+ "/AssetBundleFolder";
 
            string password = "1234567890123456";
            DecompressFileToDirectory(zipPath, dirPath, password);
            //DeCompressionFile("", "", "");
        }

        public void DecompressFileToDirectory(string inFileath, string outFilePath,string password)
        {
            try
            {
                Process process = new Process();
                string info = " x -y -p" + password + " " +inFileath + " -o" + outFilePath + " -r ";
                ProcessStartInfo startInfo = new ProcessStartInfo(_7zExeUrl, info);
                process.StartInfo = startInfo;
                //隐藏DOS窗口  
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
                process.Close();


 
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
            }

        }



        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="zipPath">压缩文件路径</param>
        /// <param name="dirPath">解压到文件夹路径</param>
        /// <param name="password">密码</param>
        //public static void DeCompressionFile(string zipPath, string dirPath, string password = "")
        //{
        //    if (!File.Exists(zipPath))
        //    {
        //        throw new ArgumentNullException("zipPath压缩文件不存在");
        //    }
        //    Directory.CreateDirectory(dirPath);
        //    try
        //    {
        //        using (Stream stream = File.OpenRead(zipPath))
        //        {
        //            var option = new ReaderOptions()
        //            {
        //                ArchiveEncoding = new SharpCompress.Common.ArchiveEncoding()
        //                {
        //                    Default = Encoding.UTF8
        //                }
        //            };
        //            if (!string.IsNullOrWhiteSpace(password))
        //            {
        //                option.Password = password;
        //            }

        //            var reader = ReaderFactory.Open(stream, option);
        //            while (reader.MoveToNextEntry())
        //            {
        //                if (reader.Entry.IsDirectory)
        //                {
        //                    Directory.CreateDirectory(Path.Combine(dirPath, reader.Entry.Key));
        //                }
        //                else
        //                {
        //                    //创建父级目录，防止Entry文件,解压时由于目录不存在报异常
        //                    var file = Path.Combine(dirPath, reader.Entry.Key);
        //                    Directory.CreateDirectory(Path.GetDirectoryName(file));
        //                    reader.WriteEntryToFile(file);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 工程压缩包操作类(利用winrar进行解压，故系统上必须安装winrar)
        /// </summary>
        //public class ZIPPackageOP
        //{
        //    /// <summary>
        //    /// 解压带密码的压缩包（zip;rar都可）
        //    /// </summary>
        //    /// <param name="zipFilePath">压缩包路径</param>
        //    /// <param name="unZipPath">解压后文件夹的路径</param>
        //    /// <param name="password">压缩包密码</param>
        //    /// <returns></returns>
        //    public static bool unZIP(string zipFilePath, string unZipPath, string password)
        //    {
        //        if (!isStallWinrar())
        //        {
                     
        //            return false;
        //        }

        //        System.Diagnostics.Process Process1 = new System.Diagnostics.Process();
        //        Process1.StartInfo.FileName = "Winrar.exe";
        //        Process1.StartInfo.CreateNoWindow = true;
        //        Process1.StartInfo.Arguments = " x -p" + password + " " + zipFilePath + " " + unZipPath;
        //        Process1.Start();
        //        if (Process1.HasExited)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    /// <summary>
        //    /// 判断系统上是否安装winrar
        //    /// </summary>
        //    /// <returns></returns>
        //    public static bool isStallWinrar()
        //    {
        //        RegistryKey the_Reg =
        //            Registry.LocalMachine.OpenSubKey(
        //                @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
        //        return !string.IsNullOrEmpty(the_Reg.GetValue("").ToString());

        //    }
        //}
 
    }
}
