using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Openexe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        open();
    }

    void open()
    {
        Process p = new Process();
        p.StartInfo.FileName = "任重道远.txt"; /*@"E:\unityProject\Personal_Project\practice\Assets\StreamingAssets\plugins\aria2\aria2c.exe";*/
        p.StartInfo.Arguments = @"C:\Users\jp\Desktop\"; /*"--conf-path=aria2.conf";*/
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
    }
    public void z7(string cmdstr)
    {
        Process p = new Process();
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.FileName = "7za.exe";//需要启动的程序名     
        //p.StartInfo.Arguments = @"a  -t7z     d:\SMMM_2011103111620.7z  d:\SMMM_2011103111620.bak  -mx=9   ";//启动参数
        p.StartInfo.Arguments = @"a  -t7z    " + cmdstr + " -mx=9   ";//启动参数 
        p.Start();//启动   
    }
}
