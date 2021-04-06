using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CTechCore.Models.Document
{
    public partial class frmDocumentBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public virtual object DataSource { get; set; }
        public frmDocumentBase()
        {
            InitializeComponent();
        }


        public string Caption
        {
            get { return lblCaption.Text; } 
            set { lblCaption.Text =value; }
        }

        private void frmDocumentBase_Load(object sender, EventArgs e)
        {

        }

        private void barBtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://www.hertex.co.za/");
        }
    }
}