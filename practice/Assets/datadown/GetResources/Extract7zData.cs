using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Extract7zData : MonoBehaviour
{

    /// <summary>
    /// 解压7Z压缩包
    /// </summary>
    /// <param name="inFileath"></param>
    /// <param name="outFilePath"></param>
    /// <param name="password"></param>
    public static void DecompressFileToDirectory(string inFileath, string outFilePath, string _password)
    {
        try
        {
            //UnityEngine.Debug.Log(outFilePath);
            string _7zExeUrl = Application.streamingAssetsPath+ "/plugins/7za.exe";
            Process process = new Process();
            string password = Decryption(_password);
            string info = " x  -aos -p" + password + " " + inFileath + " -o" + outFilePath + " -r ";
            ProcessStartInfo startInfo = new ProcessStartInfo(_7zExeUrl, info);
            process.StartInfo = startInfo;
            //隐藏DOS窗口  
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            process.Close();
            File.Delete(inFileath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    private static string Decryption(string EnPassword)
    {
        byte[] EnByte = System.Text.Encoding.UTF8.GetBytes(EnPassword);
        for (int i = 0; i < EnByte.Length; i++)
        {
            EnByte[i] = (byte)(EnByte[i] + (byte)8);

        }
        string DecryptPassword = System.Text.Encoding.UTF8.GetString(EnByte);


        return DecryptPassword;
    }
}
