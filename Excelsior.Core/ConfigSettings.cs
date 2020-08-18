using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace ConfigurationSettings
{
    public class MyApp
    {
        public MyApp()
        {

        }

        private static DataTable GetAppInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                string sSQL = $"EXEC sp_AppConfig_InsUpd {MyApp.AppID}, '{MyApp.CompanyName}', '{MyApp.Name}', '{MyApp.ComputerName}', '{MyApp.Version}'";
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    string sCon = "Data Source=41.76.213.61, 1633;Initial Catalog=createch;Persist Security Info=True;User ID=sa;Password=sql2017;MultipleActiveResultSets=true";
                    da.SelectCommand = new SqlCommand(sSQL, new SqlConnection(sCon));
                    dt.Clear();
                    da.Fill(dt);
                }
                if (dt.Rows.Count > 0)
                {
                    MyApp.AppID = dt.Rows[0].Field<int>("AutoIDX");
                    MyApp.ExpiryDate = dt.Rows[0].Field<DateTime>("dtExpiry");
                    MyApp.LicenseDaysLeft = (MyApp.ExpiryDate.Date - DateTime.Now.Date).Days;
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obtaining App info. \n" + ex.ToString());
                return null;
            }
        }

        private static ConfigSettings settings = new ConfigSettings();
        private static Configuration PrepEnvironment()
        {
            try
            {

                System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ".";
                customCulture.NumberFormat.CurrencyDecimalSeparator = ".";
                customCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
                customCulture.DateTimeFormat.LongDatePattern = "yyyy MMMM dd";
                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


                
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"STARTUP ERROR: {ex.ToString()}");
                return null;
            }
        }


        public static string CompanyName = "Hertex";
        public static string Name = "Excelsior";
        public static string ExePath = Application.ExecutablePath;
        
        public static string UserConfigFile
        {
            get
            {
                System.IO.Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{MyApp.Name}\\");
                return $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{MyApp.Name}\\{MyApp.Name}_Config.json";
            }
        }

        public static string BranchConfigFile
        {
            get
            {
                System.IO.Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{MyApp.Name}\\");
                return $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{MyApp.Name}\\{MyApp.Name}_Branch_Config.json";
            }
        }
        public static string Path = System.IO.Path.GetDirectoryName(ExePath);
        public static Configuration configFile = PrepEnvironment();
        public static string ComputerName = Environment.MachineName;
        public static Cons Cons = (new ConfigSettings()).ConApperances;
        

        public static int AppID;
        public static DateTime ExpiryDate;
        public static int LicenseDaysLeft = 100;
        private static DataTable dtAppInfo = null;///GetAppInfo();

#if DEBUG
        public static Con Evo = Cons["EvoTest"];
        public static Con CTech = Cons["RollsTest"];
#else
        
        public static Con Evo = Cons["EvoLive"];
        public static Con CTech = Cons["RollsLive"];
