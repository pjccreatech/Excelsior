using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Models.Addresses
{
    public class Address
    {
        public string Addr1 { get; set; } = string.Empty;
        public string Addr2 { get; set; } = string.Empty;
        public string Addr3 { get; set; } = string.Empty;
        public string Addr4 { get; set; } = string.Empty;
        public string Addr5 { get; set; } = string.Empty;
        public string AddrPC { get; set; } = string.Empty;

        public string Condensed
        {
            get{ return string.Join("\r\n", new List<string>() { Addr1, Addr2, Addr3, Addr4, Addr5, AddrPC }); }
        }
    }
}
