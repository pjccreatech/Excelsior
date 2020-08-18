using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Core.Models.Navigation
{
    [Table(Name = "NavigationMenu")]
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(DataRow dr)
        {

            this.ID = dr.Field<int>("AutoIDX");
            this.ParentID = dr.Field<int>("AutoIDX");
            this.Text = dr["Text"] == DBNull.Value ? string.Empty : dr.Field<string>("Text");
            this.Description = dr["Description"] == DBNull.Value ? string.Empty : dr.Field<string>("Description");
            this.Active = dr.Field<bool>("Active");
            this.ObjectType = dr["ObjectType"] == DBNull.Value ? string.Empty : dr.Field<string>("ObjectType");
            this.FormToLoad = dr["FormToLoad"] == DBNull.Value ? string.Empty : dr.Field<string>("FormToLoad");
            this.UserControl = dr["UserControl"] == DBNull.Value ? string.Empty : dr.Field<string>("UserControl");
            this.Sequence = dr.Field<int>("Sequence");
            this.SourceTable = dr["SourceTable"] == DBNull.Value ? string.Empty : dr.Field<string>("SourceTable");
            this.GetAllSQL = dr["GetAllSQL"] == DBNull.Value ? string.Empty : dr.Field<string>("GetAllSQL");
        }
        
        [Column(Name = "AutoIDX", CanBeNull = false, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column(Name = "ParentID")]
        public int ParentID { get; set; }
        [Column(Name = "Text")]
        public string Text { get; set; }
        [Column(Name = "Description")]
        public string Description { get; set; }
        [Column(Name = "Active")]
        public bool Active { get; set; }
        
        [Column(Name = "ObjectType")]
        public string ObjectType { get; set; }
        [Column(Name = "FormToLoad")]
        public string FormToLoad { get; set; }
        [Column(Name = "UserControl")]
        public string UserControl { get; set; }
        [Column(Name = "Sequence")]
        public int Sequence { get; set; }
        
        [Column(Name = "SourceTable")]
        public string SourceTable { get; set; }
        [Column(Name = "GetAllSQL")]
        public string GetAllSQL { get; set; }
        
        public virtual MenuItem Parent { get; set; }

        public System.Windows.Forms.Form MdiParent { get; set; }
        public Type RuntimeObjectType
        {
            get
            {
                if (string.IsNullOrEmpty(this.ObjectType)) return null;
                Type tpe = Type.GetType($"{this.ObjectType.Trim()}, {this.ObjectType.Split('.')[0]}");
                return tpe;
            }
        }
        public Type RuntimeFormType
        {
            get
            {
                if (string.IsNullOrEmpty(this.FormToLoad)) return null;
                Type tpe = Type.GetType($"{this.FormToLoad.Trim()}, {this.FormToLoad.Split('.')[0]}");
                return tpe;
            }
        }
        public override string ToString() => $"{this.Text} ({this.Description})";
    }
}
