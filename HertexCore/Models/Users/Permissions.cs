using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Users
{
    public class Permission
    {
        public Permission()
        {
        }

        public Permission(DataRow dr)
        {
            this.ID = (int)dr["AutoIDX"];
            this.UserID = int.Parse((string)dr["UserID1"]);
            this.ModuleName = (string)dr["ModuleName"];
            this.PermissionKey = (string)dr["PermissionKey"];
            this.PermissionValue = (string)dr["PermissionValue"];
        }
        public Permission(int id)
        {
            try
            {
                //MyApp.Settings.Refresh();
                //Permission sets= Permissions[(int)id];
                //if (sets != null)
                //{
                //    this.ID = sets.ID;
                //    this.UserID = sets.UserID;
                //    this.ModuleName = sets.ModuleName;
                //    this.PermissionKey = sets.PermissionKey;
                //    this.PermissionValue = sets.PermissionValue;
                //}
                //else
                //    new Exception($"Cannnot find\\load settings for key {id}");
            }
            catch (Exception ex)
            {
                string msg = $"Error returning setting information: {ex.Message}.\r\n {ex.StackTrace}";
                System.Windows.Forms.MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string ModuleName { get; set; }
        public string PermissionKey { get; set; }
        public string PermissionValue { get; set; }

        public override string ToString() => $"{this.ModuleName} > {this.PermissionKey} > {PermissionValue}";
        
        public void Save()
        {
        //    DataTable dt = new DataTable();
        //    List<Con.Params> parms = new List<Con.Params>()
        //{
        //    new Con.Params() { Name = "IDX", Value = this.ID},
        //    new Con.Params() { Name = "app", Value = this.App},
        //    new Con.Params() { Name = "HeaderSection", Value = this.HeaderSection},
        //    new Con.Params() { Name = "HeaderKey", Value = this.HeaderKey},
        //    new Con.Params() { Name = "Value", Value = this.Value}
        //};
        //    MyApp.CTech.ExecSQL("exec sp_XR_Config_Save @IDX, @app, @HeaderSection, @HeaderKey, @Value", ref dt, parms);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        this.ID = dr.Field<int>("AutoIDX");
        //        this.App = dr.Field<string>("App");
        //        this.HeaderSection = dr.Field<string>("HeaderSection");
        //        this.HeaderKey = dr.Field<string>("HeaderKey");
        //        this.Value = dr.Field<string>("KeyValue");
        //    }

        }
    }

    public class Permissions : System.ComponentModel.BindingList<Permission>, System.Collections.ICollection, System.Collections.IEnumerable
    {
        public Permissions()
        {
        }


        public Permissions(Models.Users.User user)
        {
        }


        public void Save()
        {
            foreach (Permission sett in this)
            {
                sett.Save();
            }
        }

        private Permission _sett;
        new public Permission this[int id]
        {
            get
            {
                return this.FirstOrDefault(s => s.ID == id);
            }
            set
            {
                _sett = value;
            }
        }



        public string ModuleName { get; set; }

        public Permission PermissionKey(string PermissionKey)
        {
            foreach (Permission _sett in this)
            {
                if (_sett.PermissionKey == PermissionKey)
                {
                    return _sett;
                }
            }
            Permission _set = new Permission()
            {
                ModuleName = "",
                PermissionKey = PermissionKey,
                PermissionValue = string.Empty
            };
            this.Add(_set);
            return _set;
        }
    }
}
