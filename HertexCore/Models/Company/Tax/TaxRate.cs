using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Library.Models.Company.Tax
{
    public class TaxRate
    {


        private int _id;
        private string _code;
        public int ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public bool Active { get; set; }

        public DateTime Created { get; private set; } = DateTime.Now;
        public DateTime LastModified { get; private set; } = DateTime.Now;


        #region METHODS        
        public TaxRate()
        {
        }

        public TaxRate(int id)
        {
            DataTable dt = new DataTable();
            MyApp.Evo.ExecSQL(string.Format("SELECT * FROM tblTaxRates where idTaxRate = {0}", id), ref dt);
            if (dt.Rows.Count > 0) Reload(dt.Rows[0]);
        }
        public TaxRate(string Code)
        {
            DataTable dt = new DataTable();
            MyApp.Evo.ExecSQL(string.Format("SELECT * FROM tblTaxRates where Code = '{0}'", Code), ref dt);
            if (dt.Rows.Count > 0) Reload(dt.Rows[0]);
        }

        public void Reload(DataRow dr)
        {
        }

        
        #endregion METHODS
    }
}
