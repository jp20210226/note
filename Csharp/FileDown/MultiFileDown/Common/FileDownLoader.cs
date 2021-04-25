using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public class FileDownLoader
    {
        private string URL;
        private long downloadSize = 0L;   //下载总大小
        private long fileSize = 0L;         //文件总大小
        private DownloadThread[] threads;
        private string saveFile;            //全路径文件名
        private string saveFileName;        //文件名
        private string saveDir;
        public Dictionary<int, long> DownProgress = new Dictionary<int, long>();    //下载进度
        private long BlockSize;             //块大小
        private bool mIsBlock=true;         //是否支持分块

        public int RowNo;
        public DateTime StartTime;
        public bool mIsStop = false;
        public bool Finished = false;
        public string URLNew;

        public event EventHandler<long> OnDownloadSize;
        public bool Init(string pURL,string pDir,string pFileName="",int pThreadNum=3)
        {
            try
            {
                mIsStop = false;
                if (string.IsNullOrWhiteSpace(pFileName))
                {
                    pFileName = Uri.UnescapeDataString(Path.GetFileName(pURL));
                }
                this.URL = pURL;
                this.URLNew = pURL;
                if (!Directory.Exists(pDir))
                {
                    Directory.CreateDirectory(pDir);
                }
                if(pDir[pDir.Length-1]!='\\')
                    pDir+="\\";
                if (pFileName.Length == 0)
                {
                    throw new Exception("获取文件名失败");
                    //return false;
                }
                this.saveDir = pDir;
                this.saveFileName = pFileName;
                this.saveFile = Path.Combine(pDir, this.saveFileName);
                if (File.Exists(this.saveFile))
                {
                    this.saveFileName = CommonFunc.GetNewFileName(this.saveFile);
                    this.saveFile = Path.Combine(pDir, this.saveFileName);
                }
                if (pThreadNum <= 0)
                    pThreadNum = 1;
                
                if(pThreadNum>1)
                    GetHead(pURL, pThreadNum);
                if (mIsBlock == false)   //不支持分块
                    pThreadNum = 1;
                this.threads = new DownloadThread[pThreadNum];
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception(exception.Message);
                //return false;
            }
            
        }
        public bool Init(DownParam pdp)
        {
            try
            {
                mIsStop = false;
                string strFileName = pdp.FileName;
                string strDir = pdp.Dir;
                string strURL = pdp.URL;
                int iThreadNum = pdp.ThreadNum;
                if (string.IsNullOrWhiteSpace(strFileName))
                {
                    strFileName = Uri.UnescapeDataString(Path.GetFileName(strURL));
                }
                this.URL = strURL;
                this.URLNew = strURL;
                if (!Directory.Exists(strDir))
                {
                    Directory.CreateDirectory(strDir);
                }
                if (strDir[strDir.Length - 1] != '\\')
                    strDir += "\\";
                if (strFileName.Length == 0)
                {
                    throw new Exception("获取文件名失败");
                }
                this.saveDir = strDir;
                this.saveFileName = strFileName;
                this.saveFile = Path.Combine(strDir, this.saveFileName);
                string strext = Path.GetExtension(this.saveFile);
                if (File.Exists(this.saveFile))
                {
                    this.saveFileName = CommonFunc.GetNewFileName(this.saveFile);
                    this.saveFile = Path.Combine(strDir, this.saveFileName);
                }
                if (iThreadNum <= 0)
                    iThreadNum = 1;

                if (iThreadNum > 1 || string.IsNullOrWhiteSpace(strext) 
                    || ".aspx;.php;".IndexOf(strext, StringComparison.OrdinalIgnoreCase)>=0)
                    GetHead(strURL, iThreadNum);
                if (mIsBlock == false && iThreadNum>1)   //不支持分块
                    iThreadNum = 1;
                this.threads = new DownloadThread[iThreadNum];
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception(exception.Message);
                //return false;
            }
        }


        private void GetHead(string pURL,int pThreadnum)
        {
            try
            {
                bool issourceforge = pURL.IndexOf("sourceforge.net", StringComparison.OrdinalIgnoreCase) > 0;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pURL);
                request.Referer = Uri.EscapeUriString(pURL);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                //request.ContentType = "application/octet-stream";
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Timeout = 10000;
                request.AllowAutoRedirect = true;
                if(!issourceforge)
                    request.AddRange(0,9);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.PartialContent)
                    {
                        mIsBlock = true;
                        string strrange = "0";
                        if (response.Headers.AllKeys.Contains("Content-Range"))
                        {
                            strrange = response.Headers["Content-Range"].ToString();
                            strrange = strrange.Substring(strrange.IndexOf('/') + 1);
                        }
                        else if (response.Headers.AllKeys.Contains("Accept-Ranges"))
                        {
                            strrange = response.Headers["Accept-Ranges"].ToString();
                            strrange = strrange.Substring(strrange.IndexOf('/') + 1);
                        }
                        else
                        {
                            strrange = response.ContentLength.ToString();
                        }
                        
                        long lfilesize = 0;
                        if (Int64.TryParse(strrange,out lfilesize))
                        {
                            this.fileSize = lfilesize;
                        }
                        if (this.fileSize <= 0L)
                        {
                            throw new Exception("获取文件大小失败");
                        }
                    }
                    else if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("服务器返回状态失败,StatusCode:" + response.StatusCode);
                    }
                    else
                    {
                        if (!issourceforge)
                        {
                            mIsBlock = false;
                            pThreadnum = 1;
                            this.fileSize = response.ContentLength;
                            if (this.fileSize <= 0L)
                            {
                                throw new Exception("获取文件大小失败");
                            }
                        }
                        else
                        {
                            //获取文件内容里面定时运行网址
                            string strret=ResponseText(response);
                            string strpattern = "<meta http-equiv=\"refresh[\\s\\S]*?url=(.*?)\"";
                            Match match = Regex.Match(strret, strpattern);
                            
                            if (match.Groups.Count > 0)
                            {
                                string strurl = match.Groups[1].Value.Replace("&amp;", "&");
                                NewURL(strurl);
                                mIsBlock = false;
                                pThreadnum = 1;
                                this.fileSize = 0;
                            }
                        }
                    }
                    

                    if (this.URL != response.ResponseUri.AbsoluteUri)
                    {
                        NewURL(response.ResponseUri.AbsoluteUri);
                    }
                    if (pThreadnum > 1 && this.fileSize>0)
                        this.BlockSize = ((this.fileSize % ((long)pThreadnum)) == 0L) ? (this.fileSize / ((long)pThreadnum)) : ((this.fileSize / ((long)pThreadnum)) + 1L);
                    else
                        this.BlockSize = 0;
                }
            }
            catch (WebException wex)
            {
                Console.WriteLine(wex.Message);
                throw new Exception(wex.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception(exception.Message);
            }
        }

        private void NewURL(string pURL)
        {
            this.URLNew = pURL;
            string strFileName = Uri.UnescapeDataString(Path.GetFileName(this.URLNew));
            if (strFileName.IndexOf("?") > 0)
            {
                strFileName = strFileName.Substring(0, strFileName.IndexOf("?"));
            }
            string regexSearch = new string(Path.GetInvalidFileNameChars());
            //检测文件名是否有效
            if (!Regex.IsMatch(strFileName, string.Format("[{0}]", Regex.Escape(regexSearch))))
            {
                this.saveFileName = strFileName;
                this.saveFile = Path.Combine(this.saveDir, this.saveFileName);
            }
            if (File.Exists(this.saveFile))
            {
                this.saveFileName = CommonFunc.GetNewFileName(this.saveFile);
                this.saveFile = Path.Combine(this.saveDir, this.saveFileName);
            }
        }

        private static string ResponseText(HttpWebResponse response)
        {
            string text;
            Encoding encode = Encoding.UTF8;
            if (response.CharacterSet != null)
            {
                if (response.CharacterSet.ToLower().Contains("gb2312"))
                    encode = Encoding.Unicode;
                else if (response.CharacterSet.ToLower().Contains("big5"))
                    encode = Encoding.BigEndianUnicode;
                else if (response.CharacterSet.ToLower().Contains("gbk"))
                    encode = Encoding.GetEncoding(54936);   //"GB18030"
            }


            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, encode))
                    {
                        text = reader.ReadToEnd();
                    }
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, encode))
                    {
                        text = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {

                    using (StreamReader reader = new StreamReader(stream, encode))
                    {
                        text = reader.ReadToEnd();
                    }
                }
            }

            return text;
        }
        public void append(long size)
        {
            lock (this)
            {
                this.downloadSize += size;
            }
        }

        public void Stop()
        {
            mIsStop = true;
            if (threads != null)
            {
                for (int i = threads.Length - 1; i >= 0; i--)
                {
                    try
                    {
                        if (threads[i] != null && threads[i].mThread != null && threads[i].mThread.ThreadState != ThreadState.Stopped
                                        && threads[i].mThread.ThreadState != ThreadState.Aborted)
                        {
                            threads[i].mThread.Abort();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            
        }

        public long getFileSize() =>
            this.fileSize;
        public string getURL() =>
            this.URL;

        public string getSaveFileName() =>
            this.saveFileName;

        public string getFullFileName() =>
            this.saveFile;
        public void SetFileSize(long size)
        {
            this.fileSize = size;
        }
        public int getThreadSize() =>
            this.threads.Length;

        public void update(int threadId, long pos)
        {
            if (this.DownProgress.ContainsKey(threadId))
            {
                this.DownProgress[threadId] = pos;
            }
            else
            {
                this.DownProgress.Add(threadId, pos);
            }
        }

        public void StartDown()
        {
            try
            {
                mIsStop = false;
                StartTime = DateTime.Now;
                int num;
                using (FileStream stream = new FileStream(this.saveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (this.fileSize > 0L)
                    {
                        stream.SetLength(this.fileSize);
                    }
                    stream.Close();
                }
                if (this.DownProgress.Count != this.threads.Length)
                {
                    DownProgress.Clear();
                    for (num = 0; num < this.threads.Length; num++)
                    {
                        this.DownProgress.Add(num + 1, 0L);
                    }
                }
                num = 0;
                while (num < this.threads.Length)
                {
                    long num2 = this.DownProgress[num + 1];
                    if (this.fileSize==0 || this.BlockSize==0 ||(num2 < this.BlockSize) && (this.downloadSize < this.fileSize))
                    {
                        this.threads[num] = new DownloadThread(this, this.URLNew, this.saveFile, this.BlockSize, this.DownProgress[num + 1], num + 1);
                        this.threads[num].ThreadRun();
                    }
                    else
                    {
                        this.threads[num] = null;
                    }
                    num++;
                }

                CommonFunc.CreateThread(CheckFinish);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                try
                {
                    if (File.Exists(this.saveFile))
                        File.Delete(this.saveFile);
                }
                catch (Exception)
                {
                }
                throw new Exception("下载文件失败"+ exception.Message);
            }
        }

        private void CheckFinish()
        {
            bool flag = true;
            while (flag && mIsStop==false)
            {
                flag = false;
                for (int num = 0; num < this.threads.Length; num++)
                {
                    if ((this.threads[num] != null) && !this.threads[num].isFinish())
                    {
                        flag = true;
                        if (this.threads[num].getDownLength() == -1L)
                        {
                            this.threads[num] = new DownloadThread(this, this.URLNew, this.saveFile, this.BlockSize, this.DownProgress[num + 1], num + 1);
                            this.threads[num].ThreadRun();
                        }
                    }
                }
                
                if (OnDownloadSize != null)
                {
                    this.Finished = !flag;
                    OnDownloadSize(this,this.downloadSize);
                    //Console.WriteLine(this.downloadSize);
                }
                Thread.Sleep(900);
            }

            if (mIsStop)
            {
                if (downloadSize < fileSize || downloadSize==0)
                {
                    try
                    {
                        if (File.Exists(saveFile))
                            File.Delete(saveFile);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
