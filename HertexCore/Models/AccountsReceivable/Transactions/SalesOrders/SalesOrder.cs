using CTechCore.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    public class SalesOrder : CTechCore.Models.Document.DocumentBase, CTechCore.Models.Document.IDocumentBase
    {

        private Other.Addresses.Address invaddr;
        private Other.Addresses.Address deladdr;
        private Other.Addresses.AddressFor3rdParty addr3rdparty;

        DataRow drCustomer = null;
        public DataRow CustomerInfo
        {
            get { return drCustomer; }
            set
            {
                drCustomer = value;
                if (drCustomer == null) return;
                //LoadCustomerInfo();
            }
        }

        private void LoadCustomerInfo()
        {

            this.DeliveryAddress = new Other.Addresses.Address()
            {
                Addr1 = drCustomer["Physical1"].ToString(),
                Addr2 = drCustomer["Physical2"].ToString(),
                Addr3 = drCustomer["Physical3"].ToString(),
                Addr4 = drCustomer["Physical4"].ToString(),
                Addr5 = drCustomer["Physical5"].ToString(),
                AddrPC = drCustomer["PhysicalPC"].ToString()
            };

            this.InvoiceAddress = new Other.Addresses.Address()
            {
                Addr1 = drCustomer["Post1"].ToString(),
                Addr2 = drCustomer["Post2"].ToString(),
                Addr3 = drCustomer["Post3"].ToString(),
                Addr4 = drCustomer["Post4"].ToString(),
                Addr5 = drCustomer["Post5"].ToString(),
                AddrPC = drCustomer["PostPC"].ToString()
            };
            
        }
        
        private int customerid;
        private Details _details;
        public int CustomerID
        {
            get { return customerid; }
            set
            {
                customerid = value;
                if (drCustomer == null) return;
                LoadCustomerInfo();
            }
        }
        
        public Other.Addresses.Address DeliveryAddress
        {
            get { return deladdr; }
            set
            {
                deladdr = value;
                OnPropertyChanged("DeliveryAddress");
            }
        } 
        public Other.Addresses.Address InvoiceAddress
        {
            get { return invaddr; }
            set
            {
                invaddr = value;
                OnPropertyChanged("InvoiceAddress");
            }
        }
        public Other.Addresses.AddressFor3rdParty AddressFor3rdParty
        {
            get { return addr3rdparty; }
            set
            {
                addr3rdparty = value;
                OnPropertyChanged("AddressFor3rdParty");
            }
        }


        public int DeliveryMethodID { get; set; }
        public int SalesRepresentativeID { get; set; }
        public string SalesRepresentativeEMail { get; set; } = string.Empty;

        //
        public CTechCore.Enums.Document.Processable ReleaseForInvoicing { get; set; } = CTechCore.Enums.Document.Processable.NotReleased;
        public int PaymentStatusID { get; set; }
        public string OriginalAgent { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string ReasonForCancellation { get; set; } = string.Empty;
        public string AdditionalComments { get; set; } = string.Empty;

        public string CustomerRefNumber { get; set; } = string.Empty;
        public string AreaOfUse { get; set; } = string.Empty;
        public string CustomerProject { get; set; } = string.Empty;

        public string Message1 { get; set; } = string.Empty;
        public string Message2 { get; set; } = string.Empty;
        public string Message3 { get; set; } = string.Empty;

        public string InvoiceNumber { get; set; } = string.Empty;

        public SalesOrder()
        {
            this.State = CTechCore.Enums.Document.State.New;
            //this.CreatedBy = MyApp.Login.User;  //todo: his.CreatedBy = MyApp.Login.User
            this.OrderDate = DateTime.Now;
            this.DeliveryDate = Defaults.NullDate;

            this.DeliveryAddress = new Other.Addresses.Address();
            this.InvoiceAddress = new Other.Addresses.Address();
            this.AddressFor3rdParty = new Other.Addresses.AddressFor3rdParty();
            this.Details = new Details();
        }
        
        public CTechCore.Enums.Document.Type DocumentType
        {
            get { return CTechCore.Enums.Document.Type.SalesOrder; }
        }
        
        public SalesOrder(Int64 id)
        {
            try
            {

                DataTable dt = new DataTable();
                List<Con.Params> parms = new List<CTechCore.Con.Params>() { new CTechCore.Con.Params() { Name = "DocIDX" , Value = id} };
                MyApp.CTech.ExecSQL("EXEC sp_XR_OrderInfo_Get @DocIDX", ref dt, parms);
                if (dt.Rows.Count > 0)
                    Reload(dt);
                else
                    throw new Exception($"Loading data for document id '{ID}' returned no results.");
            }
            catch (Exception ex)
            {
                string msg = $"Error loading document details: {ex.Message}";
                MessageBox.Show(msg);
                CTechCore.MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public string SalesOrderType  {  get;  set; }
        public Details Details { get { return _details; } set { _details = value; } }

        public override bool IsEditable
        {
            get
            {
                return (this.State == CTechCore.Enums.Document.State.Saved
                       || this.State == CTechCore.Enums.Document.State.New);
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

                //this.OrderStatus = CTechCore.Enums.Document.State.Processed;
                //this.ProcessedBy = MyApp.Login.User;
                Save();
                return true;
            }
            catch (Exception ex)
            {
                string msg = $"Error saving Document {this.DocumentNumber} details: {ex.Message}";
                MessageBox.Show(msg);
                CTechCore.MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        
        public void Reload(DataTable dt)
        {
            this.CustomerInfo =   Customers.GetCustomerInfo(dt.Rows[0].Field<int>("AccountID"));
            this.ID = dt.Rows[0].Field<Int64>("AutoIndex");
            this.DocumentNumber = dt.Rows[0].Field<string>("OrderNum");
            this.ExternalOrderNumber = dt.Rows[0].Field<string>("ExtOrderNum");

            this.DeliveryAddress = new Other.Addresses.Address
            {
                Addr1 = dt.Rows[0]["Address1"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address1"),
                Addr2 = dt.Rows[0]["Address2"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address2"),
                Addr3 = dt.Rows[0]["Address3"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address3"),
                Addr4 = dt.Rows[0]["Address4"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address4"),
                Addr5 = dt.Rows[0]["Address5"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address5"),
                AddrPC = dt.Rows[0]["Address6"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Address6")
            };

            this.InvoiceAddress = new Other.Addresses.Address()
            {
                Addr1 = dt.Rows[0]["Address1"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress1"),
                Addr2 = dt.Rows[0]["Address2"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress2"),
                Addr3 = dt.Rows[0]["Address3"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress3"),
                Addr4 = dt.Rows[0]["Address4"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress4"),
                Addr5 = dt.Rows[0]["Address5"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress5"),
                AddrPC = dt.Rows[0]["Address6"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("PAddress6")
            };

            this.AddressFor3rdParty = new Other.Addresses.AddressFor3rdParty();

            this.DeliveryMethodID = dt.Rows[0].Field<int>("DelMethodID");
            this.SalesRepresentativeID = dt.Rows[0].Field<int>("DocRepID");
            //this.SalesRepresentativeEMail = dt.Rows[0].Field<string>("DocRepID");

            this.OrderDate = dt.Rows[0].Field<DateTime>("OrderDate");
            this.DueDate = dt.Rows[0].Field<DateTime>("DueDate");


            if (dt.Rows[0]["ulIDSOrdConfirmed"] == System.DBNull.Value)
                this.ReleaseForInvoicing = CTechCore.Enums.Document.Processable.NotReleased;
            else
                this.ReleaseForInvoicing = Enum.GetValues(typeof(CTechCore.Enums.Document.Processable)).Cast<CTechCore.Enums.Document.Processable>().ToList().FirstOrDefault(i => i.GetDisplayText() == dt.Rows[0].Field<string>("ulIDSOrdConfirmed"));

            DataRow dr = HertexData.PaymentTypes.GetPaymentTypes().Select($"Description = '{dt.Rows[0].Field<string>("ulIDSOrdPaymentStatus")}'").FirstOrDefault();
            if (dr != null) this.PaymentStatusID = dr.Field<int>("AutoIDX");

            this.OriginalAgent = dt.Rows[0]["ucIDSOrdAgent"].ToString();
            this.Project  = dt.Rows[0]["ucIDSOrdProject"].ToString();
            this.ReasonForCancellation = dt.Rows[0]["ucIDSOrdCancelReason"].ToString();
            this.AdditionalComments = dt.Rows[0]["ulIDPOrdConfirmed"].ToString();

            this.CustomerRefNumber = dt.Rows[0]["ucIDSOrdARRef"].ToString();
            this.AreaOfUse = dt.Rows[0]["ucIDSOrdARAreaUsage"].ToString();
            this.CustomerProject = dt.Rows[0]["ucIDSOrdARProject"].ToString();
            
            this.Message1 = dt.Rows[0]["Message1"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Message1");
            this.Message2 = dt.Rows[0]["Message2"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Message2");
            this.Message3 = dt.Rows[0]["Message3"] == System.DBNull.Value ? String.Empty : dt.Rows[0].Field<String>("Message3");

            this.CreatedDate = dt.Rows[0].Field<DateTime>("ddtStamp");
            
        }

        public bool Save()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                string msg = $"Error loading saving details: {ex.Message}";
                MessageBox.Show(msg);
                CTechCore.MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
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
