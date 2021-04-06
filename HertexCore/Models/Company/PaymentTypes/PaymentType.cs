using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.Company.PaymentTypes
{
    public class PaymentType
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public bool Active { get; set; } = true;

        public PaymentType()
        {
            this.Created = DateTime.Now;
            this.CreatedBy = MyApp.Login.User.ID;
            this.Updated = DateTime.Now;
            this.UpdatedBy = MyApp.Login.User.ID;
        }

        public PaymentType(Int64 id)
        {
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL($"SELECT * FROM XR_PaymentTypes WHERE AutoIDX = {id}", ref dt);
            if (dt.Rows.Count > 0)
                Reload(dt.Rows[0]);
            else
                throw new Exception($"Loading data for Payment Type id '{ID}' returned no results.");
        }

        public PaymentType(DataRow dr)
        {
            Reload(dr);
        }

        public void Reload(DataRow dr)
        {
            this.ID = dr.Field<int>("AutoIDX");
            this.Description = dr.Field<string>("Description");
            this.Created = dr.Field<DateTime>("Created");
            this.CreatedBy = dr.Field<int>("CreatedBy");
            this.Updated = dr.Field<DateTime>("Updated");
            this.UpdatedBy = dr.Field<int>("UpdatedBy");
            this.Active = dr.Field<bool>("Active");
        }

        public void Save()
        {
            List<Con.Params> parms = new List<CTechCore.Con.Params>()
            {
                new CTechCore.Con.Params() { Name = "IDx", Value = this.ID},
                new CTechCore.Con.Params() { Name = "Description", Value = this.Description},
                new CTechCore.Con.Params() { Name = "UpdatedBy", Value = this.UpdatedBy},
                new CTechCore.Con.Params() { Name = "Active", Value = this.Active}
            };
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL("EXEC sp_XR_paymentType_InsUpd @IDx, @Description, @UpdatedBy, @Active", ref dt, parms);
        }
    }
    
}
