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

namespace HertexCore.Models.AccountsReceivable.Forms
{
    public partial class frmCustomerQuickView : Form
    {

        int clientId = 0;

        public frmCustomerQuickView(int CustomerIDX)
        {
            InitializeComponent();
            
            
        }


        public frmCustomerQuickView(DataRow dr)
        {
            InitializeComponent();

            this.clientId = dr.Field<int>("ClientID");

            lblCustomer.Text = dr.Field<string>("Account");
            lblName.Text = dr.Field<string>("Name");
            lblBalance.Text = dr.Field<double>("OutstandingBalance").ToString("c2");
            lblCreditLimit.Text = dr.Field<double>("Credit_Limit").ToString("c2");
            lblOnHold.Text = dr.Field<bool>("On_Hold") ? "Yes" : "No";
            
            lbCurrent.Text = dr.Field<double>("AgingCurrent").ToString("c2");
            lb30.Text = dr.Field<double>("Aging30Days").ToString("c2");
            lb60.Text = dr.Field<double>("Aging60Days").ToString("c2");
            lb90.Text = dr.Field<double>("Aging90Days").ToString("c2");
            lb120.Text = dr.Field<double>("Aging120Days").ToString("c2");
            lb150.Text = dr.Field<double>("Aging150Days").ToString("c2");
            lb180.Text = dr.Field<double>("Aging180Days").ToString("c2");
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
