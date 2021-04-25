using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class Down : MonoBehaviour
{
    string path;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    public void DownData()
    {
       List<string> url = new List<string>();
        path = Application.streamingAssetsPath + "/AssetBundleFolder";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        StartCoroutine(down7zData());
       
    }

    IEnumerator  down7zData()
    {
        using (UnityWebRequest web = UnityWebRequest.Get("http://10.11.52.93:8098/static/a0a8963c-1490-4d94-be55-a5a3261104e5\\AB_Catalyst_6500_E(14U).7z"))
        {
            
            yield return web.SendWebRequest();
            byte[] data = web.downloadHandler.data;
            using (FileStream fl = new FileStream(path + "/AB_Catalyst_6500_E(14U).7z", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fl.Write(data, 0, data.Length);
            }
        }
    }
}
