using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Models.Navigation
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
            this.ParentID = dr.Field<int>("ParentID");
            this.Text = dr["Text"] == DBNull.Value ? string.Empty : dr.Field<string>("Text");
            this.Description = dr["Description"] == DBNull.Value ? string.Empty : dr.Field<string>("Description");
            this.Active = dr.Field<bool>("Active");
            this.ObjectType = dr["ObjectType"] == DBNull.Value ? string.Empty : dr.Field<string>("ObjectType");
            this.FormToLoad = dr["FormToLoad"] == DBNull.Value ? string.Empty : dr.Field<string>("FormToLoad");
            this.UserControl = dr["UserControl"] == DBNull.Value ? string.Empty : dr.Field<string>("UserControl");
            this.Sequence = dr.Field<int>("Sequence");
            this.SourceTable = dr["SourceTable"] == DBNull.Value ? string.Empty : dr.Field<string>("SourceTable");
            this.GetAllSQL = dr["GetAllSQL"] == DBNull.Value ? string.Empty : dr.Field<string>("GetAllSQL");
            this.DisplayText = dr["DisplayText"] == DBNull.Value ? string.Empty : dr.Field<string>("DisplayText");

            if (dr.Table.Columns.Contains("DisplayAllFormBeforeLoad"))
                this.DisplayAllFormBeforeLoad = dr["DisplayAllFormBeforeLoad"] == DBNull.Value ? false : dr.Field<bool>("DisplayAllFormBeforeLoad");
            else
                this.DisplayAllFormBeforeLoad = false;

            if (dr.Table.Columns.Contains("RequiresParametersOnConstructer"))
                this.RequiresParametersOnConstructer = dr["RequiresParametersOnConstructer"] == DBNull.Value ? false : dr.Field<bool>("RequiresParametersOnConstructer");

            if (dr.Table.Columns.Contains("ExternalModuleIDX"))
                this.ExternalModuleID = dr["ExternalModuleIDX"] == DBNull.Value ? 0 : dr.Field<int>("ExternalModuleIDX");

            
        }
        
        [Column(Name = "AutoIDX", CanBeNull = false, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column(Name = "ParentID")]
        public int ParentID { get; set; }
        [Column(Name = "Text")]
        public string Text { get; set; } = string.Empty;
        [Column(Name = "Description")]
        public string Description { get; set; } = string.Empty;
        [Column(Name = "Active")]
        public bool Active { get; set; } = true;

        internal void Save()
        {
            DataTable dt = new DataTable();
            List <Con.Params> parms = new List<Con.Params>()
            {
                new Con.Params() { Name = "IDX", Value = this.ID},
                new Con.Params() { Name = "ParentID", Value = this.ParentID},
                new Con.Params() { Name = "Text", Value = this.Text},
                new Con.Params() { Name = "Description", Value = this.Description},
                new Con.Params() { Name = "Active", Value = this.Active},
                new Con.Params() { Name = "ObjectType", Value = this.ObjectType},
                new Con.Params() { Name = "FormToLoad", Value = this.FormToLoad},
                new Con.Params() { Name = "UserControl", Value = this.UserControl},
                new Con.Params() { Name = "Sequence", Value = this.Sequence},
                new Con.Params() { Name = "SourceTable", Value = this.SourceTable},
                new Con.Params() { Name = "GetAllSQL", Value = this.GetAllSQL},
                new Con.Params() { Name = "DisplayText", Value = this.DisplayText},
                new Con.Params() { Name = "DisplayAllFormBeforeLoad", Value = this.DisplayText},
                new Con.Params() { Name = "RequiresParametersOnConstructer", Value = this.RequiresParametersOnConstructer},
                new Con.Params() { Name = "ExternalModuleIDX", Value = this.ExternalModuleID},
                
            };
            MyApp.CTech.ExecSQL("EXEC sp_XR_NavMenuItem_InsUpd @IDX, @ParentID, @Text, @Description, @Active, @ObjectType, @FormToLoad, @UserControl, @Sequence, @SourceTable, @GetAllSQL, @DisplayText, @OverrrideDataModelSelect, @DisplayAllFormBeforeLoad, @RequiresParametersOnConstructer, @ExternalModuleIDX", ref dt, parms);
        }

        [Column(Name = "ObjectType")]
        public string ObjectType { get; set; } = string.Empty;
        [Column(Name = "FormToLoad")]
        public string FormToLoad { get; set; } = string.Empty;
        [Column(Name = "UserControl")]
        public string UserControl { get; set; } = string.Empty;
        [Column(Name = "Sequence")]
        public int Sequence { get; set; }
        
        [Column(Name = "SourceTable")]
        public string SourceTable { get; set; } = string.Empty;
        [Column(Name = "GetAllSQL")]
        public string GetAllSQL { get; set; } = string.Empty;

        [Column(Name = "DisplayText")]
        public string DisplayText { get; set; } = string.Empty;
        public bool DisplayAllFormBeforeLoad { get; set; }
        public bool RequiresParametersOnConstructer { get; set; } = true;
        public int ExternalModuleID { get; set; }

        public virtual MenuItem Parent { get; set; }
        public Nullable<bool> OverrrideDataModelSelect { get; set; } = false;

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
