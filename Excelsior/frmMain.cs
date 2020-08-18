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

namespace Excelsior
{
    public partial class frmMain : Form
    {

        #region FORM METHODS
        public frmMain()
        {
            InitializeComponent();
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

            treeList1.DataSource = Excelsior.Library.Models.Navigation.Menus.MenuItemsTable; //SelectMany(m => m.SubMenuItems).Where(m => m.Active).OrderBy(t => t.Text).ToList();
            treeList1.KeyFieldName = "AutoIDX";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.ExpandAll();
            ////MANAGING ITEMS BUTTONS
            //DevExpress.XtraBars.BarItemVisibility vsble = MyApp.Branch.IsHeadOffice ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //barbtnSupplier.Visibility = vsble;
            //barbtnCustomers.Visibility = vsble;
            //barbtnStock.Visibility = vsble;
            //barbtnBranches.Visibility = vsble;
            //barbtnSettings.Visibility = vsble;

            //////TRANSACTION BUTTONS
            //vsble = MyApp.Branch.IsHeadOffice ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            //barbtnPOCreate.Visibility = vsble;
            //barbtnSOCreate.Visibility = vsble;
            //barbtnGRV.Visibility = vsble;
            //barbtnRTS.Visibility = vsble;
            //barBtnStockIssue.Visibility = vsble;
            //NuLeafLibrary.Models.frmEntityBase frmDepot = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.Depot));
            //NuLeafLibrary.Models.frmEntityBase frmGrade = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.Grade));
            //NuLeafLibrary.Models.frmEntityBase frmCommGrp = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.CommodityGroup));
            //frmDepot.Show();
            //frmGrade.Show();
            //frmCommGrp.Show();

            //NuLeafLibrary.Models.frmEntityBase frmTrans = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.Transporter));
            //NuLeafLibrary.Models.frmEntityBase frmTruckCond = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.TruckCondition));
            //NuLeafLibrary.Models.frmEntityBase frmStkGrps = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.StockGroup));
            //frmTrans.Show();
            //frmTruckCond.Show();
            //frmStkGrps.Show();

            //NuLeafLibrary.Models.frmEntityBase frmBrand = new NuLeafLibrary.Models.frmEntityBase(typeof(DataModelLibrary.Brand));
            //frmBrand.Show();


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
                if (form.GetType() == typeof(Excelsior.UI.Models.AccountsRecievable.Transactions.SalesOrders.frmSalesOrder))
                {
                    form.Activate();
                    return;
                }
            }

            Excelsior.UI.Models.AccountsRecievable.Transactions.SalesOrders.frmSalesOrder frmSO = new Excelsior.UI.Models.AccountsRecievable.Transactions.SalesOrders.frmSalesOrder();
            frmSO.MdiParent = this;
            frmSO.Show();
        }

        private void barbtnStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void barbtnUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            
            string selectedNode;

            DevExpress.XtraTreeList.TreeListMultiSelection selectedNodes = treeList1.Selection;             //get the selected node
            selectedNode =  selectedNodes[0].GetValue(treeList1.Columns[0]).ToString();                     //gets the value of the selected node and store it in the selectedNode variable
            
            DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                Excelsior.Library.Models.Navigation.Menus.MenuItem mnu = new Library.Models.Navigation.Menus.MenuItem(((DataRowView)tree.GetDataRecordByNode(tree.Selection[0])).Row);
                Excelsior.Library.Models.Navigation.Menus.DisplayListAll(mnu);

            }
        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void barbtnSOFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
