namespace MultiFileDown
{
    partial class FrmTSDecrypt
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
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtDirSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowserSource = new System.Windows.Forms.Button();
            this.chkKeyFromFile = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJiemi = new System.Windows.Forms.Button();
            this.btnJiami = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.stS = new System.Windows.Forms.StatusStrip();
            this.stsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.stsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tssFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(488, 58);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(104, 27);
            this.btnBrowser.TabIndex = 26;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "保存目录";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(87, 60);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(395, 25);
            this.txtDir.TabIndex = 24;
            this.txtDir.Text = "F:\\test\\1";
            // 
            // txtDirSource
            // 
            this.txtDirSource.Location = new System.Drawing.Point(87, 27);
            this.txtDirSource.Name = "txtDirSource";
            this.txtDirSource.Size = new System.Drawing.Size(395, 25);
            this.txtDirSource.TabIndex = 24;
            this.txtDirSource.Text = "F:\\test";
            this.txtDirSource.TextChanged += new System.EventHandler(this.txtDirSource_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "源目录";
            // 
            // btnBrowserSource
            // 
            this.btnBrowserSource.Location = new System.Drawing.Point(488, 25);
            this.btnBrowserSource.Name = "btnBrowserSource";
            this.btnBrowserSource.Size = new System.Drawing.Size(104, 27);
            this.btnBrowserSource.TabIndex = 26;
            this.btnBrowserSource.Text = "浏览";
            this.btnBrowserSource.UseVisualStyleBackColor = true;
            this.btnBrowserSource.Click += new System.EventHandler(this.btnBrowserSource_Click);
            // 
            // chkKeyFromFile
            // 
            this.chkKeyFromFile.AutoSize = true;
            this.chkKeyFromFile.Checked = true;
            this.chkKeyFromFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeyFromFile.Location = new System.Drawing.Point(414, 128);
            this.chkKeyFromFile.Name = "chkKeyFromFile";
            this.chkKeyFromFile.Size = new System.Drawing.Size(113, 19);
            this.chkKeyFromFile.TabIndex = 27;
            this.chkKeyFromFile.Text = "文件读取KEY";
            this.chkKeyFromFile.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(87, 122);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(291, 25);
            this.txtKey.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "KEY";
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(87, 153);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(291, 25);
            this.txtIV.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "IV";
            // 
            // btnJiemi
            // 
            this.btnJiemi.Location = new System.Drawing.Point(114, 216);
            this.btnJiemi.Name = "btnJiemi";
            this.btnJiemi.Size = new System.Drawing.Size(112, 38);
            this.btnJiemi.TabIndex = 30;
            this.btnJiemi.Text = "解密";
            this.btnJiemi.UseVisualStyleBackColor = true;
            this.btnJiemi.Click += new System.EventHandler(this.btnJiemi_Click);
            // 
            // btnJiami
            // 
            this.btnJiami.Location = new System.Drawing.Point(288, 216);
            this.btnJiami.Name = "btnJiami";
            this.btnJiami.Size = new System.Drawing.Size(112, 38);
            this.btnJiami.TabIndex = 30;
            this.btnJiami.Text = "加密";
            this.btnJiami.UseVisualStyleBackColor = true;
            this.btnJiami.Click += new System.EventHandler(this.btnJiami_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(443, 216);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(112, 38);
            this.btnMerge.TabIndex = 34;
            this.btnMerge.Text = "合并";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // stS
            // 
            this.stS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsProgress,
            this.stsInfo,
            this.tssFileName});
            this.stS.Location = new System.Drawing.Point(0, 286);
            this.stS.Name = "stS";
            this.stS.Size = new System.Drawing.Size(632, 25);
            this.stS.TabIndex = 35;
            this.stS.Text = "statusStrip1";
            // 
            // stsProgress
            // 
            this.stsProgress.Name = "stsProgress";
            this.stsProgress.Size = new System.Drawing.Size(300, 19);
            // 
            // stsInfo
            // 
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Size = new System.Drawing.Size(0, 20);
            this.stsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(87, 91);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(395, 25);
            this.txtFileName.TabIndex = 24;
            this.txtFileName.Text = "index.mp4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "文件名";
            // 
            // tssFileName
            // 
            this.tssFileName.Name = "tssFileName";
            this.tssFileName.Size = new System.Drawing.Size(0, 20);
            // 
            // FrmTSDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 311);
            this.Controls.Add(this.stS);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnJiami);
            this.Controls.Add(this.btnJiemi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.chkKeyFromFile);
            this.Controls.Add(this.btnBrowserSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.txtDirSource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmTSDecrypt";
            this.Text = "TS文件解密";
            this.Load += new System.EventHandler(this.FrmTSDecrypt_Load);
            this.stS.ResumeLayout(false);
            this.stS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtDirSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowserSource;
        private System.Windows.Forms.CheckBox chkKeyFromFile;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnJiemi;
        private System.Windows.Forms.Button btnJiami;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.StatusStrip stS;
        private System.Windows.Forms.ToolStripProgressBar stsProgress;
        private System.Windows.Forms.ToolStripStatusLabel stsInfo;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel tssFileName;
    }
}