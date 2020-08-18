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

namespace Excelsior.Library.Models.Navigation
{
    public partial class frmListAll : System.Windows.Forms.Form
    {
        public Excelsior.Library.Models.Navigation.Menus.MenuItem ListOfType { get; set; }

        public frmListAll()
        {
            InitializeComponent();
        }

        private DialogResult LoadEntityForm(DevExpress.XtraGrid.Views.Grid.GridView sender)
        {
            try
            {
                System.Windows.Forms.Form frm = null;
                dynamic obj = null;
                object[] parms = null;

                if (sender == null)
                {
                    ///add button clicked which load new instance of obj
                    obj = Activator.CreateInstance(this.ListOfType.RuntimeObjectType);
                    
                    parms = new object[] { this.ListOfType, obj };
                }
                else
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gv = sender;
                    object itm = gv.GetRow(gv.FocusedRowHandle);

                    if (itm != null)
                    {
                        int id = (int)((System.Data.DataRowView)itm).Row[0];
                        if (obj == null) obj = Activator.CreateInstance(this.ListOfType.RuntimeObjectType, new object[] { id });
                        parms = new object[] { this.ListOfType, obj };
                    }
                    else
                        return DialogResult.None; 
                }
                frm = (System.Windows.Forms.Form)Activator.CreateInstance(this.ListOfType.RuntimeFormType, parms);
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.ReloadDataSource();
                    return DialogResult.OK;
                }
                else
                    return DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return DialogResult.Cancel;
            }

        }

        private void ReloadDataSource()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL(ListOfType.GetAllSQL, ref dt);
            cntrlSearch1.DataSource = dt;
                
            ((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.MainView).OptionsView.ColumnAutoWidth = true;
            ((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.MainView).DoubleClick -= FrmListAll_DoubleClick;
            ((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.MainView).DoubleClick += FrmListAll_DoubleClick;
        }


        public frmListAll(Menus.MenuItem args)
        {
            InitializeComponent();
            this.cntrlSearch1.pnlCustomButtons.Visible = true;
            this.ListOfType = args;
            this.Text = args.Text;

            this.lblHeader.Text = args.Text.ToUpper();
            this.MdiParent = args.MdiParent == null ? Application.OpenForms.Cast<System.Windows.Forms.Form>().FirstOrDefault(f => f.Name == "frmMain") : args.MdiParent;


            ((DevExpress.XtraGrid.Views.Grid.GridView)this.cntrlSearch1.gridControl1.MainView).PopupMenuShowing += gridView1_PopupMenuShowing;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = LoadEntityForm(null);
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult = LoadEntityForm((DevExpress.XtraGrid.Views.Grid.GridView)cntrlSearch1.gridControl1.FocusedView);
        }

        private void FrmListAll_DoubleClick(object sender, EventArgs e)
        {
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

                    if (itm != null)
                    {
                        int id = 0;
                        if (itm is System.Data.DataRowView)
                        {
                            id = (int)((System.Data.DataRowView)itm).Row[0];
                            if (obj == null) obj = Activator.CreateInstance(this.ListOfType.RuntimeObjectType, new object[] { id });
                        }
                        else
                        {
                            obj = itm;
                        }
                    }
                    
                    DevExpress.XtraGrid.Menu.GridViewMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewMenu;
                    menu.Items.Clear();
                    
                    DevExpress.Utils.Menu.DXMenuItem mgr = new DevExpress.Utils.Menu.DXMenuItem();
                    mgr.Caption = $"Edit";
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


    }
} 
