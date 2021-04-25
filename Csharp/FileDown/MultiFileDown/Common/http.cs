using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Data;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace MultiFileDown.Common
{
    public class http
    {
        public CookieContainer container = new CookieContainer(); //存储验证码cookie
        public string mCookie = "";
        private Dictionary<string, string> mcookieDic = new Dictionary<string, string>();
        public string agentip = "";    //http://127.0.0.1:1080

        public Dictionary<string, string> GetDicCookie()
        {
            return mcookieDic;
        }
        public string GetCookie()
        {
            //Uri uri = new Uri(purl);
            //return container.GetCookieHeader(uri); 
            return mCookie;
        }

        public void SetCookie(string purl,string pcookie)
        {
            Uri uri = new Uri(purl);
            string[] cookstr = pcookie.Split(";".ToCharArray());
            string pattern = @"(?<key>\w+?)\s*=\s*(?<value>.+)";
            foreach (string str in cookstr)
            {
                //string[] cookieNameValue = str.Split('=');
                Match mc1 = Regex.Match(str, pattern);
                if (mc1.Groups.Count > 1)
                {
                    string strkey = mc1.Groups["key"].Value.Trim();
                    string strvalue = mc1.Groups["value"].Value.Trim();
                    if (mcookieDic.ContainsKey(strkey))
                    {
                        mcookieDic[strkey] = strvalue;
                    }
                    else
                    {
                        mcookieDic.Add(strkey, strvalue);
                    }
                    Cookie ck = new Cookie(strkey, strvalue);
                    ck.Domain = uri.Host.Replace("www.", "");//必须写对 
                    container.Add(ck);
                }
                
            }
            //container.SetCookies(uri, pcookie);
        }
        public string gethtml(string url,out ResultState resno)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.AllowAutoRedirect = true;
                if (!string.IsNullOrWhiteSpace(agentip))
                {
                    WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                    proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                    request.Proxy = proxy;
                }
                
                request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                //request.KeepAlive = true;//建立持久性连接
                
                //响应
                //response = (HttpWebResponse)request.GetResponse();
                
                //container = request.CookieContainer; //保存cookies
                //strCookies = request.CookieContainer.GetCookieHeader(request.RequestUri); //把cookies转换成字符串

                string text = string.Empty;
                //using (Stream responseStm = response.GetResponseStream())
                //{
                //    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                //    text = redStm.ReadToEnd();
                //}
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    //container.Add(response.Cookies);
                    //response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                    //string cookieHeader = request.CookieContainer.GetCookieHeader(request.Address);
                    text =ResponseText(response);
                    //string cookie = response.Headers.Get("Set-cookie");
                    //container.Add(response.Cookies);
                    CookieString(response);
                }
                resno = ResultState.OK;
                return text;
            }
            catch (WebException wex)
            {
                resno = ResultState.Error;
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;
            }
            catch (Exception ex)
            {
                resno = ResultState.Error;
                string msg = ex.Message;
                return msg;
            }
        }

        private void CookieString(HttpWebResponse response)
        {

            for (int i = 0; i < response.Cookies.Count; i++)
            {
                string strkey = response.Cookies[i].Name;
                if (mcookieDic.ContainsKey(strkey))
                {
                    mcookieDic[strkey] = response.Cookies[i].Value;
                }
                else
                {
                    mcookieDic.Add(strkey, response.Cookies[i].Value);
                }
                //
            }
            genCookie();
        }

        private void genCookie()
        {
            mCookie = "";
            foreach (KeyValuePair<string, string> kv in mcookieDic)
            {
                mCookie += kv.Key + "=" + kv.Value + "; ";
            }
            mCookie = mCookie.Trim().Trim(';');
        }

        private string posthtml(string url, string data, string pcookie, out string cookie)
        {
            string strret = "";
            string uri = url;
            HttpWebResponse response = null;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "POST";
            req.Timeout = 5000;
            req.Accept = "*/*";
            //req.Headers.Add(HttpRequestHeader.AcceptCharset , "*/*");
            req.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
            req.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Win64; x64; Trident/7.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
            req.ContentType = "application/x-www-form-urlencoded";
            if (!string.IsNullOrWhiteSpace(agentip))
            {
                WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                req.Proxy = proxy;
            }
            Uri uu = new Uri(url);
            req.Referer = uu.AbsoluteUri;
            //CookieContainer co = new CookieContainer();
            //co.SetCookies(uu, pcookie);
            req.CookieContainer = container;

            //req.AllowAutoRedirect = false;   //是否重定向
            byte[] bdata = Encoding.UTF8.GetBytes(data);
            req.ContentLength = bdata.Length;
            Stream outstream = req.GetRequestStream();
            outstream.Write(bdata, 0, bdata.Length);
            outstream.Close();
            cookie = "";
            try
            {
                response = (HttpWebResponse)req.GetResponse();
                container.Add(response.Cookies);
                strret = ResponseText(response);
                //cookie = response.Headers.Get("Set-cookie");
                return strret;
            }
            catch (WebException wex)
            {
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }

            
        }

        public string getjson(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.AllowAutoRedirect = true;
                if (!string.IsNullOrWhiteSpace(agentip))
                {
                    WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                    proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                    request.Proxy = proxy;
                }
                //request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                //request.KeepAlive = true;//建立持久性连接

                string text = string.Empty;
                response = (HttpWebResponse)request.GetResponse();
                text = ResponseText(response);
                return text;
            }
            catch (WebException wex)
            {
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }
        }

        public string postjson(string url, string data)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";  //"application/x-www-form-urlencoded; charset=UTF-8";   //
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.AllowAutoRedirect = true;
                request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                request.KeepAlive = true;//建立持久性连接
                if (!string.IsNullOrWhiteSpace(agentip))
                {
                    WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                    proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                    request.Proxy = proxy;
                }
                //整数据
                string postData = data;
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostData = encoding.GetBytes(postData);
                request.ContentLength = bytepostData.Length;

                //发送数据  using结束代码段释放
                using (Stream requestStm = request.GetRequestStream())
                {
                    requestStm.Write(bytepostData, 0, bytepostData.Length);
                }
                string text = string.Empty;

                response = (HttpWebResponse)request.GetResponse();
                text = ResponseText(response);
                return text;
            }
            catch (WebException wex)
            {
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return msg;
            }

        }

        public string getjsonFC(string url,string pAccesskey,string pSignature,string pTimeStamp)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Add("FC-ACCESS-KEY", pAccesskey);
                request.Headers.Add("FC-ACCESS-SIGNATURE", pSignature);
                request.Headers.Add("FC-ACCESS-TIMESTAMP", pTimeStamp);
                request.AllowAutoRedirect = true;
                if (!string.IsNullOrWhiteSpace(agentip))
                {
                    WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                    proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                    request.Proxy = proxy;
                }
                //request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                //request.KeepAlive = true;//建立持久性连接

                string text = string.Empty;
                //响应
                //response = (HttpWebResponse)request.GetResponse();
                //using (Stream responseStm = response.GetResponseStream())
                //{
                //    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                //    text = redStm.ReadToEnd();
                //}

                response = (HttpWebResponse)request.GetResponse();
                text = ResponseText(response);
                return text;
            }
            catch (WebException wex)
            {
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }
        }

        public string postjsonFC(string url, string data, string pAccesskey, string pSignature, string pTimeStamp)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";  //"application/x-www-form-urlencoded; charset=UTF-8";   //
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Add("FC-ACCESS-KEY", pAccesskey);
                request.Headers.Add("FC-ACCESS-SIGNATURE", pSignature);
                request.Headers.Add("FC-ACCESS-TIMESTAMP", pTimeStamp);
                request.AllowAutoRedirect = true;
                request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                request.KeepAlive = true;//建立持久性连接
                if (!string.IsNullOrWhiteSpace(agentip))
                {
                    WebProxy proxy = new WebProxy();                                      //定義一個網關對象
                    proxy.Address = new Uri(agentip);    //"http://proxy.domain.com:3128"          //網關服務器:端口
                    request.Proxy = proxy;
                }
                //整数据
                string postData = data;
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostData = encoding.GetBytes(postData);
                request.ContentLength = bytepostData.Length;

                //发送数据  using结束代码段释放
                using (Stream requestStm = request.GetRequestStream())
                {
                    requestStm.Write(bytepostData, 0, bytepostData.Length);
                }
                string text = string.Empty;

                //响应
                //response = (HttpWebResponse)request.GetResponse();
                //using (Stream responseStm = response.GetResponseStream())
                //{
                //    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                //    text = redStm.ReadToEnd();
                //}
                response = (HttpWebResponse)request.GetResponse();
                text = ResponseText(response);
                //cookie = res.Headers.Get("Set-cookie");
                return text;
            }
            catch(WebException wex)
            {
                response = (HttpWebResponse)wex.Response;
                //Console.WriteLine("Error code: {0}", response.StatusCode);
                if (response!=null && response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return ResponseText(response);
                }
                else
                    return wex.Message;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return msg;
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
    }
}
