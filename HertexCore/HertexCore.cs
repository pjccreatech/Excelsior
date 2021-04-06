using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore
{
    public class MyApp: CTechCore.MyApp
    {
        public static Models.Users.LoginState Login { get; set; }

        public static string serialNumber = "DE07110004";
        public static string AuthorizationKey = "7630048";
        
    }
    
    public class Defaults : CTechCore.Defaults
    {
    }
    
    public class Con : CTechCore.Con
    {
    }

    public class Modules: Module
    {
        public Modules(string name) : base(name) { }
        public static readonly Modules Excelsior = new Modules("Excelsior");
        public static readonly Modules Appro = new Modules("Appro");
        public static readonly Modules Budgets = new Modules("Budgets");
        public static readonly Modules CRM = new Modules("CRM");
        public static readonly Modules Dashboard = new Modules("Dashboard");

    }

    public abstract class Module : IComparable
    {
        private readonly DataRow dr;

        public int ID { get { return (int)dr["AutoIDX"]; } }
        public string Name { get { return (string)dr["SystemModule"]; } }
        public string Description { get { return (string)dr["Description"]; } }
        public Version Version { get { return Version.Parse((string)dr["Version"]); } }
        public bool Active { get { return (bool)dr["IsActive"]; } }
        public DateTime Created { get { return (DateTime)dr["dtCreated"]; } }
        public DateTime ReleaseDate { get { return (DateTime)dr["dtReleaseDate"]; } }
        public string DisplayText { get { return $"{Name} ({Version})" ; } }
        public bool? MainModule { get { return (bool?)dr["MainModule"]; } }
        public HertexCore.Models.Users.Permissions Permissions { get; set; }
        protected Module(string name)
        {
            try
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * FROM XR_SystemModules WITH(NOLOCK) WHERE SystemModule = '{name}'", ref dt);
                if (dt.Rows.Count > 0)
                    dr = dt.Rows[0];
                else
                    throw new Exception($"Module name '{name}' does not exist.");
            }
            catch (Exception ex)
            {
                string msg = $"Error : {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public override string ToString() => Name;
        public static IEnumerable<T> GetAll<T>() where T : Module, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Module;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue.Name);

            return typeMatches && valueMatches;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static T FromValue<T>(int value) where T : Module, new()
        {
            var matchingItem = parse<T, int>(value, "value", item => item.ID == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Module, new()
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }
        private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Module, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return ID.CompareTo(((Module)other).ID);
        }
    }


}
