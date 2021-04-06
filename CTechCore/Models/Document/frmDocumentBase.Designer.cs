using System;
using DevExpress.XtraBars;

namespace CTechCore.Models.Document
{
    partial class frmDocumentBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentBase));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barbtnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnProcess = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEmail = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefreshData = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barbtnOpen,
            this.barbtnSave,
            this.barbtnNew,
            this.barbtnCancel,
            this.barbtnProcess,
            this.barBtnPrint,
            this.barBtnEmail,
            this.barBtnRefreshData});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(995, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barbtnOpen
            // 
            this.barbtnOpen.Caption = "Open";
            this.barbtnOpen.Id = 1;
            this.barbtnOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnOpen.ImageOptions.Image")));
            this.barbtnOpen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnOpen.ImageOptions.LargeImage")));
            this.barbtnOpen.Name = "barbtnOpen";
            // 
            // barbtnSave
            // 
            this.barbtnSave.Caption = "Save";
            this.barbtnSave.Id = 2;
            this.barbtnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnSave.ImageOptions.Image")));
            this.barbtnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnSave.ImageOptions.LargeImage")));
            this.barbtnSave.Name = "barbtnSave";
            // 
            // barbtnNew
            // 
            this.barbtnNew.Caption = "New";
            this.barbtnNew.Id = 3;
            this.barbtnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnNew.ImageOptions.Image")));
            this.barbtnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnNew.ImageOptions.LargeImage")));
            this.barbtnNew.Name = "barbtnNew";
            // 
            // barbtnCancel
            // 
            this.barbtnCancel.Caption = "Cancel";
            this.barbtnCancel.Id = 4;
            this.barbtnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnCancel.ImageOptions.Image")));
            this.barbtnCancel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnCancel.ImageOptions.LargeImage")));
            this.barbtnCancel.Name = "barbtnCancel";
            // 
            // barbtnProcess
            // 
            this.barbtnProcess.Caption = "Process";
            this.barbtnProcess.Id = 5;
            this.barbtnProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnProcess.ImageOptions.Image")));
            this.barbtnProcess.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnProcess.ImageOptions.LargeImage")));
            this.barbtnProcess.Name = "barbtnProcess";
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "Print";
            this.barBtnPrint.Id = 6;
            this.barBtnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnPrint.ImageOptions.Image")));
            this.barBtnPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnPrint.ImageOptions.LargeImage")));
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPrint_ItemClick);
            // 
            // barBtnEmail
            // 
            this.barBtnEmail.Caption = "eMail";
            this.barBtnEmail.Id = 7;
            this.barBtnEmail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnEmail.ImageOptions.Image")));
            this.barBtnEmail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnEmail.ImageOptions.LargeImage")));
            this.barBtnEmail.Name = "barBtnEmail";
            this.barBtnEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEmail_ItemClick);
            // 
            // barBtnRefreshData
            // 
            this.barBtnRefreshData.Caption = "Refresh";
            this.barBtnRefreshData.Id = 8;
            this.barBtnRefreshData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRefreshData.ImageOptions.Image")));
            this.barBtnRefreshData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnRefreshData.ImageOptions.LargeImage")));
            this.barBtnRefreshData.Name = "barBtnRefreshData";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "File";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnOpen);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnProcess);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnCancel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "File";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnEmail);
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnPrint);
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnRefreshData);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Actions";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(800, 3);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBox3.Size = new System.Drawing.Size(192, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "www.hertex.co.za");
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBox4.Size = new System.Drawing.Size(50, 40);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "www.hertex.co.za");
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.panel1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Appearance.Options.UseForeColor = true;
            this.panel1.Controls.Add(this.lblCaption);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 46);
            this.panel1.TabIndex = 8;
            // 
            // lblCaption
            // 
            this.lblCaption.AllowHtmlString = true;
            this.lblCaption.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
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
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblCaption.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblCaption.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.lblCaption.LineStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.lblCaption.LineVisible = true;
            this.lblCaption.Location = new System.Drawing.Point(53, 3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCaption.ShowLineShadow = false;
            this.lblCaption.Size = new System.Drawing.Size(747, 40);
            this.lblCaption.TabIndex = 9;
            this.lblCaption.Text = "<B>KOKOKOMO<B>";
            // 
            // frmDocumentBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon);
            this.Name = "frmDocumentBase";
            this.Ribbon = this.ribbon;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void barBtnEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        #endregion
        public DevExpress.XtraBars.BarButtonItem barbtnOpen;
        public DevExpress.XtraBars.BarButtonItem barbtnSave;
        public DevExpress.XtraBars.BarButtonItem barbtnNew;
        public DevExpress.XtraBars.BarButtonItem barbtnCancel;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        public DevExpress.XtraBars.BarButtonItem barbtnProcess;
        public DevExpress.XtraBars.BarButtonItem barBtnPrint;
        public BarButtonItem barBtnEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        public BarButtonItem barBtnRefreshData;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        public DevExpress.XtraEditors.LabelControl lblCaption;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        public DevExpress.XtraEditors.PanelControl panel1;
    }
}