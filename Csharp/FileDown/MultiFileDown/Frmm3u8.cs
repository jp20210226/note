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
    public partial class Frmm3u8 : Form
    {
        private string mkey = "";
        private string miv = "                ";
        private string mURL;
        private string mDir;
        private List<FileListInfo> mfileListInfos = new List<FileListInfo>();
        private List<FileDownLoader> mfileDownLoaders = new List<FileDownLoader>();
        private bool mIsStop = true;
        private int miMaxThread;
        private int miBlockSize;
        private int mMergeRowno;
        private bool mIsJiemi;
        private bool mIsMerge;
        private bool mIsAutoDown;
        private int mcurrindex;

        public Frmm3u8()
        {
            InitializeComponent();
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

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请先输入m3u8网址!");
                txtURL.Focus();
                return;
            }
            if (txtDir.Text.Trim().Length == 0)
            {
                MessageBox.Show("请选择保存目录!");
                return;
            }
            mMergeRowno = 0;
            mkey = "";
            mIsAutoDown = chkAutoStart.Checked;
            //mfileListInfos.Clear();
            //mfileDownLoaders.Clear();
            //lvFileLists.Items.Clear();
            mURL = txtURL.Text.Trim();
            mDir = txtDir.Text.Trim();
            if (!Directory.Exists(this.mDir))
            {
                Directory.CreateDirectory(this.mDir);
            }
            GetFileLists(mURL);
        }

        private void GetFileLists(string pURL,int RowNO=0)
        {
            HttpHelper hh = new HttpHelper();
            hh.OnResultInfo += EventResultInfo;
            hh.AgentIP = "";
            TParam param = new TParam();
            param.RowNO = RowNO;
            param.URL = pURL;
            param.ReTimes = 0;
            param.IsMulti = false;
            CommonFunc.CreateThreadParam(hh.GetHtml, param);
        }

        private void EventResultInfo(object sender, ResultInfo e)
        {
            ResultInfo ri = e;
            if (ri.state == ResultState.OK)
            {
                if (ri.RowNO == 1)   //key
                {
                    mkey = ri.RetStr;
                    string strfilename = Path.Combine(mDir, "key.key");
                    File.WriteAllText(strfilename, mkey);
                }
                else
                {
                    string strurlpath = HttpHelper.GetURLPath(mURL);
                    string strret = ri.RetStr;
                    int lm3u8pos = strret.IndexOf(".m3u8", StringComparison.OrdinalIgnoreCase);
                    if (lm3u8pos > 0)
                    {
                        //int lpos = strret.IndexOf("RESOLUTION=", StringComparison.OrdinalIgnoreCase);
                        //if (lm3u8pos > lpos)
                        //{
                        //    string strnewfilename = strret.Substring(lpos + 11, lm3u8pos - lpos - 6);
                        //    strnewfilename = strnewfilename.Substring(strnewfilename.IndexOf('\n')+1);
                        //    GetFileLists(strurlpath + strnewfilename);
                        //}
                        int lpos = strret.TrimEnd('\n').LastIndexOf('\n');
                        string strnewfilename = strret.Substring(lpos + 1, lm3u8pos - lpos + 4);
                        //strnewfilename = strnewfilename.Substring(strnewfilename.IndexOf('\n') + 1);
                        if (strnewfilename.StartsWith("/"))
                        {
                            //lpos = strurlpath.IndexOf('/', 9);
                            strurlpath = HttpHelper.GetURLHost(strurlpath);  // strurlpath.Substring(0,lpos);
                        }
                        GetFileLists(strurlpath + strnewfilename);
                        return;
                    }
                    string strfilename = Path.Combine(mDir, "index.m3u8");
                    File.WriteAllText(strfilename, strret);

                    CommonFunc.CreateThreadParam(ShowFileListT, ri);

                }
            }
            else
            {
                MessageBox.Show(ri.RetStr);
            }
        }

        private void ShowFileListT(object obj)
        {
            ResultInfo ri= (ResultInfo)obj;
            string strret = ri.RetStr;
            string strurlpath = HttpHelper.GetURLPath(mURL);
            string[] strlines = strret.Split(new char[] { '\r', '\n' });

            int icount = mfileListInfos.Count;
            if (icount > 0)
                icount--;
            for (int i = 0; i < strlines.Length; i++)
            {
                if (strlines[i].IndexOf("x-key", StringComparison.OrdinalIgnoreCase) > 1 && strlines[i].IndexOf("X-KEY:METHOD=NONE", StringComparison.OrdinalIgnoreCase) < 0)   //X-KEY:METHOD=NONE
                {
                    string strnewfilename = "key.key";
                    strurlpath = HttpHelper.GetURLPath(ri.URL);
                    GetFileLists(strurlpath + strnewfilename, 1);
                    //return;
                }
                else if (strlines[i].ToLower().IndexOf(".ts") > 1)
                {
                    string strurl = "";
                    string strName = "";
                    if (strlines[i].IndexOf("://") > 0)
                    {
                        strurl = strlines[i];
                        strName = Path.GetFileName(strurl);
                    }
                    else
                    {
                        if (strlines[i].StartsWith("/"))
                        {
                            strurlpath = HttpHelper.GetURLHost(ri.URL);
                            strurl = strurlpath + strlines[i];
                            strName = Path.GetFileName(strlines[i]);
                        }
                        else
                        {
                            strurlpath = HttpHelper.GetURLPath(ri.URL);
                            strurl = strurlpath + strlines[i];
                            strName = Path.GetFileName(strlines[i]);
                        }

                    }
                    if (strName.IndexOf("?") > 0)
                    {
                        strName = strName.Substring(0, strName.IndexOf("?"));
                    }
                    AddFileLists(strurl, strName, mDir, false);
                }
            }
            CommonFunc.CreateThreadParam(ShowListsThread, icount);

            if (mIsAutoDown && mIsStop && mfileListInfos.Count > 0)
                StartDownALLT();
        }

        private bool AddFileLists(string purl, string pFileName, string pDir, bool pExistsInfo = false)
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
            if (mIsAutoDown)
                fi.Status = DownStatus.Waiting;
            else
                fi.Status = DownStatus.Free;
            fi.isModify = true;
            if (badd)
                mfileListInfos.Add(fi);
            return true;
        }

        private void showFileInfotolvT(List<FileListInfo> pfi, DoubleBufferListView plv, bool isrefresh = false,int pcount=0)
        {
            this.Invoke(new Action<List<FileListInfo>, DoubleBufferListView,bool,int>(showFileInfotolv), new object[] { pfi, plv, isrefresh, pcount });
        }
        private void showFileInfotolv(List<FileListInfo> plfi, DoubleBufferListView plv, bool isrefresh = false, int pcount = 0)
        {
            bool isupdate = true;
            try
            {
                //if (plv.Items.Count == 0)
                //{
                    plv.BeginUpdate();
                //}
                //else
                //{
                //    isupdate = false;
                //}

                    
                for (int i = pcount; i < plfi.Count; i++)
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
                if(isupdate)
                    plv.EndUpdate();
                lblInfo.Text = plv.Items.Count.ToString();
            }
        }

        private void ShowFileInfoT(FileListInfo pfi, DoubleBufferListView plv)
        {
            this.Invoke(new Action<FileListInfo, DoubleBufferListView>(ShowFileInfo), new object[] { pfi, plv });
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
            else if (pfi.FileSize <= 0 && pfi.Status == DownStatus.Finished)
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

        private void Frmm3u8_Load(object sender, EventArgs e)
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
            foreach (var fld in mfileDownLoaders)
            {
                fld.Stop();
            }
            mfileDownLoaders.Clear();
            lvFileLists.Items.Clear();
            mfileListInfos.Clear();
            mcurrindex = 0;
            mMergeRowno = 0;
        }

        private void mnuDelSelect_Click(object sender, EventArgs e)
        {
            for (int i = lvFileLists.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi == null)
                    lvFileLists.Items.Remove(lvi);
                else
                {
                    if (fi.Status == DownStatus.Downing)
                    {
                        if (MessageBox.Show("当前文件正在下载中,确认要删除吗(Y/N)?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                            continue;
                        FileDownLoader fdl = mfileDownLoaders.Find(s => s.getURL().Equals(strurl, StringComparison.OrdinalIgnoreCase));
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
            mMergeRowno = 0;
            StartDownALL();
        }

        private void StartDownALLT()
        {
            this.Invoke(new Action(StartDownALL));
        }
        private void StartDownALL()
        {
            btnDown.Enabled = false;
            btnStopALL.Enabled = true;
            miMaxThread = (int)nudMaxThread.Value;
            miBlockSize = (int)nudBlockSize.Value;
            mIsJiemi = chkjiemi.Checked;
            mIsMerge = chkMerge.Checked;
            mIsStop = false;
            
            //for (int i = 0; i < mfileListInfos.Count; i++)
            //{
            //    if (mfileListInfos[i].Status != DownStatus.Finished 
            //        && mfileListInfos[i].Status != DownStatus.Downing
            //        && mfileListInfos[i].Status != DownStatus.Waiting)
            //    {
            //        mfileListInfos[i].Status = DownStatus.Waiting;
            //        mfileListInfos[i].isModify = true;
            //        ShowFileInfoT(mfileListInfos[i], lvFileLists);
            //    }
            //}
            CommonFunc.CreateThread(DownALL);
            if(mIsJiemi || mIsMerge)
                CommonFunc.CreateThread(MergeAndJiemi);
        }

        private void MergeAndJiemi()
        {
            FileStream fsMerge=null;
            string strMergefile= Path.Combine(mDir, "index.mp4");
            //if (File.Exists(strMergefile))
            //{
            //    string strnewfile = CommonFunc.GetNewFileName(strMergefile);
            //    strMergefile = Path.Combine(mDir, strnewfile);
            //}
            if (mIsMerge)
            {
                if (mMergeRowno == 0)
                {
                    //fsMerge = File.Open(strMergefile, FileMode.Create);
                    fsMerge = new FileStream(strMergefile, FileMode.Create, FileAccess.Write);

                }
                else
                {
                    //fsMerge = File.Open(strMergefile, FileMode.OpenOrCreate);
                    fsMerge = new FileStream(strMergefile, FileMode.Append, FileAccess.Write);

                }
                    
            }
                
            while (mMergeRowno < mfileListInfos.Count)
            {
                FileListInfo fi = mfileListInfos[mMergeRowno];
                byte[] buffer=null;
                if (mIsJiemi || mIsMerge )
                {
                    //下载完成
                    if (fi.Status == DownStatus.Finished)
                    {
                        string strfilename = Path.Combine(fi.Dir, fi.FileName);
                        //解密
                        if (mkey.Length > 0)
                        {
                            buffer = DeCodeFile(strfilename);
                        }
                        else
                        {
                            buffer =CommonFunc.GetFileBytes(strfilename);
                        }
                        //合并
                        if (mIsMerge)
                        {
                            if (buffer != null)
                            {
                                fsMerge.Write(buffer, 0, buffer.Length);
                                fsMerge.Flush();
                                mMergeRowno++;
                            }

                        }
                        else
                        {
                            mMergeRowno++;
                        }
                        
                    }
                        
                }
                if (mIsStop && fi.Status != DownStatus.Finished)
                    break;
                Thread.Sleep(100);
            }
            if(fsMerge!=null)
                fsMerge.Close();
        }

        private byte[] DeCodeFile(string pFileName, bool isBak = true)
        {
            string strfilename = pFileName;
            if (File.Exists(strfilename))
            {
                try
                {
                    string strpath = Path.GetDirectoryName(strfilename);
                    string strName = Path.GetFileName(strfilename);
                    string strtmpname = strfilename + ".tmp";
                    string strpathbak = Path.Combine(strpath, "bak");

                    if (isBak)
                    {
                        if (!Directory.Exists(strpathbak))
                            Directory.CreateDirectory(strpathbak);
                    }
                    byte[] buffer = CommonFunc.GetFileBytes(strfilename);
                    byte[] buffer2 = AES.AESDecrypt(buffer, this.mkey, this.miv);

                    CommonFunc.WriteFileBytes(strtmpname, buffer2);

                    if (isBak)
                    {
                        string strbakname = Path.Combine(strpathbak, strName);
                        if (File.Exists(strbakname))
                            File.Delete(strbakname);
                        File.Move(strfilename, Path.Combine(strpathbak, strName));
                        File.Move(strtmpname,strfilename);
                    }

                    return buffer2;

                }
                catch (Exception)
                {
                    //throw exception;
                }
                
            }
            return null;
        }

        private void DownALL()
        {
            
            while (mIsStop == false)
            {
                while (mIsStop == false && mfileDownLoaders.Count < miMaxThread)
                {
                    for (int i = mcurrindex; i < mfileListInfos.Count; i++)
                    {
                        if (mfileListInfos[i].Status == DownStatus.Waiting || mfileListInfos[i].Status == DownStatus.Free)
                        {
                            mfileListInfos[i].Status = DownStatus.Downing;
                            mfileListInfos[i].isModify = true;
                            FileDownLoader fdl = new FileDownLoader();
                            fdl.OnDownloadSize += EventDownSize;
                            mfileDownLoaders.Add(fdl);
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    if (chkCursorFlower.Checked)
                                    {
                                        if (lvFileLists.Items.Count > i)
                                            lvFileLists.Items[i].EnsureVisible();
                                    }
                                    
                                    //Application.DoEvents();
                                }));
                            }
                            catch (Exception)
                            {
                            }
                            CommonFunc.CreateThreadParam(CreateFileDown, new object[] { i, fdl }, 10);
                            ShowFileInfoT(mfileListInfos[i], lvFileLists);
                            mcurrindex = i+1;
                        }
                        if (mfileDownLoaders.Count >= miMaxThread || mIsStop)
                            break;
                        //Thread.Sleep(10);
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

                if ((downsize > 0 && downsize == downLoader.getFileSize()) )   //
                {
                    fi.Status = DownStatus.Finished;
                    this.Invoke(new Action(() =>
                    {
                        lblInfo.Text = (downLoader.RowNo + 1) + "/" + mfileListInfos.Count;
                    }));
                    mfileDownLoaders.Remove(downLoader);
                }else if(fi.FileSize <= 0 && downLoader.Finished && downsize <= 0)  //下载大小为0下载错误
                {
                    fi.Status = DownStatus.Error;
                    this.Invoke(new Action(() =>
                    {
                        lblInfo.Text = (downLoader.RowNo + 1) + "/" + mfileListInfos.Count;
                    }));
                    mfileDownLoaders.Remove(downLoader);

                }
                else if(mIsStop==false && downLoader.getFileSize()>0 && downsize > downLoader.getFileSize())
                {
                    //下载长度超过实际长度,重新下载
                    CommonFunc.CreateThreadParam( ReDown,downLoader);
                }
                else if(mIsStop)
                {
                    if(File.Exists( downLoader.getFullFileName()))
                    {
                        try
                        {
                            File.Delete(downLoader.getFullFileName());
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                ShowFileInfoT(fi, lvFileLists);
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
            int i = (int)obj[0];
            FileDownLoader downloader = (FileDownLoader)obj[1];
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
                }
                else if (ex.Message == "操作超时")
                {
                    //param.ThreadNum = 1;
                    //downloader = new FileDownLoader(param);
                    //downloader.OnDownloadSize += EventDownSize;
                    downloader.Init(param);

                    downloader.RowNo = param.RowNo;
                    downloader.StartDown();
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
            //mMergeRowno = lvFileLists.SelectedItems[0].Index;
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
                    ShowFileInfoT(fi, lvFileLists);
                    
                }

            }
            for(int i = 0; i < mfileDownLoaders.Count; i++)
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
                    FileDownLoader fdl = mfileDownLoaders.Find(s => s.getURL().Equals(strurl, StringComparison.OrdinalIgnoreCase));
                    if (fdl != null)
                    {
                        fdl.Stop();
                        mfileDownLoaders.Remove(fdl);
                    }
                    fi.Status = DownStatus.Free;
                    fi.isModify = true;
                    ShowFileInfoT(fi, lvFileLists);
                    
                }

            }
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

        private void btnDown_Click(object sender, EventArgs e)
        {
            mDir = txtDir.Text.Trim();
            if (!Directory.Exists(this.mDir))
            {
                Directory.CreateDirectory(this.mDir);
            }
            mcurrindex = 0;
            mMergeRowno = 0;
            StartDownALL();
        }

        private void btnStopALL_Click(object sender, EventArgs e)
        {
            StopALL();
            btnDown.Enabled = true;
            btnStopALL.Enabled = false;
        }

        private void txtURL_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnChgURL_Click(object sender, EventArgs e)
        {
            txtURL.Text = Uri.UnescapeDataString(txtURL.Text);
        }

        private void txtURL_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtURL.Tag ==null)
            {
                txtURL.Tag = 1;
                txtURL.SelectAll();
            }
        }

        private void txtURL_Leave(object sender, EventArgs e)
        {
            txtURL.Tag = null;
        }

        private void btnModifyDir_Click(object sender, EventArgs e)
        {
            string strdir = txtDir.Text.Trim();
            for(int i = 0; i < mfileListInfos.Count; i++)
            {
                mfileListInfos[i].Dir = strdir;
            }
            for (int i = 0; i < lvFileLists.Items.Count; i++)
            {
                lvFileLists.Items[i].SubItems[7].Text = strdir;
            }

        }

        private void mnuModifyDir_Click(object sender, EventArgs e)
        {
            string strdir = txtDir.Text.Trim();
            for (int i = lvFileLists.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[i];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status != DownStatus.Downing)
                {
                    fi.Dir = strdir;
                    lvi.SubItems[7].Text = strdir;
                }

            }
        }

        private void mnuModifyURL_Click(object sender, EventArgs e)
        {
            if (lvFileLists.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvFileLists.SelectedItems[0];
                string strurl = lvi.SubItems[9].Text;
                FileListInfo fi = mfileListInfos.Find(s => s.URL.Equals(strurl, StringComparison.OrdinalIgnoreCase));
                if (fi != null && fi.Status != DownStatus.Downing)
                {
                    FrmInputBox inp = new FrmInputBox("网址");
                    inp.Value = lvi.SubItems[9].Text;
                    DialogResult dr = inp.ShowDialog();
                    if (dr == DialogResult.OK && inp.Value.Length > 0)
                    {
                        string strurlnew = inp.Value;
                        fi.URL = strurlnew;
                        string strfilename = Path.GetFileName(strurlnew);
                        fi.FileName = strfilename;
                        lvi.SubItems[1].Text = strfilename;
                        lvi.SubItems[9].Text = strurlnew;
                    }
                    inp.Dispose();
                }else if(fi.Status == DownStatus.Downing)
                {
                    MessageBox.Show("正在下载中,请先停止下载!");
                }
            }
                
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "fst";
            sfd.RestoreDirectory = true;
            sfd.Filter = "文件列表(*.fst)|*.fst|所有文件(*.*)|*.*";
            if(DialogResult.OK== sfd.ShowDialog())
            {
                string strfilename = sfd.FileName;

                SerializableProcess.SaveListClass(strfilename, mfileListInfos);
                lblInfo.Text = "保存成功!";
            }
            

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "fst";
            ofd.RestoreDirectory = true;
            ofd.Filter = "文件列表(*.fst)|*.fst|所有文件(*.*)|*.*";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                string strfilename = ofd.FileName;
                txtDir.Text = Path.GetDirectoryName(strfilename);
                mfileListInfos=SerializableProcess.LoadListClass<List<FileListInfo>>(strfilename);
                CommonFunc.CreateThreadParam(ShowListsThread,0);
                mMergeRowno = 0;
                lblInfo.Text = "加载成功!";
            }
        }

        private void ShowListsThread(object pobj)
        {
            int icount = (int)pobj;
            showFileInfotolvT(mfileListInfos, lvFileLists, true,icount);
        }

        private void mnuSelectFree_Click(object sender, EventArgs e)
        {
            for (int i = lvFileLists.SelectedItems.Count - 1; i >= 0; i--)
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
                    fi.Status = DownStatus.Free;
                    fi.isModify = true;
                    ShowFileInfoT(fi, lvFileLists);
                    
                }else if (fi != null && fi.Status == DownStatus.Waiting)
                {
                    fi.Status = DownStatus.Free;
                    fi.isModify = true;
                    ShowFileInfoT(fi, lvFileLists);
                }
            }

        }

        private void mnuReDown_Click(object sender, EventArgs e)
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

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            mIsAutoDown = chkAutoStart.Checked;
        }

        private void lvFileLists_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvFileLists.SelectedItems.Count <= 0)
                {
                    return;
                }

                // put selected files into a string array
                string[] files = new String[lvFileLists.SelectedItems.Count];

                int i = 0;
                foreach (ListViewItem item in lvFileLists.SelectedItems)
                {
                    files[i++] =Path.Combine( item.SubItems[7].Text,item.SubItems[1].Text);
                }

                // create a dataobject holding this array as a filedrop
                DataObject data = new DataObject(DataFormats.FileDrop, files);

                // also add the selection as textdata
                data.SetData(DataFormats.StringFormat, files[0]);

                // Do DragDrop 
                DoDragDrop(data, DragDropEffects.Copy);
            }

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
    }
}
