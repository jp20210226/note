using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCs : MonoBehaviour
{
    private static Dictionary<GameObject, PanelData> PanelDataDic = new Dictionary<GameObject, PanelData>() ; 
    private static List<PanelData> PanelDataList = new List<PanelData>() ;
    private int testPanelDataDic;
    private int testPanelDataList;
    private void Awake()
    {
        testPanelDataDic = PanelDataDic.Count;
        testPanelDataList = PanelDataList.Count;
    }
    void Start()
    {

    }
   public  void Start1()
    {
        Debug.Log(testPanelDataDic); Debug.Log(testPanelDataList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
public class PanelData
{
    public int Index;
    public static int MaxIndex;
    public RectTransform DragTran;
    public RectTransform ZoomTran;
    public Vector3 ClickPos;
    public Vector2 Size;
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public float MinWidth;
    public float MinHeight;
    public PanelData()
    {

    }

    public PanelData(RectTransform rectTran)
    {
        ZoomTran = rectTran;
    }
}
