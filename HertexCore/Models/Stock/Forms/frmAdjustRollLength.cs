using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using HertexCore;



namespace HertexCore.Models.Stock.Forms
{
    public partial class frmAdjustRollLength : Form
    {
        private StockRollItems.StockRollItem Roll;


        public frmAdjustRollLength(StockRollItems.StockRollItem roll)
        {
            InitializeComponent();

            de_DateOfAdjustment.EditValue = DateTime.Now;
            Roll = roll;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {


        }

        private void frmAdjustRollLength_Load(object sender, EventArgs e)
        {
            if (de_DateOfAdjustment.DateTime == null)
            {
                de_DateOfAdjustment.DateTime = DateTime.Now;
            }

            txt_ProductCode.Text = Roll.StockCode;
            txt_OriginalRollLength.Text = Roll.OnHand.ToString();

            DataTable dtGetReason = new DataTable();
            MyApp.CTech.ExecSQL("select distinct ListItems from tDropDownList where ListCategory = 'StockAdjustment'", ref dtGetReason);
            lookupAdjustReason.Properties.DataSource = dtGetReason;
            lookupAdjustReason.Properties.PopulateColumns();
            lookupAdjustReason.Properties.DisplayMember = "ListItems";

            adjustedValue();
            this.ActiveControl = spinEdit1;
            spinEdit1.SelectAll();
        }

        private void edt_NewRollLength_Leave(object sender, EventArgs e)
        {
           
        }

        private void de_DateOfAdjustment_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {

        }

        private void lookupAdjustReason_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "Select Reason";
            }
            else
            {
                e.DisplayText = ((DataRowView)e.Value).Row.Field<string>("ListItems");
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            adjustedValue();
        }

        public void adjustedValue()
        {
            double spinVal = Convert.ToDouble(spinEdit1.Value);
            double adjustVal = spinVal - Roll.OnHand;
            txt_Adjustment.Text = adjustVal.ToString();
        }

        private void btnAdjustRollLength_Click(object sender, EventArgs e)
        {
            double newOnhand = double.Parse(spinEdit1.Text);
            double adjVal = Convert.ToDouble( txt_Adjustment.Text);

            if (lookupAdjustReason.EditValue != null && de_DateOfAdjustment.EditValue != null)
            {
                DataRow  result = HertexCore.Models.Stock.StockRollItems.AdjustRollLength(this.Roll, adjVal, "refrence", "refernce2", lookupAdjustReason.Text);
                if (result != null)
                    this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select an adjustment reason");
            }
        }
    }
}
