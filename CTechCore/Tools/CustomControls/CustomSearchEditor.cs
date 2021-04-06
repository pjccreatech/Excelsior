using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;
using System.Windows.Forms;

namespace CTechCore.Tools.CustomControls
{
    [UserRepositoryItem("RegisterCustomSearchEditor")]
    public class RepositoryItemCustomSearchEditor : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemCustomSearchEditor()
        {
            RegisterCustomSearchEditor();
        }

        public CTechCore.Tools.cntrlSearch cntrlSearch1;

        private PopupContainerControl _popupContainerControl;
        public const string CustomEditName = "CustomSearchEditor";

        public RepositoryItemCustomSearchEditor()
        {
            InitializeComponent();
            this.KeyUp += (o, e) =>
            {
                if (e.KeyData == System.Windows.Forms.Keys.Tab ||
                   e.KeyData == System.Windows.Forms.Keys.Escape ||
                   e.KeyData == (System.Windows.Forms.Keys.Tab | System.Windows.Forms.Keys.Shift) ||
                   e.KeyData == System.Windows.Forms.Keys.Enter ||
                   e.KeyData == System.Windows.Forms.Keys.ShiftKey ||
                   e.KeyData == (System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Shift) ||
                   e.KeyData == System.Windows.Forms.Keys.Left ||
                   e.KeyData == System.Windows.Forms.Keys.Right ||
                   e.KeyData == System.Windows.Forms.Keys.Down ||
                   e.KeyData == System.Windows.Forms.Keys.Up
                   )
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    cntrlSearch1.TextEditor.ClearFilter();

                    if (!((CustomSearchEditor)o).IsPopupOpen)
                    {
                        ((CustomSearchEditor)o).ShowPopup();
                        cntrlSearch1.TextEditor.SetFilter(((CustomSearchEditor)o).Text);
                        cntrlSearch1.TextEditor.Select(cntrlSearch1.TextEditor.Text.Length, 0);
                    }
                    e.Handled = true;
                }
            };
            this.KeyPress += (o, e) =>
            {
                if (!((CustomSearchEditor)o).IsPopupOpen)
                {
                    ((CustomSearchEditor)o).ShowPopup();
                    cntrlSearch1.TextEditor.ClearFilter();
                    cntrlSearch1.TextEditor.Text = e.KeyChar.ToString();
                    cntrlSearch1.TextEditor.Select(cntrlSearch1.TextEditor.Text.Length, 0);
                }
            };

