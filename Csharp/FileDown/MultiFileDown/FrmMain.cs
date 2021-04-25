using MultiFileDown.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFileDown
{
    public partial class FrmMain : Form
    {
        private List<FileListInfo> mfileListInfos = new List<FileListInfo>();
        private List<FileDownLoader> mfileDownLoaders = new List<FileDownLoader>();
        private bool mIsStop=true;
        private int miMaxThread;
        private int miBlockSize;
        private int mcurrindex;
        private string mDir;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //DownParam param = new DownParam();
            //param.URL = txtURL.Text;  // "http://ugcbsy.qq.com/uwMRJfz-r5jAYaQXGdGnC2_ppdhgmrDlPaRvaV7F2Ic/q14060q7kj5.p702.1.mp4?sdtfrom=v1000&type=mp4&vkey=B3A530DF2A4EFCA45D12774018792799A3328236C69C529166FB6BE82E24FA8B76BF057ABCC00F9FDE40B926DCA05BE26909D7468665ABA24FB1EC5EB5E4CA1C2937F96E9A044EBCA36A10A748BDB41D1ECD4749887DE154A2351FCCB65A9A6022F58F22039D1110A055B9F6DF505E260F895D12EE7448D6&platform=11&br=20&fmt=hd&sp=0&charge=0&vip=0&guid=DC296C161CCB75D88FDF6379EE882E7B";
            //param.Dir = txtDir.Text;
            ////string strfilename = Path.GetFileName(param.URL);
            ////if (strfilename.IndexOf('?') > 0)
            ////    strfilename = strfilename.Substring(0, strfilename.IndexOf('?'));
            //param.FileName = txtFileName.Text.Trim();
            //param.ThreadNum =(int)nudBlockSize.Value;
            //param.RowNo = 0;
            //CommonFunc.CreateThreadParam(DownFile,param);
            StartDownALL();
        }

        private void DownFile(object pobj)
        {
            DownParam dp = (DownParam)pobj;
            FileDownLoader downloader = new FileDownLoader();
            downloader.OnDownloadSize += EventDownSize;
            
            try
            {
                downloader.Init(dp.URL, dp.Dir, dp.FileName, dp.ThreadNum);
                downloader.RowNo = dp.RowNo;
                downloader.StartDown();
            }
            catch (Exception ex)
            {
                if(ex.Message== "获取文件大小失败")
                {
                    downloader.Init(dp.URL, dp.Dir, dp.FileName, 1);
                    downloader.RowNo = dp.RowNo;
                    downloader.StartDown();
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void EventDownSize(object sender, long downsize)
        {
            FileDownLoader downLoader = (FileDownLoader)sender;
            //int iseconds =(int)(DateTime.Now - downLoader.StartTime).TotalSeconds;
            //string strlog = "下载进度:" + SizeUnitChg(downsize) + "/" + SizeUnitChg(downLoader.getFileSize());
            //strlog += " 用时:" + iseconds.ToString() + "秒";
            //if (iseconds>0)
            //    strlog += " 下载速度:" + SizeUnitChg(downsize / iseconds) + "/秒";
            //if (downsize == downLoader.getFileSize())
            //    strlog += " 下载完成!";
            FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(downLoader.getURL(), StringComparison.OrdinalIgnoreCase));
            if (fi != null)
            {
                fi.FileSize = downLoader.getFileSize();
                fi.FileName = downLoader.getSaveFileName();
                fi.DownSize = downsize;
                fi.StartTime = downLoader.StartTime;
                fi.isModify = true;
                //fi.DownProgress=
                //this.Invoke(new Action(() =>
                //{
                //    //lblInfo.Text = strlog;
                //    ShowFileInfo(fi, lvFileLists);
                //}));

                if ((downsize > 0 && downsize == downLoader.getFileSize()))   //
                {
                    fi.Status = DownStatus.Finished;
                    this.Invoke(new Action(() =>
                    {
                        lblInfo.Text = (downLoader.RowNo + 1) + "/" + mfileListInfos.Count;
                    }));
                    mfileDownLoaders.Remove(downLoader);
                }
                else if (fi.FileSize <= 0 && downLoader.Finished && downsize <= 0)  //下载大小为0下载错误
                {
                    fi.Status = DownStatus.Error;
                    this.Invoke(new Action(() =>
                    {
                        lblInfo.Text = (downLoader.RowNo + 1) + "/" + mfileListInfos.Count;
                    }));
                    mfileDownLoaders.Remove(downLoader);

                }
                else if (mIsStop == false && downLoader.getFileSize() > 0 && downsize > downLoader.getFileSize())
                {
                    //下载长度超过实际长度,重新下载
                    CommonFunc.CreateThreadParam(ReDown, downLoader);
                }
                else if (mIsStop)
                {
                    if (File.Exists(downLoader.getFullFileName()))
                    {
                        File.Delete(downLoader.getFullFileName());
                    }
                }
                ShowFileInfoT(fi, lvFileLists);
            }
            
            
        }

        private string SizeUnitChg(float Size)
        {
            float num = Size;
            string[] strArray = new string[] { "B", "KB", "MB", "GB" };
            int index = 0;
            while ((num >= 1024f) && ((index + 1) < strArray.Length))
            {
                index++;
                num /= 1024f;
            }
            return $"{num:0.##} {strArray[index]}";
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
                txtDir.Text=sPath;
            }
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strfilename = Path.GetFileName(txtURL.Text);
                if (strfilename.IndexOf('?') > 0)
                    strfilename = strfilename.Substring(0, strfilename.IndexOf('?'));
                txtFileName.Text = strfilename;
            }
            catch (Exception)
            {

            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string strpath = txtDir.Text;
            if (strpath[strpath.Length - 1] != '\\')
                strpath += "\\";
            string strFileName = txtFileName.Text;
            System.Diagnostics.Process.Start("Explorer.exe", @"/select,"+ Path.Combine(strpath,strFileName));
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void InitControl()
        {
            lvFileLists.Clear();
            lvFileLists.View = View.Details;
            lvFileLists.GridLines = true;
            lvFileLists.FullRowSelect = true;
            lvFileLists.MultiSelect = true;

            lvFileLists.Columns.Add("序号", 50, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("文件名", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("总大小", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("下载大小", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("进度", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("速度(秒)", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("用时", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("保存目录", 80, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("状态", 100, HorizontalAlignment.Center);
            lvFileLists.Columns.Add("网址", 100, HorizontalAlignment.Center);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Length <= 0)
            {
                MessageBox.Show("请输入网址!");
                txtURL.Focus();
                return;
            }
            if (txtDir.Text.Length <= 0)
            {
                MessageBox.Show("请选择保存目录!");
                btnBrowser.Focus();
                return;
            }
            string strurl = Uri.UnescapeDataString(txtURL.Text.Trim().Replace("&amp;","&"));
            string strfilename = txtFileName.Text.Trim();
            string strdir = txtDir.Text.Trim();
            if(AddFileLists(strurl,strfilename,strdir,true))
                showFileInfotolv(mfileListInfos, lvFileLists);
            if (chkAutoStart.Checked && mIsStop)  //立即下载
                StartDownALL();
        }

        private bool AddFileLists(string purl,string pFileName,string pDir,bool pExistsInfo=false)
        {
            FileListInfo fi = null;
            bool badd = true;
            string strurl = purl;
            fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
            if (fi != null)
            {
                if (fi.Status == DownStatus.Finished)
                {
                    if (pExistsInfo)
                    {
                        if (MessageBox.Show("列表中已存在下载完成记录,确认要重新下载吗(Y/N)?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    else
                        return false;
                    
                }
                else
                {
                    if (pExistsInfo)
                        MessageBox.Show("列表中已存在下载地址!");
                    return false;
                }
                badd = false;
            }
            else
            {
                fi = new FileListInfo();
            }
            fi.FileName = pFileName;
            fi.URL = strurl;
            fi.Dir = pDir;
            if (chkAutoStart.Checked)
                fi.Status = DownStatus.Waiting;
            else
                fi.Status = DownStatus.Free;
            fi.isModify = true;
            if (badd)
                mfileListInfos.Add(fi);
            return true;
        }

        private void showFileInfotolv(List<FileListInfo> plfi, DoubleBufferListView plv, bool isrefresh = false)
        {
            
            try
            {
                plv.BeginUpdate();
                for (int i = 0; i < plfi.Count; i++)
                {
                    if (isrefresh == false && plfi[i].isModify == false)
                        continue;
                    ShowFileInfoT(plfi[i], plv);
                }
            }
            catch (Exception ex)
            {
                //addlogT("showorderinfotolv错误：" + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                plv.EndUpdate();
            }
        }

        private void ShowFileInfoT(FileListInfo pfi, DoubleBufferListView plv)
        {
            this.Invoke(new Action<FileListInfo, DoubleBufferListView>(ShowFileInfo), new object[] { pfi,plv });
        }
        private void ShowFileInfo(FileListInfo pfi, DoubleBufferListView plv)
        {
            ListViewItem lvi = null;
            if (plv.Items.Count > 0 && pfi.URL != "")
            {
                lvi = plv.FindItemWithText(pfi.URL, true, 0);
            }


            string strstatus = getstatus(pfi.Status);
            int iseconds = 0;
            if (pfi.StartTime.Year > 1000)
                iseconds = (int)(DateTime.Now - pfi.StartTime).TotalSeconds;
            int itsecond = 1;
            if (iseconds > 0)
                itsecond = iseconds;
            string strdownprogress = "0%";
            if (pfi.FileSize > 0)
                strdownprogress = $"{(pfi.DownSize * 100.0 / pfi.FileSize):0.##}%";
            else if(pfi.FileSize<=0 && pfi.Status== DownStatus.Finished)
                strdownprogress = "100%";
            if (lvi != null)
            {
                lvi.SubItems[1].Text = pfi.FileName;
                lvi.SubItems[2].Text = SizeUnitChg(pfi.FileSize);
                lvi.SubItems[3].Text = SizeUnitChg(pfi.DownSize);

                lvi.SubItems[4].Text = strdownprogress;
                lvi.SubItems[5].Text = SizeUnitChg(pfi.DownSize / itsecond);
                lvi.SubItems[6].Text = CommonFunc.SecondsToTimeStr(iseconds);
                lvi.SubItems[7].Text = pfi.Dir;
                lvi.SubItems[8].Text = strstatus;
            }
            else
            {
                int lcount = plv.Items.Count + 1;
                ListViewItem item = plv.Items.Add(lcount.ToString());
                //ListViewItem item = plv.Items.Insert(0, lcount.ToString());
                //item.UseItemStyleForSubItems = false;
                item.SubItems.Add(pfi.FileName);
                item.SubItems.Add(SizeUnitChg(pfi.FileSize));
                item.SubItems.Add(SizeUnitChg(pfi.DownSize));
                item.SubItems.Add(strdownprogress);


                item.SubItems.Add(SizeUnitChg(pfi.DownSize / itsecond));

                item.SubItems.Add(CommonFunc.SecondsToTimeStr(iseconds));
                item.SubItems.Add(pfi.Dir);

                item.SubItems.Add(strstatus);
                item.SubItems.Add(pfi.URL);
            }
            pfi.isModify = false;
        }

        private string getstatus(DownStatus pstatus)
        {
            string strret = "";
            switch (pstatus)
            {
                case DownStatus.Free:
                    strret = "空闲中";
                    break;
                case DownStatus.Waiting:
                    strret = "队列中";
                    break;
                case DownStatus.Downing:
                    strret = "下载中";
                    break;
                case DownStatus.Finished:
                    strret = "下载完成";
                    break;
                case DownStatus.Pause:
                    strret = "暂停中";
                    break;
                case DownStatus.Error:
                    strret = "错误";
                    break;
                default:
                    strret = "空闲中";
                    break;
            }
            return strret;
        }

        private void lvFileLists_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MnuRight.Show(lvFileLists, e.Location);//鼠标右键按下弹出菜单
            }
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要清除所有列表吗(Y/N)?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            foreach(var fld in mfileDownLoaders)
            {
                fld.Stop();
            }
            mfileDownLoaders.Clear();
            lvFileLists.Items.Clear();
            mfileListInfos.Clear();
            mcurrindex = 0;
        }

        private void mnuDelSelect_Click(object sender, EventArgs e)
        {
            for(int i = lvFileLists.SelectedItems.Count-1; i >=0 ; i--)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi == null)
                    lvFileLists.Items.Remove(lvi);
                else
                {
                    if(fi.Status== DownStatus.Downing)
                    {
                        if (MessageBox.Show("当前文件正在下载中,确认要删除吗(Y/N)?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                            continue;
                        FileDownLoader fdl= mfileDownLoaders.Find(s => s.getURL().Equals(strurl, StringComparison.OrdinalIgnoreCase));
                        if (fdl != null)
                        {
                            fdl.Stop();
                        }
                    }
                    lvFileLists.Items.Remove(lvi);
                    mfileListInfos.Remove(fi);
                }
            }
            
        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            mDir = txtDir.Text.Trim();
            if (!Directory.Exists(this.mDir))
            {
                Directory.CreateDirectory(this.mDir);
            }
            mcurrindex = 0;
            StartDownALL();
        }

        private void StartDownALL()
        {
            btnDown.Enabled = false;
            btnStopALL.Enabled = true;
            miMaxThread = (int)nudMaxThread.Value;
            miBlockSize = (int)nudBlockSize.Value;
            mIsStop = false;

            for (int i = 0; i < mfileListInfos.Count; i++)
            {
                if (mfileListInfos[i].Status != DownStatus.Finished && mfileListInfos[i].Status != DownStatus.Downing)
                {
                    mfileListInfos[i].Status = DownStatus.Waiting;
                    mfileListInfos[i].isModify = true;
                    ShowFileInfo(mfileListInfos[i], lvFileLists);
                }
            }
            CommonFunc.CreateThread(DownALL);
        }

        private void DownALL()
        {
            //int icurrindex = 0;
            while (mIsStop == false)
            {
                while (mIsStop == false && mfileDownLoaders.Count < miMaxThread)
                {
                    for(int i = mcurrindex; i < mfileListInfos.Count; i++)
                    {
                        if (mfileListInfos[i].Status == DownStatus.Waiting || mfileListInfos[i].Status == DownStatus.Free)
                        {
                            mfileListInfos[i].Status = DownStatus.Downing;
                            mfileListInfos[i].isModify = true;
                            FileDownLoader fdl = new FileDownLoader();
                            fdl.OnDownloadSize += EventDownSize;
                            mfileDownLoaders.Add(fdl);
                            CommonFunc.CreateThreadParam(CreateFileDown,new object[] { i,fdl } ,10);
                            ShowFileInfoT(mfileListInfos[i], lvFileLists);
                            mcurrindex = i+1;
                        }
                        if (mfileDownLoaders.Count >= miMaxThread || mIsStop)
                            break;
                    }
                    Thread.Sleep(10);
                    if (mcurrindex >= mfileListInfos.Count)
                        mcurrindex = 0;
                    if (mfileDownLoaders.Count == 0)   //全部完成
                    {
                        mIsStop = true;
                        try
                        {
                            this.Invoke(new Action(() =>
                            {
                                btnDown.Enabled = true;
                                btnStopALL.Enabled = false;
                            }));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                
                Thread.Sleep(1000);
            }
        }
        private void ReDown(object pobj)
        {
            FileDownLoader downLoader = (FileDownLoader)pobj;
            downLoader.Stop();
            downLoader.StartDown();
        }
        private void CreateFileDown(object pobj)
        {
            object[] obj = (object[])pobj;
            int i =(int)obj[0];
            FileDownLoader downloader =(FileDownLoader)obj[1];
            DownParam param = new DownParam();
            param.URL = mfileListInfos[i].URL;
            param.Dir = mfileListInfos[i].Dir;
            //string strfilename = Path.GetFileName(param.URL);
            //if (strfilename.IndexOf('?') > 0)
            //    strfilename = strfilename.Substring(0, strfilename.IndexOf('?'));
            param.FileName = mfileListInfos[i].FileName;
            param.ThreadNum = miBlockSize;
            param.RowNo = i;
            
            try
            {
                //downloader = new FileDownLoader(param);
                downloader.Init(param);
                //downloader.OnDownloadSize += EventDownSize;
                downloader.RowNo = param.RowNo;
                downloader.StartDown();
            }
            catch (Exception ex)
            {
                if (ex.Message == "获取文件大小失败")
                {
                    param.ThreadNum = 1;
                    //downloader = new FileDownLoader(param);
                    //downloader.OnDownloadSize += EventDownSize;
                    downloader.Init(param);
                    
                    downloader.RowNo = param.RowNo;
                    downloader.StartDown();
                }else if (ex.Message == "操作超时")
                {
                    //param.ThreadNum = 1;
                    //downloader = new FileDownLoader(param);
                    //downloader.OnDownloadSize += EventDownSize;
                    CreateFileDown(pobj);
                    //downloader.Init(param);

                    //downloader.RowNo = param.RowNo;
                    //downloader.StartDown();
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    mfileListInfos[i].Status = DownStatus.Error;
                    mfileListInfos[i].isModify = true;
                    ShowFileInfoT(mfileListInfos[i], lvFileLists);
                    mfileDownLoaders.Remove(downloader);
                }
                    
            }
        }

        private void mnuDownSelect_Click(object sender, EventArgs e)
        {
            for (int i =0; i < lvFileLists.SelectedItems.Count ; i++)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status != DownStatus.Downing) //&& fi.Status != DownStatus.Finished 
                {
                    fi.Status = DownStatus.Waiting;
                    fi.isModify = true;
                    ShowFileInfoT(fi, lvFileLists);
                }

            }
            if (mIsStop)
            {
                StartDownALL();
            }
                
        }

        private void mnuStopALL_Click(object sender, EventArgs e)
        {
            StopALL();
        }

        private void StopALL()
        {
            mIsStop = true;
            for (int i = 0; i < lvFileLists.Items.Count; i++)
            {
                ListViewItem lvi = lvFileLists.Items[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status == DownStatus.Downing)
                {
                    fi.Status = DownStatus.Free;
                    fi.isModify = true;
                    ShowFileInfo(fi, lvFileLists);
                }

            }
            for (int i = 0; i < mfileDownLoaders.Count; i++)
            {
                FileDownLoader fdl = mfileDownLoaders[i];
                if (fdl != null)
                {
                    fdl.Stop();
                    //mfileDownLoaders.Remove(fdl);
                }
            }
            
            mfileDownLoaders.Clear();
        }

        private void mnuStopSelect_Click(object sender, EventArgs e)
        {
            for (int i = lvFileLists.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status == DownStatus.Downing)
                {
                    fi.Status = DownStatus.Free;
                    fi.isModify = true;
                    ShowFileInfo(fi, lvFileLists);
                    FileDownLoader fdl = mfileDownLoaders.Find(s => s.getURL().Equals(strurl, StringComparison.OrdinalIgnoreCase));
                    if (fdl != null)
                    {
                        fdl.Stop();
                        mfileDownLoaders.Remove(fdl);
                    }
                }

            }
        }

        private void btnStopALL_Click(object sender, EventArgs e)
        {
            StopALL();
            btnDown.Enabled = true;
            btnStopALL.Enabled = false;
        }

        private void btnBatchAdd_Click(object sender, EventArgs e)
        {
            FrmBatchAdd frm = new FrmBatchAdd();
            frm.mFrmMain = this;
            frm.ShowDialog(this);
        }

        public void BatchAddURL(List<string> pLstr)
        {
            string strdir = txtDir.Text.Trim();
            for(int i = 0; i < pLstr.Count; i++)
            {
                string strurl = pLstr[i];
                if (strurl.Length > 7)
                {
                    try
                    {
                        string strfilename = Path.GetFileName(strurl);
                        if (strfilename.IndexOf('?') > 0)
                            strfilename = strfilename.Substring(0, strfilename.IndexOf('?'));
                        AddFileLists(strurl, strfilename, strdir, false);
                    }
                    catch (Exception)
                    {

                    }
                }
                
                
            }
            showFileInfotolv(mfileListInfos, lvFileLists);
            if (chkAutoStart.Checked && mIsStop)
                StartDownALL();
        }

        private void mnuSelectFile_Click(object sender, EventArgs e)
        {
            if (lvFileLists.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[0];
                string strpath = lvi.SubItems[7].Text;
                string strFileName = lvi.SubItems[1].Text;
                System.Diagnostics.Process.Start("Explorer.exe", @"/select," + Path.Combine(strpath, strFileName));
            }
        }

        private void btnm3u8_Click(object sender, EventArgs e)
        {
            //Frmm3u8 frm = new Frmm3u8();
            //frm.Show();
            Thread s = new Thread(() => Application.Run(new Frmm3u8()));
            s.SetApartmentState(ApartmentState.STA);
            s.Start();
        }

        private void mnuCopyURL_Click(object sender, EventArgs e)
        {
            if (lvFileLists.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[0];
                string strurl = lvi.SubItems[9].Text;
                Clipboard.Clear();
                Clipboard.SetText(strurl);
            }
        }

        private void txtURL_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtURL.Tag == null)
            {
                txtURL.Tag = 1;
                txtURL.SelectAll();
            }
        }

        private void txtURL_Leave(object sender, EventArgs e)
        {
            txtURL.Tag = null;
        }

        private void btnTSJJm_Click(object sender, EventArgs e)
        {
            //FrmTSDecrypt frm = new FrmTSDecrypt();
            //frm.Show();

            //CommonFunc.CreateThread(() => Application.Run(new FrmTSDecrypt()));  //后台线程
            
            Thread s = new Thread(() => Application.Run(new FrmTSDecrypt()));
            s.SetApartmentState(ApartmentState.STA);
            s.Start();
        }

        private void tsmALLPause_Click(object sender, EventArgs e)
        {
            PauseALL();
        }

        private void PauseALL()
        {
            for (int i = 0; i < lvFileLists.Items.Count; i++)
            {
                ListViewItem lvi = lvFileLists.Items[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status != DownStatus.Downing && fi.Status != DownStatus.Finished && fi.Status != DownStatus.Error)
                {
                    fi.Status = DownStatus.Pause;
                    fi.isModify = true;
                    ShowFileInfo(fi, lvFileLists);
                }

            }
        }

        private void tsmSelectPause_Click(object sender, EventArgs e)
        {
            for (int i = lvFileLists.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status != DownStatus.Downing && fi.Status != DownStatus.Finished && fi.Status != DownStatus.Error)
                {
                    fi.Status = DownStatus.Pause;
                    fi.isModify = true;
                    ShowFileInfo(fi, lvFileLists);
                }

            }
        }

        private void tsmReDown_Click(object sender, EventArgs e)
        {
            if (lvFileLists.SelectedItems.Count > 0)
            {
                int lindex = lvFileLists.SelectedItems[0].Index;
                if (lindex < mcurrindex)
                    mcurrindex = lindex;

                mDir = txtDir.Text.Trim();
                if (!Directory.Exists(this.mDir))
                {
                    Directory.CreateDirectory(this.mDir);
                }
                for (int i = 0; i < lvFileLists.SelectedItems.Count; i++)
                {
                    ListViewItem lvi = lvFileLists.SelectedItems[i];
                    string strurl = lvi.SubItems[9].Text;
                    FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                    if (fi != null && fi.Status == DownStatus.Downing)
                    {
                        FileDownLoader fdl = mfileDownLoaders.Find(s => s.getURL().Equals(strurl, StringComparison.OrdinalIgnoreCase));
                        if (fdl != null)
                        {
                            fdl.Stop();
                            mfileDownLoaders.Remove(fdl);
                        }
                        fi.Status = DownStatus.Waiting;
                        fi.isModify = true;
                        ShowFileInfoT(fi, lvFileLists);

                    }
                    else if (fi != null) //&& fi.Status != DownStatus.Finished 
                    {
                        fi.Status = DownStatus.Waiting;
                        fi.isModify = true;
                        ShowFileInfoT(fi, lvFileLists);
                    }

                }
                if (mIsStop)
                {
                    StartDownALL();
                }
            }
        }

        private void btnModifyDir_Click(object sender, EventArgs e)
        {
            string strdir = txtDir.Text.Trim();
            for (int i = 0; i < mfileListInfos.Count; i++)
            {
                mfileListInfos[i].Dir = strdir;
            }
            for (int i = 0; i < lvFileLists.Items.Count; i++)
            {
                lvFileLists.Items[i].SubItems[7].Text = strdir;
            }
        }
    }
}
