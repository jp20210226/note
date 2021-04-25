using Assets.Scripts.GetResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System;
using System.ComponentModel;
using System.Net;
using Assets.datadown.GetResources;

public class LoadResources : MonoBehaviour
{
    string _ResourcesData;//模型管理下载链接
    ResourcesData _ResData;
    string Directorypath;//单个AB包文件夹路径
    string EncryptDataExtension = ".chena";  //加密了的文件扩展名 
    private List<Data> DataUrlPool = new List<Data>();//等待下载的列表
    private Dictionary<string, string> DownLoadGid = new Dictionary<string, string>();//下载资源对应Aria下载任务Gid
    TimeSpan ts;
    Stopwatch sw = new Stopwatch();
    Aria aria = new Aria();
    string WebRequestResult;
    string serverPath;//服务地址
    GlobalStatData gbstatu;//全局任务状态信息
    TellStopped Stopstatu;//已停止或已完成任务状态信息
    TellActive Activestatu;//活跃任务状态信息
    TellWaiting Waitingstatu;//暂停任务状态信息
    bool Iscompleted = true;//资源文件是否下载完成标志

    private void Start()
    {
         serverPath = "http://127.0.0.1:4399/jsonrpc";
        //sw.Start();
        //StartCoroutine(GetModelUrl());
        aria.Aria2Start();
        string a = aria.AriaJson_tellStatus("6c8860b7ca3a9900","status");
        UnityEngine.Debug.Log(a);
        WebRequestFromUnity(serverPath, a);
    }
    private void Update()
    {
        if (Iscompleted)
        {
            if (ts.TotalSeconds > 2)
            {
                if (IsDownloadcompleted())
                {
                    CheckErrorTask();
                    sw.Stop();
                    aria.killAria2cProcess();
                    Iscompleted = false;
                    MoveToABFolder();
                    Extract();
                }
                sw.Reset();
                sw.Start();
            }
            ts = sw.Elapsed;
        }
    }

