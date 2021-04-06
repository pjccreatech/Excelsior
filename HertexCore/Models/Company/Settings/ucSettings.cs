using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Company.Settings
{
    public partial class ucSettings : UserControl
    {
        public ucSettings()
        {
            InitializeComponent();
        }

        public ucSettings(CTechCore.Models.Navigation.MenuItem mnu, object obj)
        {
            InitializeComponent();

            lkpCustomerGrp.Properties.DataSource = Models.AccountsReceivable.Customers.GetCustomerGroups();
            lkpCustomerGrp.ForceInitialize();
            lkpCustomerGrp.Properties.PopulateViewColumns();
            lkpCustomerGrp.Properties.View.Columns["IdCliClass"].Visible = false;
            lkpCustomerGrp.Properties.DisplayMember = "DisplayText";
            lkpCustomerGrp.Properties.KeyMember = "Code";
            lkpCustomerGrp.Properties.ValueMember = "Code";

            layoutHeaderKey.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutHeaderKeyCustomerGrp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            Setting sets = (Setting)obj;
            if (sets.HeaderSection == "Defaults - CreditOverflow")
            {
                layoutHeaderKey.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutHeaderKeyCustomerGrp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }


            settingBindingSource.DataSource = sets;


        }

        private void ucSettings_Load(object sender, EventArgs e)
        {
            this.ActiveControl = spinEdit1;
            spinEdit1.Focus();
            spinEdit1.SelectAll();

        }

        private void lkpCustomerGrp_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {

        }
    }
}
