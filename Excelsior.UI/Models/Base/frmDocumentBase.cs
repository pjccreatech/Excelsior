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

namespace Excelsior.UI.Models.Base
{
    public partial class frmDocumentBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public virtual object DataSource { get; set; }
        public frmDocumentBase()
        {
            InitializeComponent();
        }

        private void frmDocumentBase_Load(object sender, EventArgs e)
        {

        }

        private void barBtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


    }
}