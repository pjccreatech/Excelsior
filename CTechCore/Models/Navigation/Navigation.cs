
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Models.Navigation
{
    public class Menus : CTechCore.Models.Navigation.MenuItem
    {
        public class MenuItem : Models.Navigation.MenuItem
        {
            public ICollection<MenuItem> SubMenuItems { get; set; }

            public MenuItem(DataRow dr) : base(dr)
            {
                this.SubMenuItems = new BindingList<MenuItem>();
            }
            
        }

        public static ICollection<MenuItem> MenuItems
        {
            get
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL("SELECT * FROM vw_XR_NavigationMenu ", ref dt);

                BindingList<MenuItem> items = new BindingList<MenuItem>(dt.AsEnumerable().Where(dr => dr.Field<int>("ParentID") == 0).Select(dr => 
                {
                    MenuItem mnu = new MenuItem(dr);
                    mnu.SubMenuItems = GetChildren(dt, mnu.ID);
                    return mnu;
                }).ToList());
                            
                return items;   
            }
        }

        public static DataTable MenuItemsTable
        {
            get
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL("SELECT * FROM vw_XR_NavigationMenu order by text", ref dt);
                
                return dt;
            }
        }

        public static DataTable MenuItemsMaintenance
        {
            get
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL("SELECT * FROM NavigationMenu ", ref dt);

                return dt;
            }
        }

        public static BindingList<MenuItem> GetChildren(DataTable dt, int parentId)
        {
            return new BindingList<MenuItem>(dt.AsEnumerable()
                    .Where(dr => dr.Field<int>("ParentID") == parentId)
                    .Select(dr =>
                    {
                        MenuItem m = new MenuItem(dr);
                        m.SubMenuItems = new BindingList<MenuItem>(GetChildren(dt, m.ID).ToList());
                        return m;
                    })
                    .ToList());
        }

        public static void DisplayListAll(MenuItem mnu)
        {
            frmListAll frm = null;
            if (mnu != null)
            {
                frm = (frmListAll)CTechCore.Tools.Forms.IsFormInstantiated(typeof(frmListAll)).FirstOrDefault(f => ((frmListAll)f).ListOfType.ObjectType == mnu.ObjectType);

                if (frm == null)
                {
                    frm = new frmListAll(mnu);
                    frm.Show();
                }
                frm.Activate();

            }
        }


        public static DialogResult LoadEntityForm(MenuItem mnu, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                System.Windows.Forms.Form frm = null;
                dynamic obj = null;
                object[] parms = null;

                if (view == null)
                {
                    ///add button clicked which load new instance of obj
                    obj = Activator.CreateInstance(mnu.RuntimeObjectType);

                    parms = new object[] { mnu, obj };
                }
                else
                {
                    object itm = view.GetRow(view.FocusedRowHandle);

                    if (itm != null)
                    {
                        Int64 id = 0;
                        if (((System.Data.DataRowView)itm).Row[0] is Int64)
                            id = (Int64)((System.Data.DataRowView)itm).Row[0];
                        else
                            id = (int)((System.Data.DataRowView)itm).Row[0];
                        if (obj == null) obj = Activator.CreateInstance(mnu.RuntimeObjectType, new object[] { (int)id });
                        parms = new object[] { mnu, obj };
                    }
                    else
                        return DialogResult.None;
                }
                return DisplayForm(parms);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return DialogResult.Cancel;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static DialogResult DisplayForm( object[] parms)
        {
            MenuItem mnu = (MenuItem)parms[0];
            System.Windows.Forms.Form frm = CTechCore.Tools.Forms.IsFormInstantiated(mnu.RuntimeFormType).FirstOrDefault();
            if (frm != null)
            {
                frm.Close();
                frm.Dispose();
                frm = null;
            }

            if (mnu.RequiresParametersOnConstructer)
                frm = (System.Windows.Forms.Form)Activator.CreateInstance(mnu.RuntimeFormType, parms);
            else
                frm = (System.Windows.Forms.Form)Activator.CreateInstance(mnu.RuntimeFormType, new object[] { });
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (!mnu.DisplayAllFormBeforeLoad)
            {
                frm.MdiParent = CTechCore.Tools.Forms.IsFormInstantiated("frmMain").FirstOrDefault();
                frm.Show();
            }
            else
                frm.ShowDialog();
            return DialogResult.OK;
        }

        public static DialogResult LoadEntityForm(MenuItem mnu)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                object[] parms = new object[] { mnu };

                ///add button clicked which load new instance of obj
                if (mnu.RuntimeObjectType != null)
                {
                    dynamic obj = Activator.CreateInstance(mnu.RuntimeObjectType);
                    parms.ToList().Add( obj );
                }

                return DisplayForm(parms);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return DialogResult.Cancel;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