    /// <summary>
    /// 解压7Z压缩包
    /// </summary>
    private void Extract()
    {
        try
        {
            DirectoryInfo downfolder = new DirectoryInfo(Application.streamingAssetsPath + @"/AssetBundleFolder");
            FileInfo[] downFiles = downfolder.GetFiles();
            foreach (var file in downFiles)
            {
                if (file.Name.Contains(".7z.meta"))
                {
                    //file.Delete();
                    continue;
                }
                else if (file.Name.Contains(".7z"))
                {
                    Extract7zData.DecompressFileToDirectory(file.FullName, Path.GetDirectoryName(file.FullName) + "\\" + Path.GetFileNameWithoutExtension(file.FullName), "1]]-*Z1+-/*0,1[*Z([Y(^1.-Z1[.*+*");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void MoveToABFolder()
    {
        try
        {
            DirectoryInfo downfolder = new DirectoryInfo(Application.streamingAssetsPath + @"\plugins\aria2\Download");

            FileInfo[] downFiles = downfolder.GetFiles();
            foreach (var file in downFiles)
            {
                if (file.Name.Contains(".meta"))
                {
                    file.Delete();
                    continue;
                }
                file.MoveTo(Application.streamingAssetsPath + @"/AssetBundleFolder/" + file.Name);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void CheckErrorTask()
    {
        try
        {
            Stopstatu = JsonMapper.ToObject<TellStopped>(WebRequestFromSys(serverPath, aria.AriaJson_tellStopped(0, 1000)));
            if (Stopstatu.result != null)
                foreach (var res in Stopstatu.result)
                {
                    //为错误任务
                    if (res.errorCode == "1")
                    {
                        #region 失败检查重下
                        //if (errorTaskList.ContainsKey(res.files[0].uris[0].uri))
                        //{
                        //    errorTaskList[res.files[0].uris[0].uri] = errorTaskList[res.files[0].uris[0].uri] + 1;
                        //}
                        //else
                        //{
                        //    errorTaskList.Add(res.files[0].uris[0].uri, 1);   
                        //}

                        //if (errorTaskList[res.files[0].uris[0].uri] > canErrorCount)
                        //{
                        //    UnityEngine.Debug.LogError($"重试{canErrorCount}次{res.files[0].uris[0].uri}仍下载失败，请检查网路及链接准确性");
                        //    WebRequestFromSys(serverPath, aria.AriaJson_remove(res.gid));

                        //    }
                        //else
                        //{
                        //    WebRequestFromSys(serverPath, aria.AriaJson_remove(res.gid));
                        //    StartCoroutine(WebRequestFromUnity(serverPath, aria.AriaJson_addUri(res.files[0].uris[0].uri)));
                        //}
                        #endregion
                        UnityEngine.Debug.Log($"下载任务{res.files[0].uris[0].uri}下载失败");
                    }
                    else if (res.errorCode == "0")
                    {
                        continue;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("下载任务出现未知错误");
                    }
                }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool IsDownloadcompleted()
    {
        try
        {


            int activeNum = -1;
            //结束条件：正在下载任务为空
            //Waitingstatu = JsonMapper.ToObject<TellWaiting>(WebRequestFromSys("http://127.0.0.1:4399/jsonrpc", aria.AriaJson_tellWaiting(0, 1000)));
            //Activestatu = JsonMapper.ToObject<TellActive>(WebRequestFromSys("http://127.0.0.1:4399/jsonrpc", aria.AriaJson_tellActive()));
            string gbStr = WebRequestFromSys(serverPath, aria.AriaJson_getGlobalStat());
            if (gbStr.Contains("请求失败"))
            {
                UnityEngine.Debug.Log("getGlobalStat请求失败");
                activeNum = -1;
            }
            else if (gbStr != null && gbStr != "" && gbStr.Contains("result"))
            {
                gbstatu = JsonMapper.ToObject<GlobalStatData>(gbStr);
                activeNum = Convert.ToInt32(gbstatu.result.numActive);
            }



            if (activeNum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <summary>
    /// 场景AB包文件下载
    /// </summary>
    public void DownLoadAsset()
    {
        if (_ResourcesData != "" && !string.IsNullOrEmpty(_ResourcesData))
        {
            _ResData = JsonMapper.ToObject<ResourcesData>(_ResourcesData);
        }
        if (_ResData != null)
        {
            foreach (Data data in _ResData.data)
            {
                Data da = data;
                //判断该资源在本地是否存在，并验证一致性
                if (CheckLocalAsset(da.model_id, da.md5))//如果存在且一致则跳过
                {
                    continue;
                }
                else//否则将下载链接传入资源池等待下载
                {
                    DataUrlPool.Add(da);
                }
            }

            if (DataUrlPool.Count != 0)
            {
                //打开Aria2下载引擎下载
                //打开Aria2服务
                aria.Aria2Start();
                foreach (var da in DataUrlPool)
                {
                    //提交下载请求
                    StartCoroutine(WebRequestFromUnity(serverPath, aria.AriaJson_addUri(da.file_url)));
                }

            }
        }
        else
        {
            UnityEngine.Debug.Log("ResourcesData获取失败");
        }
    }

    #region Http请求
    /// <summary>
    /// 系统自己http请求
    /// </summary>
    /// <param name="serverUrl"></param>
    /// <param name="json_body"></param>
    /// <returns></returns> 
    public static string WebRequestFromSys(string serverUrl, string json_body)
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
    /// <summary>
    /// UnityHttp请求
    /// </summary>
    /// <param name="AriaserverUrl"></param>
    /// <param name="json_body"></param>
    /// <returns></returns>
    IEnumerator WebRequestFromUnity(string AriaserverUrl, string json_body)
    {

        WebRequestResult = string.Empty;
        // string _Json = GetAddUriJson(_data);@"http://127.0.0.1:4399/jsonrpc"
        using (UnityWebRequest web = UnityWebRequest.Post(AriaserverUrl, json_body))
        {
            SetupPosta(web, json_body);
            yield return web.SendWebRequest();
            if (web.downloadHandler.text.Contains("\\\"code\\\":1,\\\""))
            {
                UnityEngine.Debug.Log("POST提交成功-LoadResources.down7zData但返回码异常：" + web.downloadHandler.text);
            }
            else if (web.isNetworkError || web.isHttpError)
            {
                UnityEngine.Debug.Log("POST提交失败-LoadResources.down7zData！错误码：" + web.error);
            }
            else
            {
                UnityEngine.Debug.Log("成功提交表单!-LoadResources.down7zData，内容：" + web.downloadHandler.text);
                WebRequestResult = web.downloadHandler.text;
            }
        }
    }
    /// <summary>
    /// UnityWebRequest源码，解决编码问题
    /// </summary>
    /// <param name="request">UnityWebRequest实例</param>
    /// <param name="postData">Post数据</param>
    private static void SetupPosta(UnityWebRequest request, string postData)
    {
        byte[] data = null;
        bool flag = !string.IsNullOrEmpty(postData);
        if (flag)
        {
            data = Encoding.UTF8.GetBytes(postData);
            //data = CodingHelper.StringToByte(postData, Encoding.UTF8);
        }
        request.uploadHandler = new UploadHandlerRaw(data);
        //request.uploadHandler.contentType = "application/x-www-form-urlencoded";
        request.downloadHandler = new DownloadHandlerBuffer();

    }
    #endregion

    /// <summary>
    /// 通过下载连接结果返回Gid
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public string GetUrlGid(string result)
    {
        JsonData jd_result = JsonMapper.ToObject(result);
        return jd_result["result"].ToString();
    }

    /// <summary>
    /// 检测本地是否存在该文件，本验证一致性,为True则包含该文件且验证文件和服务器文件无差别
    /// </summary>
    /// <param name="AssetId"></param>
    /// <param name="Hash128"></param>
    /// <returns></returns>
    public bool CheckLocalAsset(string AssetId, string MD5)
    {
        //EncryptData(Directorypath, files);加解密
        try
        {
            Directorypath = Application.streamingAssetsPath + "/AssetBundleFolder/" + AssetId;
            //文件夹不存在
            if (!Directory.Exists(Directorypath))
            {
                return false;
            }

            string VerificationFilePath = Directorypath + "/" + AssetId + ".ntrd.chena";

            if (!File.Exists(VerificationFilePath))
            {
                return false;
            }
            //文件存在且不校验
            if (MD5 == "不校验")
            {
                return true;
            }
            //下面直接找文件MD5，文件缺失或者被服务器修改，都直接删除文件夹重新下载
            string CalcMD5 = CreatMD5(VerificationFilePath);

            if (CalcMD5 == MD5)
            {
                return true;
            }
            else//与服务器校验码不一样，删除所有文件重新下载
            {
                Directory.Delete(Directorypath, true);
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算MD5值
    /// </summary>
    /// <param name="VerificationFilePath"></param>
    /// <returns></returns>
    public string CreatMD5(string VerificationFilePath)
    {
        try
        {
            using (FileStream file = new FileStream(VerificationFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] YourFile = md5.ComputeHash(file);
                file.Close();
                StringBuilder FileMD5 = new StringBuilder();
                for (int i = 0; i < YourFile.Length; i++)
                {
                    FileMD5.Append(YourFile[i].ToString("x2"));
                }
                return FileMD5.ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 对文件加解密
    /// </summary>
    /// <param name="Directorypath">被处理的文件夹</param>
    /// <param name="files">文件夹中的文件</param>
    public void EncryptData(string Directorypath, FileInfo[] files)
    {
        try
        {


            EncryptData de = new EncryptData();
            foreach (FileInfo file in files)
            {
                if (file.Name.Contains(".meta"))
                {
                    file.Delete();
                    continue;
                }
                if (file.Name.Contains(EncryptDataExtension))
                {
                    de.Encryption(Directorypath + "/" + file.Name);
                    string newName = file.Name.Replace(".chena", "");
                    file.MoveTo(Path.Combine(Directorypath + "/" + newName));
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 获取资源下载Url
    /// </summary>
    /// <returns></returns>
    IEnumerator GetModelUrl()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://10.11.52.93:8098/modelManagement/get3dFile"))
        {
            yield return req.SendWebRequest();
            if (req.downloadHandler.text.Contains("\\\"code\\\":0,\\\""))
            {
                UnityEngine.Debug.Log("POST提交成功-HttpTool.GetFileList但返回码异常：" + req.downloadHandler.text);
            }
            else if (req.isNetworkError || req.isHttpError)
            {
                UnityEngine.Debug.Log("POST提交失败-HttpTool.GetFileList！错误码：" + req.error);
            }
            else
            {
                _ResourcesData = req.downloadHandler.text;
                UnityEngine.Debug.Log("成功提交表单!-HttpTool.GetFileList");
                DownLoadAsset();
            }

        }

    }

    /// <summary>
    /// 获取全局下载状态
    /// </summary>
    /// <returns></returns>
    public string getGlobalStat()
    {

        string body = aria.AriaJson_getGlobalStat();
        return WebRequestFromSys(@"http://127.0.0.1:4399/jsonrpc", body);
    }

}

public class JsonClass
{
    public string _jsonrpc { get; set; }
    public string _id { get; set; }
    public string _method { get; set; }
    public List<string> _params { get; set; }
    public int _offsetIni { get; set; }
    public int _offset { get; set; }

}


