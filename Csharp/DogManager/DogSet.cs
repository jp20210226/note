using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePasModLib;
 

namespace DogManager
{
    public partial class DogSet : Form
    {
        ePas1Class epass = null;

        public DogSet()
        {
            InitializeComponent();

            this.SetDefUI();

            this.date_trial.Value = DateTime.Now.AddMonths(1);
        }

        void OpenDog()
        {
            try
            {
                epass = new ePas1Class();
                epass.CreateContext(0, 0x0200); //(0, &H200)
                epass.OpenDevice(1, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void CloseDog()
        {
            if (epass != null)
            {
                try
                {
                    epass.CloseDevice();
                    epass.DeleteContext();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        void InitDog()
        {
            try
            {
                epass.ChangeCode(0x00000002, "rockey", "rockey".Length, "zxja706", "zxja706".Length);
            }
            catch
            {
                try
                {
                    epass.ChangeCode(0x00000002, "zxja706", "zxja706".Length, "zxja706", "zxja706".Length);
                }
                catch (Exception ex_so)
                {

                    throw new Exception("该锁SO密码被篡改：" + ex_so.Message);
                }
            }

            try
            {
                byte[] obj = System.Text.Encoding.ASCII.GetBytes("NI\0");
                epass.SetProperty(0x0b, "", obj, 0);
                epass.DeleteDir(0, 0, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void SetValue(string value)
        {
            try
            {
                int tSize;

                try
                {
                    epass.DeleteFile(0, 0xABC);
                }
                catch { }

                WFileInfo fi = new WFileInfo();
                fi.lID = 0xABC;
                fi.lFlags = 0;
                fi.lFileSize = 512;
                fi.ucFileType = 0x02;           //flag.EPAS_FILETYPE_DATA 0x2;
                fi.ucReadAccess = 0x00;         //flag.EPAS_ACCESS_ANYONE;
                fi.ucWriteAccess = 0x02;        //flag.EPAS_ACCESS_ANYONE;
                fi.ucCryptAccess = 0x07;        //flag.EPAS_ACCESS_NONE;

                epass.CreateFile(0, ref fi);
                epass.OpenFile(0x10 + 0x20, 0xABC, ref fi); //flag.EPAS_FILE_READ 0x10  flag.EPAS_FILE_WRITE 0x20
                byte[] obj = System.Text.Encoding.ASCII.GetBytes(value);
                epass.Write(0, 0, obj, obj.Length, out tSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { epass.CloseFile(); }
        }

        string GetName()
        {
            try
            {
                return epass.GetProperty(0x0b, "", 32);//EPAS_PROP_FRIENDLY_NAME
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        string GetSernum()
        {
            try
            {
                return epass.GetProperty(7, "", 8);//EPAS_PROP_SERNUM
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        string GetValue()
        {
            try
            {
                int tSize;

                WFileInfo fi = new WFileInfo();
                epass.OpenFile(0x10, 0xABC, ref fi); //flag.EPAS_FILE_READ 0x10  flag.EPAS_FILE_WRITE 0x20

                byte[] obj = (byte[])epass.Read(0, 0, 512, out tSize);
                string str = System.Text.Encoding.ASCII.GetString(TrimBytes(obj));
                return Smart.Security.Encryptor.DESDecrypt(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { epass.CloseFile(); }
        }

        byte[] TrimBytes(byte[] bytes)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (byte b in bytes)
            {
                if (b != 0)
                    list.Add(b);
            }
            byte[] returns = new byte[list.Count];
            list.CopyTo(returns, 0);
            return returns;
        }


        private void but_con_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenDog();

                this.lab_name.Text = this.GetName();
                this.lab_sernum.Text = this.GetSernum();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接狗失败：" + ex.Message);
                this.but_c_Click(null, null);
            }
        }

        private void but_init_Click(object sender, EventArgs e)
        {
            try
            {
                this.InitDog();

                this.SetDefUI();

                this.lab_name.Text = this.GetName();
                this.lab_sernum.Text = this.GetSernum();

                MessageBox.Show("初始完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始狗失败：" + ex.Message);
            }
        }

        private void but_w_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lab_name.Text.Trim() != "NI")
                {
                    MessageBox.Show("未连接或初始狗！");
                    return;
                }
                if (this.txt_unit.Text.Trim() == "")
                {
                    MessageBox.Show("请填写甲方机构名称！");
                    return;
                }

                SetValue(this.L_Key(""));

                this.richTextBox1.Text = "";

                MessageBox.Show("写入完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入狗失败：" + ex.Message);
            }
        }

        private void but_r_Click(object sender, EventArgs e)
        {
            try
            {
                string[] values = GetValue().Split('\n');
                foreach (string value in values)
                {
                    string[] objs = value.Split('=');
                    switch (objs[0].Trim())
                    {
                        case "U":
                            this.richTextBox1.Text += "甲方：" + objs[1].Trim() + "\n";
                            break;
                        case "P":
                            this.richTextBox1.Text += "点数：" + objs[1].Trim() + "\n";
                            break;
                        case "M":
                            this.richTextBox1.Text += "模块：";
                            int LimitsModules = Convert.ToInt32(objs[1].Trim());
                            if ((LimitsModules & (int)Smart.Security.Modules.Demand) != 0)
                                this.richTextBox1.Text += "需求、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Knowledge) != 0)
                                this.richTextBox1.Text += "知识、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Project) != 0)
                                this.richTextBox1.Text += "项目(客户关系)、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Task) != 0)
                                this.richTextBox1.Text += "任务、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Patrol) != 0)
                                this.richTextBox1.Text += "巡检、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Log) != 0)
                                this.richTextBox1.Text += "日志、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Integration) != 0)
                                this.richTextBox1.Text += "一体化、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Incident) != 0)
                                this.richTextBox1.Text += "事件、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Problem) != 0)
                                this.richTextBox1.Text += "问题、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Change) != 0)
                                this.richTextBox1.Text += "变更、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Development) != 0)
                                this.richTextBox1.Text += "开发、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Defect) != 0)
                                this.richTextBox1.Text += "缺陷、";
                            if ((LimitsModules & (int)Smart.Security.Modules.Deploy) != 0)
                                this.richTextBox1.Text += "部署、";

                            this.richTextBox1.Text = this.richTextBox1.Text.TrimEnd('、') + "\n";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取狗失败：" + ex.Message);
            }
        }

        private void but_c_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseDog();

                this.SetDefUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("关闭狗失败：" + ex.Message);
            }
        }

        private void but_trial_Click(object sender, EventArgs e)
        {
            string sn = "";
            if (this.che_all.Checked)
            {
                if (r_sn.Checked)
                {
                    try
                    {
                        sn = Smart.Security.Encryptor.DESDecrypt(this.txt_sn.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("生成无限期许可，请输入正确的SN！\n" + ex.Message, "SN无效！");
                        return;
                    }
                }
                else if (r_niid.Checked)
                {
                    string niids = txt_niid.Text.Trim().ToUpper();
                    if (!String.IsNullOrWhiteSpace(niids))
                        sn = niids;
                    else
                    {
                        MessageBox.Show("生成无限期许可，请输入正确的NIID！\n多个请用 , 号分隔");
                        return;
                    }
                }
            }



            try
            {
                if (this.txt_unit.Text.Trim() == "")
                {
                    MessageBox.Show("请填写甲方机构名称！");
                    return;
                }

                rich_trial.Text = this.L_Key(sn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成许可失败：" + ex.Message);
            }
        }

        void SetDefUI()
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.lab_name.Text = "未连接";
                this.lab_sernum.Text = "";
                this.richTextBox1.Text = "";
                this.txt_unit.Text = "";
            }
            else
            {
                this.rich_trial.Text = "";
                this.txt_unit.Text = "未授权（试用）";
            }

            this.num_app.Value = 0;
            this.num_host.Value = 0;
            this.num_host_hw.Value = 0;
            this.num_net.Value = 0;
            this.num_stor.Value = 0;
            this.num_env.Value = 0;

            this.che_Incident.Checked = true;
            this.che_Problem.Checked = true;
            this.che_Change.Checked = true;
            this.che_Deploy.Checked = true;
            this.che_Task.Checked = true;
            this.che_Patrol.Checked = true;
            this.che_Log.Checked = true;
            this.che_Integration.Checked = true;
            this.che_Project.Checked = true;
            this.che_Demand.Checked = true;
            this.che_Development.Checked = true;
            this.che_Defect.Checked = true;
            this.che_Knowledge.Checked = true;
            this.che_Trouble.Checked = true;
            this.che_Knownissues.Checked = true;
        }

        private void che_all_CheckedChanged(object sender, EventArgs e)
        {
            this.date_trial.Enabled = !this.che_all.Checked;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (r_sn.Checked)
            {
                txt_sn.Enabled = true;
                txt_niid.Enabled = false;
            }
            else if (r_niid.Checked)
            {
                txt_sn.Enabled = false;
                txt_niid.Enabled = true;
            }
        }

        private string L_Key(string sn)
        {
            try
            {
                string U = "U=" + this.txt_unit.Text.Trim();
                string P = "P=";
                if (this.tabControl1.SelectedIndex == 0)
                {
                    if (this.che_all.Checked)
                        P += "2100-01-01;";
                    else
                        P += this.date_trial.Value.ToString("yyyy-MM-dd") + ";";
                }
                P = P + this.num_app.Text + ";"
                        + this.num_host.Text + ";"
                        + this.num_host_hw.Text + ";"
                        + this.num_net.Text + ";"
                        + this.num_stor.Text + ";"
                        + this.num_env.Text;

                Smart.Security.Modules LimitsModules = 0;
                if (this.che_Incident.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Incident;
                if (this.che_Problem.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Problem;
                if (this.che_Change.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Change;
                if (this.che_Deploy.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Deploy;
                if (this.che_Task.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Task;
                if (this.che_Patrol.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Patrol;
                if (this.che_Log.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Log;
                if (this.che_Integration.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Integration;
                if (this.che_Project.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Project;
                if (this.che_Demand.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Demand;
                if (this.che_Development.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Development;
                if (this.che_Defect.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Defect;
                if (this.che_Knowledge.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Knowledge;
                if (this.che_Trouble.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Trouble;
                if (this.che_Knownissues.Checked)
                    LimitsModules = LimitsModules | Smart.Security.Modules.Knownissues;


                string M = "M=" + (int)LimitsModules;

                string key = U + "\n" + P + "\n" + M;
                if (sn != "")
                    key = U + "\n" + sn + "\n" + P + "\n" + sn + "\n" + M;

                return Smart.Security.Encryptor.DESEncrypt(key);
            }
            catch (Exception ex)
            {
                throw new Exception("生成许可错误:" + ex.Message);
            }
        }
    }
}
