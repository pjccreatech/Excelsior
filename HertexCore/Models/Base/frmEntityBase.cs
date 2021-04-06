using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Base
{
    public partial class frmEntityBase : CTechCore.Models.Document.frmEntityBase
    {
        public frmEntityBase(CTechCore.Models.Navigation.MenuItem mnu, object obj):base(mnu, obj)
        {
            InitializeComponent();
        }
    }
}
