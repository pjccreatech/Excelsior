using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.AccountsReceivable.Models.AccountRecievable.Customers
{
    public class Customer
    {
        private int _id;

        public int ID { get { return _id; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }

        public string PhysicalAddress { get; set; } = string.Empty;
        public string PhysicalPostalCode { get; set; } = string.Empty;

        public string InvoiceAddress { get; set; } = string.Empty;
        public string InvoicePostalCode { get; set; } = string.Empty;

        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public decimal TaxRate { get; set; }
        public string VATNumber { get; set; }
        public string CoRegNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public bool OnHold { get; set; }
        public bool IsActive { get; set; } = true;
        public string eMail { get; set; }
        public int MainAccLink { get; set; }
        public decimal AccountBalance { get; set; }
        

        public bool Checked { get; set; }

        public Customer()
        {
        }

        public Customer(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                MyApp.Evo.ExecSQL($"SELECT * FROM tblCustomers WHERE CustomerID = {ID}", ref dt);
                if (dt.Rows.Count > 0)
                    Reload(dt.Rows[0]);
                else
                    throw new Exception($"Loading data for Customer id '{ID}' returned no results.");
            }
            catch (Exception ex)
            {
                string msg = $"Error loading supplier details: {ex.Message}";
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public Customer(string Code)
        {
            try
            {
                DataTable dt = new DataTable();
                MyApp.Evo.ExecSQL($"SELECT * FROM tblCustomers WHERE CustomerCode = '{Code}'", ref dt);
                if (dt.Rows.Count > 0)
                    Reload(dt.Rows[0]);
                else
                    throw new Exception($"Loading data for Customer code '{Code}' returned no results.");
            }
            catch (Exception ex)
            {
                string msg = $"Error loading Customer details: {ex.Message}";
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public Customer(DataRow dr)
        {
            Reload(dr);
        }

        public void Reload(DataRow dr)
        {
            _id = dr.Field<int>("CustomerID");

            this.Code = dr.Field<string>("CustomerCode");
            this.Name = dr.Field<string>("CustomerName");
            this.ContactPerson = dr.Field<string>("ContactPerson");


            this.PhysicalAddress = string.Join("\r\n", new string[]
            {
                dr.Field<string>("PhysicalAddress1"),
                dr.Field<string>("PhysicalAddress2"),
                dr.Field<string>("PhysicalAddress3"),
                dr.Field<string>("PhysicalAddress4"),
                dr.Field<string>("PhysicalAddress5")
            });
            this.PhysicalPostalCode = dr.Field<string>("PhysicalPostalCode");

            this.InvoiceAddress = string.Join("\r\n", new string[]
            {
                            dr.Field<string>("PostalAddress1"),
                            dr.Field<string>("PostalAddress2"),
                            dr.Field<string>("PostalAddress3"),
                            dr.Field<string>("PostalAddress4"),
                            dr.Field<string>("PostalAddress5")
            });
            this.InvoicePostalCode = dr.Field<string>("PostalPostalCode");

            this.Telephone1 = dr.Field<string>("Telephone1");
            this.Telephone2 = dr.Field<string>("Telephone2");
            this.Fax1 = dr.Field<string>("Fax1");
            this.Fax2 = dr.Field<string>("Fax2");
            this.TaxRate = Convert.ToDecimal(dr.Field<double>("TaxRate"));
            this.VATNumber = dr.Field<string>("VATNumber");
            this.CoRegNumber = dr.Field<string>("CoRegNumber");
            this.CreditLimit = Convert.ToDecimal(dr.Field<double>("CreditLimit"));
            this.OnHold = dr.Field<bool>("OnHold");
            this.IsActive = dr.Field<bool>("IsActive");
            this.eMail = dr.Field<string>("eMail");
            this.MainAccLink = dr.Field<int>("MainAccLink");
            this.AccountBalance = Convert.ToDecimal(dr.Field<double>("AccountBalance"));
            

        }
        
    }
}
