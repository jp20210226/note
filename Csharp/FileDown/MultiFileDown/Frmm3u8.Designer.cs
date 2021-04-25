namespace MultiFileDown
{
    partial class Frmm3u8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMaxThread = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.mnuSelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStopSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopALL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDownSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectFree = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuModifyDir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopALL = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.chkjiemi = new System.Windows.Forms.CheckBox();
            this.chkMerge = new System.Windows.Forms.CheckBox();
            this.btnChgURL = new System.Windows.Forms.Button();
            this.btnModifyDir = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvFileLists = new MultiFileDown.Common.DoubleBufferListView();
            this.chkCursorFlower = new System.Windows.Forms.CheckBox();
            this.tsmALLPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxThread)).BeginInit();
            this.MnuRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(287, 80);
            this.nudBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.Size = new System.Drawing.Size(88, 25);
            this.nudBlockSize.TabIndex = 33;
            this.nudBlockSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "分块数";
            // 
            // nudMaxThread
            // 
            this.nudMaxThread.Location = new System.Drawing.Point(114, 80);
            this.nudMaxThread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxThread.Name = "nudMaxThread";
            this.nudMaxThread.Size = new System.Drawing.Size(88, 25);
            this.nudMaxThread.TabIndex = 32;
            this.nudMaxThread.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "线程数";
            // 
            // mnuSelectFile
            // 
            this.mnuSelectFile.Name = "mnuSelectFile";
            this.mnuSelectFile.Size = new System.Drawing.Size(183, 24);
            this.mnuSelectFile.Text = "转到文件";
            this.mnuSelectFile.Click += new System.EventHandler(this.mnuSelectFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuDelSelect
            // 
            this.mnuDelSelect.Name = "mnuDelSelect";
            this.mnuDelSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuDelSelect.Text = "删除选中行";
            this.mnuDelSelect.Click += new System.EventHandler(this.mnuDelSelect_Click);
            // 
            // mnuClear
            // 
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(183, 24);
            this.mnuClear.Text = "清除列表";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuStopSelect
            // 
            this.mnuStopSelect.Name = "mnuStopSelect";
            this.mnuStopSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuStopSelect.Text = "停止选中行下载";
            this.mnuStopSelect.Click += new System.EventHandler(this.mnuStopSelect_Click);
            // 
            // mnuStopALL
            // 
            this.mnuStopALL.Name = "mnuStopALL";
            this.mnuStopALL.Size = new System.Drawing.Size(183, 24);
            this.mnuStopALL.Text = "全部停止下载";
            this.mnuStopALL.Click += new System.EventHandler(this.mnuStopALL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuDownSelect
            // 
            this.mnuDownSelect.Name = "mnuDownSelect";
            this.mnuDownSelect.Size = new System.Drawing.Size(183, 24);
            this.mnuDownSelect.Text = "下载选中行";
            this.mnuDownSelect.Click += new System.EventHandler(this.mnuDownSelect_Click);
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(183, 24);
            this.mnuStart.Text = "全部下载";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // MnuRight
            // 
            this.MnuRight.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuDownSelect,
            this.mnuReDown,
            this.toolStripSeparator2,
            this.mnuStopALL,
            this.mnuStopSelect,
            this.mnuSelectFree,
            this.toolStripSeparator1,
            this.tsmALLPause,
            this.tsmSelectPause,
            this.toolStripSeparator5,
            this.mnuClear,
            this.mnuDelSelect,
            this.toolStripSeparator3,
            this.mnuSelectFile,
            this.mnuCopyURL,
            this.toolStripSeparator4,
            this.mnuModifyDir,
            this.mnuModifyURL});
            this.MnuRight.Name = "MnuRight";
            this.MnuRight.Size = new System.Drawing.Size(211, 398);
            // 
            // mnuReDown
            // 
            this.mnuReDown.Name = "mnuReDown";
            this.mnuReDown.Size = new System.Drawing.Size(183, 24);
            this.mnuReDown.Text = "重新下载";
            this.mnuReDown.Click += new System.EventHandler(this.mnuReDown_Click);
            // 
            // mnuSelectFree
            // 
            this.mnuSelectFree.Name = "mnuSelectFree";
            this.mnuSelectFree.Size = new System.Drawing.Size(183, 24);
            this.mnuSelectFree.Text = "取消选中行队列";
            this.mnuSelectFree.Click += new System.EventHandler(this.mnuSelectFree_Click);
            // 
            // mnuCopyURL
            // 
            this.mnuCopyURL.Name = "mnuCopyURL";
            this.mnuCopyURL.Size = new System.Drawing.Size(183, 24);
            this.mnuCopyURL.Text = "复制网址";
            this.mnuCopyURL.Click += new System.EventHandler(this.mnuCopyURL_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuModifyDir
            // 
            this.mnuModifyDir.Name = "mnuModifyDir";
            this.mnuModifyDir.Size = new System.Drawing.Size(183, 24);
            this.mnuModifyDir.Text = "修改目录";
            this.mnuModifyDir.Click += new System.EventHandler(this.mnuModifyDir_Click);
            // 
            // mnuModifyURL
            // 
            this.mnuModifyURL.Name = "mnuModifyURL";
            this.mnuModifyURL.Size = new System.Drawing.Size(183, 24);
            this.mnuModifyURL.Text = "修改网址";
            this.mnuModifyURL.Click += new System.EventHandler(this.mnuModifyURL_Click);
            // 
            // btnStopALL
            // 
            this.btnStopALL.Enabled = false;
            this.btnStopALL.Location = new System.Drawing.Point(860, 83);
            this.btnStopALL.Name = "btnStopALL";
            this.btnStopALL.Size = new System.Drawing.Size(104, 27);
            this.btnStopALL.TabIndex = 34;
            this.btnStopALL.Text = "全部停止";
            this.btnStopALL.UseVisualStyleBackColor = true;
            this.btnStopALL.Click += new System.EventHandler(this.btnStopALL_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(651, 85);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(89, 19);
            this.chkAutoStart.TabIndex = 29;
            this.chkAutoStart.Text = "立即下载";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(750, 10);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(123, 27);
            this.btnGetFiles.TabIndex = 27;
            this.btnGetFiles.Text = "获取文件列表";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(750, 47);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(104, 27);
            this.btnBrowser.TabIndex = 23;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "保存目录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "m3u8文件地址";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(113, 49);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(627, 25);
            this.txtDir.TabIndex = 19;
            this.txtDir.Text = "F:\\test";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(113, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(627, 25);
            this.txtURL.TabIndex = 18;
            this.txtURL.Text = "http://cdn1.chlpdq.com/20181013/90zvJnlV/index.m3u8";
            this.txtURL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtURL_MouseClick);
            this.txtURL.Enter += new System.EventHandler(this.txtURL_Enter);
            this.txtURL.Leave += new System.EventHandler(this.txtURL_Leave);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.Location = new System.Drawing.Point(1, 584);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1272, 21);
            this.lblInfo.TabIndex = 17;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(750, 83);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(104, 27);
            this.btnDown.TabIndex = 16;
            this.btnDown.Text = "全部下载";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // chkjiemi
            // 
            this.chkjiemi.AutoSize = true;
            this.chkjiemi.Location = new System.Drawing.Point(392, 85);
            this.chkjiemi.Name = "chkjiemi";
            this.chkjiemi.Size = new System.Drawing.Size(59, 19);
            this.chkjiemi.TabIndex = 29;
            this.chkjiemi.Text = "解密";
            this.chkjiemi.UseVisualStyleBackColor = true;
            // 
            // chkMerge
            // 
            this.chkMerge.AutoSize = true;
            this.chkMerge.Location = new System.Drawing.Point(466, 85);
            this.chkMerge.Name = "chkMerge";
            this.chkMerge.Size = new System.Drawing.Size(59, 19);
            this.chkMerge.TabIndex = 29;
            this.chkMerge.Text = "合并";
            this.chkMerge.UseVisualStyleBackColor = true;
            // 
            // btnChgURL
            // 
            this.btnChgURL.Location = new System.Drawing.Point(885, 10);
            this.btnChgURL.Name = "btnChgURL";
            this.btnChgURL.Size = new System.Drawing.Size(104, 27);
            this.btnChgURL.TabIndex = 35;
            this.btnChgURL.Text = "转换网址";
            this.btnChgURL.UseVisualStyleBackColor = true;
            this.btnChgURL.Click += new System.EventHandler(this.btnChgURL_Click);
            // 
            // btnModifyDir
            // 
            this.btnModifyDir.Location = new System.Drawing.Point(864, 47);
            this.btnModifyDir.Name = "btnModifyDir";
            this.btnModifyDir.Size = new System.Drawing.Size(104, 27);
            this.btnModifyDir.TabIndex = 36;
            this.btnModifyDir.Text = "修改目录";
            this.btnModifyDir.UseVisualStyleBackColor = true;
            this.btnModifyDir.Click += new System.EventHandler(this.btnModifyDir_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(985, 83);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 26);
            this.btnLoad.TabIndex = 37;
            this.btnLoad.Text = "加载列表";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1085, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 26);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "保存列表";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvFileLists
            // 
            this.lvFileLists.AllowDrop = true;
            this.lvFileLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileLists.Location = new System.Drawing.Point(4, 116);
            this.lvFileLists.Name = "lvFileLists";
            this.lvFileLists.Size = new System.Drawing.Size(1272, 465);
            this.lvFileLists.TabIndex = 26;
            this.lvFileLists.UseCompatibleStateImageBehavior = false;
            this.lvFileLists.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvFileLists_ItemDrag);
            this.lvFileLists.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvFileLists_MouseClick);
            // 
            // chkCursorFlower
            // 
            this.chkCursorFlower.AutoSize = true;
            this.chkCursorFlower.Checked = true;
            this.chkCursorFlower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCursorFlower.Location = new System.Drawing.Point(998, 15);
            this.chkCursorFlower.Name = "chkCursorFlower";
            this.chkCursorFlower.Size = new System.Drawing.Size(89, 19);
            this.chkCursorFlower.TabIndex = 38;
            this.chkCursorFlower.Text = "光标跟随";
            this.chkCursorFlower.UseVisualStyleBackColor = true;
            // 
            // tsmALLPause
            // 
            this.tsmALLPause.Name = "tsmALLPause";
            this.tsmALLPause.Size = new System.Drawing.Size(210, 24);
            this.tsmALLPause.Text = "全部暂停";
            this.tsmALLPause.Click += new System.EventHandler(this.tsmALLPause_Click);
            // 
            // tsmSelectPause
            // 
            this.tsmSelectPause.Name = "tsmSelectPause";
            this.tsmSelectPause.Size = new System.Drawing.Size(210, 24);
            this.tsmSelectPause.Text = "暂停选中行";
            this.tsmSelectPause.Click += new System.EventHandler(this.tsmSelectPause_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(180, 6);
            // 
            // Frmm3u8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 609);
            this.Controls.Add(this.chkCursorFlower);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnModifyDir);
            this.Controls.Add(this.btnChgURL);
            this.Controls.Add(this.nudBlockSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudMaxThread);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvFileLists);
            this.Controls.Add(this.btnStopALL);
            this.Controls.Add(this.chkMerge);
            this.Controls.Add(this.chkjiemi);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnDown);
            this.Name = "Frmm3u8";
            this.Text = "下载TS文件";
            this.Load += new System.EventHandler(this.Frmm3u8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxThread)).EndInit();
            this.MnuRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMaxThread;
        private System.Windows.Forms.Label label4;
        private Common.DoubleBufferListView lvFileLists;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuDelSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuStopSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuStopALL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDownSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ContextMenuStrip MnuRight;
        private System.Windows.Forms.Button btnStopALL;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.CheckBox chkjiemi;
        private System.Windows.Forms.CheckBox chkMerge;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyURL;
        private System.Windows.Forms.Button btnChgURL;
        private System.Windows.Forms.Button btnModifyDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyDir;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyURL;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectFree;
        private System.Windows.Forms.ToolStripMenuItem mnuReDown;
        private System.Windows.Forms.CheckBox chkCursorFlower;
        private System.Windows.Forms.ToolStripMenuItem tsmALLPause;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}