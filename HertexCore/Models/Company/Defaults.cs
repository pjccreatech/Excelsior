using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Library.Models.Company
{
    public class Defaults
    {
        public static Models.Company.Tax.TaxRate  DefaultTaxRate
        {
            get
            {
                return new Tax.TaxRate(1);
            }
        }
    }
}
