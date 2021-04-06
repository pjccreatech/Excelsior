using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Models.Document
{
    public abstract class DetailBase : INotifyPropertyChanged
    {
        private DetailsBase _parent;
        public DetailsBase Parent { get { return _parent; } set { _parent = value; } }
        public int ID { get; protected set; }
        public int QuanityOrdered { get; set; }
        public int StockItemID { get; set; }
        public string StockItemCode { get; set; }
        public string StockItemDescription { get; set; }

        public double QuanityReserved { get; set; }
        public double QuanitySupplied { get; set; }
        public double QuanityOutstanding { get; set; }
        public double QuanityReturned { get; set; }
        public double QuanityOnHand { get; set; }

        public int PriceListID { get; set; }
        public double UnitSellingPriceExcl { get; set; }
        public double DiscountPercentage { get; set; }
        public double UnitSellingTax { get; set; }
        public double UnitSellingPriceIncl { get; set; }

        public double TotalExcl { get; set; }
        public double TotalTax { get; set; }
        public double TotalIncl { get; set; }
        public double LineNote { get; set; }

        public DetailBase(DetailsBase _Parent)
        {
            this.Parent = _Parent;           
        }

        public abstract void Recalc();

        public abstract bool Save();

        public abstract void Reload(DataRow dr);

        public abstract void Delete();
        
        #region EVENTS
        public event EventHandler OnAfterSaveEvent;

        public virtual void AfterSaveEvent(EventArgs e)
        {
            EventHandler handler = OnAfterSaveEvent;
            handler?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion EVENTS
    }
}
