using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.AccountsReceivable.Models.Transactions.SalesOrders
{
    public class Details : Excelsior.Core.Models.Document.DetailsBase
    {
        public Details(SalesOrder so) : base(so)
        {
            DataTable dt = new DataTable();
            string sSQL = string.Format("SELECT * FROM tblSODetail WHERE SOHeaderID = {0}", this.Parent.ID);
            MyApp.Evo.ExecSQL(sSQL, ref dt);

            this.ListChanged += new ListChangedEventHandler(OnListChangedEvent);
            foreach (DataRow dr in dt.Rows)
            {
                Detail dtl = new Detail(this);
                dtl.Reload(dr);
                this.Add(dtl);
            }
        }

        public void Save()
        {
            this.ToList().ForEach(d => d.Save());
        }

        public void Reload()
        {
        }

        public void Delete()
        {
            this.ToList().ForEach(d => d.Delete());
        }

        protected override void OnListChangedEvent(object sender, ListChangedEventArgs args)
        {
            // Do any circle-specific processing here.

            // Call the base class event invocation method.
            base.OnListChangedEvent(sender, args);
        }

        public override object AddNew()
        {
            Detail dtl = new Detail(this);
            dtl.PropertyChanged += delegate (object s, PropertyChangedEventArgs e)
            {
                OnListChangedEvent(this, new ListChangedEventArgs(ListChangedType.ItemChanged, 0));
            };
            base.Add(dtl);
            OnListChangedEvent(this, new ListChangedEventArgs(ListChangedType.ItemAdded, 0));
            return dtl;
        }

        internal void Process()
        {
            foreach (Detail dtl in this)
            {
                dtl.UpdateCostPrices();
            }
        }
    }
}
