using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个脚本挂在摄像机上才能正确运行
/// </summary>
[RequireComponent(typeof(Camera))]
public class OverDrawModel : MonoBehaviour
{

    public Shader m_OverdrawShader;

    private Camera m_Camera;
    private bool m_SceneFogSettings = false;
    private CameraClearFlags m_ClearFlagSetting;
    private Color m_BackGroundColor;
    void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }
    void OnEnable()
    {

            if (m_OverdrawShader != null && m_Camera != null)
            {
                RenderSettings.fog = false;
                m_Camera.clearFlags = CameraClearFlags.Skybox;
                m_Camera.backgroundColor = Color.black;
                m_Camera.SetReplacementShader(m_OverdrawShader, "");
            } 
    }

    void OnDisable()
    {
        if (m_Camera != null)
        {
            RestoreParam();
        }
    }

    void RestoreParam()
    {
        RenderSettings.fog = m_SceneFogSettings;
        //m_Camera.SetReplacementShader(null, ""); //和下面效果相同
        m_Camera.ResetReplacementShader();
        m_Camera.backgroundColor = m_BackGroundColor;
        m_Camera.clearFlags = CameraClearFlags.Skybox;
    }

 
}