using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    public class Detail : CTechCore.Models.Document.DetailBase
    {
        DataRow drStkInfo = null;
        public Detail(Details dtls) : base(dtls)
        {

        }
        
        public DataRow StockItemInfo
        {
            get { return drStkInfo; }
            set
            {
                drStkInfo = value;
            }
        }

        public override bool Save()
        {
            try
            {
                List<Con.Params> parms = new List<Con.Params>()
                {
                    new Con.Params() { Name = "SODetailID", Value = this.ID },
                };

                DataTable dt = new DataTable();

                throw new NotImplementedException();
                if (dt.Rows.Count == 0) return false;

                Reload(dt.Rows[0]);
                return true;
            }
            catch (Exception ex)
            {

                string msg = $"Error saving Document detail lines  {this.Parent.Parent.DocumentNumber} : {ex.Message}";
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public override void Reload(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public void UpdateCostPrices()
        {
            throw new NotImplementedException();
        }

        public override void Recalc()
        {
            throw new NotImplementedException();
        }
    }
}
