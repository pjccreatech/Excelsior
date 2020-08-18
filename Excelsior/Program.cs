using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior
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
            Application.Run(new Excelsior.UI.Models.Users.frmLogins() { Condition = u => typeof(frmMain) });
        }
    }
}
