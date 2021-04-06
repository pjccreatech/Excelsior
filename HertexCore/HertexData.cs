using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore
{
    public static class HertexData
    {
        
        public static class Modules
        {

            public static DataRow GetModulesInfo(int IDX)
            {
                return GetModules.Table.Select($"AutoIDX = {IDX}").FirstOrDefault();
            }

            public static DataView GetModules
            {
                get 
                {
                    DataTable dt = new DataTable();
                    string sSQL = " SELECT * FROM vw_XR_Modules_Manage ORDER BY Module DESC";
                    MyApp.CTech.ExecSQL(sSQL, ref dt);
                    return new DataView(dt);
                }
            }
        }
        public static class Users
        {

            public static DataView GetUsers
            {
                get
                {
                    DataTable dt = new DataTable();
                    string sSQL = " SELECT * FROM vw_XR_Users_Manage order by username ";
                    MyApp.CTech.ExecSQL(sSQL, ref dt);
                    return new DataView(dt);
                }
            }

            public static DataView GetUserInfo(int IDX)
            {
                DataTable dt = new DataTable();
                string sSQL = $" EXEC sp_XR_UsersInfo_Get {IDX}";
                MyApp.CTech.ExecSQL(sSQL, ref dt);
                return new DataView(dt);
            }
        }

        public static class Customers
        {
            public static DataTable GetDeliveryMethods()
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * FROM vw_XR_DeliveryMethodsForSelect order by method", ref dt);

                return dt;
            }

            public static DataTable GetReps()
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * FROM vw_XR_SaleRepForSelect order by Name", ref dt);

                return dt;
            }


            public static DataTable Get3rdPartyAddressList()
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL("SELECT * FROM vw_XR_Customer3rdPartyAddressSelect ORDER BY 1", ref dt);
                return dt;
            }
        }


        public static class StockItems
        {
            public static DataTable GetStockItemList(int ClientID)
            {
                DataTable dt = new DataTable();

                MyApp.CTech.ExecSQL($"EXEC sp_XR_Stock_Get {ClientID} ", ref dt);

                return dt;
            }
        }
        public static class PaymentTypes
        {
            public static DataTable GetPaymentTypes()
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * FROM XR_PaymentTypes order by Description", ref dt);

                return dt;
            }
        }




    }
}
