using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Excelsior.UI.Models.AccountsRecievable.Transactions.SalesOrders
{
    public partial class frmSalesOrder : Models.Base.frmDocumentBase
    {
        public frmSalesOrder()
        {
            InitializeComponent();

            spnQtyOrdered.MinValue = 0;
            spnQtyOrdered.MaxValue = int.MaxValue;
            spnPriceExcl.MinValue = 0;
            spnPriceExcl.MaxValue = int.MaxValue;
        }



        private void LoadData()
        {
            
            DataTable dt = new DataTable();
            MyApp.Evo.ExecSQL($" SELECT * FROM vw_Xlsr_GetCustomersBasics", ref dt);
            DataView dv = new DataView(dt);
            cntrlSearch1.DataSource = dv;
            
            DataTable dtStk = new DataTable();
            MyApp.Evo.ExecSQL($"SELECT * FROM vwStk_Get", ref dtStk);
            DataView dvStk = new DataView(dtStk);
            dvStk.RowFilter = " ItemActive = 1";
            ddlStkCode.DataSource = dvStk;
            ddlStkCode.PopulateColumns();
            ddlStkCode.DisplayMember = "StockCode";
            ddlStkCode.KeyMember = "StockCodeID";
            ddlStkCode.ValueMember = "StockCodeID";
            ddlStkCode.Columns["StockCodeID"].Visible = false;
            ddlStkCode.Columns["ItemActive"].Visible = false;
            ddlStkCode.Columns["ItemGroup"].Visible = false;
            ddlStkCode.Columns["CustomerGroupCode"].Visible = false;
            


            ddlStkDescr.DataSource = dvStk;
            ddlStkDescr.PopulateColumns();
            ddlStkDescr.DisplayMember = "Description1";
            ddlStkDescr.KeyMember = "StockCodeID";
            ddlStkDescr.ValueMember = "StockCodeID";
            ddlStkDescr.Columns["StockCodeID"].Visible = false;
            ddlStkDescr.Columns["ItemActive"].Visible = false;
            ddlStkDescr.Columns["ItemGroup"].Visible = false;
            ddlStkDescr.Columns["CustomerGroupCode"].Visible = false;

            DataTable dtVAT = new DataTable();
            MyApp.Evo.ExecSQL("SELECT idTaxRate, Code, Description FROM tblTaxRates WHERE bActive = 1", ref dtVAT);
            DataView dvVAT = new DataView(dtVAT);
            lkpVAT.DataSource = dvVAT;
            lkpVAT.PopulateColumns();
            lkpVAT.Columns["idTaxRate"].Visible = false;


        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
        
        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            SalesOrderBindingSource.DataSource = new Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder();
            this.DataBindings[0].Format += frmSalesOrder_Format; ;
            barbtnOpen.ItemClick += BarbtnOpen_ItemClick;
            barbtnSave.ItemClick += BarbtnSave_ItemClick;
            barbtnNew.ItemClick += BarbtnNew_ItemClick;
            barbtnProcess.ItemClick += BarbtnProcess_ItemClick;
            barBtnPrint.ItemClick += BarbtnPrint_ItemClick;
            barBtnEmail.ItemClick += BarBtnEmail_ItemClick;

            barbtnSave.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));
            barbtnCancel.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));
            barbtnProcess.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));
            //splitContainerControl1.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));

            List<dynamic> lst = new List<dynamic>();
            GetControls(splitContainerControl1, ref lst);
            lst.ForEach(c =>
                {
                    repositoryItemMemoEdit1.AppearanceDisabled.ForeColor = Color.Black;
                    c.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));

                    System.Reflection.PropertyInfo prop = (c.GetType()).GetProperty("ForeColor");
                    c.ForeColor = Color.Black;
                    IList<System.Reflection.PropertyInfo> props = new List<System.Reflection.PropertyInfo>((c.GetType()).GetProperties());
                    

                });
            //gridControl1.DataBindings.Add(new Binding("Enabled", SalesOrderBindingSource, "IsEditable", true, DataSourceUpdateMode.OnPropertyChanged));
            LoadData();
        }

        private void BarBtnEmail_ItemClick(object sender, ItemClickEventArgs e)
        {                        
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;           
            if (so.Status < Excelsior.Core.Enums.DocumentState.Saved)
            {
                MessageBox.Show("Document was not saved and cannot be mailed.", "Action not possible.");
                return;
            }
            so.eMailDocument();        
        }

        private void GetControls(object cntrl, ref List<dynamic> lst)
        {
            foreach (Control itm in ((Control)cntrl).Controls)
            {
                if (itm is DevExpress.XtraEditors.LookUpEdit ||
                itm is DevExpress.XtraEditors.MemoEdit ||
                itm is DevExpress.XtraEditors.TextEdit ||
                itm is DevExpress.XtraEditors.LookUpEdit ||
                itm is DevExpress.XtraEditors.SpinEdit ||
                itm is DevExpress.XtraEditors.PopupContainerEdit ||
                itm is DevExpress.XtraEditors.DateEdit ||
                itm is TextBox )
                    lst.Add(itm);
                if (itm.HasChildren)
                {
                    GetControls(itm, ref lst);
                }
            }
        }

        private void BarbtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;
            if (so.Status < Excelsior.Core.Enums.DocumentState.Saved)
            {
                MessageBox.Show("Document was not saved and cannot be printed", "Action not possible.");
                return;
            }
            so.PrintDocument();
        }

        private void BarbtnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;

            if (!so.Validate())
            {
                string errs = string.Join("", so.Errors.Select(s => $"\r\n- {s}"));
                MessageBox.Show($"Please review the following errors in order to save successfully:\r\n {errs}", "Cannot proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlg = MessageBox.Show("Please confirm you want to process.\r\n\r\nNo changes will be allowed afterwards.", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                so.Process();
                so.PrintDocument();
                so.eMailDocument();
                MessageBox.Show($"Sales Order '{so.DocumentNumber}' processed successfully.", "Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SalesOrderBindingSource.DataSource = new Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder();
            }
        }

        private void frmSalesOrder_Format(object sender, ConvertEventArgs e)
        {
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;

            e.Value = $"Sales Order: {so.DocumentNumber}";
            //e.Value += so.Status == Excelsior.Core.Enums.DocumentState.New ? " - New": $": {so.Customer.Name}";
        }

        private void BarbtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            SalesOrderBindingSource.DataSource = new Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder();
        }

        private void BarbtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder SO = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;

            if (!SO.Validate())
            {
                string errs = string.Join("", SO.Errors.Select(s => $"\r\n- {s}"));
                MessageBox.Show($"Please review the following errors in order to save successfully:\r\n {errs}", "Cannot proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SO.Save())
            {
                MessageBox.Show($"Sales Order '{SO.DocumentNumber}' saved successfully.", "Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
                MessageBox.Show("An error has occured and details could not be saved. \r\n\r\nTry again or contact support for assistance.");
        }

        private void BarbtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Excelsior.Core.Tools.frmSearch frm = new Excelsior.Core.Tools.frmSearch();
            ///LOAD DATASOURCE & SET EVENTS FOR Customers
            frm.cntrlSearch1.btnNew.Click += (o, args) =>
            {
                frm.cntrlSearch1.EditValue = new Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder();
            };

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Excelsior.Core.WaitForms.frmWaitBasic));
            DataTable dt = new DataTable();
            MyApp.Evo.ExecSQL($"SELECT AutoIDX, SONumber, CustomerName, ExtOrdNum, OrderDate  from tblSOHeader WHERE OrderStatus in ({(int)Excelsior.Core.Enums.DocumentState.New}, {(int)Excelsior.Core.Enums.DocumentState.Saved})", ref dt);
#if DEBUG

            MyApp.Evo.ExecSQL($"SELECT AutoIDX, SONumber, CustomerName, ExtOrdNum, OrderDate FROM tblSOHeader ", ref dt);
#endif
            frm.cntrlSearch1.DataSource = dt;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.cntrlSearch1.EditValue is DataRow)
                    SalesOrderBindingSource.DataSource = new Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder(((DataRow)frm.cntrlSearch1.EditValue).Field<int>("AutoIDX"));
                else if (frm.cntrlSearch1.EditValue is Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder)
                {
                    SalesOrderBindingSource.DataSource = (Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder)frm.cntrlSearch1.EditValue;
                }
                lkpStokGroup.Enabled = false;
            }
        }

        private void popupContainerEdit1_Popup(object sender, EventArgs e)
        {
            LoadData();
        }

        private void popupContainerEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {



        }

        private void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.PopupContainerEdit pp = (DevExpress.XtraEditors.PopupContainerEdit)sender;

            if (pp.EditValue == null) return;
           

        }

        private void popupContainerEdit1_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {

        }

        private void popupContainerEdit1_QueryDisplayText(object sender, DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs e)
        {
            if (e.EditValue == null)
            {
                e.DisplayText = "Select Customer";
                return;
            }

            if (e.EditValue.GetType().Equals(typeof(Excelsior.Library.Models.AccountRecievable.Customers.Customer)))
            {
                Excelsior.Library.Models.AccountRecievable.Customers.Customer dr = (Excelsior.Library.Models.AccountRecievable.Customers.Customer)e.EditValue;
                e.DisplayText = $"{dr.Name} ({dr.Code})";
            }
        }

        private void popupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            if (e.Value == null) return; 

            if (e.Value.GetType().Equals(typeof(DataRow)))
            {
                Excelsior.Library.Models.AccountRecievable.Customers.Customer cr = new Excelsior.Library.Models.AccountRecievable.Customers.Customer(((DataRow)e.Value).Field<int>("CustomerID"));
                e.Value = cr;
            }
            else if (e.Value.GetType().Equals(typeof(Excelsior.Library.Models.AccountRecievable.Customers.Customer)))
            {
                
            }
            else
            {
                e.Value = null;
            }
        }

        private void ddlStk_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            { 
                e.Handled = true;
                return;
            }

            if (e.Value is int)
                e.Handled = true;
            else if (e.Value is  DataRowView)
            {
                e.Handled = true;
                e.Value = ((DataRowView)e.Value).Row.Field<int>("StockCodeID");
            }
            
        }

        private void ddlStk_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void ddlStk_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || (int)e.Value < 1)
            {
                e.DisplayText = "Select Stock Item";
                return;
            }
        }

        private void ddlStkDescr_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void ddlStkDescr_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || (int)e.Value < 1)
            {
                e.DisplayText = "Select Stock Item";
                return;
            }
        }

        private void ddlStkDescr_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            {
                e.Handled = true;
                return;
            }

            if (e.Value is int)
            {
                e.Handled = true;
            }
            else if (e.Value is DataRowView)
            {
                e.Handled = true;
                e.Value = ((DataRowView)e.Value).Row.Field<int>("StockCodeID");
            }
        }

        private void ddlStkCode_Popup(object sender, EventArgs e)
        {
            //((DevExpress.XtraEditors.LookUpEdit)sender).Properties.DisplayMember = "StockCode";


        }

        private void ddlStkDescr_Popup(object sender, EventArgs e)
        {
           // ((DevExpress.XtraEditors.LookUpEdit)sender).Properties.DisplayMember = "Description1";


        }

        private void lkpVAT_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null) return;

            e.DisplayText = ((Excelsior.Library.Models.Company.Tax.TaxRate)e.Value).Code;
        }

        private void lkpVAT_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null) return;
            int x = 0;

            if (e.Value.GetType().Equals(typeof(int)))
            {
                e.Handled = true;
                e.Value = new Excelsior.Library.Models.Company.Tax.TaxRate((int)e.Value);
            }
            else if (e.Value.GetType().Equals(typeof(DataRowView)))
            {
                e.Handled = true;
                e.Value = new Excelsior.Library.Models.Company.Tax.TaxRate(((DataRowView)e.Value).Row.Field<int>("idTaxRate"));
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder SO = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;
            if (popupContainerEdit1.EditValue == null || SO.Customer == null)
            {
                MessageBox.Show("You need to select a valid customer", "No customer selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;
            if (so.IsEditable && so.Customer != null)
            {
                DevExpress.XtraGrid.Views.Grid.GridView vw = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                if (( vw.FocusedColumn.FieldName == "StockItemID") )
                    e.Cancel = false;
                
                else
                    e.Cancel = (vw.GetFocusedRowCellValue("StockItem") == null);
                
            }
            else
                e.Cancel = !(so.IsEditable && so.Customer != null);
            
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder so = SalesOrderBindingSource.DataSource as Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder;
            if (!so.IsEditable)
                (sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn = null;
            ((DevExpress.XtraGrid.Views.Grid.GridView)sender).ShowEditor();
        }

        private void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {

        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {

        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {

            var edit = ((DevExpress.XtraEditors.TextEdit)((DevExpress.XtraGrid.Views.Grid.GridView)sender).ActiveEditor);

            if (edit.GetType() == typeof(DevExpress.XtraEditors.SpinEdit) )
                {
                BeginInvoke(new MethodInvoker(() =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                }));
                edit.Enter += (o, args) =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                };
                edit.MouseClick += (o, args) =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                };
                edit.MouseDown += (o, args) =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                };
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           ((DevExpress.XtraGrid.Views.Grid.GridView)sender).ShowEditor();
        }

        private void lkpStokGroup_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barBtnImportXMLFile_ItemClick(object sender, ItemClickEventArgs e)
        {;
        }

        private void ddlStkCode_PopupFilter(object sender, DevExpress.XtraEditors.Controls.PopupFilterEventArgs e)
        {
            //e.Criteria = null;

        }

        private void ddlStkCode_BeforePopup(object sender, EventArgs e)
        {
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder SO = (Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder)SalesOrderBindingSource.DataSource;
            DataView dv = (DataView)((DevExpress.XtraEditors.LookUpEdit)sender).Properties.DataSource;
            //dv.RowFilter = $" CustomerGroupCode IN ('{SO.Customer.CustomerGroup.Code}')";
        }

        private void ddlStkDescr_BeforePopup(object sender, EventArgs e)
        {
            Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder SO = (Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders.SalesOrder)SalesOrderBindingSource.DataSource;
            DataView dv = (DataView)((DevExpress.XtraEditors.LookUpEdit)sender).Properties.DataSource;
            //dv.RowFilter = $" CustomerGroupCode IN ('{SO.Customer.CustomerGroup.Code}')";
        }
    }
}
