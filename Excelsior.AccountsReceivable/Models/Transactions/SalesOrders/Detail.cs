using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.AccountsReceivable.Models.Transactions.SalesOrders
{
    public class Detail : Excelsior.Core.Models.Document.DetailBase
    {
        public Detail(Details dtls) : base(dtls)
        {

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
