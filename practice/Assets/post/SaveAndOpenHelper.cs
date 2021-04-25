using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace old
{
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
        public string guid { get; set; }
        public string Fguid { get; set; }
        public string sceneguid { get; set; }
        //第三方平台ID
        public string Sid { get; set; }
        //定义设备类型的ID
        public string compModelID { get; set; }
        //设备类型名
        public string compType { get; set; }
        //用户填写的设备名
        public string compName { get; set; }
        //unity查找游戏物体用
        public string signName { get; set; }
        //U位
        public int U_Position { get; set; }
        //U高
        public int U_High { get; set; }
        //设备配置
        public string compConfig { get; set; }
        //SN号
        public string compSN { get; set; }

        public string groupguid { get; set; }
        //机柜分组
        public string group { get; set; }
        //责任人
        public string compDutyMan { get; set; }
        //维保商电话
        public string MaintenanceProviderNum { get; set; }
        //维保到期
        public string MaintenanceExpiration { get; set; }
        public pos compAngle { get; set; }
        public pos pos { get; set; }
        public pos CameraEpos { get; set; }
        public pos CameraCompangle { get; set; }
    }
    //设备信息类
    public class Equipment
    {
        public string guid { get; set; }
        public string Sid { get; set; }
        public string Fguid { get; set; }
        public string sceneguid { get; set; }
        //用户填写的机柜名
        public string compName { get; set; }
        //unity查找游戏物体用
        public string signName { get; set; }
        //设备配置
        public string compConfig { get; set; }
        //U位
        public int U_Position { get; set; }
        //U高
        public int U_High { get; set; }
        //SN号
        public string compSN { get; set; }
        public string groupguid { get; set; }
        //机柜分组
        public string group { get; set; }

        public List<SubEquipment> subEquip { get; set; }
        //责任人
        public string compModelDutyMan { get; set; }
        //维保商电话
        public string MaintenanceProviderNum { get; set; }
        //维保到期
        public string MaintenanceExpiration { get; set; }
        //柜内存储信息
        public Dictionary<int, bool> cabinetCap { get; set; }
        //设备坐标
        public pos pos { get; set; }
        //设备角度
        public pos compAngle { get; set; }
        public pos CameraEpos { get; set; }
        public pos CameraCompangle { get; set; }

    }
    //机房墙体类
    public class JCalcLine
    {
        public string guid { get; set; }
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

        public string guid { get; set; }
        public string projectName { get; set; }
        public string projectDes { get; set; }
        public string projectPhoto { get; set; }
    }

}
