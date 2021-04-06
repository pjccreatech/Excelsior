using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Models.Document
{
    public abstract class DocumentBase:  INotifyPropertyChanged
    {

        public Int64 ID { get; protected set; }
        public string DocumentNumber { get; protected set; }
        public Enums.Document.State State { get; set; }

        public string Description { get; set; }
        public string Comments { get; set; }
        public string ExternalOrderNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public DateTime ETADate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CancelledDate { get; set; }

        public int CreatedByID { get; set; }
        public int ProcessedByID { get; set; }
        public int CancelledByID { get; set; }

        public string Contact { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;

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
