using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Core.Tools
{
    public class Forms
    {
        public static List<Form> IsFormInstantiated(Type tpe)
        {
            List<Form> lst = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == tpe) lst.Add(frm);
            }
            return lst;
        }

        public static List<Form> IsFormInstantiatedByType(Type tpe)
        {
            List<Form> lst = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType().GetProperty("BaseType") != null)  lst.Add(frm);
            }
            return lst;
        }

    }
}
