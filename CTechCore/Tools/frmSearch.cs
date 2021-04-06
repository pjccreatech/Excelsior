using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Tools
{
    public partial class frmSearch : CTechCore.Tools.frmBorderlessForm
    {

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {

        }




        private void frmAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //btnAccept.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cntrlSearch1_Load(object sender, EventArgs e)
        {

        }
    }
}
