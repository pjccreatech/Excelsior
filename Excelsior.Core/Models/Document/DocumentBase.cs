using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Core.Models.Document
{
    public abstract class DocumentBase:  INotifyPropertyChanged
    {

        public int ID { get; protected set; }
        public string DocumentNumber { get; protected set; }

        public Enums.Document.State Status { get; set; }

        public string Comments { get; set; }
        public string ExternalOrderNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public DateTime ETADate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CancelledDate { get; set; }

        public Models.Users.User CreatedBy { get; set; }
        public Models.Users.User ProcessedBy { get; set; }
        public Models.Users.User CancelledBy { get; set; }

        public string PhysicalAddress { get; set; }
        public string PhysicalPostalCode { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoicePostalCode { get; set; }

        public string InternalEventMessages { get; set; }

        public int DocumentVersion { get; set; }

        public int TransactionEntityID { get; protected set; }

        public double TotalExclusive { get; set; }
        public double TotalTax { get; set; }
        public double TotalInculsive { get; set; }
        
        public abstract bool IsEditable { get; }
        public abstract bool IsLoading { get; set; }



        #region EVENTS
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
