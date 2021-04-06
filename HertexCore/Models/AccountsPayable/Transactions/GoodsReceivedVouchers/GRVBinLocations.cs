using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    public static class GRVBinLocations
    {
        public static DataView GetList()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL("SELECT * FROM  tStoreName WITH(NOLOCK) WHERE ISNULL(IsGRVBin, 0) > 0", ref dt);
            return new DataView(dt);        
        }
    }
}
