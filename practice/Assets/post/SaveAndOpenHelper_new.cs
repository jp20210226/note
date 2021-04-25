using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.post
{
    public class CalcLine
    {
        public IWall iwall;
        //public List<IWall> iwall_List;//保存这面墙  相交的墙的所有信息
        public static Vector3 betweenPos;
        public static double angleAMB;
        private GameObject allwall;
        public CalcLine()
        {
            iwall = new IWall();
        }
    }
    public class IWall
    {
        public List<ILine> line_List;

        public IWall()
        {
            line_List = new List<ILine>();
        }
    }
    public class ILine
    {
        public Vector3 pos1;
        public Vector3 pos2;
        public float k;
        public float b;
    }
    //点信息类
    public class pos
    {
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }
    //线信息类
    public class jLine
    {


        public string k { get; set; }
        public string b { get; set; }
        public pos pos1 { get; set; }
        public pos pos2 { get; set; }

    }
    //子设备信息类
    public class SubEquipment
    {
        public string GroupName { get; set; }
        //责任人
        public string CompModelDutyMan { get; set; }
        public pos Cam_Pos { get; set; }
        public string PGUID { get; set; }
        public string BelongGroupGUID { get; set; }
        public int UHeight { get; set; }
        public pos Cam_Euler { get; set; }
        public string Height { get; set; }
        public int ID { get; set; }
        public string Room { get; set; }
        public string Width { get; set; }

        //维保到期
        public string MaintenanceExpiration { get; set; }
        //维保商电话
        public string MaintenanceProviderNum { get; set; }
        public string SubdevsGUID { get; set; }
        public string Floor { get; set; }
        public string ModelName { get; set; }
        public string Buildings { get; set; }
        public string GUID { get; set; }
        public double Scale { get; set; }

        public string City { get; set; }
        //设备角度
        public pos AssetEuler { get; set; }
        public int Flag { get; set; }
        //unity查找游戏物体用
        public string SignName { get; set; }
        //用户填写的设备名
        public string AssetName { get; set; }
        public string CompSN { get; set; }
        //第三方平台ID
        public string SID { get; set; }
        public string Park { get; set; }
        public string Area { get; set; }
        public string Length { get; set; }
        public string Model { get; set; }
        //U位
        public int UPosition { get; set; }
        //设备坐标
        public pos AssetPos { get; set; }

    }
    //设备信息类
    public class Equipment
    {  //机柜分组
        public string GroupName { get; set; }
        public List<SubEquipment> subEquip { get; set; }
        public pos Cam_Pos { get; set; }
        public string PGUID { get; set; }
        public string BelongGroupGUID { get; set; }
        public pos Cam_Euler { get; set; }
        public string Height { get; set; }
        public int ID { get; set; }
        public string Room { get; set; }
        public string Width { get; set; }
        public string SubdevsGUID { get; set; }
        public string Floor { get; set; }
        public string ModelName { get; set; }
        public string Buildings { get; set; }
        public string GUID { get; set; }
        public double Scale { get; set; }
        public string City { get; set; }
        //设备角度
        public pos AssetEuler { get; set; }
        public int Flag { get; set; }
        //unity查找游戏物体用
        public string SignName { get; set; }
        //用户填写的机柜名
        public string AssetName { get; set; }
        public string SID { get; set; }

        public string Park { get; set; }

        public string Area { get; set; }
        public string Length { get; set; }
        public string Model { get; set; }
        //柜内存储信息
        public string CabinetCap { get; set; }
        //U位
        public int UPosition { get; set; }
        //设备坐标
        public pos AssetPos { get; set; }
        ////设备配置
        //public string compConfig { get; set; }
        ////U高
        //public int U_High { get; set; }
        ////SN号
        //public string compSN { get; set; }

    }
    //机房墙体类
    public class JCalcLine
    {
        public string PGUID { get; set; }
        public List<jLine> line_List { get; set; } = new List<jLine>();

    }
    //机房设备类
    public class JComp
    {

        public Equipment comp { get; set; }


    }
    //机房类
    public class Lab
    {
        public List<JComp> lab_jcomp { get; set; }
        public List<JCalcLine> lab_JCalcLine { get; set; }
        public Scene lab_project { get; set; }
    }
    //场景信息
    public class Scene
    {

        public string GUID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDes { get; set; }
        public string ProjectPhoto { get; set; }
    }
    public class project
    {
        public double code { get; set; }
        public string message { get; set; }
        public Lab data { get; set; }
    }
}
