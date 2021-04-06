using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.AccountsPayable
{
    public class Suppliers
    {
        public class Supplier
        {
            public Supplier()
            {

            }

            public Supplier(int id)
            {

            }
        }

        public static DataView GetSuppliersInfo()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL("EXEC sp_XR_SuppliersInfo_Get 0", ref dt);

            return new DataView(dt);
        }

        public static DataRow GetSupplierInfo(int SupplierID)
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"EXEC sp_XR_SuppliersInfo_Get {SupplierID}", ref dt);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        public static void SupplierQuickView(int SupplierID)
        {
            DataRow dr = GetSupplierInfo(SupplierID);
            if (dr != null) new Forms.frmSupplierQuickView(dr).ShowDialog();
            }
        
    }
}
