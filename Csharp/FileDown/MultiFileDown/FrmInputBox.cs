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
    public partial class FrmInputBox : Form
    {
        public string Value { get; set; }
        public FrmInputBox()
        {
            InitializeComponent();
        }
        public FrmInputBox(string label)
        {
            InitializeComponent();
            label1.Text = label;
        }

        public FrmInputBox(string label, string title)
        {
            InitializeComponent();
            label1.Text = label;
            this.Text = title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Value = txtValue.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmInputBox_Load(object sender, EventArgs e)
        {
            txtValue.Focus();
            txtValue.Text = Value;
        }
    }
}
