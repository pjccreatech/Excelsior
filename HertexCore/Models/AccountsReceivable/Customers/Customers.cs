using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.AccountsReceivable
{
    public static class Customers
    {
        public class Customer:Pastel.Evolution.Customer
        {
            public string Name { get; set; }

            public string PhysicalAddress { get; set; } = string.Empty;
            public string PhysicalPostalCode { get; set; } = string.Empty;

            public string InvoiceAddress { get; set; } = string.Empty;
            public string InvoicePostalCode { get; set; } = string.Empty;

            public string Telephone1 { get; set; }
            public string Fax1 { get; set; }
            public string Fax2 { get; set; }
            public decimal TaxRate { get; set; }
            public string VATNumber { get; set; }
            public string CoRegNumber { get; set; }
            public bool OnHold { get; set; }
            public bool IsActive { get; set; } = true;
            public string eMail { get; set; }
            public int MainAccLink { get; set; }
            public decimal AccountBalance { get; set; }

            public bool Checked { get; set; }

            public Customer():base()
            {
            }

            public Customer(int ID):base(ID)
            {
                try
                {
                    DataTable dt = new DataTable();
                    HertexCore.MyApp.Evo.ExecSQL($"SELECT * FROM tblCustomers WHERE CustomerID = {ID}", ref dt);
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

            public Customer(string Code):base(Code)
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
                this.OnHold = dr.Field<bool>("OnHold");
                this.IsActive = dr.Field<bool>("IsActive");
                this.eMail = dr.Field<string>("eMail");
                this.MainAccLink = dr.Field<int>("MainAccLink");
                this.AccountBalance = Convert.ToDecimal(dr.Field<double>("AccountBalance"));


            }
        }
        public static DataView GetCustomersInfo()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL("EXEC sp_XR_CustomersInfo_Get 0", ref dt);
            return new DataView(dt);
        }
        public static DataRow GetCustomerInfo(int ClientID)
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"EXEC sp_XR_CustomersInfo_Get {ClientID}", ref dt);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }
        public static void CustomerQuickView(int SupplierID)
        {
            DataRow dr = GetCustomerInfo(SupplierID);
            if (dr != null) new Forms.frmCustomerQuickView(dr).ShowDialog();
        }
        public enum PaymentTypes
        {
            PayInAdvance = 0,
            Terms = 1,
        }
        public static double CreditOverflow(PaymentTypes pmnttype)
        {
            switch (pmnttype)
            {
                case PaymentTypes.PayInAdvance:
                    return 0;
                    break;
                case PaymentTypes.Terms:
                    return 0;
                    break;
                default:
                    return 0;
                    break;
                    return 0;
            }
        }
        public static DataView GetCustomerGroups()
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL("SELECT * FROM  vw_XR_CustomerGroups_Get  ORDER BY Description", ref dt);
            return new DataView(dt);
        }
    }
}
