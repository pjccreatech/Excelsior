using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.Other.Addresses
{
    public class Address: CTechCore.Models.Addresses.Address
    {

    }


    public class AddressFor3rdParty : Address
    {
        public int ID { get; set; }
        public string Description { get { return string.Join("\r\n", new List<string> { this.PartyName, this.ContactPerson, this.ContactNumber }); } } 
        public int ClientID { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public void Save()
        {
            DataTable dt = new DataTable();
            List<Con.Params> parms = new List<CTechCore.Con.Params>()
            {
                new CTechCore.Con.Params() { Name = "IDX", Value = this.ID},
                new CTechCore.Con.Params() { Name = "ClientID", Value = this.ClientID},
                new CTechCore.Con.Params() { Name = "PartyName", Value = this.PartyName},
                new CTechCore.Con.Params() { Name = "Addr1", Value = this.Addr1},
                new CTechCore.Con.Params() { Name = "Addr2", Value = this.Addr2},
                new CTechCore.Con.Params() { Name = "Addr3", Value = this.Addr3},
                new CTechCore.Con.Params() { Name = "Addr4", Value = this.Addr4},
                new CTechCore.Con.Params() { Name = "Addr5", Value = this.Addr5},
                new CTechCore.Con.Params() { Name = "AddrPC", Value = this.AddrPC},
                new CTechCore.Con.Params() { Name = "ContactName", Value = this.ContactPerson},
                new CTechCore.Con.Params() { Name = "ContactNumber", Value = this.ContactNumber},
                new CTechCore.Con.Params() { Name = "Comment", Value = this.Comment}
            };
            MyApp.CTech.ExecSQL("EXEC sp_XR_3rdPartyAddress_InsUpd @IDX, @ClientID, @PartyName, @Addr1, @Addr2, @Addr3, @Addr4, @Addr5, @AddrPC, @ContactName, @ContactNumber, @Comment", ref dt, parms);
            if (dt.Rows.Count > 0)
                this.ID = dt.Rows[0].Field<int>("AutoIDX");

        }
    }
}
