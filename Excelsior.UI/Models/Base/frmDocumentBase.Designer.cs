using System;
using DevExpress.XtraBars;

namespace Excelsior.UI.Models.Base
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentBase));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barbtnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnProcess = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEmail = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barbtnOpen,
            this.barbtnSave,
            this.barbtnNew,
            this.barbtnCancel,
            this.barbtnProcess,
            this.barBtnPrint,
            this.barBtnEmail});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(995, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
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
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnEmail);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "File";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(995, 31);
            // 
            // frmDocumentBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 606);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmDocumentBase";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void barBtnEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
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
    }
}