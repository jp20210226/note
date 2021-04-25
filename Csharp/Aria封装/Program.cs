using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Aria封装
{
    public class JsonClass
    {
        public string _jsonrpc { get; set; }
        public string _id { get; set; }
        public string _method { get; set; }
        public List<string> _params { get; set; }
        public int _offsetIni { get; set; }
        public int _offset { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Aria a = new Aria();//1abb65666048a5fd ,"gid", "completedLength"
            string json = httpWebRequest(@"http://127.0.0.1:4399/jsonrpc", a.AriaJson_getFiles("1abb65666048a5fd"));
            //webreq(tellStopped());"002f90567a3d5316"
            Console.WriteLine(json);
        }

        public static string httpWebRequest(string serverUrl,string json_body)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(serverUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000;
                byte[] btBodys = Encoding.UTF8.GetBytes(json_body);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();
                return responseContent;
            }
            catch
            {
                return "请求失败";
            }
        }
    }
    public class Aria 
    {
        /// <summary>
        /// 添加下载链接
        /// </summary>
        /// <param name="file_url"></param>
        /// <returns></returns>
        public string AriaJson_addUri(string file_url)
        {
            JsonClass _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = DateTime.Now.ToString();
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.addUri";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(file_url);
            _jsonClass._params = paramslist;
            //"jsonrpc":"2.0","id":"2021/4/13 10:04:56","method":"aria2.addUri","params":["token:ntrj",["http://10.11.52.93:8098/static/javaZipFile/18d9b8b4-8af1-4e2b-bf07-e0d1a2c02155.7z"]]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 删除任务，强制删除请使用ForceRemove方法
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_remove(string gid)
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.remove";
            List<string> paramslist = new List<string>();
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.remove","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }
        /// <summary>
        /// 强制删除
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_forceRemove(string gid)
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.forceRemove";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.forceRemove","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 暂停下载,强制暂停请使用ForcePause方法
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_pause(string gid)
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.pause";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.pause","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 暂停全部任务
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_pauseAll()
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.pauseAll";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add("");
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.pauseAll","params":["token:ntrj"]}
            return ToJson(_jsonClass);
        }
        /// <summary>
        /// 关闭aria2
        /// </summary>
        /// <returns></returns>
        public string AriaJson_shutdown()
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.shutdown";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add("");
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.shutdown","params":["token:ntrj"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 强制暂停指定任务下载
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_forcePause(string gid)
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.forcePause";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.forcePause","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 强制暂停全部下载
        /// </summary>
        /// <returns></returns>
        public string AriaJson_forcePauseAll()
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.forcePauseAll";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add("");
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.forcePauseAll","params":["token:ntrj"]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 把暂停指定任务状态改为等待下载
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_unpause(string gid)
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.unpause";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.unpause","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 把全部暂停的任务状态改为等待下载
        /// </summary>
        /// <returns></returns>
        public string AriaJson_unpauseAll()
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.unpauseAll";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add("");
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.unpauseAll","params":["token:ntrj"]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 返回单个任务下载状态,，返回可选参数：gid,bitfield,completedLength,connections,dir,downloadSpeed,files,numPieces,pieceLength,status,totalLength,uploadLength,uploadSpeed
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <param name="pa">返回可选参数</param>
        /// <returns></returns>
        public string AriaJson_tellStatus(string gid, params string[] pa)
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.tellStatus";
            List<string> paramslist = new List<string>();
            paramslist.Add(gid);
            if (pa.Length > 0)
            {
                foreach (string p in pa)
                {
                    paramslist.Add(p);
                }

            }
            _jsonClass._params = paramslist;
            //{"jsonrpc":"2.0","id":"qwer","method":"aria2.tellStatus","params":["token:ntrj","04552343df764b53",["gid","completedLength"]]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 返回全局统计信息，例如整体下载和上载速度
        /// </summary>
        /// <returns></returns>
        public string AriaJson_getGlobalStat()
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.getGlobalStat";
            List<string> paramslist = new List<string>();
            //添加下载地址
            //paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{"jsonrpc":"2.0","id":"qwer","method":"aria2.getGlobalStat","params":["token:ntrj"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 返回由gid（字符串）表示的下载中使用的URI 。响应是一个结构数组
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_getUris(string gid)
        {

            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.getUris";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.getUris","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 返回由gid（字符串）表示的下载文件列表
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_getFiles(string gid)
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.getFiles";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.getFiles","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 返回由gid（字符串）表示当前链接下载的服务器
        /// </summary>
        /// <param name="gid">下载任务ID</param>
        /// <returns></returns>
        public string AriaJson_getServers(string gid)
        {
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.getServers";
            List<string> paramslist = new List<string>();
            //添加下载地址
            paramslist.Add(gid);
            _jsonClass._params = paramslist;
            //{ "jsonrpc":"2.0","id":"qwer","method":"aria2.getServers","params":["token:ntrj","515921d982b2f766"]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 取得全部活跃状态的任务，返回可选参数：gid,bitfield,completedLength,connections,dir,downloadSpeed,files,numPieces,pieceLength,status,totalLength,uploadLength,uploadSpeed
        /// </summary>
        /// <param name="pa">返回的参数列表</param>
        /// <returns></returns>
        public string AriaJson_tellActive(params string[] pa)
        {
            
            string str = string.Empty;
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.tellActive";
            List<string> paramslist = new List<string>();
            
            foreach (string p in pa)
            {
                paramslist.Add(p);
            }
            _jsonClass._params = paramslist;
            //{"jsonrpc":"2.0", "id":"qwer","method":"aria2.tellActive","params":["token:ntrj",["completedLength","gid"]]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// 返回已停止下载的列表,返回可选参数：gid,bitfield,completedLength,connections,dir,downloadSpeed,files,numPieces,pieceLength,status,totalLength,uploadLength,uploadSpeed
        /// </summary>
        /// <param name="pa">返回的参数列表</param>
        /// <returns></returns>
        public string AriaJson_tellStopped(int offsetIni,int offset,params string[] pa)
        {
            string str = string.Empty;
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.tellStopped";
            _jsonClass._offsetIni = offsetIni;
            _jsonClass._offset = offset;
            List<string> paramslist = new List<string>();
            //paramslist.Add("1000");
            //添加下载地址
            if (pa.Length > 0)
            {
                foreach (string p in pa)
                {
                    paramslist.Add(p);
                }
                
            }
            _jsonClass._params = paramslist;
            //{"jsonrpc":"2.0","method":"aria2.tellStopped","id":"QXJpYU5nXzE2MTc4Njc0ODlfMC44NDk1Nzc5OTQ2NDA0NTYy","params":["token:ntrj",-1,1000,["gid","totalLength","completedLength","uploadSpeed","downloadSpeed","connections","numSeeders","seeder","status","errorCode","files","bittorrent"]]}
            return ToJson(_jsonClass);
        }

        /// <summary>
        /// 返回已暂停下载的列表,返回可选参数：gid,bitfield,completedLength,connections,dir,downloadSpeed,files,numPieces,pieceLength,status,totalLength,uploadLength,uploadSpeed
        /// </summary>
        /// <param name="pa">返回的参数列表</param>
        /// <returns></returns>
        public string AriaJson_tellWaiting(int offsetIni, int offset, params string[] pa)
        {
            string str = string.Empty;
            var _jsonClass = new JsonClass();
            _jsonClass._jsonrpc = "2.0";
            _jsonClass._id = DateTime.Now.ToString();
            _jsonClass._method = "aria2.tellWaiting";
            _jsonClass._offsetIni = offsetIni;
            _jsonClass._offset = offset;
            List<string> paramslist = new List<string>();
            //paramslist.Add("1000");
            //添加下载地址
            if (pa.Length > 0)
            {
                foreach (string p in pa)
                {
                    paramslist.Add(p);
                }

            }
            _jsonClass._params = paramslist;
            //{"jsonrpc":"2.0","method":"aria2.tellWaiting","id":"QXJpYU5nXzE2MTc4Njc0ODlfMC44NDk1Nzc5OTQ2NDA0NTYy","params":["token:ntrj",-1,1000,["gid","totalLength","completedLength","uploadSpeed","downloadSpeed","connections","numSeeders","seeder","status","errorCode","files","bittorrent"]]}
            return ToJson(_jsonClass);
        }


        /// <summary>
        /// JsonClass转换为PostJson，仅aria类内部用
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static string ToJson(JsonClass json)
        {
            string str = "";
           
            str = "{" + "\"jsonrpc\":\"" + json._jsonrpc + "\",\"id\":\"" + json._id + "\",\"method\":\"" + json._method + "\",\"params\":[\"token:ntrj\"";
            if (json._params.Count > 0)
            {
                str += ",";
            }

            if (json._method == "aria2.tellStopped"|| json._method == "aria2.tellWaiting")
            {
                if (json._params.Count > 0)//有其他参数
                { str +=  json._offsetIni + "," + json._offset+ ","; }
                else//无其他参数
                { str += "," + json._offsetIni + "," + json._offset; }
            }

            for (int i = 0; i < json._params.Count; i++)
            {
                if (json._method == "aria2.addUri")
                {
                    str += "[\"" + json._params[i] + "\"]";
                }
                else if (json._method == "aria2.tellStatus")
                {
                    if (i == 0)
                    {
                        str += "\"" + json._params[i] + "\"";
                    }
                    else if(i == 1)
                    {
                        if (json._params.Count > 1)
                        {
                            str += "[\"" + json._params[i] + "\"";
                        }
                        else
                        {
                            str += "[\"" + json._params[i] + "\"]";
                        }
                    }
                    else if (json._params.Count - 1 == i)
                    {
                        str += "\"" + json._params[i] + "\"]";
                    }
                    else
                    {
                        str += "\"" + json._params[i] + "\"";
                    }
                }

                else if(json._method == "aria2.tellActive"|| json._method == "aria2.tellStopped" || json._method == "aria2.tellWaiting")
                {
                    if (i == 0)
                    {
                        if(json._params.Count >1)
                        {
                            str += "[\"" + json._params[i] + "\"";
                        }
                        else
                        {
                            str += "[\"" + json._params[i] + "\"]";
                        }
                        
                    }
                    else if(json._params.Count-1 ==i)
                    {
                        str += "\"" + json._params[i] + "\"]";
                    }
                    else
                    {
                        str += "\"" + json._params[i] + "\"";
                    }
                }
                else
                {
                    str += "\"" + json._params[i] + "\"";
                }
                if (json._params.Count - 1 > i)
                {
                    str += ",";
                }
            }
            str += "]}";
            //最后得到类似
            //{"jsonrpc":"2.0","id":"qwer","method":"aria2.addUri","params:"[["http://www.baidu.com"]]}
            return str;
        }

       
    }
}
