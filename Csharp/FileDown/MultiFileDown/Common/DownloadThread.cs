using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public class DownloadThread
    {
        private string saveFilePath;
        private string downUrl;
        private long blocksize;
        private int threadId = -1;
        private long downLength;
        private bool finish = false;
        private FileDownLoader downloader;
        public Thread mThread = null;

        public DownloadThread(FileDownLoader downloader, string downUrl, string saveFile, long blocksize, long downLength, int threadId)
        {
            this.downUrl = downUrl;
            this.saveFilePath = saveFile;
            this.blocksize = blocksize;
            this.downloader = downloader;
            this.threadId = threadId;
            this.downLength = downLength;
        }

        public long getDownLength() =>
            this.downLength;

        public bool isFinish() =>
            this.finish;

        public void ThreadRun()
        {
            mThread = new Thread(delegate ()
            {
                if (this.downLength < this.blocksize || this.blocksize == 0)
                {
                    try
                    {
                        int from = 0;
                        if (this.blocksize > 0)
                            from = (int)((this.blocksize * (this.threadId - 1)) + this.downLength);
                        int to = (int)((this.blocksize * this.threadId) - 1L);
                        Console.WriteLine(string.Concat(new object[] { "Thread ", this.threadId, " start download from position ", from, "  and endwith ", to }));
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.downUrl);
                        request.Referer = Uri.EscapeUriString(this.downUrl);
                        request.Method = "GET";
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                        //request.AllowAutoRedirect = false;
                        request.ContentType = "application/octet-stream";
                        request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                        request.Timeout = 0x2710;
                        request.AllowAutoRedirect = true;
                        if (this.blocksize > 0)
                            request.AddRange(from, to);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        using (Stream stream = response.GetResponseStream())
                        {
                            byte[] buffer = new byte[0xc800];
                            long size = -1L;
                            using (Stream stream2 = new FileStream(this.saveFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                if (this.blocksize == 0 && this.downloader.getFileSize() == 0)
                                    this.downloader.SetFileSize(response.ContentLength);
                                stream2.Seek((long)from, SeekOrigin.Begin);
                                while ((size = stream.Read(buffer, 0, buffer.Length)) != 0L)
                                {
                                    this.downloader.append(size);
                                    stream2.Write(buffer, 0, (int)size);
                                    this.downLength += size;
                                    this.downloader.update(this.threadId, this.downLength);
                                    if (this.downloader.mIsStop)  //停止
                                        break;
                                }
                                stream2.Close();
                                stream.Close();
                                Console.WriteLine("Thread " + this.threadId + " download finish");
                                this.finish = true;
                            }
                        }
                    }
                    catch (WebException wex)
                    {
                        string strErr = "";
                        HttpWebResponse response = (HttpWebResponse)wex.Response;
                        //Console.WriteLine("Error code: {0}", response.StatusCode);
                        if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            strErr = ResponseText(response);
                        }
                        else
                        {
                            strErr = wex.Message;
                            //this.finish = true;
                        }
                            
                        try
                        {
                            if (File.Exists(this.saveFilePath))
                                File.Delete(this.saveFilePath);
                        }
                        catch (Exception)
                        {
                        }
                        this.downLength = -1L;
                        Console.WriteLine(string.Concat(new object[] { "Thread ", this.threadId, ":", strErr }));
                    }
                    catch (Exception exception)
                    {
                        try
                        {
                            if (File.Exists(this.saveFilePath))
                                File.Delete(this.saveFilePath);
                        }
                        catch (Exception)
                        {
                        }
                        //this.finish = true;
                        this.downLength = -1L;
                        Console.WriteLine(string.Concat(new object[] { "Thread ", this.threadId, ":", exception.Message }));
                    }
                    
                }
            })
            { IsBackground = true };
            mThread.Start();
        }
        private string ResponseText(HttpWebResponse response)
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
    }
}
