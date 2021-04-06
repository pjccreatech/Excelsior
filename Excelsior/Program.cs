using HertexCore;
using System;
using System.Windows.Forms;
using System.Linq;

namespace ExcelsiorMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.XtraEditors.WindowsFormsSettings.LoadApplicationSettings();
            //Application.SetCompatibleTextRenderingDefault(false);

            if (MyApp.LicenseDaysLeft < 0)
            {
                System.Windows.Forms.MessageBox.Show("You license has expired! Please contact createch to continue.", "Important!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (MyApp.LicenseDaysLeft <= 5)
            {
                string msg = string.Format("You license will expire in {0} days. \nYou will not be able to use this application after this period.", MyApp.LicenseDaysLeft);
                System.Windows.Forms.MessageBox.Show(msg, "Important!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Application.Run(new HertexCore.Models.Users.Forms.frmLogins() 
            { 
                Module = HertexCore.Modules.Excelsior,
                Condition = (u) => typeof(frmMain)
            });
        }


    }
}