            //this.GotFocus += (o, e) => ((CustomSearchEditor)o).SelectAll();
            this.BeforePopup += (o, e) => cntrlSearch1.TextEditor.ClearFilter(); ;
            this.MouseUp += (o, e) => ((CustomSearchEditor)o).SelectAll();
        }

        public override string EditorTypeName
        {
            get
            {
                return CustomEditName;
            }
        }

        public static void RegisterCustomSearchEditor()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, 
                typeof(CustomSearchEditor), 
                typeof(RepositoryItemCustomSearchEditor), 
                typeof(CustomSearchEditorViewInfo), 
                new CustomSearchEditorPainter(), 
                true, 
                img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemCustomSearchEditor source = item as RepositoryItemCustomSearchEditor;
                if (source == null)
                    return;
                else
                {
                    this.DataSource = source.DataSource;
                }

                //
            }
            finally
            {
                EndUpdate();
            }
        }

        private void InitializeComponent()
        {
            this.cntrlSearch1 = new CTechCore.Tools.cntrlSearch();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cntrlSearch1
            // 
            this.cntrlSearch1.BackColor = System.Drawing.Color.White;
            this.cntrlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlSearch1.DataSource = null;
            this.cntrlSearch1.EditValue = null;
            this.cntrlSearch1.FocusedRow = null;
            this.cntrlSearch1.Location = new System.Drawing.Point(0, 0);
            this.cntrlSearch1.Name = "cntrlSearch1";
            this.cntrlSearch1.NewButtonVisible = false;
            this.cntrlSearch1.OnRowCellStyle = null;
            this.cntrlSearch1.OnRowClick = null;
            this.cntrlSearch1.ShowButtonPanel = false;
            this.cntrlSearch1.ShowFindPanel = true;
            this.cntrlSearch1.ViewShowGroupPanel = false;
            this.cntrlSearch1.ShowSummary = false;
            this.cntrlSearch1.Size = new System.Drawing.Size(865, 536);
            this.cntrlSearch1.TextEditor.Properties.EditValueChanging += TextEditor_EditValueChanged;

            _popupContainerControl = new PopupContainerControl() { Name = "1" };            
            _popupContainerControl.Size = new System.Drawing.Size(400, 300);
            _popupContainerControl.Controls.Add(cntrlSearch1);
            PopupControl = _popupContainerControl;
            
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void TextEditor_EditValueChanged(object sender, EventArgs e)
        {
            
            //this.OwnerEdit.Text = ((DevExpress.XtraEditors.SearchControl)sender).Text;
        }

        #region Custom Properties
        public Object DataSource
        {
            get
            {
                return cntrlSearch1.DataSource;

            }
            set
            {
                this.cntrlSearch1.DataSource = value;

            }

        }

        private string keycolumn;
        public string KeyColumn
        { get { return this.cntrlSearch1.gridView1.Columns.Count > 0 ? this.cntrlSearch1.gridView1.Columns[0].FieldName : null; }
        }
        #endregion
    }

    [ToolboxItem(true)]
    public class CustomSearchEditor : PopupContainerEdit
    {
        static CustomSearchEditor()
        {
            RepositoryItemCustomSearchEditor.RegisterCustomSearchEditor();
        }

        public CustomSearchEditor()
        {
            base.Properties.KeyDown += Properties_KeyDown;
            base.GotFocus += (o, e) => ((CustomSearchEditor)o).SelectAll();
            base.Properties.BeforePopup += (o, e) => Properties.cntrlSearch1.TextEditor.ClearFilter(); ;
            base.MouseUp += (o, e) => ((CustomSearchEditor)o).SelectAll();
            base.KeyUp += CustomSearchEditor_KeyUp;
            base.KeyPress += CustomSearchEditor_KeyPress;

        }

        private void CustomSearchEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsPopupOpen)
            {
                DoShowPopup();
                Properties.cntrlSearch1.TextEditor.ClearFilter();
                Properties.cntrlSearch1.TextEditor.Text = e.KeyChar.ToString();
                Properties.cntrlSearch1.TextEditor.Select(Properties.cntrlSearch1.TextEditor.Text.Length, 0);
            }
        }

        private void CustomSearchEditor_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
                    {
            if (e.KeyData == System.Windows.Forms.Keys.Tab ||
                e.KeyData == System.Windows.Forms.Keys.Escape ||
                e.KeyData == (System.Windows.Forms.Keys.Tab | System.Windows.Forms.Keys.Shift) ||
                e.KeyData == System.Windows.Forms.Keys.Enter ||
                e.KeyData == System.Windows.Forms.Keys.ShiftKey ||
                e.KeyData == (System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Shift) ||
                e.KeyData == System.Windows.Forms.Keys.Left ||
                e.KeyData == System.Windows.Forms.Keys.Right)
            {
                e.Handled = true;
                return;
            }
            else
            {
                Properties.cntrlSearch1.TextEditor.ClearFilter();
                if (!IsPopupOpen)
                {
                    DoShowPopup();
                    Properties.cntrlSearch1.TextEditor.SetFilter(this.Text);
                    Properties.cntrlSearch1.TextEditor.Select(Properties.cntrlSearch1.TextEditor.Text.Length, 0);
                }
                e.Handled = true;
            }
        }

        private void Properties_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            



            
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomSearchEditor Properties
        {
            get
            {
                return base.Properties as RepositoryItemCustomSearchEditor;
            }
        }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemCustomSearchEditor.CustomEditName;
            }
        }

        protected override PopupBaseForm CreatePopupForm()
        {
            if (Properties.PopupControl == null) return null;
            return new CustomSearchEditorPopupForm(this);
        }

    }

    public class CustomSearchEditorViewInfo : PopupContainerEditViewInfo
    {
        public CustomSearchEditorViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class CustomSearchEditorPainter : ButtonEditPainter
    {
        public CustomSearchEditorPainter()
        {
        }
    }

    public class CustomSearchEditorPopupForm : PopupContainerForm
    {
        public CustomSearchEditorPopupForm(CustomSearchEditor ownerEdit) : base(ownerEdit)
        {
             
        }
    }
}
