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
    public partial class frmPurchaseOrdersToGRV : CTechCore.Models.Document.frmDocumentBase
    {
        public frmPurchaseOrdersToGRV()
        {
            InitializeComponent();

            InitializeControls();

            LoadData();
        }

        private void InitializeControls()
        {

            barBtnRefreshData.ItemClick += BarBtnRefreshData_ItemClick;
            barbtnOpen.ItemClick += BarbtnOpen_ItemClick;

            barbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnProcess.ItemClick += BarbtnProcess_ItemClick;
            DevExpress.XtraBars.BarButtonItem barbtnPrintBarcodes = new DevExpress.XtraBars.BarButtonItem();
            barbtnPrintBarcodes.Caption = "Print Barcodes";
            barbtnPrintBarcodes.ImageOptions.Image = ((System.Drawing.Image)(Properties.Resources.Print_32x32 ));
            barbtnPrintBarcodes.ImageOptions.LargeImage = ((System.Drawing.Image)(Properties.Resources.Print_32x32));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barbtnPrintBarcodes });
            barbtnPrintBarcodes.ItemClick += BarbtnPrintBarcodes_ItemClick;
            this.ribbonPageGroup2.ItemLinks.Add(barbtnPrintBarcodes);
        }

        private void BarbtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTechCore.Tools.frmSearch frm = new CTechCore.Tools.frmSearch();
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(CTechCore.WaitForms.frmWaitBasic));
            DataTable dt = new DataTable();

            MyApp.CTech.ExecSQL($"select AutoIndex, OrderNum, Account, Name, OrderDate,  ulIDPOrdConfirmed State from vw_XR_PurchaseOrdersForGRV ", ref dt);
            frm.cntrlSearch1.DataSource = dt;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            frm.cntrlSearch1.gridView1.Columns.ToList().ForEach(c => c.MinWidth = 150);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.cntrlSearch1.EditValue is DataRow)
                    purchaseOrderToGRVBindingSource.DataSource = new PurchaseOrderToGRV(((DataRow)frm.cntrlSearch1.EditValue).Field<Int64>("AutoIndex"));
                else if (frm.cntrlSearch1.EditValue is PurchaseOrderToGRV)
                    purchaseOrderToGRVBindingSource.DataSource = (PurchaseOrderToGRV)frm.cntrlSearch1.EditValue;

                PurchaseOrderToGRV grv = (PurchaseOrderToGRV)purchaseOrderToGRVBindingSource.DataSource;
                gcPOHeader.DataSource = grv.HeaderInfo;
                gcPODetails.DataSource = grv.DetailInfo;
                //lkpStokGroup.Enabled = false;
            }
        }

        private void BarbtnPrintBarcodes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PurchaseOrderToGRV grv = (PurchaseOrderToGRV)purchaseOrderToGRVBindingSource.DataSource;
            List<int> rolls = new List<int>();
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"SELECT StockRollID FROM StockRollHdr (NOLOCK) WHERE PONumber = '{grv.HeaderInfo.Table.AsEnumerable().FirstOrDefault().Field<string>("Ordernum")}' ", ref dt);
            
            Stock.StockRollItems.PrintBarcodes(dt.AsEnumerable().Select(r => (int)r["StockRollID"]).ToList());
        }

        public void LoadData()
        {
            DataTable dt = new DataTable();
            DataView dv = GRVBinLocations.GetList();
            lkpBinLocation.Properties.DataSource = dv;
            lkpBinLocation.Properties.ForceInitialize();
            lkpBinLocation.Properties.PopulateColumns();
            lkpBinLocation.Properties.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "BinLocation", "LongName" }.Contains(c.FieldName));
            lkpBinLocation.Properties.DisplayMember = "BinLocation";
            lkpBinLocation.Properties.KeyMember = "AutoIDX";

            lkpBinLocation.EditValue = dv.Table.AsEnumerable().FirstOrDefault(r => (int)r["IsGRVBin"] > 1);
        }

        public frmPurchaseOrdersToGRV(int poid)
        {
            InitializeComponent();
            InitializeControls();
            LoadData();
        }
        public frmPurchaseOrdersToGRV(DataRow dr)
        {
            InitializeComponent();
            InitializeControls();
            LoadData();

        }

        public frmPurchaseOrdersToGRV(CTechCore.Models.Navigation.MenuItem mnu, object grvobj)
        {
            InitializeComponent();
            InitializeControls();
            LoadData();


            purchaseOrderToGRVBindingSource.DataSource = (PurchaseOrderToGRV)grvobj;
            gcPOHeader.DataSource = ((PurchaseOrderToGRV)grvobj).HeaderInfo;
            gcPODetails.DataSource = ((PurchaseOrderToGRV)grvobj).DetailInfo;
        }

        private void BarBtnRefreshData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarbtnProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lkpBinLocation.EditValue == null)
            {
                MessageBox.Show("Please select a bin location for all these items", "Invalid Bin Location ", MessageBoxButtons.OK);
                lkpBinLocation.Focus();
                return;
            }

            if (lkpBinLocation.Text.ToLower() == "photo")
            {
                //if(not user in ("vanessa", "richard", "cheslyn") )
                //if not((vStaffID = 'vanessa') or(vStaffID = 'cheslyn') or(vStaffID = 'richard')) then
                //begin
                //      messagedlg('You are not permitted to use this bin location', mtError, [mbOK], 0);
                //      exit;
                //end;
            }
            PurchaseOrderToGRV grv = (PurchaseOrderToGRV)purchaseOrderToGRVBindingSource.DataSource;
            string OrdNumber = grv.HeaderInfo.Table.AsEnumerable().FirstOrDefault().Field<string>("OrderNum");
            if (MessageBox.Show($"Are you sure that you want to create a GRV for Purchase Order number '{OrdNumber}'?'", "Please confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UseWaitCursor = true;
                grv.Location = lkpBinLocation.Text;

                DataSet results = (DataSet)CTechCore.WaitForms.cWaitWindow.Show(grv.Process, "", new object[] { });
                List<int> rolls = results.Tables.OfType<DataTable>().ToList().SelectMany(t => t.AsEnumerable().Select(r => (int)r["StockRollID"])).ToList();
                Stock.StockRollItems.PrintBarcodes(rolls);

                grv.Reload(grv.DocumentNumber);
                purchaseOrderToGRVBindingSource.DataSource = grv;

                gcPOHeader.DataSource = grv.HeaderInfo;
                gcPODetails.DataSource = grv.DetailInfo;
                UseWaitCursor = false;
            }
        }

        private void gcPODetails_DoubleClick(object sender, EventArgs e)
        {


        }

        private void gvPODetails_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                frmReceiveStock frm = new frmReceiveStock((DataRow)view.GetDataRow(info.RowHandle));
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PurchaseOrderToGRV grv = (PurchaseOrderToGRV)purchaseOrderToGRVBindingSource.DataSource;
                    grv.Reload();
                    gcPOHeader.DataSource = grv.HeaderInfo;
                    gcPODetails.DataSource = grv.DetailInfo;
                }
            }
        }

        private void lkpBinLocation_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
