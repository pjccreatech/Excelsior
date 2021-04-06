using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    public class PurchaseOrderToGRV
    {
        DataRow Info;
        public PurchaseOrderToGRV(DataRow info)
        {
            Info = info;
        }


        public PurchaseOrderToGRV(Int64 id)
        {
            this.ID = id;

            Reload();
        }

        public string DocumentNumber {get; set;}

        public void Reload()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"SELECT * FROM vw_XR_PurchaseOrdersForGRV WHERE AutoIndex = {this.ID}", ref dt);
            this.HeaderInfo = new DataView(dt);

            this.DocumentNumber = dt.Rows[0].Field<string>("OrderNum");


            DataTable dtDtl = new DataTable();
            MyApp.CTech.ExecSQL($"EXEC sp_XR_POForGRVDetails_Get @InvID = {this.ID}", ref dtDtl);
            this.DetailInfo = new DataView(dtDtl);
        }

        public void Reload(string sOrderNum)
        {
            try
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * FROM vw_XR_PurchaseOrdersForGRV WHERE OrderNum = '{sOrderNum}'", ref dt);
                
                if (dt.Rows.Count > 0)
                {
                    this.ID = (Int64)dt.Rows[0]["AutoIndex"];
                    Reload();
                }
                else
                    throw new Exception("Could not find details for order 'sOrderNum'");
            }
            catch (Exception ex)
            {
                string msg = $"Error reloading GRV details: {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }


        public Int64 ID { get; set; }

        public DataView HeaderInfo { get; set; }
        public DataView DetailInfo { get; set; }
        public string Location { get; set; }

        public void Process(object sender, CTechCore.WaitForms.WaitWindowEventArgs e)
        {
            try
            {
                MyApp.PastelHlpr.CreateCommonDBConnection("uid=" + MyApp.Common.Username + ";pwd=" + MyApp.Common.Password + ";Initial Catalog=" + MyApp.Common.Database + ";server=" + MyApp.Common.Server + ";Persist Security Info=True;");
                MyApp.PastelHlpr.SetLicense(MyApp.serialNumber, MyApp.AuthorizationKey);
                MyApp.PastelHlpr.CreateConnection("server=" + MyApp.Evo.Server + ";initial catalog=" + MyApp.Evo.Database + ";User ID=" + MyApp.Evo.Username + ";Password=" + MyApp.Evo.Password + ";Persist Security Info=True");


                Int64 poid = this.HeaderInfo.Table.AsEnumerable().FirstOrDefault().Field<Int64>("AutoIndex");
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * from PurchaseOrder WHERE InvDocIDX = {poid}", ref dt);
                
                Pastel.Evolution.PurchaseOrder po = new Pastel.Evolution.PurchaseOrder(poid);

                foreach (Pastel.Evolution.OrderDetail l in po.Detail)
                {
                    DataRow dr = this.DetailInfo.Table.AsEnumerable().FirstOrDefault(r => (int)r["iStockCodeID"] == l.InventoryItemID && (double)r["QtyReceived"] > 0);

                    if (dr != null) l.ToProcess = (double)dr["QtyReceived"];
                }
                e.Window.Message = "Processing GRV";
                string restult = po.ProcessStock();
                //po.UserFields

                e.Window.Message = $"Document '{restult}' created";
                List<Stock.StockRollItems.StockRollItem> rolls = new List<Stock.StockRollItems.StockRollItem>();
                foreach (DataRow r in dt.Rows)
                {
                    DataRow dr = this.DetailInfo.Table.AsEnumerable().FirstOrDefault(x => (string)x["Code"] == (string)r["StockCode"]);

                    rolls.Add(new Stock.StockRollItems.StockRollItem()
                    {
                        ID = 0,
                        AuditNo = po.Audit,
                        GRVNumber = restult,
                        PONumber = po.OrderNo,
                        SupplierID = (int)this.HeaderInfo.Table.Rows[0]["SupplierID"],
                        StockCodeID = (int)dr["iStockCodeID"],
                        StockCode = (string)dr["Code"],
                        StockDescription = (string)dr["Description_1"],
                        DyeLot = (string)r["DyeLot"],
                        SupplierDyeLot = (string)r["SupplierDyeLot"], 
                        Available = 'Y',
                        Location = this.Location,
                        OpenBal = (double)r["qty"],
                        UnitCost = (decimal)r["UnitPriceExcl"],
                        ItemGroup = (string)dr["stgroup"],
                        Quantity = (double)r["qty"],
                    }) ;
                }
                if (rolls.Count > 0)
                {
                    e.Result = Stock.StockRollItems.Save(rolls);
                    e.Window.Message = "Roll(s)/Items created :\r" +string.Join("\r", ((DataSet)e.Result).Tables.Cast<DataTable>().SelectMany(t => t.AsEnumerable().Select(r => "\t\t" + (int)r["StockRollID"])).ToList());
                }
                else
                    throw new Exception($"Failed to create Stock Rolls for Document '{restult}'");

            }
            catch (Exception ex)
            {
                e.Window.ForeColor = System.Drawing.Color.Red;
                string msg = $"Error create GRV: {ex.Message}.\r\n {ex.StackTrace}";
                e.Window.Message = msg;
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                e.Window.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
