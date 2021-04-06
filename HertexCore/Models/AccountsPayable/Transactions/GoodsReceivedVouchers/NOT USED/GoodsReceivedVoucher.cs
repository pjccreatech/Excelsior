using CTechCore.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    public class GoodsReceivedVoucher : CTechCore.Models.Document.DocumentBase, CTechCore.Models.Document.IDocumentBase
    {
        public GoodsReceivedVoucher() : base()
        { 
        }

        public GoodsReceivedVoucher(Int64 id) :base()
        {

        }

        DataRow drSupplier = null;
        public DataRow SupplierInfo
        {
            get { return drSupplier; }
            set
            {
                drSupplier = value;
                if (drSupplier == null) return;
            }
        }

        private void LoadSupplierInfo()
        {

            //this.DeliveryAddress = new Other.Addresses.Address()
            //{
            //    Addr1 = drCustomer["Physical1"].ToString(),
            //    Addr2 = drCustomer["Physical2"].ToString(),
            //    Addr3 = drCustomer["Physical3"].ToString(),
            //    Addr4 = drCustomer["Physical4"].ToString(),
            //    Addr5 = drCustomer["Physical5"].ToString(),
            //    AddrPC = drCustomer["PhysicalPC"].ToString()
            //};

            //this.InvoiceAddress = new Other.Addresses.Address()
            //{
            //    Addr1 = drCustomer["Post1"].ToString(),
            //    Addr2 = drCustomer["Post2"].ToString(),
            //    Addr3 = drCustomer["Post3"].ToString(),
            //    Addr4 = drCustomer["Post4"].ToString(),
            //    Addr5 = drCustomer["Post5"].ToString(),
            //    AddrPC = drCustomer["PostPC"].ToString()
            //};

        }

        private int supplierid;
        private Details _details;
        public int SupplierID
        {
            get { return supplierid; }
            set
            {
                supplierid = value;
                if (drSupplier == null) return;
                LoadSupplierInfo();
            }
        }
        public override bool IsEditable => throw new NotImplementedException();

        public override bool IsLoading { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Document.Type DocumentType => throw new NotImplementedException();

        public void Delete()
        {
            throw new Exception("Operation not possible");
        }

        public void eMailDocument()
        {
            throw new NotImplementedException();
        }

        public void PrintDocument()
        {
            throw new NotImplementedException();
        }

        public bool Process()
        {
            throw new NotImplementedException();
        }

        public void Reload(DataTable dr)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
