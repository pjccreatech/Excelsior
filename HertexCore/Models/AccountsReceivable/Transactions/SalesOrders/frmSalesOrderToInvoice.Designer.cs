
namespace HertexCore.Models.AccountsReceivable.Transactions.SalesOrders
{
    partial class frmSalesOrderToInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrderToInvoice));
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barbtnFilterAll = new DevExpress.XtraBars.BarCheckItem();
            this.barbtnFilterNewOrd = new DevExpress.XtraBars.BarCheckItem();
            this.barbtnFilterBO = new DevExpress.XtraBars.BarCheckItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcPOHeader = new DevExpress.XtraGrid.GridControl();
            this.gvPOHeader = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPODetails = new DevExpress.XtraGrid.GridControl();
            this.gvPODetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPOHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPOHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPODetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPODetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnFilterAll,
            this.barbtnFilterNewOrd,
            this.barbtnFilterBO});
            this.ribbon.MaxItemId = 20;
            // 
            // 
            // 
            this.ribbon.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbon.SearchEditItem.EditWidth = 150;
            this.ribbon.SearchEditItem.Id = -5000;
            this.ribbon.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(1054, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaption.Appearance.Options.UseBackColor = true;
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseForeColor = true;
            this.lblCaption.Appearance.Options.UseImageAlign = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.Size = new System.Drawing.Size(806, 49);
            this.lblCaption.Text = "<B>INVOICING<B>";
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.panel1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Appearance.Options.UseForeColor = true;
            this.panel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel1.Size = new System.Drawing.Size(1054, 55);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnFilterAll);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnFilterNewOrd);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnFilterBO);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Filters";
            // 
            // barbtnFilterAll
            // 
            this.barbtnFilterAll.Caption = "All";
            this.barbtnFilterAll.Id = 17;
            this.barbtnFilterAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnFilterAll.ImageOptions.Image")));
            this.barbtnFilterAll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnFilterAll.ImageOptions.LargeImage")));
            this.barbtnFilterAll.LargeWidth = 60;
            this.barbtnFilterAll.Name = "barbtnFilterAll";
            this.barbtnFilterAll.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnFilterAll_CheckedChanged);
            // 
            // barbtnFilterNewOrd
            // 
            this.barbtnFilterNewOrd.Caption = "New Orders";
            this.barbtnFilterNewOrd.Id = 18;
            this.barbtnFilterNewOrd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnFilterNewOrd.ImageOptions.Image")));
            this.barbtnFilterNewOrd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnFilterNewOrd.ImageOptions.LargeImage")));
            this.barbtnFilterNewOrd.LargeWidth = 60;
            this.barbtnFilterNewOrd.Name = "barbtnFilterNewOrd";
            this.barbtnFilterNewOrd.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnFilterNewOrd_CheckedChanged);
            // 
            // barbtnFilterBO
            // 
            this.barbtnFilterBO.Caption = "Backorders";
            this.barbtnFilterBO.Id = 19;
            this.barbtnFilterBO.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnFilterBO.ImageOptions.Image")));
            this.barbtnFilterBO.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnFilterBO.ImageOptions.LargeImage")));
            this.barbtnFilterBO.LargeWidth = 65;
            this.barbtnFilterBO.Name = "barbtnFilterBO";
            this.barbtnFilterBO.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnFilterBO_CheckedChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 198);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcPOHeader);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcPODetails);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1054, 414);
            this.splitContainerControl1.SplitterPosition = 174;
            this.splitContainerControl1.TabIndex = 13;
            // 
            // gcPOHeader
            // 
            this.gcPOHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPOHeader.Location = new System.Drawing.Point(0, 0);
            this.gcPOHeader.MainView = this.gvPOHeader;
            this.gcPOHeader.Name = "gcPOHeader";
            this.gcPOHeader.Size = new System.Drawing.Size(1054, 174);
            this.gcPOHeader.TabIndex = 12;
            this.gcPOHeader.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPOHeader});
            // 
            // gvPOHeader
            // 
            this.gvPOHeader.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.gvPOHeader.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPOHeader.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPOHeader.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPOHeader.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvPOHeader.GridControl = this.gcPOHeader;
            this.gvPOHeader.Name = "gvPOHeader";
            this.gvPOHeader.OptionsMenu.ShowFooterItem = true;
            this.gvPOHeader.OptionsView.ShowFooter = true;
            this.gvPOHeader.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "OrderNum";
            this.gridColumn1.FieldName = "OrderNum";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderNum", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Name";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "OrderDate";
            this.gridColumn4.FieldName = "OrderDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Confirmed";
            this.gridColumn5.FieldName = "ulIDPOrdConfirmed";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gcPODetails
            // 
            this.gcPODetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPODetails.Location = new System.Drawing.Point(0, 48);
            this.gcPODetails.MainView = this.gvPODetails;
            this.gcPODetails.Name = "gcPODetails";
            this.gcPODetails.Size = new System.Drawing.Size(1054, 187);
            this.gcPODetails.TabIndex = 16;
            this.gcPODetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPODetails});
            // 
            // gvPODetails
            // 
            this.gvPODetails.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.gvPODetails.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvPODetails.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPODetails.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPODetails.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPODetails.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPODetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gvPODetails.GridControl = this.gcPODetails;
            this.gvPODetails.Name = "gvPODetails";
            this.gvPODetails.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Code";
            this.gridColumn6.FieldName = "Code";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 139;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Description_1";
            this.gridColumn7.FieldName = "Description_1";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 139;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Description_2";
            this.gridColumn8.FieldName = "Description_2";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 139;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Group";
            this.gridColumn9.FieldName = "stgroup";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 142;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Order Qty";
            this.gridColumn10.FieldName = "fQuantity";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 138;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Processed";
            this.gridColumn11.FieldName = "fQtyProcessed";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            this.gridColumn11.Width = 138;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Received Qty";
            this.gridColumn12.FieldName = "QtyReceived";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            this.gridColumn12.Width = 141;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1054, 48);
            this.panelControl1.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlString = true;
            this.labelControl2.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseImageAlign = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl2.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(60, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.labelControl2.Size = new System.Drawing.Size(991, 43);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "DETAILS";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 3);
            this.pictureEdit1.MenuManager = this.ribbon;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(57, 42);
            this.pictureEdit1.TabIndex = 0;
            // 
            // frmSalesOrderToInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "<B>INVOICING<B>";
            this.ClientSize = new System.Drawing.Size(1054, 612);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmSalesOrderToInvoice";
            this.Text = "Process Sales Orders";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPOHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPOHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPODetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPODetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcPOHeader;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPOHeader;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraBars.BarCheckItem barbtnFilterAll;
        private DevExpress.XtraBars.BarCheckItem barbtnFilterNewOrd;
        private DevExpress.XtraBars.BarCheckItem barbtnFilterBO;
        private DevExpress.XtraGrid.GridControl gcPODetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPODetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}