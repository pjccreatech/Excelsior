using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.Stock
{
    public class StockPrice
    {
        private DataRow dr;

        public int ID { get; set; }
        public int DCLink { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public int CustomerDefPriceList { get; set; }
        public decimal CustomerDefPriceListValue { get; set; }
        public decimal CustomerDefPriceListValExcl { get; set; }
        public decimal CustomerDefPriceListValVATValue { get; set; }
        public decimal CustomerDefPriceListValIncl { get; set; }
        public decimal CustomerDefVATPerc { get; set; }
        public int CustomerDefVATID { get; set; }
        public int StockLink { get; set; }
        public String StockCode { get; set; }
        public String StockDescription { get; set; }
        public int StockGroupID { get; set; }
        public decimal SpecialPrice { get; set; }
        public bool AsPercentage { get; set; }
        public int SpecialPriceListFound { get; set; }
        public DateTime QueryDate { get; set; }
        public DateTime DateEff { get; set; } = new DateTime(1900, 01, 01);
        public DateTime DateExp { get; set; } = new DateTime(1900, 01, 01);
        public bool UseStockPrc { get; set; }
        public decimal SpecialPriceListQty { get; set; }
        public decimal QtyTorOrder { get; set; }
        public decimal UseThisPriceExcl { get; set; }

        public int PriceDiscListIDVD { get; set; }
        public int PriceDiscListIDVDLn { get; set; }
        public int PriceDiscListiDVDLnLvl { get; set; }
        public int PriceDiscListiLevel { get; set; }

        public int DocumentID { get; set; }
        public int DocumentLineID { get; set; }

        public StockPrice(int ClientID, DateTime docdate, int stockId, decimal qty)
        {
            DataTable dt = new DataTable();
            List<Con.Params> parms = new List<Con.Params>()
            {
                new Con.Params() { Name = "ClientID", Value = ClientID },
                new Con.Params() { Name = "StockId", Value = stockId },
                new Con.Params() { Name = "WhsID", Value = stockId },
                new Con.Params() { Name = "QueryDate", Value = docdate  },
                new Con.Params() { Name = "Qty", Value = qty }
            };
            //todo: price list and shit
            MyApp.CTech.ExecSQL($"exec sp_XR_SpecialPricesByDateAnQty_Get @ClientID, @StockId, @WhsID, @QueryDate, @Qty", ref dt, parms);


            if (dt.Rows.Count > 0) Reload(dt.Rows[0]);
        }
        public StockPrice(int id)
        {


        }

        public void Reload(DataRow row)
        {
            try
            {
                this.dr = row;
                this.DCLink = dr["DCLink"] == System.DBNull.Value ? 0 : dr.Field<int>("DCLink");
                this.AccountCode = dr["AccountCode"] == System.DBNull.Value ? string.Empty : dr.Field<string>("AccountCode");
                this.AccountName = dr["AccountName"] == System.DBNull.Value ? string.Empty : dr.Field<string>("AccountName");
                this.CustomerDefPriceList = dr["CustomerDefPriceList"] == System.DBNull.Value ? 0 : dr.Field<int>("CustomerDefPriceList");
                this.CustomerDefPriceListValue = dr["CustomerDefPriceListValue"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["CustomerDefPriceListValue"].ToString());
                this.CustomerDefPriceListValExcl = dr["CustomerDefPriceListValExcl"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["CustomerDefPriceListValExcl"].ToString());
                this.CustomerDefPriceListValVATValue = dr["CustomerDefPriceListValVATValue"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["CustomerDefPriceListValVATValue"].ToString());
                this.CustomerDefPriceListValIncl = dr["CustomerDefPriceListValIncl"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["CustomerDefPriceListValIncl"].ToString());
                this.CustomerDefVATPerc = dr["CustomerDefVATPerc"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["CustomerDefVATPerc"].ToString());
                this.CustomerDefVATID = dr["CustomerDefVATID"] == System.DBNull.Value ? 0 : dr.Field<int>("CustomerDefVATID");
                this.StockLink = dr["StockLink"] == System.DBNull.Value ? 0 : dr.Field<int>("StockLink");
                this.StockCode = dr["StockCode"] == System.DBNull.Value ? string.Empty : dr.Field<string>("StockCode");
                this.StockDescription = dr["StockDescription"] == System.DBNull.Value ? string.Empty : dr.Field<string>("StockDescription");
                this.StockGroupID = dr["StockGroupID"] == System.DBNull.Value ? 0 : dr.Field<int>("StockGroupID");
                this.SpecialPrice = dr["SpecialPrice"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["SpecialPrice"].ToString());
                this.AsPercentage = dr["AsPercentage"] == System.DBNull.Value ? false : dr.Field<bool>("AsPercentage");
                this.SpecialPriceListFound = dr["SpecialPriceListFound"] == System.DBNull.Value ? 0 : dr.Field<int>("SpecialPriceListFound");
                this.QueryDate = dr["QueryDate"] == System.DBNull.Value ? new DateTime(1900, 01, 01) : dr.Field<DateTime>("QueryDate");
                this.DateEff = dr["DateEff"] == System.DBNull.Value ? new DateTime(1900, 01, 01) : dr.Field<DateTime>("DateEff");
                this.DateExp = dr["DateExp"] == System.DBNull.Value ? new DateTime(1900, 01, 01) : dr.Field<DateTime>("DateExp");
                this.UseStockPrc = dr["UseStockPrc"] == System.DBNull.Value ? false : dr.Field<bool>("UseStockPrc");
                this.SpecialPriceListQty = dr["SpecialPriceListQty"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["SpecialPriceListQty"].ToString());
                this.QtyTorOrder = dr["QtyTorOrder"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["QtyTorOrder"].ToString());
                this.UseThisPriceExcl = dr["UseThisPriceExcl"] == System.DBNull.Value ? 0 : Decimal.Parse(dr["UseThisPriceExcl"].ToString());

                this.PriceDiscListIDVD = dr["IDVD"] == System.DBNull.Value ? 0 : int.Parse(dr["IDVD"].ToString());
                this.PriceDiscListIDVDLn = dr["IDVDLn"] == System.DBNull.Value ? 0 : int.Parse(dr["IDVDLn"].ToString());
                this.PriceDiscListiDVDLnLvl = dr["iDVDLnLvl"] == System.DBNull.Value ? 0 : int.Parse(dr["iDVDLnLvl"].ToString());
                this.PriceDiscListiLevel = dr["iLevel"] == System.DBNull.Value ? 0 : int.Parse(dr["iLevel"].ToString());


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error obtaining Pricing Information from Evolution: {ex.ToString()}");
            }
        }
    }

    public static class Tools
    {

        public static void RecordDetails(List<StockPrice> prices)
        {
            DataTable dt = new DataTable();
            string sSQL = string.Empty;
            List<Con.Params> parms = new List<Con.Params>();
            int i = 0;
            foreach (StockPrice price in prices)
            {
                parms.Add(new Con.Params() { Name = $"InvNumID{i}", Value = price.DocumentID });
                parms.Add(new Con.Params() { Name = $"InvLineID{i}", Value = price.DocumentLineID });
                parms.Add(new Con.Params() { Name = $"@OrderDate{i}", Value = price.QueryDate });
                parms.Add(new Con.Params() { Name = $"StockLink{i}", Value = price.StockLink });
                parms.Add(new Con.Params() { Name = $"fOrderQuantity{i}", Value = price.QtyTorOrder });
                parms.Add(new Con.Params() { Name = $"IDVD{i}", Value = price.PriceDiscListIDVD });
                parms.Add(new Con.Params() { Name = $"IDVDLn{i}", Value = price.PriceDiscListIDVDLn });
                parms.Add(new Con.Params() { Name = $"iDVDLnLvl{i}", Value = price.PriceDiscListiDVDLnLvl });
                parms.Add(new Con.Params() { Name = $"iLevel{i}", Value = price.PriceDiscListiLevel });
                parms.Add(new Con.Params() { Name = $"iStGroupID{i}", Value = price.StockGroupID });
                parms.Add(new Con.Params() { Name = $"dEffDate{i}", Value = price.DateEff });
                parms.Add(new Con.Params() { Name = $"dExpDate{i}", Value = price.DateExp });
                parms.Add(new Con.Params() { Name = $"bUseStockPrc{i}", Value = price.UseStockPrc });
                parms.Add(new Con.Params() { Name = $"fDiscQuantity{i}", Value = price.SpecialPriceListQty });
                parms.Add(new Con.Params() { Name = $"fPriceDisc{i}", Value = price.UseThisPriceExcl });
                sSQL += $"\rEXEC zz_sp_CTECH_InvLinesDiscInfo_Ins @InvNumID{i}, @InvLineID{i}, @OrderDate{i}, @StockLink{i}, @fOrderQuantity{i}, @IDVD{i}, @IDVDLn{i}, @iDVDLnLvl{i}, @iLevel{i}, @iStGroupID{i}, @dEffDate{i}, @dExpDate{i}, @bUseStockPrc{i}, @fDiscQuantity{i}, @fPriceDisc{i}";
                ++i;
            }

            MyApp.CTech.ExecSQL(sSQL, ref dt, parms);

        }
    }
}
