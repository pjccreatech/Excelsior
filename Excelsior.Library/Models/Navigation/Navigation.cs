using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Library.Models.Navigation
{
    public class Menus : Excelsior.Core.Models.Navigation.MenuItem
    {
        public class MenuItem : Excelsior.Core.Models.Navigation.MenuItem
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
                MyApp.CTech.ExecSQL("SELECT * FROM vwNavigationMenu ", ref dt);

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
                MyApp.CTech.ExecSQL("SELECT * FROM vwNavigationMenu ", ref dt);
                
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
                frm = (frmListAll)Excelsior.Core.Tools.Forms.IsFormInstantiated(typeof(frmListAll)).FirstOrDefault(f => ((frmListAll)f).ListOfType.ObjectType == mnu.ObjectType);

                if (frm == null)
                {
                    frm = new frmListAll(mnu);
                    frm.Show();
                }
                frm.Activate();

            }
        }
    }
}
