using System;
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
    public partial class frmManagerOverride : CTechCore.Tools.frmBorderlessForm
    {
        public Models.Users.User Manager { get; set; }
        Models.Users.PasswordOverrrideType PasswordType { get; set; }

        public frmManagerOverride(Models.Users.PasswordOverrrideType passwordType)
        {
            InitializeComponent();
            this.PasswordType = passwordType;


            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BringToFront();
            this.Location = new System.Drawing.Point(0, 0);
            this.DesktopLocation = new System.Drawing.Point(0, 0);
            this.Size = Screen.GetWorkingArea(this).Size;
            pnl.Width = this.Width;
            pnl.Left = 0;
            pnl.Top = this.Height / 2 - (pnl.Height / 2);
            pnlLeft.Width = (Screen.GetWorkingArea(Cursor.Position).Width - (label1.Width + textEdit1.Width + btnAccept.Width)) / 2;
            textEdit1.Focus();
        }

        private void frmManagerOverride_Load(object sender, EventArgs e)
        {

            //Form frm = Application.OpenForms["frmMain"];

        }

        private void frmManagerOverride_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmManagerOverride_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnAccept.PerformClick();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string sSQL = $"EXEC sp_XR_ManagerOverride @PasswordType = '{this.PasswordType.ToString()}',@Password = '{textEdit1.Text}' ";
            DataTable dt = new DataTable();
            MyApp.CTech.ExecSQL(sSQL, ref dt);

            if (dt.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
             }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(@"c:\Windows\Media\Windows Critical Stop.wav");
                simpleSound.Play();
                textEdit1.Focus();
                textEdit1.SelectAll();
            }

        }
    }
}
