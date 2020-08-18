using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;

namespace Excelsior.Core.Tools
{
    public partial class cntrlSearch : UserControl
    {
        private bool _ShowSummary;
        public delegate void OnRowClickEvent(object sender, object Row);
        public OnRowClickEvent OnRowClick { get; set; }

        public delegate void OnRowCellStyleEvent(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e);
        public OnRowCellStyleEvent OnRowCellStyle { get; set; }

        public bool? ShowButtonPanel
        {
            get { return panel4.Visible; }
            set { panel4.Visible = value.HasValue ? Convert.ToBoolean( value): true; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(bool)), DefaultValue(true)]
        public bool ShowSummary
        {
            get
            {
                DevExpress.XtraGrid.Columns.GridColumn col = this.gridView1.Columns.Where(c => c.Visible).FirstOrDefault();
                if (col == null) return false;
                
                return col.SummaryItem.SummaryType != SummaryItemType.None;
            }
            set
            {
                SummaryItemType tpe =
                    value ? DevExpress.Data.SummaryItemType.Count : DevExpress.Data.SummaryItemType.None;

                DevExpress.XtraGrid.Columns.GridColumn col = this.gridView1.Columns.Where(c => c.Visible).FirstOrDefault();
                if (col != null)
                {
                    col.SummaryItem.SummaryType = tpe;
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    col.SummaryItem.DisplayFormat = "# Rows: {0}";
                }
            }
        }


        public object FocusedRow { get; set; }
        public object EditValue { get; set; }

        [Category("Data")]
        [AttributeProvider(typeof(bool)), DefaultValue(true)]
        public bool NewButtonVisible
        {
            get { return btnNew.Visible; }
            set { btnNew.Visible = value; }
        }

        [Category("Data")]
        [Description("Grid Columns")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(DevExpress.XtraGrid.Columns.GridColumnCollection))]
        public DevExpress.XtraGrid.Columns.GridColumnCollection Columns { get { return this.gridView1.Columns; } }

        [Category("Data")]
        [Description("Grid")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(ControlHelpers.CustomGridControl))]
        public ControlHelpers.CustomGridControl GridControl { get { return gridControl1; } }



        [Category("Data")]
        [Description("Grid")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(DevExpress.XtraGrid.Views.Grid.GridView))]
        public DevExpress.XtraGrid.Views.Grid.GridView MainView { get { return gridView1; } }

        [Category("Data")]
        [Description("ViewShowGroupPanel")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(bool)), DefaultValue(true)]
        public bool ViewShowGroupPanel
        {
            get { return gridView1.OptionsView.ShowGroupPanel; }
            set { gridView1.OptionsView.ShowGroupPanel = value; }
        }



        [Category("Data")]
        [Description("ViewSelectionMultiSelect")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(bool)), DefaultValue(false)]
        public bool ViewSelectionMultiSelect
        {
            get { return gridView1.OptionsSelection.MultiSelect; }
            set { gridView1.OptionsSelection.MultiSelect = value; }
        }


        [Category("Data")]
        [Description("ViewMultiSelectMode")]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [AttributeProvider(typeof(DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode)), DefaultValue(DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect)]
        public DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode ViewMultiSelectMode
        {
            get { return gridView1.OptionsSelection.MultiSelectMode; }
            set { gridView1.OptionsSelection.MultiSelectMode = value; }
        }

        [Category("Data")]
        [Description("Indicates the source of data for the control.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return this.gridControl1.DataSource; }
            set
            {
                this.gridControl1.DataSource = value;
                if(this.gridView1.Columns.Count > 0) this.gridView1.Columns[0].Visible = false;

                DevExpress.XtraGrid.Columns.GridColumn col = this.gridView1.Columns.Where(c => c.Visible).FirstOrDefault();
                if (col != null)
                {
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    col.SummaryItem.DisplayFormat = "# Rows: {0}";
                }

                foreach (DevExpress.XtraGrid.Columns.GridColumn c in gridView1.Columns)
                {
                    c.OptionsColumn.AllowFocus = false;
                }
            }
        }
        public void FocusSearchBox() { searchControl1.Focus(); }
        public void FocusGrid() { gridControl1.Focus(); }
        public cntrlSearch()
        {
            InitializeComponent();
            searchControl1.Properties.MaxItemCount = -1;
            searchControl1.Focus();

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                if (gridView1.GetRow(gridView1.FocusedRowHandle) is DataRowView)
                {
                    this.EditValue = ((System.Data.DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle)).Row;
                }
                else
                {
                    this.EditValue = gridView1.GetRow(gridView1.FocusedRowHandle);
                }

                if (this.Parent is Form) ((Form)this.Parent).DialogResult = DialogResult.OK;
                if (this.Parent is DevExpress.XtraEditors.PopupContainerControl)
                {
                    ((DevExpress.XtraEditors.PopupContainerControl)this.Parent).OwnerEdit.EditValue = this.EditValue;
                    ((DevExpress.XtraEditors.PopupContainerControl)this.Parent).OwnerEdit.ClosePopup();
                    searchControl1.ClearFilter();
                    gridView1.FindFilterText = string.Empty;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gridView1.FindFilterText = string.Empty;
            if (this.Parent is Form)  ((Form)this.Parent).DialogResult = DialogResult.Cancel;
            if (this.Parent is DevExpress.XtraEditors.PopupContainerControl) ((DevExpress.XtraEditors.PopupContainerControl)this.Parent).OwnerEdit.CancelPopup();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnAccept.PerformClick();
        }
        
        private void searchControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridControl1.Focus();
            }
            else if(e.KeyCode == Keys.Up)
            {
                gridControl1.Focus();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAccept.PerformClick();
            if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && !(e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12) )
            {
                searchControl1.Focus();
            }

        }

        private void cntrlSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnClose.PerformClick();
        }

        private void searchControl1_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridView1.FindFilterText = string.Empty;
        }

        private void searchControl1_AddingMRUItem(object sender, DevExpress.XtraEditors.Controls.AddingMRUItemEventArgs e)
        {
            e.Cancel = true;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.OnRowClick != null)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
                if (!gv.IsValidRowHandle(gv.FocusedRowHandle)) return;
                //this.OnRowClick(sender, ((System.Data.DataRowView)(gv.GetRow(e.FocusedRowHandle))).Row);
                this.OnRowClick(sender, gv.GetRow(e.FocusedRowHandle));
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (this.OnRowClick != null)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);

                //this.OnRowClick(sender, ((System.Data.DataRowView)(gv.GetRow(e.RowHandle))).Row);
                this.OnRowClick(sender, (gv.GetRow(e.RowHandle)));
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (this.OnRowCellStyle != null)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);

                this.OnRowCellStyle(sender, e);
                
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form) ((Form)this.Parent).DialogResult = DialogResult.OK;
        }
    }
}
