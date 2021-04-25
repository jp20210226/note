namespace MultiFileDown
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBatchAdd = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.MnuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDownSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStopALL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmALLPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaxThread = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.btnStopALL = new System.Windows.Forms.Button();
            this.btnm3u8 = new System.Windows.Forms.Button();
            this.btnTSJJm = new System.Windows.Forms.Button();
            this.lvFileLists = new MultiFileDown.Common.DoubleBufferListView();
            this.btnModifyDir = new System.Windows.Forms.Button();
            this.MnuRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(754, 123);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(104, 27);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "全部下载";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.Location = new System.Drawing.Point(8, 628);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1217, 21);
            this.lblInfo.TabIndex = 1;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(85, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(659, 25);
            this.txtURL.TabIndex = 2;
            this.txtURL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtURL_MouseClick);
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            this.txtURL.Enter += new System.EventHandler(this.txtURL_Enter);
            this.txtURL.Leave += new System.EventHandler(this.txtURL_Leave);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(85, 49);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(659, 25);
            this.txtDir.TabIndex = 2;
            this.txtDir.Text = "F:\\test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "下载地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "保存目录";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(754, 47);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(104, 27);
            this.btnBrowser.TabIndex = 5;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "文件名";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(85, 84);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(659, 25);
            this.txtFileName.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(754, 83);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(104, 27);
            this.btnSelectFile.TabIndex = 7;
            this.btnSelectFile.Text = "转到文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(754, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 27);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBatchAdd
            // 
            this.btnBatchAdd.Location = new System.Drawing.Point(864, 9);
            this.btnBatchAdd.Name = "btnBatchAdd";
            this.btnBatchAdd.Size = new System.Drawing.Size(104, 27);
            this.btnBatchAdd.TabIndex = 9;
            this.btnBatchAdd.Text = "批量添加";
            this.btnBatchAdd.UseVisualStyleBackColor = true;
            this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(643, 128);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(89, 19);
            this.chkAutoStart.TabIndex = 10;
            this.chkAutoStart.Text = "立即下载";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // MnuRight
            // 
            this.MnuRight.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuDownSelect,
            this.tsmReDown,
            this.toolStripSeparator2,
            this.mnuStopALL,
            this.mnuStopSelect,
            this.toolStripSeparator1,
            this.tsmALLPause,
            this.tsmSelectPause,
            this.toolStripSeparator4,
            this.mnuClear,
            this.mnuDelSelect,
            this.toolStripSeparator3,
            this.mnuSelectFile,
            this.mnuCopyURL});
            this.MnuRight.Name = "MnuRight";
            this.MnuRight.Size = new System.Drawing.Size(184, 292);
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(183, 24);
            this.mnuStart.Text = "全部下载";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuDownSelect
            // 
            this.mnuDownSelect.Name = "mnuDownSelect";
            this.mnuDownSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuDownSelect.Text = "下载选中行";
            this.mnuDownSelect.Click += new System.EventHandler(this.mnuDownSelect_Click);
            // 
            // tsmReDown
            // 
            this.tsmReDown.Name = "tsmReDown";
            this.tsmReDown.Size = new System.Drawing.Size(183, 24);
            this.tsmReDown.Text = "重新下载";
            this.tsmReDown.Click += new System.EventHandler(this.tsmReDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuStopALL
            // 
            this.mnuStopALL.Name = "mnuStopALL";
            this.mnuStopALL.Size = new System.Drawing.Size(183, 24);
            this.mnuStopALL.Text = "全部停止下载";
            this.mnuStopALL.Click += new System.EventHandler(this.mnuStopALL_Click);
            // 
            // mnuStopSelect
            // 
            this.mnuStopSelect.Name = "mnuStopSelect";
            this.mnuStopSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuStopSelect.Text = "停止选中行下载";
            this.mnuStopSelect.Click += new System.EventHandler(this.mnuStopSelect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // tsmALLPause
            // 
            this.tsmALLPause.Name = "tsmALLPause";
            this.tsmALLPause.Size = new System.Drawing.Size(183, 24);
            this.tsmALLPause.Text = "全部暂停";
            this.tsmALLPause.Click += new System.EventHandler(this.tsmALLPause_Click);
            // 
            // tsmSelectPause
            // 
            this.tsmSelectPause.Name = "tsmSelectPause";
            this.tsmSelectPause.Size = new System.Drawing.Size(183, 24);
            this.tsmSelectPause.Text = "暂停选中行";
            this.tsmSelectPause.Click += new System.EventHandler(this.tsmSelectPause_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuClear
            // 
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(183, 24);
            this.mnuClear.Text = "清除列表";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // mnuDelSelect
            // 
            this.mnuDelSelect.Name = "mnuDelSelect";
            this.mnuDelSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuDelSelect.Text = "删除选中行";
            this.mnuDelSelect.Click += new System.EventHandler(this.mnuDelSelect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuSelectFile
            // 
            this.mnuSelectFile.Name = "mnuSelectFile";
            this.mnuSelectFile.Size = new System.Drawing.Size(183, 24);
            this.mnuSelectFile.Text = "转到文件";
            this.mnuSelectFile.Click += new System.EventHandler(this.mnuSelectFile_Click);
            // 
            // mnuCopyURL
            // 
            this.mnuCopyURL.Name = "mnuCopyURL";
            this.mnuCopyURL.Size = new System.Drawing.Size(183, 24);
            this.mnuCopyURL.Text = "复制网址";
            this.mnuCopyURL.Click += new System.EventHandler(this.mnuCopyURL_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "线程数";
            // 
            // nudMaxThread
            // 
            this.nudMaxThread.Location = new System.Drawing.Point(85, 120);
            this.nudMaxThread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxThread.Name = "nudMaxThread";
            this.nudMaxThread.Size = new System.Drawing.Size(88, 25);
            this.nudMaxThread.TabIndex = 14;
            this.nudMaxThread.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "分块数";
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(258, 120);
            this.nudBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.Size = new System.Drawing.Size(88, 25);
            this.nudBlockSize.TabIndex = 14;
            this.nudBlockSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnStopALL
            // 
            this.btnStopALL.Enabled = false;
            this.btnStopALL.Location = new System.Drawing.Point(864, 123);
            this.btnStopALL.Name = "btnStopALL";
            this.btnStopALL.Size = new System.Drawing.Size(104, 27);
            this.btnStopALL.TabIndex = 15;
            this.btnStopALL.Text = "全部停止";
            this.btnStopALL.UseVisualStyleBackColor = true;
            this.btnStopALL.Click += new System.EventHandler(this.btnStopALL_Click);
            // 
            // btnm3u8
            // 
            this.btnm3u8.Location = new System.Drawing.Point(980, 9);
            this.btnm3u8.Name = "btnm3u8";
            this.btnm3u8.Size = new System.Drawing.Size(104, 27);
            this.btnm3u8.TabIndex = 16;
            this.btnm3u8.Text = "m3u8下载";
            this.btnm3u8.UseVisualStyleBackColor = true;
            this.btnm3u8.Click += new System.EventHandler(this.btnm3u8_Click);
            // 
            // btnTSJJm
            // 
            this.btnTSJJm.Location = new System.Drawing.Point(980, 45);
            this.btnTSJJm.Name = "btnTSJJm";
            this.btnTSJJm.Size = new System.Drawing.Size(104, 27);
            this.btnTSJJm.TabIndex = 17;
            this.btnTSJJm.Text = "TS文件合并";
            this.btnTSJJm.UseVisualStyleBackColor = true;
            this.btnTSJJm.Click += new System.EventHandler(this.btnTSJJm_Click);
            // 
            // lvFileLists
            // 
            this.lvFileLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileLists.Location = new System.Drawing.Point(8, 156);
            this.lvFileLists.Name = "lvFileLists";
            this.lvFileLists.Size = new System.Drawing.Size(1217, 469);
            this.lvFileLists.TabIndex = 8;
            this.lvFileLists.UseCompatibleStateImageBehavior = false;
            this.lvFileLists.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvFileLists_MouseClick);
            // 
            // btnModifyDir
            // 
            this.btnModifyDir.Location = new System.Drawing.Point(864, 47);
            this.btnModifyDir.Name = "btnModifyDir";
            this.btnModifyDir.Size = new System.Drawing.Size(104, 27);
            this.btnModifyDir.TabIndex = 37;
            this.btnModifyDir.Text = "修改目录";
            this.btnModifyDir.UseVisualStyleBackColor = true;
            this.btnModifyDir.Click += new System.EventHandler(this.btnModifyDir_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 654);
            this.Controls.Add(this.btnModifyDir);
            this.Controls.Add(this.btnTSJJm);
            this.Controls.Add(this.btnm3u8);
            this.Controls.Add(this.btnStopALL);
            this.Controls.Add(this.nudBlockSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudMaxThread);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.btnBatchAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvFileLists);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnDown);
            this.Name = "FrmMain";
            this.Text = "多线程文件下载";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MnuRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private Common.DoubleBufferListView lvFileLists;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBatchAdd;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.ContextMenuStrip MnuRight;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuDownSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripMenuItem mnuDelSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMaxThread;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuStopALL;
        private System.Windows.Forms.ToolStripMenuItem mnuStopSelect;
        private System.Windows.Forms.Button btnStopALL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectFile;
        private System.Windows.Forms.Button btnm3u8;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyURL;
        private System.Windows.Forms.Button btnTSJJm;
        private System.Windows.Forms.ToolStripMenuItem tsmALLPause;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmReDown;
        private System.Windows.Forms.Button btnModifyDir;
    }
}

