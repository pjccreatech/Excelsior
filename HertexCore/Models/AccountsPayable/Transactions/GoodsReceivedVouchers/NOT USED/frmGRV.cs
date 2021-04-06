using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    public partial class frmGRV : Base.frmDocBase
    {
        public frmGRV()
        {
            InitializeComponent();
        }

        public frmGRV(GoodsReceivedVoucher grv)
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            goodsReceivedVoucherBindingSource.DataSource = grv;

            base.Caption = $"ORDER: {grv.DocumentNumber} ({grv.ExternalOrderNumber})";
        }
        public frmGRV(CTechCore.Models.Navigation.MenuItem mnu, object grvobj)
        {
            InitializeComponent();

            InitializeControls();

            ReloadData();

            GoodsReceivedVoucher grv = (GoodsReceivedVoucher)grvobj;
            goodsReceivedVoucherBindingSource.DataSource = grv;

            base.Caption = $"ORDER: {grv.DocumentNumber} ({grv.ExternalOrderNumber})";
        }


        private void InitializeControls()
        {
            base.Caption = "Goods Received Voucher";


            List<Control> cntrls = CTechCore.Tools.Forms.GetControls(this).ToList();
            foreach (Control ctrl in cntrls)
            {

                ctrl.GotFocus += (o, args) =>
                {
                    var c = o as Control;
                    Console.WriteLine(c.GetType().ToString());
                    c.BackColor = Color.Silver;
                    System.Reflection.MethodInfo theMethod = c.GetType().GetMethod("SelectAll");

                    if (theMethod != null && !(c is DevExpress.XtraEditors.TextBoxMaskBox))
                        theMethod.Invoke(c, null);

                };
                ctrl.LostFocus += (o, args) =>
                {
                    var c = o as Control;
                    ctrl.BackColor = Color.Empty;
                };
            }
        }

        private void ReloadData()
        {
            //Pastel.Evolution.purch
            //throw new NotImplementedException();
        }
    }
}
