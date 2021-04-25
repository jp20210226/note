using MultiFileDown.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFileDown
{
    public partial class FrmTSDecrypt : Form
    {
        private string mDirSource;
        private string mDir;
        private string mFileName;
        private string mKey;
        private string miv = "                ";

        public FrmTSDecrypt()
        {
            InitializeComponent();
        }

        private void btnBrowserSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件保存目录";
            folder.ShowNewFolderButton = true;
            if(txtDirSource.Text.Length>0)
                folder.SelectedPath = txtDirSource.Text;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
                txtDirSource.Text = sPath;
                txtDir.Text = sPath;
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件保存目录";
            folder.ShowNewFolderButton = true;
            if (txtDir.Text.Length > 0)
                folder.SelectedPath = txtDir.Text;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
                txtDir.Text = sPath;
            }
        }

        private void btnJiemi_Click(object sender, EventArgs e)
        {
            if (txtDirSource.Text.Length == 0)
            {
                MessageBox.Show("请先选择加密TS文件所在目录!");
                return;
            }
            if (txtDir.Text.Length == 0)
            {
                MessageBox.Show("请先选择解密后TS文件所存放的目录!");
                return;
            }
            btnJiemi.Enabled = false;
            btnJiami.Enabled = false;
            btnMerge.Enabled = false;
            mDirSource = txtDirSource.Text.Trim();
            mDir = txtDir.Text.Trim();
            if (!Directory.Exists(mDir))
            {
                Directory.CreateDirectory(mDir);
            }
            List<string> lstFiles = new List<string>();
            if (chkKeyFromFile.Checked)
            {
                string strIndexFile = Path.Combine(mDirSource, "index.m3u8");
                if (!File.Exists(strIndexFile))
                {
                    MessageBox.Show("index.m3u8文件未找到!");
                    btnJiemi.Enabled = true;
                    btnJiami.Enabled = true;
                    btnMerge.Enabled = true;
                    return;
                }
                string strkeyFile = Path.Combine(mDirSource, "key.key");
                if (!File.Exists(strkeyFile))
                {
                    MessageBox.Show("key.key文件未找到!");
                    btnJiemi.Enabled = true;
                    btnJiami.Enabled = true;
                    btnMerge.Enabled = true;
                    return;
                }
                mKey = File.ReadAllText(strkeyFile);
                miv = "                ";
                lstFiles.AddRange( File.ReadAllLines(strIndexFile));
                CommonFunc.CreateThreadParam(DecryptFile,new object[] { lstFiles,1});

            }
            else
            {
                mKey = txtKey.Text;
                if (txtIV.Text.Length > 0)
                    miv = txtIV.Text;
                DirectoryInfo TheFolder = new DirectoryInfo(mDirSource);
                //遍历文件夹
                //foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                //    this.listBox1.Items.Add(NextFolder.Name);
                //遍历文件
                
                foreach (FileInfo NextFile in TheFolder.GetFiles("*.ts"))
                    lstFiles.Add(NextFile.Name);
                CommonFunc.CreateThreadParam(DecryptFile, new object[] { lstFiles, 0 });

            }

        }

        private void DecryptFile(object pobj)
        {
            object[] obj = (object[])pobj;
            List<string> lstFiles = (List<string>)obj[0];
            int lindex = (int)obj[1];
            string strcurrfile = "";
            UpdateProcess(0, strcurrfile);
            StreamWriter writer = null;
            if (lindex == 1)
            {
                string strIndexFile = Path.Combine(mDirSource, "index.m3u8");
                writer = File.CreateText(Path.Combine(mDir, "index.m3u8"));
            }


            FileStream stream;
            if (mFileName.Length == 0)
            {
                stream = File.Open(Path.Combine(mDir, "index.mp4"), FileMode.Create);
            }
            else
            {
                stream = File.Open(Path.Combine(mDir, mFileName), FileMode.Create);
            }

            int num = 0;
            for (int i = 0; i < lstFiles.Count; i++)
            {
                if (lindex == 1 && writer!=null)
                {
                    if (lstFiles[i].ToUpper().IndexOf("EXT-X-KEY") < 0)
                    {
                        writer.WriteLine(lstFiles[i]);
                    }
                }
                    
                if (lstFiles[i].ToLower().IndexOf(".ts") > 1)
                {
                    string strfile = Path.Combine(mDirSource, lstFiles[i]);
                    if (File.Exists(strfile))
                    {
                        try
                        {

                            byte[] buffer = CommonFunc.GetFileBytes(strfile);
                            byte[] buffer2 = AES.AESDecrypt(buffer, mKey, miv);
                            CommonFunc.WriteFileBytes(Path.Combine(mDir, lstFiles[i]), buffer2);
                            stream.Write(buffer2, 0, buffer2.Length);
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                    }
                    num++;
                    strcurrfile = lstFiles[i];
                }
                   
                UpdateProcess((int)( i * 100 / lstFiles.Count), strcurrfile);
            }
            if(lindex==1 && writer!=null)
                writer.Close();
            stream.Close();
            UpdateProcess( 100, strcurrfile);
        }

        private void UpdateProcess(int pvalue,string pfile)
        {
            this.Invoke(new Action<int>(value =>
            {
                this.stsInfo.Text = value.ToString() + "%";
                this.stsProgress.Value = value;
                this.tssFileName.Text = pfile;
                //Application.DoEvents();
                if (value == 100)
                {
                    btnJiemi.Enabled = true;
                    btnJiami.Enabled = true;
                    btnMerge.Enabled = true;
                }
            }), pvalue);
        }

        private void btnJiami_Click(object sender, EventArgs e)
        {
            if (txtDirSource.Text.Length == 0)
            {
                MessageBox.Show("请先选择加密TS文件所在目录!");
                return;
            }
            if (txtDir.Text.Length == 0)
            {
                MessageBox.Show("请先选择解密后TS文件所存放的目录!");
                return;
            }
            btnJiemi.Enabled = false;
            btnJiami.Enabled = false;
            btnMerge.Enabled = false;
            mDirSource = txtDirSource.Text.Trim();
            mDir = txtDir.Text.Trim();
            tssFileName.Text = mDir;
            if (!Directory.Exists(mDir))
            {
                Directory.CreateDirectory(mDir);
            }
            List<string> lstFiles = new List<string>();
            if (chkKeyFromFile.Checked)
            {
                string strIndexFile = Path.Combine(mDirSource, "index.m3u8");
                if (!File.Exists(strIndexFile))
                {
                    MessageBox.Show("index.m3u8文件未找到!");
                    btnJiemi.Enabled = true;
                    btnJiami.Enabled = true;
                    btnMerge.Enabled = true;
                    return;
                }
                string strkeyFile = Path.Combine(mDirSource, "key.key");
                //if (!File.Exists(strkeyFile))
                //{
                //    MessageBox.Show("key.key文件未找到!");
                //    btnJiemi.Enabled = true;
                //    btnJiami.Enabled = true;
                //    return;
                //}
                //mKey = File.ReadAllText(strkeyFile);
                mKey = AES.GetRandomString(0x10, "", true, true, true, false);
                File.WriteAllText(strkeyFile, mKey);
                miv = "                ";
                lstFiles.AddRange(File.ReadAllLines(strIndexFile));
                CommonFunc.CreateThreadParam(EncryptFile, new object[] { lstFiles, 1 });

            }
            else
            {
                mKey = txtKey.Text;
                if (txtIV.Text.Length > 0)
                    miv = txtIV.Text;
                string strkeyFile = Path.Combine(mDirSource, "key.key");
                File.WriteAllText(strkeyFile, mKey);
                DirectoryInfo TheFolder = new DirectoryInfo(mDirSource);
                //遍历文件夹
                //foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                //    this.listBox1.Items.Add(NextFolder.Name);
                //遍历文件

                foreach (FileInfo NextFile in TheFolder.GetFiles("*.ts"))
                    lstFiles.Add(NextFile.Name);
                CommonFunc.CreateThreadParam(EncryptFile, new object[] { lstFiles, 0 });

            }
        }
        private void EncryptFile(object pobj)
        {
            object[] obj = (object[])pobj;
            List<string> lstFiles = (List<string>)obj[0];
            int lindex = (int)obj[1];
            string strcurrfile = "";
            UpdateProcess(0,strcurrfile );
            StreamWriter writer = null;
            if (lindex == 1)
            {
                string strIndexFile = Path.Combine(mDirSource, "index.m3u8");
                writer = File.CreateText(Path.Combine(mDir, "index.m3u8"));
            }


            FileStream stream;
            if (mFileName.Length == 0)
            {
                stream = File.Open(Path.Combine(mDir, "index.mp4"), FileMode.Create);
            }
            else
            {
                stream = File.Open(Path.Combine(mDir, mFileName), FileMode.Create);
            }

            int num = 0;
            bool flag = false;
            for (int i = 0; i < lstFiles.Count; i++)
            {
                if (lindex == 1 && writer != null)
                {
                    if (((lstFiles[i].ToUpper().IndexOf(".TS") > 1) || (lstFiles[i].ToUpper().IndexOf("#EXTINF") > 1)) && !flag)
                    {
                        writer.WriteLine("#EXT-X-KEY:METHOD=AES-128,URI=\"key.key\"");
                        flag = true;
                    }
                }

                if (lstFiles[i].ToLower().IndexOf(".ts") > 1)
                {
                    string strfile = Path.Combine(mDirSource, lstFiles[i]);
                    if (File.Exists(strfile))
                    {
                        try
                        {
                            byte[] buffer = CommonFunc.GetFileBytes(strfile);
                            byte[] buffer2 = AES.AESEncrypt(buffer, mKey, miv);
                            CommonFunc.WriteFileBytes(Path.Combine(mDir, lstFiles[i]), buffer2);
                            stream.Write(buffer2, 0, buffer2.Length);
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                    }
                    num++;
                    strcurrfile = lstFiles[i];
                }
                UpdateProcess((int)(i * 100 / lstFiles.Count), strcurrfile);
            }
            if (lindex == 1 && writer != null)
                writer.Close();
            stream.Close();
            UpdateProcess(100, strcurrfile);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (txtDirSource.Text.Length == 0)
            {
                MessageBox.Show("请先选择TS文件所在目录!");
                return;
            }
            if (txtDir.Text.Length == 0)
            {
                MessageBox.Show("请先选择合并后文件所存放的目录!");
                return;
            }
            btnJiemi.Enabled = false;
            btnJiami.Enabled = false;
            btnMerge.Enabled = false;
            mDirSource = txtDirSource.Text.Trim();
            mDir = txtDir.Text.Trim();
            mFileName=txtFileName.Text.Trim();
            tssFileName.Text = mFileName;
            if (!Directory.Exists(mDir))
            {
                Directory.CreateDirectory(mDir);
            }
            List<string> lstFiles = new List<string>();
            if (chkKeyFromFile.Checked)
            {
                string strIndexFile = Path.Combine(mDirSource, "index.m3u8");
                if (!File.Exists(strIndexFile))
                {
                    MessageBox.Show("index.m3u8文件未找到!");
                    btnJiemi.Enabled = true;
                    btnJiami.Enabled = true;
                    btnMerge.Enabled = true;
                    return;
                }
                lstFiles.AddRange(File.ReadAllLines(strIndexFile));
            }
            else
            {
                DirectoryInfo TheFolder = new DirectoryInfo(mDirSource);
                //遍历文件夹
                //foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                //    this.listBox1.Items.Add(NextFolder.Name);
                //遍历文件

                foreach (FileInfo NextFile in TheFolder.GetFiles("*.ts"))
                    lstFiles.Add(NextFile.Name);
            }
            CommonFunc.CreateThreadParam(MergeFile, new object[] { lstFiles, 0 });

        }

        private void MergeFile(object pobj)
        {
            object[] obj = (object[])pobj;
            List<string> lstFiles = (List<string>)obj[0];
            int lindex = (int)obj[1];
            string strcurrfile = "";
            UpdateProcess(0, strcurrfile);

            FileStream stream;
            if (mFileName.Length == 0)
            {
                stream = File.Open(Path.Combine(mDir, "index.mp4"), FileMode.Create);
            }
            else
            {
                stream = File.Open(Path.Combine(mDir, mFileName), FileMode.Create);
            }
            int num = 0;
            int iprogress = 0;
            for (int i = 0; i < lstFiles.Count; i++)
            {

                if (lstFiles[i].ToLower().IndexOf(".ts") > 1)
                {
                    string strFileName = Path.GetFileName(lstFiles[i]);
                    string strfile = Path.Combine(mDirSource, strFileName);
                    if (File.Exists(strfile))
                    {
                        try
                        {
                            byte[] buffer = CommonFunc.GetFileBytes(strfile);
                            //byte[] buffer2 = AES.AESEncrypt(buffer, mKey, miv);
                            //CommonFunc.WriteFileBytes(Path.Combine(mDir, lstFiles[i]), buffer2);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                    }
                    num++;
                }
                if(iprogress!= (int)(i * 100 / lstFiles.Count))
                {

                    iprogress = (int)(i * 100 / lstFiles.Count);
                    if (lstFiles[i].ToLower().IndexOf(".ts") > 1)
                        strcurrfile = lstFiles[i];
                    UpdateProcess(iprogress, strcurrfile);
                }
                
            }
            stream.Close();
            UpdateProcess(100, strcurrfile);
        }

        private void FrmTSDecrypt_Load(object sender, EventArgs e)
        {
            //this.stsProgress.Minimum = 0;
            //this.stsProgress.Maximum = 100;
            //this.stsProgress.Value = 10;
        }

        private void txtDirSource_TextChanged(object sender, EventArgs e)
        {
            string strfile = Path.GetFileName(txtDirSource.Text);
            if(CommonFunc.IsNumber(strfile))
            {
                txtFileName.Text = strfile + ".mp4";
            }
        }
    }
}
