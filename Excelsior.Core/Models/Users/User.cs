using ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Core.Models.Users
{
    public class User
    {
        public int ID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public User(int id)
        {

        }
        public User(DataRow dr)
        {
            Reload(dr);
        }

        private void Reload(DataRow dr)
        {
            this.ID = dr.Field<int>("AutoIndex");
            this.Username = dr.Field<string>("UserID");
            this.Password = dr.Field<string>("Password");
            this.Active = dr.Field<bool>("IsActive");
        }
    }


    public class LoginState: INotifyPropertyChanged
    {
        public System.Windows.Forms.Form frmLogin;

        public User User { get; set; }
        
        public LoginState(string Uname, string Pword)
        {
            List<Con.Params> parms = new List<Con.Params>()
            {
                new Con.Params() {Name = "username", Value = Uname},
                new Con.Params() {Name = "password", Value = Pword}
            };

            DataTable dtUsers = new DataTable();
            if (MyApp.CTech.ExecSQL("EXEC dbo.sp_Xlsr_UserLogin @username, @password", ref dtUsers, parms))
            {
                if (dtUsers.Rows.Count > 0)
                {
                    this.User = new User(dtUsers.Rows[0]);

                }
                else
                {
                    MessageBox.Show("Username or password were not recognised locally!");
                }
            }
        }

        public void LogOut()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }


}
