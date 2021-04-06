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

namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    public partial class frmSalesOrderToInvoice : CTechCore.Models.Document.frmDocumentBase
    {
        public frmSalesOrderToInvoice()
        {
            InitializeComponent();
            InitializeControls();
        }
        public frmSalesOrderToInvoice(CTechCore.Models.Navigation.MenuItem mnu)
        {
            InitializeComponent();
            InitializeControls();
        }
        public frmSalesOrderToInvoice(CTechCore.Models.Navigation.MenuItem mnu, object grvobj)
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {


            barbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barBtnRefreshData.ItemClick += BarBtnRefreshData_ItemClick;
            barbtnProcess.ItemClick += BarbtnProcess_ItemClick;
            //DevExpress.XtraBars.BarButtonItem barbtnPrintBarcodes = new DevExpress.XtraBars.BarButtonItem();
            //barbtnPrintBarcodes.Caption = "Print Barcodes";
            //barbtnPrintBarcodes.ImageOptions.Image = ((System.Drawing.Image)(Properties.Resources.Print_32x32));
            //barbtnPrintBarcodes.ImageOptions.LargeImage = ((System.Drawing.Image)(Properties.Resources.Print_32x32));
            //this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barbtnPrintBarcodes });
            //barbtnPrintBarcodes.ItemClick += BarbtnPrintBarcodes_ItemClick;
            //this.ribbonPageGroup2.ItemLinks.Add(barbtnPrintBarcodes);
        }

        private void BarbtnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BarBtnRefreshData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barbtnFilterAll_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (((DevExpress.XtraBars.BarCheckItem)sender).Checked == false) return;
            barbtnFilterNewOrd.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
            barbtnFilterBO.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
        }

        private void barbtnFilterNewOrd_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (((DevExpress.XtraBars.BarCheckItem)sender).Checked == false) return;
            barbtnFilterAll.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
            barbtnFilterBO.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
        }

        private void barbtnFilterBO_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (((DevExpress.XtraBars.BarCheckItem)sender).Checked == false) return;
            barbtnFilterAll.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
            barbtnFilterNewOrd.Checked = !((DevExpress.XtraBars.BarCheckItem)sender).Checked;
        }
    }
}
