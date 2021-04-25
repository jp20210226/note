using Assets.post;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.Networking;
//using JinYiHelp.CodingHelp;
using System.Text;
using System;

public class post : MonoBehaviour
{
 
    static string savedata;
    static string oldData;
    public void loadOldData()
    {
        StartCoroutine(LoadJsonData());
    }
    IEnumerator LoadJsonData()
    {
        //WWWForm form = new WWWForm();
        //form.AddField("method", "readFileJson");
        //form.AddField("fileName", "Scene");
        using (UnityWebRequest www = UnityWebRequest.Get("http://10.11.15.177:18080/IDCV/queryProject?guid=1234567890"))
        {
            www.SetRequestHeader("Content-Type", " application/x-www-form-urlencoded;charset=UTF-8");
            yield return www.SendWebRequest();
            while (www.downloadHandler.text == "")
            {
            }
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("POST提交失败-HttpTool.ReadFile！错误码：" + www.error);
            }
            else
            {
                Debug.Log("成功提交表单!-HttpTool.ReadFile");
            }
            if (www.downloadHandler.text.Contains("\\\"code\\\":1,\\\""))
            {
                Debug.Log("POST提交成功-HttpTool.ReadFile：" + www.downloadHandler.text);
            }
            oldData = www.downloadHandler.text;
            Debug.Log(oldData);
        }

    }
    public void Transform()
    {

        old.Lab o_lab = new old.Lab();
        o_lab = JsonMapper.ToObject<old.Lab>(oldData);

        Lab lab = new Lab();
        lab.lab_jcomp =new List<JComp>();
        Scene scene = new Scene();
        scene.GUID = o_lab.lab_project.guid;
        scene.ProjectName = o_lab.lab_project.projectName;
        //scene.ProjectDes = o_lab.lab_project.projectDes;
        //scene.ProjectPhoto = o_lab.lab_project.projectPhoto;
        lab.lab_project = scene;
        lab.lab_JCalcLine = new List<JCalcLine>();
        //遍历墙的信息
        o_lab.lab_JCalcLine.ForEach(wl =>
        {
            JCalcLine cl = new JCalcLine();
            cl.PGUID = wl.guid;
            wl.line_List.ForEach(line =>
            {
                jLine jl = new jLine();
                jl.b = line.b;
                jl.k = line.k;

                pos p1 = new pos();
                p1.x = line.pos1.x;
                p1.y = line.pos1.y;
                p1.z = line.pos1.z;
                jl.pos1 = p1;

                pos p2 = new pos();
                p2.x = line.pos2.x;
                p2.y = line.pos2.y;
                p2.z = line.pos2.z;
                jl.pos2 = p2;

                cl.line_List.Add(jl);
            });
            lab.lab_JCalcLine.Add(cl);
        });
        



        //遍历机柜信息
        o_lab.lab_jcomp.ForEach(comp=> {
            JComp jComp = new JComp();
            Equipment eq = new Equipment();
            eq.GUID = comp.comp.guid;
            eq.PGUID = comp.comp.sceneguid;
            //eq.Sid = comp.comp.Sid;
            eq.AssetName = comp.comp.compName;
            eq.SignName = comp.comp.signName;
            eq.BelongGroupGUID = "";
            eq.GroupName = comp.comp.group;
            eq.ModelName = getModel(comp.comp.signName)[0];
            eq.Model = getModel(comp.comp.signName)[1];
            pos p1 = new pos();
            p1.x = comp.comp.pos.x;
            p1.y = comp.comp.pos.y;
            p1.z = comp.comp.pos.z;
            eq.AssetPos = p1;

            pos p2 = new pos();
            p2.x = comp.comp.compAngle.x;
            p2.y = comp.comp.compAngle.y;
            p2.z = comp.comp.compAngle.z;
            eq.AssetEuler = p2;
            //p1.x = comp.comp.CameraCompangle.x;
            //p1.y = comp.comp.CameraCompangle.y;
            //p1.z = comp.comp.CameraCompangle.z;
            //eq.Cam_Pos = p1;
            //p1.x = comp.comp.CameraEpos.x;
            //p1.y = comp.comp.CameraEpos.y;
            //p1.z = comp.comp.CameraEpos.z;
            //eq.Cam_Euler = p1;
            eq.subEquip = new List<SubEquipment>();
            comp.comp.subEquip.ForEach(sub =>
            {
                SubEquipment subEquip = new SubEquipment();
                subEquip.GUID = comp.comp.guid;
                subEquip.PGUID = comp.comp.sceneguid;
                subEquip.SID = comp.comp.Sid;
                subEquip.AssetName = comp.comp.compName;
                subEquip.SignName = comp.comp.signName;
                subEquip.UHeight = comp.comp.U_High;
                subEquip.UPosition = comp.comp.U_Position;
                subEquip.ModelName = getModel(comp.comp.signName)[0];
                subEquip.Model = getModel(comp.comp.signName)[1];
                pos p3 = new pos();
                p3.x = comp.comp.pos.x;
                p3.y = comp.comp.pos.y;
                p3.z = comp.comp.pos.z;
                subEquip.AssetPos = p3;
                pos p4 = new pos();
                p4.x = comp.comp.compAngle.x;
                p4.y = comp.comp.compAngle.y;
                p4.z = comp.comp.compAngle.z;
                subEquip.AssetEuler = p4;

                pos p5 = new pos();
                p5.x = comp.comp.CameraCompangle.x;
                p5.y = comp.comp.CameraCompangle.y;
                p5.z = comp.comp.CameraCompangle.z;
                subEquip.Cam_Pos = p5;

                pos p6 = new pos();
                p6.x = comp.comp.CameraEpos.x;
                p6.y = comp.comp.CameraEpos.y;
                p6.z = comp.comp.CameraEpos.z;
                subEquip.Cam_Euler = p6;
                eq.subEquip.Add(subEquip);
            });

            jComp.comp = eq;
            lab.lab_jcomp.Add(jComp);
        });
        
        savedata = JsonMapper.ToJson(lab);
    }
    public void save()
    {
        Transform();
        StartCoroutine(save1());
    }

    IEnumerator save1()
    { 
        using (UnityWebRequest unityWebRequest = new UnityWebRequest("http://10.11.15.177:8080/3d/project/change", "POST"))
        {
            SetupPosta(unityWebRequest, savedata);
            unityWebRequest.SetRequestHeader("Content-Type", "application/json;charset=utf8");
            //unityWebRequest.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
            yield return unityWebRequest.SendWebRequest();
            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log("POST提交失败-HttpTool.GetFileList！错误码：" + unityWebRequest.error);
            }
            else
            {
                Debug.Log("成功提交表单!-HttpTool.GetFileList");
            }
            if (unityWebRequest.downloadHandler.text.Contains("\\\"code\\\":1,\\\""))
            {
                Debug.Log("POST提交成功-HttpTool.GetFileList但返回码异常：" + unityWebRequest.downloadHandler.text);
            }
        }
    }

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
    public   string[] getModel(string modelName)
    {
        string[] Md = new string[2];

        switch (modelName)
        {
            case "JiGui_new(Clone)":
                Md[0] = "Model_Cabinet";
                Md[1] = "22d776eb-dc92-42b7-a500-51c93fc08f65";
                break;
            case "LuYouQi_High(Clone)":
                Md[0] = "Model_Router";
                Md[1] = "53849aa9-72e9-4de9-a402-5a10a21840d4";
                break;
        }
        return Md;
    }
}
