using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Models.Navigation
{
    public partial class frmListAll : System.Windows.Forms.Form
    {
        public Menus.MenuItem ListOfType { get; set; }
        public event EventHandler Row_KeyPress;

        public frmListAll()
        {
            InitializeComponent();

            cntrlSearch1.gridView1.KeyUp += GridView1_KeyUp;
            cntrlSearch1.gridControl1.KeyUp += GridView1_KeyUp;
            cntrlSearch1.OnRowEnterKeyPress += (o, e) =>
           {

           };
        }

        public frmListAll(Menus.MenuItem args)
        {
            InitializeComponent();

            cntrlSearch1.gridView1.KeyUp += GridView1_KeyUp;
            cntrlSearch1.gridControl1.KeyUp += GridView1_KeyUp;
            this.cntrlSearch1.OnRowEnterKeyPress += (o, e) =>
            {
                LoadEntityForm(cntrlSearch1.gridView1);
            };

            this.cntrlSearch1.ShowFindPanel = true;
            this.cntrlSearch1.ShowButtonPanel = false;
            this.cntrlSearch1.pnlCustomButtons.Visible = true;
            this.cntrlSearch1.pnlCustomButtons.Controls.Add(btnEdit);
            this.cntrlSearch1.pnlCustomButtons.Controls.Add(btnAdd);
            this.cntrlSearch1.pnlCustomButtons.Controls.Add(btnRefresh);
            this.ListOfType = args;
            this.Text = args.Text;

            this.lblCaption.Text = args.Text.ToUpper();
            this.MdiParent = args.MdiParent == null ? Application.OpenForms.Cast<System.Windows.Forms.Form>().FirstOrDefault(f => f.Name == "frmMain") : args.MdiParent;

            ((DevExpress.XtraGrid.Views.Grid.GridView)this.cntrlSearch1.gridControl1.MainView).PopupMenuShowing += gridView1_PopupMenuShowing;
        }

        private void GridView1_KeyUp(object sender, KeyEventArgs e)        
        {
            if (e.KeyData == Keys.Enter)
            {
                //DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
                //CTechCore.Tools.ControlHelpers.CustomGridControl cntrl = (CTechCore.Tools.ControlHelpers.CustomGridControl)sender;
                //DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)cntrl.MainView;
                //if (view == null) return;

                //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
                //if (info.InRow || info.InRowCell)
                //    DialogResult = LoadEntityForm((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.FocusedView);
            }
        }

        private DialogResult LoadEntityForm(DevExpress.XtraGrid.Views.Grid.GridView sender)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                cntrlSearch1.Enabled = false;
                DialogResult result = CTechCore.Models.Navigation.Menus.LoadEntityForm(this.ListOfType, sender);
                if (result == DialogResult.OK) this.ReloadDataSource();
                return result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return DialogResult.Cancel;
            }
            finally
            {
                cntrlSearch1.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void ReloadDataSource()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL(ListOfType.GetAllSQL, ref dt);
            cntrlSearch1.DataSource = dt;
                
            cntrlSearch1.gridView1.OptionsView.ColumnAutoWidth = true;
            cntrlSearch1.gridControl1.DoubleClick -= FrmListAll_DoubleClick;
            cntrlSearch1.gridControl1.DoubleClick += FrmListAll_DoubleClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = LoadEntityForm(null);
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult = LoadEntityForm((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.FocusedView);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ReloadDataSource();
            Cursor.Current = Cursors.Default;
        }

        private void FrmListAll_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            CTechCore.Tools.ControlHelpers.CustomGridControl cntrl = (CTechCore.Tools.ControlHelpers.CustomGridControl)sender;
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)cntrl.MainView;
            if (view == null) return;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                DialogResult = LoadEntityForm((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.FocusedView);
            
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRow && e.HitInfo.RowInfo != null)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

                    dynamic obj = null;
                    object itm = gv.GetRow(gv.FocusedRowHandle);

                    string displaytext = String.Empty;
                    List<string> columns = new List<string>();
                    DataRow drSelected = null;
                    if (itm != null)
                    {
                        Int64 id = 0;
                        if (itm is System.Data.DataRowView)
                        {
                            drSelected = ((System.Data.DataRowView)itm).Row;
                            id = (Int64)((System.Data.DataRowView)itm).Row[0];
                            foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(this.ListOfType.DisplayText, @"(?<!\w)@\w+"))
                                columns.Add(match.Value);
                            displaytext = this.ListOfType.DisplayText;
                            columns.ForEach(c => displaytext = displaytext.Replace(c, drSelected[c.Replace("@", "")].ToString()));
                        }
                        else
                        {
                            obj = itm;
                        }
                    }


                    DevExpress.XtraGrid.Menu.GridViewMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewMenu;
                    menu.Items.Clear();
                    
                    DevExpress.Utils.Menu.DXMenuItem mgr = new DevExpress.Utils.Menu.DXMenuItem();
                    mgr.Caption = $"Edit {displaytext}";
                    mgr.Click += delegate (object o, EventArgs args)
                    {
                        LoadEntityForm((DevExpress.XtraGrid.Views.Grid.GridView)sender);
                    };
                    menu.Items.Add(mgr);
                    
                    DataTable dt = new DataTable();
                    MyApp.CTech.ExecSQL($"SELECT * FROM  MenuItemContextMenu WHERE Menuitem = {this.ListOfType.ID}", ref dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DevExpress.Utils.Menu.DXMenuItem mnu = new DevExpress.Utils.Menu.DXMenuItem();
                        mnu.Caption = dr.Field<string>("DisplayText");
                        mnu.Click += delegate (object o, EventArgs args)
                        {
                            
                            System.Reflection.MethodInfo theMethod = this.ListOfType.RuntimeObjectType.GetMethod(dr.Field<string>("Event"));
                            if (theMethod != null)
                            {
                                var x = theMethod.Invoke(obj, new object[] { });
                                this.ReloadDataSource();
                            }

                        };
                        menu.Items.Add(mnu);
                    }
                    mgr = new DevExpress.Utils.Menu.DXMenuItem();
                    mgr.BeginGroup = true;
                    mgr.Caption = $"Excel(xlsx) Export";
                    mgr.Click += delegate (object o, EventArgs args)
                    {
                        SaveFileDialog dlg = new SaveFileDialog();
                        dlg.Filter = "*.xlsx|*.xlsx";
                        dlg.DefaultExt = ".xlsx";                        
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            cntrlSearch1.gridView1.ExportToXlsx(dlg.FileName);
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                    };
                    menu.Items.Add(mgr);
                }
            }
        }
        
        private void frmListAll_Shown(object sender, EventArgs e)
        {
            this.ReloadDataSource();
        }

        private void frmListAll_Load(object sender, EventArgs e)
        {
        }

        private void cntrlSearch1_Load(object sender, EventArgs e)
        {

        }

        private void cntrlSearch1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
} 
