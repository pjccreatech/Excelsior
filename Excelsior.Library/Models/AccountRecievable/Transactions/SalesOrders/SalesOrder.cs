using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Library.Models.AccountRecievable.Transactions.SalesOrders
{
    public class SalesOrder: Excelsior.AccountsReceivable.Models.Transactions.SalesOrders.SalesOrder
    {
        public Excelsior.Library.Models.AccountRecievable.Customers.Customer Customer
        {
            get;
            set;
        }

        public SalesOrder(int id) : base(id)
        {
        }

        public SalesOrder() : base()
        {
        }
    }
}
