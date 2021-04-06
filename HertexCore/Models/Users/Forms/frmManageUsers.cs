using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Users.Forms
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            CTechCore.Tools.Forms.InitializeControlsFocus(this);
            LoadData();
        }

        public frmManageUsers(CTechCore.Models.Navigation.MenuItem mnu, object usrobj)
        {
            InitializeComponent();
            CTechCore.Tools.Forms.InitializeControlsFocus(this);
            LoadData();
            vwUsers.FindFilterText = ((User)usrobj).Username;
            if (usrobj != null) LoadUser((User)usrobj);
        }

        private void LoadData()
        {
            pnlUserInfo.Visible = false;
            grdUsers.DataSource = HertexData.Users.GetUsers;
            grdModules.DataSource = HertexData.Modules.GetModules;

            DataView dv = new DataView(CTechCore.Models.Navigation.Menus.MenuItemsTable);
            dv.RowFilter = "ExternalModuleIDX = 0";
            treeList1.DataSource = dv;
            treeList1.KeyFieldName = "AutoIDX";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "Text",  }.Contains(c.FieldName));
            treeList1.SelectNode(treeList1.Nodes.FirstNode);
            treeList1.ClearFocusedColumn();
            treeList1.ExpandAll();

            lkpRep.Properties.DataSource = new DataView(HertexData.Customers.GetReps());
            lkpRep.Properties.PopulateViewColumns();
            lkpRep.Properties.ValueMember = "Code";
            lkpRep.Properties.KeyMember = "Code";
            lkpRep.Properties.DisplayMember = "DisplayText";
            
            lkpRep.Properties.View.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "Code", "Name" }.Contains(c.FieldName));
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = (User)userBindingSource.DataSource;
            CaptureExcelsiorPermissions(user);
            if (user.Save())
            {
                grdUsers.Enabled = true;
                pnlUserInfo.Visible = false;
            }
        }

        private void CaptureExcelsiorPermissions(User user)
        {

            if (user.Modules.Any(m => m.Key.Equals(HertexCore.Modules.Excelsior)))
            {
                KeyValuePair<Module, Permissions> excelsior = user.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.Excelsior));
                excelsior.Value.Clear();
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeList1.GetAllCheckedNodes())
                {
                    excelsior.Value.Add(new Permission()
                    {
                        ID = 0,
                        UserID = user.ID,
                        ModuleName = excelsior.Key.Name,
                        PermissionKey = node.GetValue("Description").ToString(),
                        PermissionValue = node.GetValue("AutoIDX").ToString(),
                    }); ;
                }
            }


        }

        private void btnAddModules_Click(object sender, EventArgs e)
        {
            try
            {
                CTechCore.Tools.frmSearch frm = new CTechCore.Tools.frmSearch();
                DataView dv = HertexData.Modules.GetModules;
                dv.RowFilter = $"Active = 1";
                frm.cntrlSearch1.DataSource = dv;
                frm.cntrlSearch1.ViewMultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                frm.cntrlSearch1.ViewSelectionMultiSelect = true;
                //frm.cntrlSearch1.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "Varieties" }.Contains(c.FieldName));


                User user = (User)userBindingSource.DataSource;
                foreach (var module in user.Modules)
                {
                    int irow = frm.cntrlSearch1.gridView1.LocateByValue("AutoIDX", module.Key.ID);
                    frm.cntrlSearch1.gridView1.SelectRow(irow);
                }


                if (frm.ShowDialog() == DialogResult.OK)
                {
                    user.Modules.Clear();
                    foreach (int i in frm.cntrlSearch1.gridView1.GetSelectedRows())
                    {
                        DataRow r = ((DataRowView)frm.cntrlSearch1.gridView1.GetRow((int)i)).Row;
                        user.Modules.Add(new KeyValuePair<Module, Permissions>(new Modules(r.Field<string>("Module")), new Permissions()) );
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {e.ToString()}");
            }
        }

        private void vwUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void grdUsers_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.GridControl cntrl = (DevExpress.XtraGrid.GridControl)sender;
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)cntrl.MainView;
            if (view == null) return;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                try
                {
                    DataRow dr = vwUsers.GetDataRow(view.GetSelectedRows()[0]);
                    LoadUser(new User(dr.Field<int>("AutoIndex")));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Error: {e.ToString()}");
                }
            }


        }

        private void LoadUser(User user)
        {
            grdUsers.Enabled = false;
            pnlUserInfo.Visible = true;
            userBindingSource.DataSource = user;
            if (user.Modules.Any(m => m.Key.Equals(HertexCore.Modules.Excelsior)))
            {
                foreach (Permission permission in user.Modules.FirstOrDefault(m => m.Key.Equals(HertexCore.Modules.Excelsior)).Value)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList1.FindNodeByFieldValue("AutoIDX", int.Parse(permission.PermissionValue));
                    if (node != null) node.Checked = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            userBindingSource.DataSource = typeof(User);            
            grdUsers.Enabled = true;
            pnlUserInfo.Visible = false;
        }

        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void treeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {

        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                if (e.Node.Checked)
                    e.Node.CheckAll();
                else
                    e.Node.UncheckAll();
            }
        }
    }
}
