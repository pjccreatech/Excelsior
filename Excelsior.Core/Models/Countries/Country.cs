using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Core.Models.Countries
{
    public partial class Country
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool Active { get; set; }

        private int CreatedByID { get; set; }
        private int LastUpdateByID { get; set; }

        
        public virtual Users.User CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        
        public virtual Users.User LastUpdatedBy { get; set; }
        public System.DateTime LastUpdated { get; set; }

        public Country()
        {
        }
        public override string ToString() => $"{this.Description} ({this.Code})";
    }
}
