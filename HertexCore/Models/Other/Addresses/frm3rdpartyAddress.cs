using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace HertexCore.Models.Other.Addresses
{
    public partial class frm3rdpartyAddress : Form
    {
        object document;
        public frm3rdpartyAddress(AccountsReceivable.Transactions.SalesOrders.SalesOrder so)
        {
            InitializeComponent();

            ppAddress.Properties.DataSource = new DataView(HertexData.Customers.Get3rdPartyAddressList());

            txtcontactnumber.KeyUp += Txtcontactnumber_KeyUp;
            document = so;

            txtName.Text = so.AddressFor3rdParty.PartyName;
            txtAddr1.Text = so.AddressFor3rdParty.Addr1;
            txtAddr2.Text = so.AddressFor3rdParty.Addr2;
            txtAddr3.Text = so.AddressFor3rdParty.Addr3;
            txtAddr4.Text = so.AddressFor3rdParty.Addr4;
            txtAddr5.Text = so.AddressFor3rdParty.Addr5;
            txtAddrPC.Text = so.AddressFor3rdParty.AddrPC;
            txtContactPerson.Text = so.AddressFor3rdParty.ContactPerson;
            txtcontactnumber.Text = so.AddressFor3rdParty.ContactNumber;

            ppAddress.ParseEditValue += HandleParseEditValue;
            ppAddress.CustomDisplayText += HandleDisplayText;
            ppAddress.EditValueChanged += PpAddress_EditValueChanged;

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

        private void PpAddress_EditValueChanged(object sender, EventArgs e)
        {
            CTechCore.Tools.CustomControls.CustomSearchEditor cntrl = (CTechCore.Tools.CustomControls.CustomSearchEditor)sender;
            DataRow row = (DataRow)cntrl.EditValue;

            txtAddr1.Text = row["Address1"].ToString();
            txtAddr2.Text = row["Address2"].ToString();
            txtAddr3.Text = row["Address3"].ToString();
            txtAddr4.Text = row["Address4"].ToString();
            txtAddr5.Text = row["Address5"].ToString();
            txtAddrPC.Text = row["AddressPC"].ToString();
            txtName.Text = row["Name"].ToString();
            txtcontactnumber.Text = row["ContactNumber"].ToString();
            txtContactPerson.Text = row["ContactPerson"].ToString();
        }

        private void HandleDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {

            }
            else
            {
                if (e.Value is DataRow)
                    e.DisplayText = ((DataRow)e.Value).Field<string>("Name");
                else
                {

                }
            }
        }

        private void HandleParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            {

            }
            else
            {
                if (e.Value is DataRow)
                {

                }
                else
                {

                }
            }
        }

        private void Txtcontactnumber_KeyUp(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit)sender;


            label1.Text = txt.Text.Length >= 25 ? "(Max 25 Characters)" : string.Empty;
            label1.ForeColor = txt.Text.Length >= 25 ? Color.Red : Color.Black;
            txt.ForeColor = txt.Text.Length >= 25 ? Color.Red : Color.Black;
            layoutControlItem7.AppearanceItemCaption.ForeColor = txt.Text.Length >= 55 ? Color.Red : Color.Black;

            //txt.Invoke((MethodInvoker)delegate ()
            //{
            //    label1.Text = txt.Text.Length >= 25 ? "(Max 25 Characters)" : string.Empty;
            //    label1.ForeColor = txt.Text.Length >= 25 ? Color.Red : Color.Black;
            //    txt.ForeColor = txt.Text.Length >= 25 ? Color.Red : Color.Black;
            //    layoutControlItem7.AppearanceItemCaption.ForeColor = txt.Text.Length >= 55 ? Color.Red : Color.Black;
            //});
        }

        private void frm3rdpartyAddress_Load(object sender, EventArgs e)
        {
            this.ActiveControl = ppAddress;
            ppAddress.Focus();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                AccountsReceivable.Transactions.SalesOrders.SalesOrder so = ((AccountsReceivable.Transactions.SalesOrders.SalesOrder)document);
                so.AddressFor3rdParty = new AddressFor3rdParty()
                {
                    ClientID = so.CustomerID,
                    PartyName = txtName.Text,
                    Addr1 = txtAddr1.Text,
                    Addr2 = txtAddr2.Text,
                    Addr3 = txtAddr3.Text,
                    Addr4 = txtAddr4.Text,
                    Addr5 = txtAddr5.Text,
                    AddrPC = txtAddrPC.Text,
                    ContactPerson = txtContactPerson.Text,
                    ContactNumber = txtcontactnumber.Text
                };
                so.AddressFor3rdParty.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void customSearchEditor1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}
