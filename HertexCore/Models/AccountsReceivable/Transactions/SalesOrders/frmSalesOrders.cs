using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using CTechCore.Enums;

namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    public partial class frmSalesOrders : CTechCore.Models.Document.frmDocumentBase
    {
        public frmSalesOrders()
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            salesOrderBindingSource.DataSource = new SalesOrder();
        }

        public frmSalesOrders(SalesOrder so)
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            salesOrderBindingSource.DataSource = so;
            
            base.Caption = $"ORDER: {so.DocumentNumber} ({so.ExternalOrderNumber})";
        }

        private void InitializeControls()
        {
            base.Caption = "Sales Order";

            btnCustomerQuickView.StyleController = null;
            btnCustomerQuickView.LookAndFeel.UseDefaultLookAndFeel = false;
            btnCustomerQuickView.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnEditAddr.StyleController = null;
            btnEditAddr.LookAndFeel.UseDefaultLookAndFeel = false;
            btnEditAddr.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            
            btn3rdPartyAddr.StyleController = null;
            btn3rdPartyAddr.LookAndFeel.UseDefaultLookAndFeel = false;
            btn3rdPartyAddr.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            CTechCore.Tools.Forms.InitializeControlsFocus(this);
        }

        public frmSalesOrders(CTechCore.Models.Navigation.MenuItem mnu)
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            salesOrderBindingSource.DataSource = new SalesOrder();


            base.Caption = $"NEW ORDER";
        }

        public frmSalesOrders(CTechCore.Models.Navigation.MenuItem mnu, object so)
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            salesOrderBindingSource.DataSource = (SalesOrder)so;
            
            base.Caption = $"ORDER: {((SalesOrder)so).DocumentNumber} ({((SalesOrder)so).ExternalOrderNumber})";
        }

        private void frmSalesOrders_Load(object sender, EventArgs e)
        {
            this.DataBindings[0].Format += frmSalesOrder_Format;
            barbtnOpen.ItemClick += BarbtnOpen_ItemClick;
            barbtnSave.ItemClick += BarbtnSave_ItemClick;
            barbtnNew.ItemClick += BarbtnNew_ItemClick;
            barbtnProcess.ItemClick += BarbtnProcess_ItemClick;
            barBtnPrint.ItemClick += BarbtnPrint_ItemClick;
            barBtnEmail.ItemClick += BarBtnEmail_ItemClick;
            barBtnRefreshData.ItemClick += BarBtnRefreshData_ItemClick;

            ppDeliverMethod.ParseEditValue += HandleParseEditValue;
            ppDeliverMethod.CustomDisplayText += HandleCustomDisplayText;

            ppRep.ParseEditValue += HandleParseEditValue;
            ppRep.CustomDisplayText += HandleCustomDisplayText;

            ppReleaseForInvoicing.CustomDisplayText += (o, args) =>
            {
                if (args.Value is CTechCore.Enums.Document.Processable)
                    args.DisplayText = ((CTechCore.Enums.Document.Processable)args.Value).GetDisplayText();
                else
                    args.DisplayText = ((System.Collections.Generic.KeyValuePair<CTechCore.Enums.Document.Processable, string>)args.Value).Value;
            };

            ppReleaseForInvoicing.ParseEditValue += (o, args) =>
            {
                if (args.Value is CTechCore.Enums.Document.Processable)
                    args.Value = ((CTechCore.Enums.Document.Processable)args.Value);
                else
                {
                    args.Value = ((System.Collections.Generic.KeyValuePair<CTechCore.Enums.Document.Processable, string>)args.Value).Key;
                }
            };

            ppPmntStatus.ParseEditValue += HandleParseEditValue;
            ppPmntStatus.CustomDisplayText += HandleCustomDisplayText;
        }


        private string GetCustomSearchEditor(object sender)
        {
            if (sender == ppRep)
                return "idSalesRep";
            else if (sender == ppDeliverMethod)
                return "Counter";
            else if (sender == ppPmntStatus)
                return "AutoIDX";
            else
            {
                return string.Empty;
            }
        }

        private string GetCustomSearchEditorDisplayText(object sender, DataRow dr)
        {
            if (sender == ppRep)
                return  dr == null ? "Select Representative" : $"{dr.Field<string>("Code")}: {dr.Field<string>("Name")}";
            else if (sender == ppDeliverMethod)
                return dr == null ? "Select Delivery Method" : dr.Field<string>("Method");
            else if (sender == ppPmntStatus)
                return dr == null ? "Select Payment Status" : dr.Field<string>("Description");
            else
            {
                return string.Empty;
            }
        }

        private void HandleCustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                e.DisplayText = GetCustomSearchEditorDisplayText(sender, null);
            else
            {
                DataRow dr = null;
                if (e.Value is int)
                {
                    if (((CTechCore.Tools.CustomControls.CustomSearchEditor)sender).Properties.DataSource == null) return;
                    dr = ((DataView)((CTechCore.Tools.CustomControls.CustomSearchEditor)sender).Properties.DataSource).Table.Select($"{GetCustomSearchEditor(sender)} = {(int)e.Value} ").FirstOrDefault();
                }
                else if (e.Value is DataRowView)
                    dr = ((DataRowView)e.Value).Row;
                else if (e.Value is DataRow)
                    dr = (DataRow)e.Value;
                else
                {

                }

                if (dr != null)
                    e.DisplayText = GetCustomSearchEditorDisplayText(sender, dr);
            }
        }

        private void HandleParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                return;
            else
            {
                if (e.Value is int)
                    return;
                else if (e.Value is DataRowView)
                {
                   e.Value = (int)((DataRowView)e.Value).Row[GetCustomSearchEditor(sender)];
                }
                else if (e.Value is DataRow)
                    e.Value = (int)((DataRow)e.Value)[GetCustomSearchEditor(sender)];
                else
                {
                }
            }
        }

        private void BarBtnRefreshData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReloadData();
        }

        private void BarbtnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            SalesOrder so = salesOrderBindingSource.DataSource as SalesOrder;

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
                salesOrderBindingSource.DataSource = new SalesOrder();
            }
        }


        private void BarbtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadData();
            salesOrderBindingSource.DataSource = new SalesOrder();
        }

        private void BarbtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            SalesOrder SO = salesOrderBindingSource.DataSource as SalesOrder;

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
            CTechCore.Tools.frmSearch frm = new CTechCore.Tools.frmSearch();
            ///LOAD DATASOURCE & SET EVENTS FOR Customers
            frm.cntrlSearch1.btnNew.Click += (o, args) =>
            {
                frm.cntrlSearch1.EditValue = new SalesOrder();
            };

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(CTechCore.WaitForms.frmWaitBasic));
            DataTable dt = new DataTable();
            
            MyApp.CTech.ExecSQL($"select * from vw_XR_OrdersForView", ref dt);
            frm.cntrlSearch1.DataSource = dt;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            frm.cntrlSearch1.gridView1.Columns.ToList().ForEach(c => c.MinWidth = 150);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.cntrlSearch1.EditValue is DataRow)
                    salesOrderBindingSource.DataSource = new SalesOrder(((DataRow)frm.cntrlSearch1.EditValue).Field<Int64>("AutoIndex"));
                else if (frm.cntrlSearch1.EditValue is SalesOrder)
                {
                    salesOrderBindingSource.DataSource = (SalesOrder)frm.cntrlSearch1.EditValue;
                }
                //lkpStokGroup.Enabled = false;
            }
        }

        private void frmSalesOrder_Format(object sender, ConvertEventArgs e)
        {
            SalesOrder so = salesOrderBindingSource.DataSource as SalesOrder;

            e.Value = $"Sales Order: {so.DocumentNumber}";
            e.Value += so.State == CTechCore.Enums.Document.State.New ? " - New" : $"ORDER: {so.DocumentNumber} ({so.ExternalOrderNumber})";
        }

        private void BarbtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            SalesOrder so = salesOrderBindingSource.DataSource as SalesOrder;
            if (so.State < CTechCore.Enums.Document.State.Saved)
            {
                MessageBox.Show("Document was not saved and cannot be printed", "Action not possible.");
                return;
            }
            so.PrintDocument();
        }


        private void BarBtnEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            SalesOrder so = salesOrderBindingSource.DataSource as SalesOrder;
            if (so.State < CTechCore.Enums.Document.State.Saved)
            {
                MessageBox.Show("Document was not saved and cannot be mailed.", "Action not possible.");
                return;
            }
            so.eMailDocument();

        }

        private void ReloadData()
        {
            DataTable dt = new DataTable();
            ppCustomer.Properties.DataSource = Customers.GetCustomersInfo();
            
            List<string> visiblecolumns = new List<string>()
            {
                "Account",
                "Name",
                "Email",
                "Telephone",
                "Telephone2"
            };
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns.ToList().ForEach(c => c.Visible = visiblecolumns.Contains(c.FieldName));

            ppCustomer.Properties.PopupFormSize = new Size(1000, 600);
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns["Account"].MinWidth = 100;
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns["Name"].MinWidth = 300;
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns["Email"].MinWidth = 200;
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns["Telephone"].MinWidth = 100;
            ppCustomer.Properties.cntrlSearch1.gridView1.Columns["Telephone2"].MinWidth = 100;
            
            ppDeliverMethod.Properties.DataSource = new DataView(HertexData.Customers.GetDeliveryMethods());
            
            ppRep.Properties.DataSource = new DataView(HertexData.Customers.GetReps());
            
            ppReleaseForInvoicing.Properties.DataSource = Enum.GetValues(typeof(CTechCore.Enums.Document.Processable)).Cast<CTechCore.Enums.Document.Processable>().ToDictionary(c => c, c => c.GetDisplayText() );

            ppPmntStatus.Properties.DataSource = new DataView(HertexData.PaymentTypes.GetPaymentTypes());
            ppPmntStatus.Properties.cntrlSearch1.gridView1.Columns.ToList().ForEach(c => c.Visible = c.FieldName == "Description");
            
            DataTable dtVAT = new DataTable();
            MyApp.Evo.ExecSQL($"SELECT idTaxRate as iTaxTypeID, Code, Description, Description + ' (' +  Code + ')' DisplayText, (TaxRate/100) TaxRate FROM TaxRate", ref dtVAT);
            lkpVAT.DataSource = dtVAT;
            lkpVAT.PopulateColumns();
            lkpVAT.Columns["iTaxTypeID"].Visible = false;
            lkpVAT.ValueMember = "iTaxTypeID";
            lkpVAT.KeyMember = "iTaxTypeID";
            lkpVAT.DisplayMember = "DisplayText";
        }
        
        private void btnCustomerQuickView_Click(object sender, EventArgs e)
        {            
            if (ppCustomer.EditValue == null || (int)ppCustomer.EditValue <= 0) return;
            
            Customers.CustomerQuickView((int)ppCustomer.EditValue);
        }

        private void ppCustomer_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {

            SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                so.CustomerInfo = null;
            else
            {
                if (e.Value is DataRowView)
                    e.Value = (int)((DataRowView)e.Value).Row["ClientID"];
                else if (e.Value is DataRow)
                    e.Value = (int)((DataRow)e.Value)["ClientID"];
                else
                {
                }

                if (e.Value is int)
                    so.CustomerInfo = ((DataView)((CTechCore.Tools.CustomControls.CustomSearchEditor)sender).Properties.DataSource).Table.Select($"ClientID = {(int)e.Value} ").FirstOrDefault();
            }
            
        }

        private void ppCustomer_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                e.DisplayText = "Select Customer";
            else
            {
                if (e.Value is int)
                {
                    if (((CTechCore.Tools.CustomControls.CustomSearchEditor)sender).Properties.DataSource == null) return;
                    DataRow dr = ((DataView)((CTechCore.Tools.CustomControls.CustomSearchEditor)sender).Properties.DataSource).Table.Select($"ClientID = {(int)e.Value} ").FirstOrDefault();
                    e.DisplayText = $"{dr.Field<string>("Account")}: {dr.Field<string>("Name")}";
                }
                else if (e.Value is DataRowView)
                {
                    DataRow dr = ((DataRowView)e.Value).Row;
                    e.DisplayText = $"{dr.Field<string>("Account")}: {dr.Field<string>("Name")}";
                }
                else if (e.Value is DataRow)
                {
                    DataRow dr = (DataRow)e.Value;
                    e.DisplayText = $"{dr.Field<string>("Account")}: {dr.Field<string>("Name")}";
                }
                else
                {
                }
            }
        }

        private void ppCustomer_BeforePopup(object sender, EventArgs e)
        {

        }

        private void ppCustomer_EditValueChanged(object sender, EventArgs e)
        {
            CTechCore.Tools.CustomControls.CustomSearchEditor cntrl = ((CTechCore.Tools.CustomControls.CustomSearchEditor)sender);
            if (cntrl.EditValue != null && cntrl.EditValue is int && (int)cntrl.EditValue > 0)
            {
                SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
                Cursor.Current = Cursors.WaitCursor;
                ppStk.DataSource = new DataView(HertexData.StockItems.GetStockItemList((int)cntrl.EditValue));
                ppStk.PopupControl.Width = 1000;
                ppStk.cntrlSearch1.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "Item", "ItemDesc", "ItemGroup" }.Contains(c.FieldName));
                ppStk.cntrlSearch1.Columns["Item"].MinWidth = 100;
                ppStk.cntrlSearch1.Columns["ItemDesc"].MinWidth = 300;
                ppStk.cntrlSearch1.Columns["ItemColour"].MinWidth = 200;
                Console.WriteLine($"lookup stk: {so.CustomerInfo.Field<int>("ClientID")} | {so.CustomerInfo.Field<string>("Account")} | {so.CustomerInfo.Field<string>("Name")}");
                Cursor.Current = Cursors.Default;
            }
            else
                ppStk.DataSource = null;

        }

        private void ppStk_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            if (e.EditValue == null || (e.EditValue is int && (int)e.EditValue == 0))
                e.DisplayText = "Select Stock Item";
            else
            {
                if (e.EditValue is int)
                {
                    DataView dv = (DataView)ppStk.DataSource;
                    DataRow dr = dv.Table.Select($"StockLink = {(int)e.EditValue}").FirstOrDefault();
                    e.DisplayText = dr.Field<string>("ItemDesc");
                }
                else if (e.EditValue is DataRow)
                {
                    DataRow dr = (DataRow)e.EditValue;
                    e.DisplayText = dr.Field<string>("ItemDesc");
                }
                else
                {
                }
            }
        }

        private void ppStk_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.Value is int)
                return;
            else if (e.Value is DataRow)
                e.Value = ((DataRow)e.Value).Field<int>("StockLink");
            else
            {

            }
        }

        private void ppStk_EditValueChanged(object sender, EventArgs e)
        {
            Decimal finalPrice = 0;
            CTechCore.Tools.CustomControls.CustomSearchEditor cntrl = (CTechCore.Tools.CustomControls.CustomSearchEditor)sender;
            DataRow dr = ((DataView)cntrl.Properties.DataSource).Table.Select($"StockLink = {(int)cntrl.EditValue}").FirstOrDefault();
            int stockLink = int.Parse(dr["StockLink"].ToString());
            
            Decimal defaultPrice = Decimal.Parse(dr["fExclPrice"].ToString());
            SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
            Detail soLine = (Detail)gridView1.GetFocusedRow();
            Models.Stock.StockPrice CurPrice = new Models.Stock.StockPrice(ClientID: so.CustomerID, docdate: so.OrderDate, stockId: (int)cntrl.EditValue, qty: 0);
            if (soLine.PriceListID > 0)
            {
                DataTable dt = new DataTable();
                MyApp.Evo.ExecSQL($"SELECT * FROM zz_CTECH_InvLinesDiscInfo WHERE AutoIDX = {soLine.PriceListID}", ref dt);
                if (dt.Rows.Count > 0)
                {
                    CurPrice.ID = dt.Rows[0].Field<int>("AutoIDX");
                    if (
                        dr.Field<int>("StockLink") == int.Parse(dt.Rows[0]["StockLink"].ToString()) &&
                        (so.OrderDate >= DateTime.Parse(dt.Rows[0]["dEffDate"].ToString()) && so.OrderDate <= DateTime.Parse(dt.Rows[0]["dExpDate"].ToString())))
                    {
                        CurPrice.SpecialPrice = bool.Parse(dt.Rows[0]["bUseStockPrc"].ToString()) ? decimal.Parse(dt.Rows[0]["fPriceDisc"].ToString()) : 0;
                        CurPrice.UseStockPrc = bool.Parse(dt.Rows[0]["bUseStockPrc"].ToString());
                        CurPrice.UseThisPriceExcl = decimal.Parse(dt.Rows[0]["fPriceDisc"].ToString());
                    }
                }
            }
            finalPrice = CurPrice.UseThisPriceExcl;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void btnEditAddr_Click(object sender, EventArgs e)
        {
            SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
            if (new Other.Addresses.frmEditAddress(so).ShowDialog() == DialogResult.OK)
                salesOrderBindingSource.ResetBindings(true);
        }

        private void btn3rdPartyAddr_Click(object sender, EventArgs e)
        {
            SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
            if (new Other.Addresses.frm3rdpartyAddress(so).ShowDialog() == DialogResult.OK )
            {

            }
        }

        private void ppRep_EditValueChanged(object sender, EventArgs e)
        {
            SalesOrder so = (SalesOrder)salesOrderBindingSource.DataSource;
            CTechCore.Tools.CustomControls.CustomSearchEditor cntrl = (CTechCore.Tools.CustomControls.CustomSearchEditor)sender;
            if (cntrl.EditValue is int && (int)cntrl.EditValue > 0)
            {
                DataView dv = (DataView)cntrl.Properties.DataSource;
                DataRow dr = dv.Table.Select($"idSalesRep = {(int)cntrl.EditValue}").FirstOrDefault();
                so.SalesRepresentativeEMail = dr.Field<string>("RepMail");
            }
            else if (cntrl.EditValue is DataRow)
                so.SalesRepresentativeEMail = ((DataRow)cntrl.EditValue).Field<string>("RepMail");
            else
            {
            }
        }

        private void ppDeliverMethod_EditValueChanged(object sender, EventArgs e)
        {

            layoutControlGroup10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            CTechCore.Tools.CustomControls.CustomSearchEditor cntrl = (CTechCore.Tools.CustomControls.CustomSearchEditor)sender;
            if (cntrl.EditValue is int && (int)cntrl.EditValue > 0)
            {
                DataView dv = (DataView)cntrl.Properties.DataSource;
                DataRow dr = dv.Table.Select($"counter = {(int)cntrl.EditValue}").FirstOrDefault();
                if (dr.Field<string>("method").ToUpper().StartsWith("3RD"))
                {
                    layoutControlGroup10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            else if(cntrl.EditValue is DataRow)
            {
                DataRow dr = (DataRow)cntrl.EditValue;
                if (dr.Field<string>("method").ToUpper().StartsWith("3RD"))
                {
                    layoutControlGroup10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
        }
    }
}
