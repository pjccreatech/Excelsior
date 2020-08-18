using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excelsior.Core;

namespace  Excelsior.AccountsReceivable.Models.Transactions.SalesOrders
{
    public class SalesOrder : Excelsior.Core.Models.Document.DocumentBase, Excelsior.Core.Models.Document.IDocumentBase
    {
        
        private Details _details;
        public SalesOrder()
        {
            this.Status = Excelsior.Core.Enums.Document.State.New;
            //this.CreatedBy = MyApp.Login.User;  //todo: his.CreatedBy = MyApp.Login.User
            this.OrderDate = DateTime.Now;
            this.DeliveryDate = Excelsior.Core.Enums.Enums.NullDate;
            this.Details = new Details(this);

        }
        
        public Excelsior.Core.Enums.Document.Type DocumentType
        {
            get { return Excelsior.Core.Enums.Document.Type.SalesOrder; }
        }
        
        public SalesOrder(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                throw new NotImplementedException();
                if (dt.Rows.Count > 0)
                    Reload(dt.Rows[0]);
                else
                    throw new Exception($"Loading data for document id '{ID}' returned no results.");
            }
            catch (Exception ex)
            {
                string msg = $"Error loading document details: {ex.Message}";
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public string SalesOrderType  {  get;  set;  }

        
        public Details Details { get { return _details; } set { _details = value; } }

        public override bool IsEditable
        {
            get
            {
                return (this.Status == Excelsior.Core.Enums.Document.State.Saved
                       || this.Status == Excelsior.Core.Enums.Document.State.New);
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void PrintDocument()
        {
            throw new NotImplementedException();
        }

        public void eMailDocument()
        {
            throw new NotImplementedException();
        }

        public bool Process()
        {
            try
            {
                throw new NotImplementedException();

                this.Status = Excelsior.Core.Enums.Document.State.Processed;
                //this.ProcessedBy = MyApp.Login.User;
                Save();
                this.Details.Process();
                return true;
            }
            catch (Exception ex)
            {
                string msg = $"Error saving Document {this.DocumentNumber} details: {ex.Message}";
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        
        public void Reload(DataRow dr)
        {
            ReloadHeader(dr);
            this.Details = new Details(this);
        }

        private void ReloadHeader(DataRow dr)
        {

            this.ID = dr.Field<int>("AutoIDX");
            this.DocumentNumber = dr.Field<string>("SONumber");
            //this.Customer = new Customers.Customer( dr.Field<int>("CustomerID"));


            this.PhysicalAddress = dr["DeliverToAddress"] == System.DBNull.Value ? String.Empty : dr.Field<String>("DeliverToAddress");
            this.PhysicalPostalCode = dr["DeliverToAddressPostalCode"] == System.DBNull.Value ? String.Empty : dr.Field<String>("DeliverToAddressPostalCode");
            this.InvoiceAddress = dr["InvoiceToAddress"] == System.DBNull.Value ? String.Empty : dr.Field<String>("InvoiceToAddress");
            this.InvoicePostalCode = dr["InvoiceToAddressPostalCode"] == System.DBNull.Value ? String.Empty : dr.Field<String>("InvoiceToAddressPostalCode");

            this.ExternalOrderNumber = dr.Field<string>("ExtOrdNum");
            this.OrderDate = dr.Field<DateTime>("OrderDate");
            this.Status = (Excelsior.Core.Enums.Document.State)dr.Field<int>("OrderStatus");            
            this.DeliveryDate = dr.Field<DateTime>("DeliveryDate");
            this.Comments = dr.Field<string>("Comments");
            this.DocumentVersion = dr.Field<int>("DocVersion");
            
            this.CreatedDate = dr.Field<DateTime>("dtStamp");
            this.ETADate = dr.Field<DateTime>("dtETA");
            this.SalesOrderType = dr.Field<string>("salesOrderType");
            OnPropertyChanged("SalesOrder");
        }

        public bool Save()
        {
            //DataRow dr = SaveHeader();

            throw new NotImplementedException();
            DataRow dr = null;
            if (dr != null)
            {
                this.Details.Save();
                Reload(dr);
                return true;
            }
            else
                return false;
        }
        
        public bool Validate()
        {
            return Errors.Count == 0;
        }
        public List<string> Errors
        {
            get
            {
                List<string> Errs = new List<string>();
                if (this.Details.Count == 0) Errs.Add("At least 1 item needs to be entered.");
                return Errs;
            }
        }

        public override bool IsLoading
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
