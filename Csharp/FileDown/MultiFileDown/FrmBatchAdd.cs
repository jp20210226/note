using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFileDown
{
    public partial class FrmBatchAdd : Form
    {
        public FrmMain mFrmMain;
        public FrmBatchAdd()
        {
            InitializeComponent();
        }

        private void txtBegin_TextChanged(object sender, EventArgs e)
        {
            if (txtBegin.Text.Length == 0 || txtEnd.Text.Length == 0 || txtURL.Text.Trim().Length==0)
                return;
            int iBegin, iEnd;
            if (!Int32.TryParse(txtBegin.Text, out iBegin))
                return;
            if (!Int32.TryParse(txtEnd.Text, out iEnd))
                return;
            int iLen =(int)nudLength.Value;

            
            string strformat = "{0:D" + iLen + "}";
            string strurl = txtURL.Text.Trim();
            string strret = "";
            for (int i = iBegin; i <= iEnd; i++)
            {
                string strnum = string.Format(strformat, i);
                strret += strurl.Replace("(*)", strnum)+"\r\n";
            }
            rtbBatchURL.Text = strret.TrimEnd(new char[] { '\r', '\n' });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string> lstr = new List<string>();
            lstr.AddRange(rtbBatchURL.Lines);
            mFrmMain.BatchAddURL(lstr);
            this.Close();
        }
    }
}
