using DG.Tweening;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PresuppositionView : MonoBehaviour
{
    [SerializeField]
    private SceneName CurScene = SceneName.YuanQu;
    private Camera ViewCamera;
    private Camera MainCamera;
    private Transform ButtonParent;
    private Transform GodParent;
    private GameObject ButtonPrefab;
    private string ViewConfig;
    private string ImagePath;
    private InputField SaveViewName;
    private Button AddButton;
    private Button DelButton;
    private List<ViewData> ViewList = new List<ViewData>();
    private Dictionary<string, ViewData> ViewNameDic = new Dictionary<string, ViewData>();


    private void Awake()
    {
        ButtonPrefab = Resources.Load("AssetDatabase/ViewButton") as GameObject;
        switch (CurScene)
        {
            case SceneName.YuanQu:
                MainCamera = Camera.main;
                ViewCamera = MainCamera.transform.Find("ViewCamera").GetComponent<Camera>();
                ButtonParent = GameObject.Find("Canvas").transform.Find("ButtonParent");
                ViewConfig = Application.streamingAssetsPath + "/YuanQuViewConfig.json";
                ImagePath = Application.streamingAssetsPath + "/YuanQuViewList/";
                GodParent = GameObject.Find("PopupParent").transform.Find("ViewBoardPanel");
                break;
            case SceneName.JiFang:
                MainCamera = Camera.main;
                ViewCamera = MainCamera.transform.Find("ViewCamera").GetComponent<Camera>();
                ButtonParent = GameObject.Find("PresuppositionView_Panel").transform.Find("Scroll View/Viewport/ButtonParent");
                ViewConfig = Application.streamingAssetsPath + "/JiFangViewConfig.json";
                ImagePath = Application.streamingAssetsPath + "/JiFangViewList/";
                GodParent = GameObject.Find("PopupParent").transform.Find("ViewBoardPanel");
                break;
            default:
                break;
        }
        ReadView();
        SaveViewName = GodParent.transform.Find("InputField").GetComponent<InputField>();
        AddButton = GodParent.transform.Find("Btn1").GetComponent<Button>();
        DelButton = GodParent.transform.Find("Btn2").GetComponent<Button>();
        AddButton.onClick.AddListener(AddView);
        DelButton.onClick.AddListener(DelView);
    }

    private void ReadView()
    {
        ViewList.Clear();
        ViewNameDic.Clear();
        for (int i = 0; i < ButtonParent.childCount; i++)
        {
            Destroy(ButtonParent.GetChild(i));
        }
        string str = File.ReadAllText(ViewConfig);
        JsonData jd = JsonMapper.ToObject(str)["ViewList"];
        for (int i = 0; i < jd.Count; i++)
        {
            ViewData viewData = new ViewData();
            viewData.ViewName = jd[i]["ViewName"].ToString();
            if (File.Exists(ImagePath + viewData.ViewName + ".png"))
            {
                viewData.Pos = new Vector3(float.Parse(jd[i]["ViewPosX"].ToString()),
                    float.Parse(jd[i]["ViewPosY"].ToString()), float.Parse(jd[i]["ViewPosZ"].ToString()));
                viewData.Rot = new Vector3(float.Parse(jd[i]["ViewRotX"].ToString()),
                    float.Parse(jd[i]["ViewRotY"].ToString()), float.Parse(jd[i]["ViewRotZ"].ToString()));
                GameObject obj = Instantiate(ButtonPrefab);
                obj.GetComponentInChildren<Text>().text = viewData.ViewName;
                obj.transform.SetParent(ButtonParent);
                obj.transform.localScale = Vector3.one;
                viewData.ViewImage = obj.transform.Find("ViewImage").GetComponent<RawImage>();
                StartCoroutine(GetImage(ImagePath + viewData.ViewName + ".png", viewData.ViewImage));
                viewData.ViewButton = obj.GetComponent<Button>();
                viewData.SetButton(MainCamera.gameObject);
                ViewList.Add(viewData);
                ViewNameDic.Add(viewData.ViewName, viewData);
            }
        }
        WriteView();
    }

    private void WriteView()
    {
        JsonWriter jsonWriter = new JsonWriter();
        jsonWriter.WriteObjectStart();
        jsonWriter.WritePropertyName("ViewList");
        jsonWriter.WriteArrayStart();
        for (int i = 0; i < ViewList.Count; i++)
        {
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("ViewName");
            jsonWriter.Write(ViewList[i].ViewName.ToString());
            jsonWriter.WritePropertyName("ViewPosX");
            jsonWriter.Write(ViewList[i].Pos.x.ToString());
            jsonWriter.WritePropertyName("ViewPosY");
            jsonWriter.Write(ViewList[i].Pos.y.ToString());
            jsonWriter.WritePropertyName("ViewPosZ");
            jsonWriter.Write(ViewList[i].Pos.z.ToString());
            jsonWriter.WritePropertyName("ViewRotX");
            jsonWriter.Write(ViewList[i].Rot.x.ToString());
            jsonWriter.WritePropertyName("ViewRotY");
            jsonWriter.Write(ViewList[i].Rot.y.ToString());
            jsonWriter.WritePropertyName("ViewRotZ");
            jsonWriter.Write(ViewList[i].Rot.z.ToString());
            jsonWriter.WriteObjectEnd();
        }
        jsonWriter.WriteArrayEnd();
        jsonWriter.WriteObjectEnd();
        File.WriteAllText(ViewConfig, jsonWriter.ToString());
    }

    private void AddView()
    {
        if (CurScene == SceneName.YuanQu && ViewNameDic.Count > 5)
        {
            Debug.Log("视角超过五个");
            return;
        }
        if (ViewNameDic.ContainsKey(SaveViewName.text))
        {
            Debug.Log("已有该视角");
            return;
        }
        ScreenShot();
        ViewData NewViewData = new ViewData();
        NewViewData.ViewName = SaveViewName.text;
        NewViewData.Pos = MainCamera.transform.localPosition;
        NewViewData.Rot = MainCamera.transform.localEulerAngles;
        GameObject obj = Instantiate(ButtonPrefab);
        obj.GetComponentInChildren<Text>().text = NewViewData.ViewName;
        obj.transform.parent = ButtonParent;
        obj.transform.localScale = Vector3.one;
        NewViewData.ViewImage = obj.transform.Find("ViewImage").GetComponent<RawImage>();
        NewViewData.ViewButton = obj.GetComponent<Button>();
        StartCoroutine(GetImage(ImagePath + NewViewData.ViewName + ".png", NewViewData.ViewImage));
        NewViewData.SetButton(MainCamera.gameObject);
        ViewList.Add(NewViewData);
        ViewNameDic.Add(NewViewData.ViewName, NewViewData);
        WriteView();
    }

    private void DelView()
    {
        if (!ViewNameDic.ContainsKey(SaveViewName.text))
        {
            Debug.Log("不含该视角");
            return;
        }
        if (ViewList.Count == 1)
        {
            Debug.Log("仅剩一个不能删除");
            return;
        }
        Destroy(ViewNameDic[SaveViewName.text].ViewImage.transform.parent.gameObject);
        ViewList.Remove(ViewNameDic[SaveViewName.text]);
        ViewNameDic.Remove(SaveViewName.text);
        File.Delete(ImagePath + SaveViewName.text + ".png");
        WriteView();
    }

    private void ScreenShot()
    {
        RenderTexture rt = new RenderTexture(Screen.height, Screen.height, 0);
        ViewCamera.targetTexture = rt;
        ViewCamera.Render();
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D(Screen.height, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.height, Screen.height), 0, 0);
        screenShot.Apply();
        ViewCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ImagePath + SaveViewName.text + ".png";
        File.WriteAllBytes(filename, bytes);
    }

    private IEnumerator GetImage(string url, RawImage rawImage)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        DownloadHandlerTexture tex = new DownloadHandlerTexture(true);
        webRequest.downloadHandler = tex;
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            rawImage.texture = tex.texture;
        }
    }
}

public enum SceneName
{
    YuanQu,
    JiFang
}

public class ViewData
{
    public string ViewName;
    public Vector3 Pos;
    public Vector3 Rot;
    public RawImage ViewImage;
    public Button ViewButton;

    public void SetButton(GameObject obj)
    {
        ViewButton.onClick.AddListener(delegate ()
        {
            obj.transform.localEulerAngles = Rot;
            obj.transform.localPosition = new Vector3(Pos.x, Pos.y - 10f, Pos.z - 10f);
            obj.transform.DOLocalMove(Pos, 0.5f);
        });
    }
}