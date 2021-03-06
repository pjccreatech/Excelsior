﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Users.Forms
{ 
    public partial class frmLogins : Form
    {
        public HertexCore.Module Module { get; set; }
        public Func<Models.Users.User, Type> Condition;
        public Type MainFormType { get; set; }

        public frmLogins()
        {
            InitializeComponent();
        }



        private void frmLogins_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = MyApp.Name;
                toolStripStatusLabel1.Text = $"Server: {MyApp.CTech.Server} [{MyApp.CTech.Database}] | {MyApp.Version}";

#if DEBUG
                // you are debugging 
                txtuname.Text = "sa";
                txtpword.Text = "sa";

                //btnLogin.PerformClick();
                return;
#endif

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: starting up application: {ex.ToString()}");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MyApp.Login = new Models.Users.LoginState(Module, txtuname.Text, txtpword.Text);
            if (MyApp.Login.User != null )
            {
                this.Hide();
                this.MainFormType = this.Condition(MyApp.Login.User);
                if (this.MainFormType != null)
                {

                    MyApp.Log.WriteEntry($"{MyApp.Login.User.Username} logged in.", System.Diagnostics.EventLogEntryType.Information);
                    using (Form frm = (Form)Activator.CreateInstance(this.MainFormType))
                    {
                        frm.ShowDialog();
                        MyApp.Login.LogOut();
                    }
                }

                this.Show();
                this.Activate();
                txtpword.Text = string.Empty;
                this.ActiveControl = txtpword;
                txtpword.Focus();
                txtpword.SelectAll();
            }
            this.DialogResult = DialogResult.No;
        }

        private void txtuname_Properties_Enter(object sender, EventArgs e)
        {
        }

        private void txtuname_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtpword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                txtpword.Focus();
                txtpword.SelectAll();
            }
        }
    }
}
