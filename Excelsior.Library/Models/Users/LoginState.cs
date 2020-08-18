using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationSettings;
using System.ComponentModel;

namespace Excelsior.Library.Models.Users
{
    public class LoginState : Core.Models.Users.LoginState
    {
        private Core.Models.Users.User user;
        public static Settings Settings = new Settings();

        public LoginState(string Uname, string Pword) : base(Uname, Pword)
        {
        }
    }
}
