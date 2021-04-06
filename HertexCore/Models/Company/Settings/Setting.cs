using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertexCore.Models.Company.Settings
{
    public class Setting: CTechCore.Setting
    {
        public Setting()
        {
            this.App = MyApp.Name;
        }
        public Setting(Int64 id):base (id)
        {
        }
    }
}
