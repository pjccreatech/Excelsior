using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    public partial class frmReceiveStock : Form
    {
        DataRow drInfo;
        public frmReceiveStock()
        {
            InitializeComponent();
        }

        public frmReceiveStock(DataRow dr)
        {
            InitializeComponent();

            CTechCore.Tools.Forms.InitializeControlsFocus(this);

            drInfo = dr;
            LoadData();

            this.ActiveControl = txtDyeLot;
        }


        private void LoadData( )
        {

            dateEdit1.DateTime = DateTime.Now;
            textEdit1.Text = drInfo.Field<string>("OrderNum");
            textEdit2.Text = drInfo.Field<string>("stgroup");
            textEdit3.Text = drInfo.Field<string>("Code");
            textEdit4.Text = drInfo.Field<double>("fUnitPriceExcl").ToString("c2");
            textEdit5.Text = drInfo.Field<string>("Description_1");
            textEdit6.Text = drInfo.Field<string>("Description_2");

            textEdit7.Text = drInfo.Field<double>("fQuantity").ToString("0.000");

            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"SELECT Qty Length, Available, DyeLot, SupplierDyeLot from PurchaseOrder WHERE PurchaseOrderNumber = '{drInfo.Field<string>("OrderNum")}' AND StockCode = '{drInfo.Field<string>("Code")}'",ref dt);
            DataView dv = new DataView(dt);
            gcRolls.DataSource = dv;

            ReCalcs();
        }

        private void ReCalcs()
        {
            DataView dv = (DataView)gcRolls.DataSource;
            dv.Table.AcceptChanges();
            double isum = dv.Table.AsEnumerable().Sum(r => r.Field<double>("Length"));
            txtQtyRemaining.Text = (drInfo.Field<double>("fQuantity") - (drInfo.Field<double>("fQtyProcessed") + isum)).ToString("0.000");
        }

        private void btnAddRolll_Click(object sender, EventArgs e)
        {
            if (spnRollQty.Value == 0) return;

            bool bAllow = MyApp.Login.User.IsManager;
            if (spnRollQty.Value > (decimal.Parse(txtQtyRemaining.Text) ))
            {
                double allowance = (drInfo.Field<double>("fQuantity") * 0.2);
                if (MessageBox.Show("You are trying to receive a total quantity larger than what was ordered. Is this correct?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                if (Convert.ToDouble(spnRollQty.Value) > allowance)
                {
                    Models.Users.Forms.frmManagerOverride frm = new Models.Users.Forms.frmManagerOverride(Users.PasswordOverrrideType.GRVOverride);
                    bAllow = frm.ShowDialog() == DialogResult.OK;
                }

            }
            //QtyOrdered.Value := QtyOrdered.Value + (RollQuantity.Value - QtyRemaining.Value);
            if (bAllow)
            {
                DataView dv = (DataView)gcRolls.DataSource;
                DataRow dr = dv.Table.NewRow();
                dr.SetField("Length", spnRollQty.Value);
                dr.SetField("DyeLot", txtDyeLot.Text);
                dr.SetField("SupplierDyeLot", txtDyeLot.Text);

                dv.Table.Rows.InsertAt(dr, dv.Table.Rows.Count);

                ReCalcs();
                //spnRollQty.Focus();
                this.ActiveControl = txtDyeLot;
            }

            //   if RollQuantity.Value > QtyRemaining.Value then
            //   begin
            //   if  then
            //exit;
            //   if RollQuantity.Value > vAllowance then
            //   begin
            //vPassword:= inputbox('Manager Password', 'Enter the override password', '');
            //   if vPassword = '' then
            //      exit;
            //   if vPassword <> '12345' then
            //   begin
            //   messagedlg('Incorrect password', mtError, [mbOK], 0);
            //   exit;
            //   end;
            //   end;
            //   QtyOrdered.Value := QtyOrdered.Value + (RollQuantity.Value - QtyRemaining.Value);
            //   end;
            //   memRoll.Append;
            //   memRoll.FieldByName('Length').AsCurrency := RollQuantity.EditValue;
            //   memRoll.FieldByName('DyeLot').AsString := edtDyeLot.Text;
            //   // memRoll.FieldByName('DyeLot').AsString := formatdatetime('dd/mm/yy', date) + edtDyeLot.Text;
            //   memRoll.FieldByName('SupplDyeLot').AsString := memRoll.FieldByName('DyeLot').AsString; // edtSupplDyeLot.Text;
            //   memRollAvailable.AsBoolean := true;
            //   memRoll.Post;
            //   RollQuantity.SetFocus;
        }

        private void spnRollQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && (spnRollQty.IsEditorActive || btnAddRolll.Focused))
            {
                btnAddRolll.PerformClick();
            }
        }

        private void gvRolls_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRow && e.HitInfo.RowInfo != null)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

                    dynamic obj = null;
                    object itm = gv.GetRow(gv.FocusedRowHandle);



                    DevExpress.XtraGrid.Menu.GridViewMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewMenu;
                    menu.Items.Clear();

                    DevExpress.Utils.Menu.DXMenuItem mgr = new DevExpress.Utils.Menu.DXMenuItem();
                    mgr.Caption = $"Delete";
                    mgr.Click += delegate (object o, EventArgs args)
                    {
                        gv.DeleteSelectedRows();
                        ReCalcs();
                    };
                    menu.Items.Add(mgr);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)gvRolls.DataSource;

            try
            {
                List<Con.Params> parms = new List<CTechCore.Con.Params>();
                string sSQL = $"DELETE FROM PurchaseOrder where PurchaseOrderNumber = '{drInfo.Field<string>("OrderNum")}' AND  StockCode = '{drInfo.Field<string>("Code")}'";
                if (dv.Table.Rows.Count > 0)
                {
                    sSQL += "\rINSERT INTO PurchaseOrder(PurchaseOrderNumber, StockCode, ItemGroup, Qty, UnitPriceExcl, Available, DateReceived, DyeLot, SupplierDyeLot, Finalized, InvDocIDX, InvDocLineIDX)";
                    sSQL += "\rVALUES";
                    int i = 0;
                    foreach (DataRow dr in dv.Table.Rows)
                    {
                        sSQL += $"\r (@OrderNumber{i}, @StockCode{i}, @ItemGroup{i}, @Qty{i}, @UnitPriceExcl{i}, @Available{i}, @DateReceived{i}, @DyeLot{i}, @SupplierDyeLot{i}, @Finalized{i}, @InvDocIDX{i}, @InvDocLineIDX{i}),";
                        parms.Add(new CTechCore.Con.Params() { Name = $"OrderNumber{i}", Value = drInfo.Field<string>("OrderNum") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"StockCode{i}", Value = drInfo.Field<string>("Code") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"ItemGroup{i}", Value = drInfo.Field<string>("stgroup") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"Qty{i}", Value = dr.Field<double>("Length") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"UnitPriceExcl{i}", Value = drInfo.Field<double>("fUnitPriceExcl") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"Available{i}", Value = 1 });
                        parms.Add(new CTechCore.Con.Params() { Name = $"DateReceived{i}", Value = dateEdit1.DateTime });
                        parms.Add(new CTechCore.Con.Params() { Name = $"DyeLot{i}", Value = dr.Field<string>("DyeLot") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"SupplierDyeLot{i}", Value = dr.Field<string>("SupplierDyeLot") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"Finalized{i}", Value = "0" });
                        parms.Add(new CTechCore.Con.Params() { Name = $"InvDocIDX{i}", Value = drInfo.Field<Int64>("AutoIndex") });
                        parms.Add(new CTechCore.Con.Params() { Name = $"InvDocLineIDX{i}", Value = drInfo.Field<Int64>("idInvoiceLines") });
                        i++;
                    }

                }
                if (sSQL.EndsWith(",")) sSQL = sSQL.TrimEnd(new char[] { ',' });
                DataTable dt = new DataTable();
                if(MyApp.CTech.ExecSQL(sSQL, ref dt, parms))
                    this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error trying to save. {ex.ToString()}", "", MessageBoxButtons.OK);
            }
        }
    }
}
