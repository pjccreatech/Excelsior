using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Company.PaymentTypes
{
    public partial class frmPaymentType : Form
    {
        public frmPaymentType()
        {
            InitializeComponent();
            paymentTypeBindingSource.DataSource = new PaymentType();
        }

        public frmPaymentType(CTechCore.Models.Navigation.MenuItem mnu, object obj)
        {
            InitializeComponent();
            paymentTypeBindingSource.DataSource = (PaymentType)obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaymentType obj = (PaymentType)paymentTypeBindingSource.DataSource;
            obj.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
