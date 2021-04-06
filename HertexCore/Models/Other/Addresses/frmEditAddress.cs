using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Other.Addresses
{
    public partial class frmEditAddress : Form
    {
        private object document;
        public frmEditAddress(Models.AccountsReceivable.Transactions.SalesOrders.SalesOrder so)
        {
            InitializeComponent();
            textEdit1.Focus();

            textEdit1.GotFocus += TextEdit_GotFocus;
            textEdit2.GotFocus += TextEdit_GotFocus;
            textEdit3.GotFocus += TextEdit_GotFocus;
            textEdit4.GotFocus += TextEdit_GotFocus;
            textEdit5.GotFocus += TextEdit_GotFocus;
            textEdit6.GotFocus += TextEdit_GotFocus;

            textEdit7.GotFocus += TextEdit_GotFocus;
            textEdit8.GotFocus += TextEdit_GotFocus;
            textEdit9.GotFocus += TextEdit_GotFocus;
            textEdit10.GotFocus += TextEdit_GotFocus;
            textEdit11.GotFocus += TextEdit_GotFocus;
            textEdit12.GotFocus += TextEdit_GotFocus;

            document = so;
            textEdit1.Text = so.DeliveryAddress.Addr1;
            textEdit2.Text = so.DeliveryAddress.Addr2;
            textEdit3.Text = so.DeliveryAddress.Addr3;
            textEdit4.Text = so.DeliveryAddress.Addr4;
            textEdit5.Text = so.DeliveryAddress.Addr5;
            textEdit6.Text = so.DeliveryAddress.AddrPC;

            textEdit7.Text = so.InvoiceAddress.Addr1;
            textEdit8.Text = so.InvoiceAddress.Addr2;
            textEdit9.Text = so.InvoiceAddress.Addr3;
            textEdit10.Text = so.InvoiceAddress.Addr4;
            textEdit11.Text = so.InvoiceAddress.Addr5;
            textEdit12.Text = so.InvoiceAddress.AddrPC;

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

        private void TextEdit_GotFocus(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.TextEdit)sender).SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AccountsReceivable.Transactions.SalesOrders.SalesOrder so = ((AccountsReceivable.Transactions.SalesOrders.SalesOrder)document);
            so.DeliveryAddress.Addr1 = textEdit1.Text;
            so.DeliveryAddress.Addr2 = textEdit2.Text;
            so.DeliveryAddress.Addr3 = textEdit3.Text;
            so.DeliveryAddress.Addr4 = textEdit4.Text;
            so.DeliveryAddress.Addr5 = textEdit5.Text;
            so.DeliveryAddress.AddrPC = textEdit6.Text;
            
            so.InvoiceAddress.Addr1 = textEdit7.Text;
            so.InvoiceAddress.Addr2 = textEdit8.Text;
            so.InvoiceAddress.Addr3 = textEdit9.Text;
            so.InvoiceAddress.Addr4 = textEdit10.Text;
            so.InvoiceAddress.Addr5 = textEdit11.Text;
            so.InvoiceAddress.AddrPC = textEdit12.Text;
                
            this.DialogResult = DialogResult.OK;
        }

        private void frmEditAddress_Load(object sender, EventArgs e)
        {
            textEdit1.Focus();
        }
    }
}
