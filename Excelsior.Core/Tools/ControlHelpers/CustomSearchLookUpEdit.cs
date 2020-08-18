using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Popup;
using System.Reflection;

namespace Excelsior.Core.Tools.ControlHelpers
{
    public class CustomPopupSearchLookUpEditForm : PopupSearchLookUpEditForm
    {
        public CustomPopupSearchLookUpEditForm(SearchLookUpEdit edit) : base(edit) { }

        protected override void UpdateDisplayFilter(string displayFilter)
        {
            DisplayFilterEventArgs args = new DisplayFilterEventArgs(displayFilter);
            Properties.RaiseUpdateDisplayFilter(args);
            base.UpdateDisplayFilter(args.FilterText);
        }

        public new RepositoryItemCustomSearchLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomSearchLookUpEdit; }
        }
    }
    public class CustomSearchLookUpEdit : SearchLookUpEdit
    {
        private RepositoryItemSearchLookUpEdit fProperties;
        private DevExpress.XtraGrid.Views.Grid.GridView fPropertiesView;

        static CustomSearchLookUpEdit() { RepositoryItemCustomSearchLookUpEdit.RegisterCustomEdit(); }

        public CustomSearchLookUpEdit() { }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemCustomSearchLookUpEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomSearchLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomSearchLookUpEdit; }
        }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new CustomPopupSearchLookUpEditForm(this);
        }

        public event UpdateDisplayFilterHandler UpdateDisplayFilter
        {
            add { this.Properties.UpdateDisplayFilter += value; }
            remove { this.Properties.UpdateDisplayFilter -= value; }
        }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.fPropertiesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            this.fProperties.View = this.fPropertiesView;
            // 
            // fPropertiesView
            // 
            this.fPropertiesView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.fPropertiesView.Name = "fPropertiesView";
            this.fPropertiesView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fPropertiesView.OptionsView.ShowGroupPanel = false;
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).EndInit();
            this.ResumeLayout(false);

        }
    }



    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomSearchLookUpEdit : RepositoryItemSearchLookUpEdit
    {
        static readonly object _updateDisplayFilter = new object();

        static RepositoryItemCustomSearchLookUpEdit() { RegisterCustomEdit(); }

        public RepositoryItemCustomSearchLookUpEdit() { }

        public const string CustomEditName = "CustomSearchLookUpEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            Image img = null;
            try
            {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch
            {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomSearchLookUpEdit), typeof(RepositoryItemCustomSearchLookUpEdit),
              typeof(SearchLookUpEditBaseViewInfo), new ButtonEditPainter(), true, img));
        }

        public event UpdateDisplayFilterHandler UpdateDisplayFilter
        {
            add { this.Events.AddHandler(_updateDisplayFilter, value); }
            remove { this.Events.RemoveHandler(_updateDisplayFilter, value); }
        }

        protected internal virtual void RaiseUpdateDisplayFilter(DisplayFilterEventArgs e)
        {
            UpdateDisplayFilterHandler handler = (UpdateDisplayFilterHandler)Events[_updateDisplayFilter];
            if (handler != null) handler(GetEventSender(), e);
        }

        public override void Assign(RepositoryItem item)
        {
            base.Assign(item);
            RepositoryItemCustomSearchLookUpEdit source = item as RepositoryItemCustomSearchLookUpEdit;
            Events.AddHandler(_updateDisplayFilter, source.Events[_updateDisplayFilter]);
        }
    }


    public delegate void UpdateDisplayFilterHandler(object sender, DisplayFilterEventArgs e);
    public class DisplayFilterEventArgs : EventArgs
    {
        string filterText;
        public DisplayFilterEventArgs(string filterText)
        {
            this.filterText = filterText;
        }
        public string FilterText
        {
            get { return filterText; }
            set
            {
                if (filterText != value)
                    filterText = value;
            }
        }
    }
}