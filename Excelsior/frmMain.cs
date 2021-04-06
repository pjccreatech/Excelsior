using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HertexCore;

namespace ExcelsiorMain
{
    public partial class frmMain : Form
    {

        #region FORM METHODS
        public frmMain()
        {
            InitializeComponent();
            ribbonControl1.Minimized = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //var x = cntxt.MenuItems.Where(m => m.Active);
            //var y = cntxt.MenuItems.Include("SubMenuItems").ToList();
            //var z = x.Where(m => m.ParentID == null).ToList();
            //var items = x.Where(d => d.ParentID == 0).OrderBy(i => i.ID);
            

            this.Text = MyApp.Name + " - " + MyApp.Version; ;
            toolStripStatusLabel1.Text = $"{MyApp.Version} | ";
            toolStripStatusLabel2.Text = $"";
            toolStripStatusLabel3.Text = $"{MyApp.Evo.Server} [{MyApp.Evo.Database}] | Expiry Date: {MyApp.ExpiryDate.ToString("yyyy-MMM-dd")} |";
            toolStripStatusLabel4.Text = MyApp.ExePath;

            ReloadNavigation();

            MyApp.PastelHlpr.CreateCommonDBConnection("uid=" + MyApp.Common.Username + ";pwd=" + MyApp.Common.Password + ";Initial Catalog=" + MyApp.Common.Database + ";server=" + MyApp.Common.Server + ";Persist Security Info=True;");
            MyApp.PastelHlpr.SetLicense(MyApp.serialNumber, MyApp.AuthorizationKey);
            MyApp.PastelHlpr.CreateConnection("server=" + MyApp.Evo.Server + ";initial catalog=" + MyApp.Evo.Database + ";User ID=" + MyApp.Evo.Username + ";Password=" + MyApp.Evo.Password + ";Persist Security Info=True");
            toolStripStatusLabel2.Text = $"Pastel Version: {MyApp.PastelHlpr.AssemblyVersion.ToString()} | Pastel Company: {MyApp.Evo.Database} | User: {MyApp.Login.User.Username}";



        }

        private void ReloadNavigation()
        {
            DataView dv = new DataView(CTechCore.Models.Navigation.Menus.MenuItemsTable);


            //SecurityLevel = -1: GOD MODE
            if (MyApp.Login.User.SecurityLevel >= 0)
            {
                KeyValuePair<Module, HertexCore.Models.Users.Permissions> excelsior = MyApp.Login.User.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.Excelsior));
                var modules = MyApp.Login.User.Modules.Where(m => !m.Key.Equals(HertexCore.Modules.Excelsior)).Select(m => m).ToList();

                string filter = "Active = 1";
                filter += $" AND (AutoIDX IN ({(excelsior.Value.Count == 0 ? "0" : string.Join(",", excelsior.Value.Select(p => p.PermissionValue).ToList()))})";
                if (modules.Count > 0) filter += $" OR ExternalModuleIDX IN ({string.Join(",", modules.Select(m => m.Key.ID.ToString())) })";
                filter += ")";
                dv.RowFilter = filter;

                ribbonPageCRM.Visible = MyApp.Login.User.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.CRM)).Key != null;
                ribbonPageAppro.Visible = MyApp.Login.User.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.Appro)).Key != null;
                ribbonPageExcelsior.Visible = MyApp.Login.User.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.Excelsior)).Key != null;
                ribbonPageUsers.Visible = false;
                ribbonPageCreatech.Visible = false;
            }

            treeList1.DataSource = dv; //SelectMany(m => m.SubMenuItems).Where(m => m.Active).OrderBy(t => t.Text).ToList();
            treeList1.KeyFieldName = "AutoIDX";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.ExpandAll();
        }

        #endregion FORM METHODS

        #region RIBBON EVENTS
        private void barbtnSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }


        private void barbtnCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnSOCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(HertexCore.Models.AccountsReceivable.Transactions.SalesOrders.frmSalesOrders))
                {
                    form.Activate();
                    return;
                }
            }

            HertexCore.Models.AccountsReceivable.Transactions.SalesOrders.frmSalesOrders frmSO = new HertexCore.Models.AccountsReceivable.Transactions.SalesOrders.frmSalesOrders();
            frmSO.MdiParent = this;
            frmSO.Show();
        }

        private void barbtnStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void barbtnUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(HertexCore.Models.Users.Forms.frmManageUsers))
                {
                    form.Activate();
                    return;
                }
            }

            HertexCore.Models.Users.Forms.frmManageUsers frm = new HertexCore.Models.Users.Forms.frmManageUsers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barbtnBranches_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnPOCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barBtnStockReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnRTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barBtnStockIssue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnGRV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers.frmPurchaseOrdersToGRV))
                {
                    form.Activate();
                    return;
                }
            }

            HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers.frmPurchaseOrdersToGRV frmSO = new HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers.frmPurchaseOrdersToGRV();
            frmSO.MdiParent = this;
            frmSO.Show();


        }

        private void barBtnReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barbtnShowHideNavPane_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanel2.Visibility = dockPanel2.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden ? DevExpress.XtraBars.Docking.DockVisibility.Visible : DevExpress.XtraBars.Docking.DockVisibility.Hidden;
        }

        private void btnCommodityCheckIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        #endregion RIBBON EVENTS

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
                DevExpress.XtraTreeList.TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {
                    CTechCore.Models.Navigation.Menus.MenuItem mnu = new CTechCore.Models.Navigation.Menus.MenuItem(((DataRowView)tree.GetDataRecordByNode(tree.Selection[0])).Row);
                    if (mnu.DisplayAllFormBeforeLoad)
                        CTechCore.Models.Navigation.Menus.DisplayListAll(mnu);
                    else
                        CTechCore.Models.Navigation.Menus.LoadEntityForm(mnu);

                }
            }
            catch (Exception ex)
            {
                string msg = $"Error loading screen : {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }   
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void barbtnSOFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnNavManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTechCore.Models.Navigation.Manager.frmNavigationManager frm = new CTechCore.Models.Navigation.Manager.frmNavigationManager();
            frm.ShowDialog();
        }

        private void dockPanel2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Refresh")
                ReloadNavigation();
        }


        private void barbtnCRM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CRM.Form1 frm = new CRM.Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barbtnAppro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ApproARM.Form1 frm = new ApproARM.Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HertexCore.Models.Stock.Forms.frmAdjustRollLength frm = new HertexCore.Models.Stock.Forms.frmAdjustRollLength( new HertexCore.Models.Stock.StockRollItems.StockRollItem(2085680));
            frm.ShowDialog();

        }
    }
}