#endif

        public static Settings Settings = new Settings();

        public static Excelsior.Core.Tools.frmEvents EventsScreen = new Excelsior.Core.Tools.frmEvents();

        public static string Version
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        return "Debug Mode";
                    }
                    else
                    {
                        try
                        {
                            return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

                        }
                        catch (Exception err)
                        {
                            return err.ToString();
                        }
                    };
                }
                else
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                    return fvi.FileVersion;
                }
            }
        }

        public static Excelsior.Core.Tools.cLog Log
        {
            get { return new Excelsior.Core.Tools.cLog(); }
        }

        public static Excelsior.Core.Models.Users.LoginState Login { get; set; }

        ///
    }
    

    /// <summary>
    /// Node
    /// </summary>
    public class Con : ConfigurationElement
    {
        public Con()
        { 
        }
        
        public Con(SqlConnection sqlcon)
        {
            this.SQLCon = sqlcon;
        }

        [ConfigurationProperty("Name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["Name"]; }
            set { base["Name"] = value; }
        }

        [ConfigurationProperty("Username", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Username
        {
            get { return (string)base["Username"]; }
            set { base["Username"] = value; }
        }

        [ConfigurationProperty("Password", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        [ConfigurationProperty("Server", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Server
        {
            get { return (string)base["Server"]; }
            set { base["Server"] = value; }
        }
        [ConfigurationProperty("Database", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Database
        {
            get { return (string)base["Database"]; }
            set { base["Database"] = value; }
        }

        [ConfigurationProperty("ConnectionTimeOut", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string ConnectionTimeOut
        {
            get { return (string)base["ConnectionTimeOut"]; }
            set { base["ConnectionTimeOut"] = value; }
        }

        [ConfigurationProperty("CommandTimeOut", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string CommandTimeOut
        {
            get { return (string)base["CommandTimeOut"]; }
            set { base["CommandTimeOut"] = value; }
        }


        public SqlConnection SQLCon { get; set; }
        public SqlTransaction SQLTrans { get; set; }

        // some methods for querying a database
        public bool ExecSQL(string sSQL)
        {
            try
            {
                if (this.SQLCon != null)
                {
                    if (this.SQLCon.State != ConnectionState.Open)
                    {
                        this.SQLCon.Open();
                    }

                    using (this.SQLTrans = this.SQLCon.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(sSQL, this.SQLCon))
                            {
                                cmd.CommandTimeout = Convert.ToInt32( (string.IsNullOrEmpty( this.CommandTimeOut) ? "15" :this.CommandTimeOut));
                                cmd.Transaction = this.SQLTrans;
                                cmd.ExecuteNonQuery();
                                this.SQLTrans.Commit();
                                return true;
                            }
                        }
                        catch (Exception e)
                        {
                            this.SQLTrans.Rollback();
                            MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);
                            return false;
                        }

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);

                return false;
            }
        }

        public bool ExecSQL(string sSQL, ref DataTable dt)
        {
            try
            {
                if (this.SQLCon != null)
                {
                    if (this.SQLCon.State != ConnectionState.Open)
                    {
                        this.SQLCon.Open();
                    }

                    using (this.SQLTrans = this.SQLCon.BeginTransaction())
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sSQL, this.SQLCon);
                        try
                        {
                            if (dt == null) dt = new DataTable();
                            da.SelectCommand.CommandTimeout = Convert.ToInt32((string.IsNullOrEmpty(this.CommandTimeOut) ? "15" : this.CommandTimeOut));
                            da.SelectCommand.Transaction = this.SQLTrans;
                            dt.Clear();
                            da.Fill(dt);
                            if (this.SQLTrans != null) this.SQLTrans.Commit();
                            return true;
                        }
                        catch (Exception e)
                        {
                            this.SQLTrans.Rollback();
                            MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);
                return false;
            }
        }

        public class Params
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }

        public bool ExecSQL(string sSQL, ref DataTable dt, List<Params> parms)
        {
            try
            {
                if (this.SQLCon != null)
                {
                    if (this.SQLCon.State != ConnectionState.Open)
                    {
                        this.SQLCon.Open();
                    }
                    using (this.SQLTrans = this.SQLCon.BeginTransaction())
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sSQL, this.SQLCon);
                        try
                        {
                            if (dt == null) dt = new DataTable();
                            parms.ForEach(o => da.SelectCommand.Parameters.AddWithValue("@" + o.Name, o.Value));
                            da.SelectCommand.CommandTimeout = Convert.ToInt32((string.IsNullOrEmpty(this.CommandTimeOut) ? "15" : this.CommandTimeOut));
                            da.SelectCommand.Transaction = this.SQLTrans;

                            dt.Clear();
                            da.Fill(dt);
                            this.SQLTrans.Commit();
                            return true;
                        }
                        catch (Exception e)
                        {
                            this.SQLTrans.Rollback();
                            MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);
                            return false;
                        }
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error ocurred: " + e.Message + " -> SQL:" + sSQL);
                return false;
            }
        }

        public void Open()
        {
            this.SQLCon = new SqlConnection();
            try
            {
                this.SQLCon.ConnectionString = "Data Source=" + this.Server +
                        ";Initial Catalog=" + this.Database +
                        ";Persist Security Info=True;User ID=" +
                        this.Username + ";Password=" +
                        this.Password + ";MultipleActiveResultSets=true";

                if (ConnectionState.Open != this.SQLCon.State)
                { this.SQLCon.Open(); }
            }
            catch (Exception err)
            {
                MyApp.Log.WriteEntry(err.ToString() + " - " + this.SQLCon.ConnectionString + "\n" + err.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public T GetList<T>(System.Data.SqlClient.SqlDataReader reader) where T : class
        {
            T returnedObject = Activator.CreateInstance<T>();
            System.Reflection.PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();
            for (int i = 0; i < modelProperties.Length; i++)
            {
                // Attribute[] attributes = modelProperties[i].GetCustomAttributes<Attribute>(true).ToArray();

                //if (attributes.Length > 0 && attributes[0]. != null)
                //    modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader[attributes[0].ColumnName], modelProperties[i].PropertyType), null);
            }
            return returnedObject;
        }

    }


    /// <summary>
    /// Collection
    /// 
    /// </summary>
    [ConfigurationCollection(typeof(Con))]
    public class Cons : ConfigurationElementCollection
    {
        internal const string PropertyName = "Con";

        public override ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.BasicMapAlternate; } }
        protected override string ElementName { get { return PropertyName; } }
        protected override bool IsElementName(string elementName) { return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase); }
        public override bool IsReadOnly() { return false; }
        protected override ConfigurationElement CreateNewElement() { return new Con(); }
        protected override object GetElementKey(ConfigurationElement element) { return ((Con)(element)).Name; }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
        public void Add(Con con)
        {
            BaseAdd(con);
        }
        public Con this[int idx]
        {
            get
            {

                Con ThisCon = (Con)BaseGet(idx);
                ThisCon.SQLCon = new SqlConnection();
                try
                {
                    ThisCon.SQLCon.ConnectionString = "Data Source=" + ThisCon.Server + ";Initial Catalog=" + ThisCon.Database + ";Persist Security Info=True;User ID=" + ThisCon.Username + ";Password=" + ThisCon.Password + ";MultipleActiveResultSets=true";

                    if (ConnectionState.Open != ThisCon.SQLCon.State)
                    { ThisCon.SQLCon.Open(); }
                }
                catch (Exception err)
                {
                    MyApp.Log.WriteEntry(err.ToString() + " - " + ThisCon.SQLCon.ConnectionString + "\n" + err.ToString(), System.Diagnostics.EventLogEntryType.Error);
                }
                return ThisCon;
            }
            set
            {
                if (BaseGet(idx) != null)
                {
                    BaseRemoveAt(idx);
                }
                BaseAdd(idx, value);
            }
        }

        new public Con this[string Name]
        {
            get
            {
                Con ThisCon = (Con)BaseGet(Name);
                ThisCon.SQLCon = new SqlConnection();
                try
                {
                    ThisCon.SQLCon.ConnectionString = "Persist Security Info=True" +
                                            ";Password=" + ThisCon.Password +
                                            ";User ID=" + ThisCon.Username +
                                            ";Data Source=" + ThisCon.Server +
                                            ";Initial Catalog=" + ThisCon.Database + ";MultipleActiveResultSets=true";
                    if (ConnectionState.Open != ThisCon.SQLCon.State)
                    { ThisCon.SQLCon.Open(); }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.ToString());
                }
                return ThisCon;
            }
        }

        public void Refresh()
        {

            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationManager.RefreshSection("ConSection");
        }
    }


    /// <summary>
    /// ???
    /// </summary>
    public class ConnectionSection : ConfigurationSection
    {
        [ConfigurationProperty("Cons")]
        public Cons ConElement
        {
            get { return ((Cons)(base["Cons"])); }
            set { base["Cons"] = value; }
        }
    }



    /// <summary>
    /// ???
    /// </summary>
    public class ConfigSettings
    {
        public ConnectionSection ConAppearanceConfiguration
        {
            get
            {
                ConfigurationManager.RefreshSection("ConSection");
                return (ConnectionSection)ConfigurationManager.GetSection("ConSection");
            }
        }

        public Cons ConApperances
        {
            get
            {
                return this.ConAppearanceConfiguration.ConElement;
            }
        }

        public IEnumerable<Con> ConElements
        {
            get
            {
                foreach (Con selement in this.ConApperances)
                {
                    if (selement != null)
                        yield return selement;
                }
            }
        }

    }



    /// <summary>
    /// 
    /// </summary>
    ///         
    public class Setting
    {
        public int ID { get; set; }
        public string App { get; set; }
        public string HeaderSection { get; set; }
        public string HeaderKey { get; set; }
        public string Value { get; set; }

        public void Save()
        {
            DataTable dt = new DataTable();
            List<Con.Params> parms = new List<Con.Params>()
        {
            new Con.Params() { Name = "app", Value = this.App},
            new Con.Params() { Name = "HeaderSection", Value = this.HeaderSection},
            new Con.Params() { Name = "HeaderKey", Value = this.HeaderKey},
            new Con.Params() { Name = "Value", Value = this.Value}
        };
            MyApp.CTech.ExecSQL("exec zz_sp_CRE_Config_Save '@app', '@HeaderSection', '@HeaderKey', '@Value'", ref dt, parms);
            foreach (DataRow dr in dt.Rows)
            {
                this.ID = dr.Field<int>("AutoIDX");
                this.App = dr.Field<string>("App");
                this.HeaderSection = dr.Field<string>("HeaderSection");
                this.HeaderKey = dr.Field<string>("HeaderKey");
                this.Value = dr.Field<string>("KeyValue");
            }

        }
    }

    public class Settings : System.ComponentModel.BindingList<Setting>, System.Collections.ICollection, System.Collections.IEnumerable
    {
        public Settings()
        {
            Refresh();
        }

        public void Refresh()
        {
            try
            {
                DataTable dt = new DataTable();
                MyApp.CTech.ExecSQL($"SELECT * from tblConfig WHERE App = '{MyApp.Name}' ", ref dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Setting _sett = new Setting
                    {
                        ID = dr.Field<int>("AutoIDX"),
                        App = dr.Field<string>("App"),
                        HeaderSection = dr.Field<string>("HeaderSection"),
                        HeaderKey = dr.Field<string>("HeaderKey"),
                        Value = dr.Field<string>("KeyValue")
                    };
                    this.Add(_sett);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obtaining application settings: {ex.ToString()}");
            }
        }

        public void Save()
        {
            foreach (Setting sett in this)
            {
                sett.Save();
            }
        }

        private Setting _sett;
        new public Setting this[int Index]
        {
            get
            {
                Setting _sett = (Setting)this[Index];
                return _sett;
            }
            set
            {
                _sett = value;
            }
        }

        public Settings this[string HeaderSection]
        {
            get
            {
                Settings _setts = new Settings();
                _setts.HeaderSection = HeaderSection;
                foreach (Setting item in _setts.ToList())
                {
                    if (item.HeaderSection != HeaderSection)
                    {
                        _setts.Remove(item);
                    }

                }
                return _setts;
            }
        }

        public string HeaderSection { get; set; }

        public Setting HeaderKey(string HeaderKey)
        {
            foreach (Setting _sett in this)
            {
                if (_sett.HeaderKey == HeaderKey)
                {
                    return _sett;
                }
            }
            Setting _set = new Setting()
            {
                App = MyApp.Name,
                HeaderSection = this.HeaderSection,
                HeaderKey = HeaderKey,
                Value = string.Empty
            };
            this.Add(_set);
            return _set;
        }
    }
}
