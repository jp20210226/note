using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public  void Shot()
    {
        RenderTexture rt = new RenderTexture(Screen.height, Screen.height, 0);
        Camera.main.targetTexture = rt;
        RenderTexture.active = rt;
        Camera.main.Render();
        Texture2D screenShot = new Texture2D(Screen.height, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.height, Screen.height), 0, 0);
        screenShot.Apply();
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename =Application.streamingAssetsPath+"1.png";
        File.WriteAllBytes(filename, bytes);
    }
}
