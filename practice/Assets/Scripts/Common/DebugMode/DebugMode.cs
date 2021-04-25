using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{
    private List<Button> AllBtn = new List<Button>();
    public SceneName CurScene;

    #region Debug信息
    private List<string> m_logEntries = new List<string>();
    private List<string> m_logWarning = new List<string>();
    private List<string> m_logLog = new List<string>();
    private bool m_IsVisible = false;
    private bool m_IsSystem = false;
    private Rect WindowDebugRect = new Rect(0, 0, Screen.width, Screen.height);
    private Rect WindowSystemRect = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
    private Vector2 m_scrollPositionText = Vector2.zero;
    private string InputKeyBoard = null;
    private GameObject DebugPanel;
    #endregion

    public static bool IsClick = false;
    private void Start()
    {
        Application.logMessageReceived += (string condition, string stackTrace, LogType type) =>
        {
            if (type == LogType.Exception || type == LogType.Error)
            {
                m_logEntries.Add(string.Format("{0}\n{1}", condition, stackTrace));
            }
            else if (type == LogType.Warning)
            {
                m_logWarning.Add(string.Format("{0}\n{1}", condition, stackTrace));
            }
            else if (type == LogType.Log)
            {
                m_logLog.Add(string.Format("{0}\n{1}", condition, stackTrace));
            }

        };
        switch (CurScene)
        {
            case SceneName.YuanQu:
                DebugPanel = GameObject.Find("PopupParent").transform.Find("DebugPanel").gameObject;
                foreach (var item in DebugPanel.transform.Find("BtnParent").GetComponentsInChildren<Button>())
                {
                    AllBtn.Add(item);
                    item.gameObject.AddComponent<DebugModeHelper>();
                }
                AllBtn[0].onClick.AddListener(ShowDebugError);
                AllBtn[2].onClick.AddListener(ShowOverDrawYQ);
                break;
            case SceneName.JiFang:
                DebugPanel = GameObject.Find("PopupParent").transform.Find("DebugPanel").gameObject;
                foreach (var item in DebugPanel.transform.Find("BtnParent").GetComponentsInChildren<Button>())
                {
                    AllBtn.Add(item);
                    item.gameObject.AddComponent<DebugModeHelper>();
                }
                AllBtn[0].onClick.AddListener(ShowDebugError);
                AllBtn[3].onClick.AddListener(ShowSystemInfo);
                AllBtn[4].onClick.AddListener(ShowEditLeftMenu);
                AllBtn[5].onClick.AddListener(ShowOverDraw);

                break;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            InputKeyBoard = null;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                InputKeyBoard += "g";
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                InputKeyBoard += "o";
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                InputKeyBoard += "d";
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                InputKeyBoard += "m";
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                InputKeyBoard += "e";
            }
            if (InputKeyBoard == "godmode")
            {
                DebugPanel.SetActive(true);
                DebugPanel.transform.SetParent(GameObject.Find("Canvas").transform);
                DebugPanel.transform.SetAsLastSibling();
            }
        }
    }

    private void ShowDebugError()
    {
        m_IsVisible = !m_IsVisible;
    }
  
    private void ShowSystemInfo()
    {
        m_IsSystem = !m_IsSystem;
    }

    private void ShowEditLeftMenu()
    {
        IsClick = !IsClick;
       GameObject ChangeLMenuPanel = GameObject.Find("PopupParent").transform.Find("ChangeLMenuPanel").gameObject;
        if (IsClick)
        {
            ChangeLMenuPanel.SetActive(true);
        }
        else
        {
            ChangeLMenuPanel.SetActive(false);
        }
    }

    private void ShowOverDraw()
    {
        Camera.main.transform.GetComponent<OverDrawModel>().enabled = !Camera.main.transform.GetComponent<OverDrawModel>().enabled;
    }

    private void ShowOverDrawYQ()
    {
        Camera.main.transform.Find("ViewCamera").GetComponent<OverDrawModel>().enabled = !Camera.main.transform.Find("ViewCamera").GetComponent<OverDrawModel>().enabled;
    }

    void ConsoleSystem(int windowID)
    {

        if (GUILayout.Button("Close", GUILayout.MaxWidth(500), GUILayout.MaxHeight(100)))
        {
            m_IsSystem = false;
        }
        m_scrollPositionText = GUILayout.BeginScrollView(m_scrollPositionText);
        string platform = "    运行平台:   " + Application.platform.ToString();
        string InstalMode = "    应用安装方式:   " + Application.installMode.ToString();
        string internetReachability = "    网络连接方式:   " + Application.internetReachability.ToString();
        string targetFrameRate = "    目标帧率速度:   " + Application.targetFrameRate.ToString();
        string unityVersion = "    Unity3D版本:   " + Application.unityVersion;
        string version = "    应用程序版本:   " + Application.version;
        string backgroundLoadingPriority = "    后台加载线程优先级:   " + Application.backgroundLoadingPriority.ToString();
        string HasProLicense = "    是否激活Unity:   " + Application.HasProLicense().ToString();
        GUILayout.TextArea(platform, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(InstalMode, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(internetReachability, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(targetFrameRate, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(unityVersion, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(version, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(backgroundLoadingPriority, GUIStyle(Color.white), GUILayout.Height(100));
        GUILayout.TextArea(HasProLicense, GUIStyle(Color.white), GUILayout.Height(100));

        GUILayout.EndScrollView();
    }
    void ConsoleWindow(int windowID)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Clear", GUILayout.MaxWidth(500), GUILayout.MaxHeight(100)))
        {
            m_logEntries.Clear();
            m_logWarning.Clear();
            m_logLog.Clear();
        }
        if (GUILayout.Button("Close", GUILayout.MaxWidth(500), GUILayout.MaxHeight(100)))
        {
            m_IsVisible = false;
        }
        GUILayout.EndHorizontal();

        m_scrollPositionText = GUILayout.BeginScrollView(m_scrollPositionText);

        foreach (var entry in m_logEntries)
        {
            GUILayout.TextArea(entry, GUIStyle(Color.red), GUILayout.Height(200));
        }
        foreach (var entry in m_logWarning)
        {
            GUILayout.TextArea(entry, GUIStyle(Color.yellow), GUILayout.Height(200));
        }
        foreach (var entry in m_logLog)
        {
            
            GUILayout.TextArea(entry, GUIStyle(Color.white), GUILayout.Height(200));
        }
        GUILayout.EndScrollView();
        
    }

    public GUIStyle GUIStyle(Color WordCol)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = WordCol;
        style.normal.background = null /*Resources.Load<Texture2D>("Debug/debug底图")*/;
        return style;
    }
    private void OnGUI()
    {
        if (m_IsVisible)
        {
            WindowDebugRect = GUILayout.Window(0, WindowDebugRect, ConsoleWindow, "Console");
        }
        else if (m_IsSystem)
        {
            WindowSystemRect = GUILayout.Window(0, WindowSystemRect, ConsoleSystem, "SystemInfo");
        }
    }


}



