using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    public class Details : CTechCore.Models.Document.DetailsBase
    {

        public void Save()
        {
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
