using System;
using System.Diagnostics;
namespace _7Z
{
    class Program
    {
        string _7zExeUrl = @"C:\Users\jp\Desktop\7za.exe";
        public void DecompressFileToDirectory(string inFileath, string outFilePath, string password)
        {
            try
            {
                Process process = new Process();
                string info = " x  -aos -p" + password + " " + inFileath + " -o" + outFilePath + " -r ";
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
                Console.WriteLine(e.Message);
            }

        }
        static void Main(string[] args)
        {
            Program a = new Program();
            string zipPath = @"C:\Users\jp\Desktop\AB_Catalyst_6500_E(14U).7z";
            string dirPath = @"C:\Users\jp\Desktop\新建文件夹";
            string EnPassword = "1]]-*Z1+-/*0,1[*Z([Y(^1.-Z1[.*+*";
            string password = a.Decryption(EnPassword);
            a.DecompressFileToDirectory(zipPath, dirPath, password);
        }

        public string Decryption(string EnPassword)
        {
            byte[] EnByte = System.Text.Encoding.UTF8.GetBytes(EnPassword);
            for (int i = 0; i < EnByte.Length; i++)
            {
                EnByte[i] = (byte)(EnByte[i] + (byte)8);

            }
            string DecryptPassword = System.Text.Encoding.UTF8.GetString(EnByte);


            return DecryptPassword;
        }

        public string Encrypt(string Password)
        {
            byte[] Byte = System.Text.Encoding.UTF8.GetBytes(Password);
            for (int i = 0; i < Byte.Length; i++)
            {
                Byte[i] = (byte)(Byte[i] - (byte)8);

            }
            string DecryptPassword = System.Text.Encoding.UTF8.GetString(Byte);


            return DecryptPassword;
        }

    }
}
