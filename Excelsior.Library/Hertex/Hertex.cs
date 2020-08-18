using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Excelsior.Library
{
    public static class Hertex
    {

        public static class Stock
        {
            public static decimal GetQtyOnHand(int stkId)
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"EXEC zz_sp_GetStkQTyOnHand {stkId}", ref dt);
                return dt.Rows.Count > 0 ? Convert.ToDecimal(dt.Rows[0].Field<double>("QtyOnHand")) : 0;

            }
        }
    }
}
