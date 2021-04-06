using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.AccountsPayable.Forms
{
    public partial class frmSupplierQuickView : Form
    {

        int clientId = 0;

        public frmSupplierQuickView(int CustomerIDX)
        {
            InitializeComponent();
            
            
        }


        public frmSupplierQuickView(DataRow dr)
        {
            InitializeComponent();

            this.clientId = dr.Field<int>("ClientID");

            lblCustomer.Text = dr.Field<string>("Account");
            lblName.Text = dr.Field<string>("Name");
            lblBalance.Text = dr.Field<double>("OutstandingBalance").ToString("c2");
            lblCreditLimit.Text = dr.Field<double>("Credit_Limit").ToString("c2");
            lblOnHold.Text = dr.Field<bool>("On_Hold") ? "Yes" : "No";
            
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
