namespace DogManager
{
    partial class DogSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.but_w = new System.Windows.Forms.Button();
            this.but_r = new System.Windows.Forms.Button();
            this.but_init = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.but_con = new System.Windows.Forms.Button();
            this.but_c = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_unit = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.num_env = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_stor = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.num_net = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.num_host_hw = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.num_host = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_app = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.che_Knownissues = new System.Windows.Forms.CheckBox();
            this.che_Trouble = new System.Windows.Forms.CheckBox();
            this.che_Defect = new System.Windows.Forms.CheckBox();
            this.che_Development = new System.Windows.Forms.CheckBox();
            this.che_Knowledge = new System.Windows.Forms.CheckBox();
            this.che_Integration = new System.Windows.Forms.CheckBox();
            this.che_Log = new System.Windows.Forms.CheckBox();
            this.che_Patrol = new System.Windows.Forms.CheckBox();
            this.che_Demand = new System.Windows.Forms.CheckBox();
            this.che_Project = new System.Windows.Forms.CheckBox();
            this.che_Task = new System.Windows.Forms.CheckBox();
            this.che_Deploy = new System.Windows.Forms.CheckBox();
            this.che_Change = new System.Windows.Forms.CheckBox();
            this.che_Problem = new System.Windows.Forms.CheckBox();
            this.che_Incident = new System.Windows.Forms.CheckBox();
            this.lab_name = new System.Windows.Forms.TextBox();
            this.lab_sernum = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_niid = new System.Windows.Forms.TextBox();
            this.r_niid = new System.Windows.Forms.RadioButton();
            this.r_sn = new System.Windows.Forms.RadioButton();
            this.che_all = new System.Windows.Forms.CheckBox();
            this.txt_sn = new System.Windows.Forms.TextBox();
            this.but_trial = new System.Windows.Forms.Button();
            this.rich_trial = new System.Windows.Forms.RichTextBox();
            this.date_trial = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_env)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_stor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_net)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_host_hw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_host)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_app)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(14, 112);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(590, 126);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // but_w
            // 
            this.but_w.Location = new System.Drawing.Point(494, 262);
            this.but_w.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_w.Name = "but_w";
            this.but_w.Size = new System.Drawing.Size(112, 34);
            this.but_w.TabIndex = 1;
            this.but_w.Text = "写入";
            this.but_w.UseVisualStyleBackColor = true;
            this.but_w.Click += new System.EventHandler(this.but_w_Click);
            // 
            // but_r
            // 
            this.but_r.Location = new System.Drawing.Point(615, 112);
            this.but_r.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_r.Name = "but_r";
            this.but_r.Size = new System.Drawing.Size(112, 34);
            this.but_r.TabIndex = 2;
            this.but_r.Text = "读取";
            this.but_r.UseVisualStyleBackColor = true;
            this.but_r.Click += new System.EventHandler(this.but_r_Click);
            // 
            // but_init
            // 
            this.but_init.Location = new System.Drawing.Point(615, 50);
            this.but_init.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_init.Name = "but_init";
            this.but_init.Size = new System.Drawing.Size(112, 34);
            this.but_init.TabIndex = 3;
            this.but_init.Text = "初始";
            this.but_init.UseVisualStyleBackColor = true;
            this.but_init.Click += new System.EventHandler(this.but_init_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称：";
            // 
            // but_con
            // 
            this.but_con.Location = new System.Drawing.Point(615, 6);
            this.but_con.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_con.Name = "but_con";
            this.but_con.Size = new System.Drawing.Size(112, 34);
            this.but_con.TabIndex = 6;
            this.but_con.Text = "连接";
            this.but_con.UseVisualStyleBackColor = true;
            this.but_con.Click += new System.EventHandler(this.but_con_Click);
            // 
            // but_c
            // 
            this.but_c.Location = new System.Drawing.Point(615, 264);
            this.but_c.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_c.Name = "but_c";
            this.but_c.Size = new System.Drawing.Size(112, 34);
            this.but_c.TabIndex = 7;
            this.but_c.Text = "断开";
            this.but_c.UseVisualStyleBackColor = true;
            this.but_c.Click += new System.EventHandler(this.but_c_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "锁号：";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(714, 3);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "授权给：";
            // 
            // txt_unit
            // 
            this.txt_unit.Location = new System.Drawing.Point(87, 34);
            this.txt_unit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_unit.MaxLength = 50;
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(523, 28);
            this.txt_unit.TabIndex = 12;
            this.txt_unit.Text = "未授权(试用)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.num_env);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.num_stor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.num_net);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.num_host_hw);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.num_host);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.num_app);
            this.groupBox1.Location = new System.Drawing.Point(20, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(592, 114);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "点数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 74);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "环境：";
            // 
            // num_env
            // 
            this.num_env.Location = new System.Drawing.Point(500, 66);
            this.num_env.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_env.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_env.Name = "num_env";
            this.num_env.Size = new System.Drawing.Size(84, 28);
            this.num_env.TabIndex = 21;
            this.num_env.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 74);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "存储：";
            // 
            // num_stor
            // 
            this.num_stor.Location = new System.Drawing.Point(290, 66);
            this.num_stor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_stor.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_stor.Name = "num_stor";
            this.num_stor.Size = new System.Drawing.Size(84, 28);
            this.num_stor.TabIndex = 19;
            this.num_stor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "网络：";
            // 
            // num_net
            // 
            this.num_net.Location = new System.Drawing.Point(80, 66);
            this.num_net.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_net.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_net.Name = "num_net";
            this.num_net.Size = new System.Drawing.Size(84, 28);
            this.num_net.TabIndex = 17;
            this.num_net.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "主机硬件：";
            // 
            // num_host_hw
            // 
            this.num_host_hw.Location = new System.Drawing.Point(500, 26);
            this.num_host_hw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_host_hw.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_host_hw.Name = "num_host_hw";
            this.num_host_hw.Size = new System.Drawing.Size(84, 28);
            this.num_host_hw.TabIndex = 15;
            this.num_host_hw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "主机系统：";
            // 
            // num_host
            // 
            this.num_host.Location = new System.Drawing.Point(290, 26);
            this.num_host.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_host.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_host.Name = "num_host";
            this.num_host.Size = new System.Drawing.Size(84, 28);
            this.num_host.TabIndex = 13;
            this.num_host.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "应用：";
            // 
            // num_app
            // 
            this.num_app.Location = new System.Drawing.Point(80, 26);
            this.num_app.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_app.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_app.Name = "num_app";
            this.num_app.Size = new System.Drawing.Size(84, 28);
            this.num_app.TabIndex = 0;
            this.num_app.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.che_Knownissues);
            this.groupBox2.Controls.Add(this.che_Trouble);
            this.groupBox2.Controls.Add(this.che_Defect);
            this.groupBox2.Controls.Add(this.che_Development);
            this.groupBox2.Controls.Add(this.che_Knowledge);
            this.groupBox2.Controls.Add(this.che_Integration);
            this.groupBox2.Controls.Add(this.che_Log);
            this.groupBox2.Controls.Add(this.che_Patrol);
            this.groupBox2.Controls.Add(this.che_Demand);
            this.groupBox2.Controls.Add(this.che_Project);
            this.groupBox2.Controls.Add(this.che_Task);
            this.groupBox2.Controls.Add(this.che_Deploy);
            this.groupBox2.Controls.Add(this.che_Change);
            this.groupBox2.Controls.Add(this.che_Problem);
            this.groupBox2.Controls.Add(this.che_Incident);
            this.groupBox2.Location = new System.Drawing.Point(20, 198);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(730, 118);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模块";
            // 
            // che_Knownissues
            // 
            this.che_Knownissues.AutoSize = true;
            this.che_Knownissues.Location = new System.Drawing.Point(588, 76);
            this.che_Knownissues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Knownissues.Name = "che_Knownissues";
            this.che_Knownissues.Size = new System.Drawing.Size(106, 22);
            this.che_Knownissues.TabIndex = 11;
            this.che_Knownissues.Text = "已知问题";
            this.che_Knownissues.UseVisualStyleBackColor = true;
            // 
            // che_Trouble
            // 
            this.che_Trouble.AutoSize = true;
            this.che_Trouble.Location = new System.Drawing.Point(507, 76);
            this.che_Trouble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Trouble.Name = "che_Trouble";
            this.che_Trouble.Size = new System.Drawing.Size(70, 22);
            this.che_Trouble.TabIndex = 12;
            this.che_Trouble.Text = "故障";
            this.che_Trouble.UseVisualStyleBackColor = true;
            // 
            // che_Defect
            // 
            this.che_Defect.AutoSize = true;
            this.che_Defect.Location = new System.Drawing.Point(336, 76);
            this.che_Defect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Defect.Name = "che_Defect";
            this.che_Defect.Size = new System.Drawing.Size(70, 22);
            this.che_Defect.TabIndex = 10;
            this.che_Defect.Text = "缺陷";
            this.che_Defect.UseVisualStyleBackColor = true;
            // 
            // che_Development
            // 
            this.che_Development.AutoSize = true;
            this.che_Development.Location = new System.Drawing.Point(255, 76);
            this.che_Development.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Development.Name = "che_Development";
            this.che_Development.Size = new System.Drawing.Size(70, 22);
            this.che_Development.TabIndex = 9;
            this.che_Development.Text = "开发";
            this.che_Development.UseVisualStyleBackColor = true;
            // 
            // che_Knowledge
            // 
            this.che_Knowledge.AutoSize = true;
            this.che_Knowledge.Location = new System.Drawing.Point(93, 30);
            this.che_Knowledge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Knowledge.Name = "che_Knowledge";
            this.che_Knowledge.Size = new System.Drawing.Size(70, 22);
            this.che_Knowledge.TabIndex = 8;
            this.che_Knowledge.Text = "知识";
            this.che_Knowledge.UseVisualStyleBackColor = true;
            // 
            // che_Integration
            // 
            this.che_Integration.AutoSize = true;
            this.che_Integration.Location = new System.Drawing.Point(588, 30);
            this.che_Integration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Integration.Name = "che_Integration";
            this.che_Integration.Size = new System.Drawing.Size(88, 22);
            this.che_Integration.TabIndex = 7;
            this.che_Integration.Text = "一体化";
            this.che_Integration.UseVisualStyleBackColor = true;
            // 
            // che_Log
            // 
            this.che_Log.AutoSize = true;
            this.che_Log.Location = new System.Drawing.Point(507, 30);
            this.che_Log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Log.Name = "che_Log";
            this.che_Log.Size = new System.Drawing.Size(70, 22);
            this.che_Log.TabIndex = 6;
            this.che_Log.Text = "日志";
            this.che_Log.UseVisualStyleBackColor = true;
            // 
            // che_Patrol
            // 
            this.che_Patrol.AutoSize = true;
            this.che_Patrol.Location = new System.Drawing.Point(426, 30);
            this.che_Patrol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Patrol.Name = "che_Patrol";
            this.che_Patrol.Size = new System.Drawing.Size(70, 22);
            this.che_Patrol.TabIndex = 5;
            this.che_Patrol.Text = "巡检";
            this.che_Patrol.UseVisualStyleBackColor = true;
            // 
            // che_Demand
            // 
            this.che_Demand.AutoSize = true;
            this.che_Demand.Location = new System.Drawing.Point(12, 30);
            this.che_Demand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Demand.Name = "che_Demand";
            this.che_Demand.Size = new System.Drawing.Size(70, 22);
            this.che_Demand.TabIndex = 4;
            this.che_Demand.Text = "需求";
            this.che_Demand.UseVisualStyleBackColor = true;
            // 
            // che_Project
            // 
            this.che_Project.AutoSize = true;
            this.che_Project.Location = new System.Drawing.Point(174, 30);
            this.che_Project.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Project.Name = "che_Project";
            this.che_Project.Size = new System.Drawing.Size(160, 22);
            this.che_Project.TabIndex = 4;
            this.che_Project.Text = "项目(客户关系)";
            this.che_Project.UseVisualStyleBackColor = true;
            // 
            // che_Task
            // 
            this.che_Task.AutoSize = true;
            this.che_Task.Location = new System.Drawing.Point(345, 30);
            this.che_Task.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Task.Name = "che_Task";
            this.che_Task.Size = new System.Drawing.Size(70, 22);
            this.che_Task.TabIndex = 4;
            this.che_Task.Text = "任务";
            this.che_Task.UseVisualStyleBackColor = true;
            // 
            // che_Deploy
            // 
            this.che_Deploy.AutoSize = true;
            this.che_Deploy.Location = new System.Drawing.Point(417, 76);
            this.che_Deploy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Deploy.Name = "che_Deploy";
            this.che_Deploy.Size = new System.Drawing.Size(70, 22);
            this.che_Deploy.TabIndex = 3;
            this.che_Deploy.Text = "部署";
            this.che_Deploy.UseVisualStyleBackColor = true;
            // 
            // che_Change
            // 
            this.che_Change.AutoSize = true;
            this.che_Change.Location = new System.Drawing.Point(174, 76);
            this.che_Change.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Change.Name = "che_Change";
            this.che_Change.Size = new System.Drawing.Size(70, 22);
            this.che_Change.TabIndex = 2;
            this.che_Change.Text = "变更";
            this.che_Change.UseVisualStyleBackColor = true;
            // 
            // che_Problem
            // 
            this.che_Problem.AutoSize = true;
            this.che_Problem.Location = new System.Drawing.Point(93, 76);
            this.che_Problem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Problem.Name = "che_Problem";
            this.che_Problem.Size = new System.Drawing.Size(70, 22);
            this.che_Problem.TabIndex = 1;
            this.che_Problem.Text = "问题";
            this.che_Problem.UseVisualStyleBackColor = true;
            // 
            // che_Incident
            // 
            this.che_Incident.AutoSize = true;
            this.che_Incident.Location = new System.Drawing.Point(12, 76);
            this.che_Incident.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_Incident.Name = "che_Incident";
            this.che_Incident.Size = new System.Drawing.Size(70, 22);
            this.che_Incident.TabIndex = 0;
            this.che_Incident.Text = "事件";
            this.che_Incident.UseVisualStyleBackColor = true;
            // 
            // lab_name
            // 
            this.lab_name.BackColor = System.Drawing.Color.LemonChiffon;
            this.lab_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_name.Location = new System.Drawing.Point(81, 9);
            this.lab_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lab_name.MaxLength = 50;
            this.lab_name.Name = "lab_name";
            this.lab_name.ReadOnly = true;
            this.lab_name.Size = new System.Drawing.Size(524, 28);
            this.lab_name.TabIndex = 16;
            // 
            // lab_sernum
            // 
            this.lab_sernum.BackColor = System.Drawing.Color.LemonChiffon;
            this.lab_sernum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_sernum.Location = new System.Drawing.Point(81, 52);
            this.lab_sernum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lab_sernum.MaxLength = 50;
            this.lab_sernum.Name = "lab_sernum";
            this.lab_sernum.ReadOnly = true;
            this.lab_sernum.Size = new System.Drawing.Size(524, 28);
            this.lab_sernum.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 345);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_niid);
            this.tabPage2.Controls.Add(this.r_niid);
            this.tabPage2.Controls.Add(this.r_sn);
            this.tabPage2.Controls.Add(this.che_all);
            this.tabPage2.Controls.Add(this.txt_sn);
            this.tabPage2.Controls.Add(this.but_trial);
            this.tabPage2.Controls.Add(this.rich_trial);
            this.tabPage2.Controls.Add(this.date_trial);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(757, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "License Key";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_niid
            // 
            this.txt_niid.Enabled = false;
            this.txt_niid.Location = new System.Drawing.Point(93, 92);
            this.txt_niid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_niid.MaxLength = 50;
            this.txt_niid.Multiline = true;
            this.txt_niid.Name = "txt_niid";
            this.txt_niid.Size = new System.Drawing.Size(649, 70);
            this.txt_niid.TabIndex = 24;
            // 
            // r_niid
            // 
            this.r_niid.AutoSize = true;
            this.r_niid.Location = new System.Drawing.Point(14, 93);
            this.r_niid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.r_niid.Name = "r_niid";
            this.r_niid.Size = new System.Drawing.Size(78, 22);
            this.r_niid.TabIndex = 23;
            this.r_niid.Text = "NIID:";
            this.r_niid.UseVisualStyleBackColor = true;
            this.r_niid.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // r_sn
            // 
            this.r_sn.AutoSize = true;
            this.r_sn.Checked = true;
            this.r_sn.Location = new System.Drawing.Point(14, 52);
            this.r_sn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.r_sn.Name = "r_sn";
            this.r_sn.Size = new System.Drawing.Size(60, 22);
            this.r_sn.TabIndex = 22;
            this.r_sn.TabStop = true;
            this.r_sn.Text = "SN:";
            this.r_sn.UseVisualStyleBackColor = true;
            this.r_sn.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // che_all
            // 
            this.che_all.AutoSize = true;
            this.che_all.Location = new System.Drawing.Point(256, 18);
            this.che_all.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.che_all.Name = "che_all";
            this.che_all.Size = new System.Drawing.Size(88, 22);
            this.che_all.TabIndex = 21;
            this.che_all.Text = "无限期";
            this.che_all.UseVisualStyleBackColor = true;
            this.che_all.CheckedChanged += new System.EventHandler(this.che_all_CheckedChanged);
            // 
            // txt_sn
            // 
            this.txt_sn.Location = new System.Drawing.Point(93, 51);
            this.txt_sn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_sn.MaxLength = 50;
            this.txt_sn.Name = "txt_sn";
            this.txt_sn.Size = new System.Drawing.Size(649, 28);
            this.txt_sn.TabIndex = 20;
            // 
            // but_trial
            // 
            this.but_trial.Location = new System.Drawing.Point(630, 172);
            this.but_trial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_trial.Name = "but_trial";
            this.but_trial.Size = new System.Drawing.Size(114, 69);
            this.but_trial.TabIndex = 18;
            this.but_trial.Text = "生成License Key";
            this.but_trial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_trial.UseVisualStyleBackColor = true;
            this.but_trial.Click += new System.EventHandler(this.but_trial_Click);
            // 
            // rich_trial
            // 
            this.rich_trial.BackColor = System.Drawing.Color.LemonChiffon;
            this.rich_trial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_trial.Location = new System.Drawing.Point(14, 172);
            this.rich_trial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rich_trial.Name = "rich_trial";
            this.rich_trial.ReadOnly = true;
            this.rich_trial.Size = new System.Drawing.Size(606, 122);
            this.rich_trial.TabIndex = 17;
            this.rich_trial.Text = "";
            // 
            // date_trial
            // 
            this.date_trial.CustomFormat = "yyyy-MM-dd";
            this.date_trial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_trial.Location = new System.Drawing.Point(81, 10);
            this.date_trial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date_trial.Name = "date_trial";
            this.date_trial.Size = new System.Drawing.Size(164, 28);
            this.date_trial.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 18);
            this.label18.TabIndex = 15;
            this.label18.Text = "期限：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lab_sernum);
            this.tabPage1.Controls.Add(this.lab_name);
            this.tabPage1.Controls.Add(this.but_c);
            this.tabPage1.Controls.Add(this.but_init);
            this.tabPage1.Controls.Add(this.but_r);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.but_w);
            this.tabPage1.Controls.Add(this.but_con);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(757, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dog Key";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(14, 256);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(714, 3);
            this.label11.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txt_unit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(18, 372);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(765, 333);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "License";
            // 
            // DogSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 696);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(808, 752);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(808, 752);
            this.Name = "DogSet";
            this.Text = "License 设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_env)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_stor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_net)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_host_hw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_host)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_app)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button but_w;
        private System.Windows.Forms.Button but_r;
        private System.Windows.Forms.Button but_init;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_con;
        private System.Windows.Forms.Button but_c;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_unit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown num_app;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown num_env;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_stor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_net;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_host_hw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_host;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox che_Log;
        private System.Windows.Forms.CheckBox che_Patrol;
        private System.Windows.Forms.CheckBox che_Task;
        private System.Windows.Forms.CheckBox che_Deploy;
        private System.Windows.Forms.CheckBox che_Change;
        private System.Windows.Forms.CheckBox che_Problem;
        private System.Windows.Forms.CheckBox che_Incident;
        private System.Windows.Forms.TextBox lab_name;
        private System.Windows.Forms.TextBox lab_sernum;
        private System.Windows.Forms.CheckBox che_Integration;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button but_trial;
        private System.Windows.Forms.RichTextBox rich_trial;
        private System.Windows.Forms.DateTimePicker date_trial;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_sn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox che_all;
        private System.Windows.Forms.CheckBox che_Demand;
        private System.Windows.Forms.CheckBox che_Project;
        private System.Windows.Forms.TextBox txt_niid;
        private System.Windows.Forms.RadioButton r_niid;
        private System.Windows.Forms.RadioButton r_sn;
        private System.Windows.Forms.CheckBox che_Knowledge;
        private System.Windows.Forms.CheckBox che_Defect;
        private System.Windows.Forms.CheckBox che_Development;
        private System.Windows.Forms.CheckBox che_Knownissues;
        private System.Windows.Forms.CheckBox che_Trouble;
    }
}

