using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Models.Navigation.Manager
{
    public partial class frmNavigationManager : Form
    {
        public frmNavigationManager()
        {
            InitializeComponent();
        }

        private void frmNavigationManager_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            treeList1.DataSource = CTechCore.Models.Navigation.Menus.MenuItemsMaintenance; //SelectMany(m => m.SubMenuItems).Where(m => m.Active).OrderBy(t => t.Text).ToList();
            treeList1.KeyFieldName = "AutoIDX";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.ExpandAll();

            treeListLookUpEdit1TreeList.DataSource = CTechCore.Models.Navigation.Menus.MenuItemsMaintenance;
            treeListLookUpEdit1TreeList.KeyFieldName = "AutoIDX";
            treeListLookUpEdit1TreeList.ParentFieldName = "ParentID";
            treeListLookUpEdit1TreeList.OptionsBehavior.PopulateServiceColumns = true;
            treeListLookUpEdit1TreeList.ExpandAll();

            treeListLookUpEdit1TreeList.Columns.ToList().ForEach(c => c.Visible = new List<string>() { "Text", "Description" }.Contains(c.FieldName));
            treelkpParent.ParseEditValue += TreeListLookUpEdit1_ParseEditValue;
            treelkpParent.CustomDisplayText += TreeListLookUpEdit1_CustomDisplayText;

        }
        
        private void TreeListLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                return;
            else
            {
                if (e.Value is int)
                {
                    List<string> list = GetText((DataTable)((DevExpress.XtraEditors.TreeListLookUpEdit)sender).Properties.TreeList.DataSource, (int)e.Value);
                    list.Reverse();
                    e.DisplayText = string.Join(" > ", list);
                }
                else if(e.Value is DataRowView)
                {
                    DataRow r = ((DataRowView)e.Value).Row;
                    List<string> list = GetText((DataTable)((DevExpress.XtraEditors.TreeListLookUpEdit)sender).Properties.TreeList.DataSource, r.Field<int>("AutoIDX"));
                    list.Reverse();
                    e.DisplayText = string.Join(" > ", list);
                }
                else
                    throw new NotImplementedException();
            }
        }

        private List<string> GetText(DataTable dataSource, int idx)
        {
            List<string> text = new List<string>();
            DataRow r = dataSource.Select($"AutoIDX = {idx}").FirstOrDefault();
            if (r == null || idx == 0)
                return text;
            else
            {
                text.Add(r.Field<string>("Text"));
                text.AddRange( GetText(dataSource, r.Field<int>("ParentID")));
            }
            return text;
        }

        private void TreeListLookUpEdit1_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null || (e.Value is int && (int)e.Value <= 0))
                return;
            else
            {
                if (e.Value is int)
                    return;
                else if (e.Value is DataRowView)
                    e.Value = (int)((DataRowView)e.Value).Row["AutoIDX"];
                else
                    throw new NotImplementedException();
            }
        }

        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
                return;
            else
            {
                DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
                menuItemBindingSource.DataSource = new MenuItem(((DataRowView)tree.GetDataRecordByNode(e.Node)).Row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MenuItem itm = (MenuItem)menuItemBindingSource.DataSource;
            if (itm != null)
            {
                itm.Save();
                ReloadData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            DataRow ParentRow = ((DataRowView)treeList1.GetDataRecordByNode(treeList1.FocusedNode)).Row;
            treelkpParent.EditValue = ParentRow.Field<int>("AutoIDX");
            if (treelkpParent.EditValue == null)
                MessageBox.Show("Select Parent First");
            else
                menuItemBindingSource.DataSource = new MenuItem() { ParentID = (int)treelkpParent.EditValue, GetAllSQL = "SELECT * FROM " };
        }
    }
}
