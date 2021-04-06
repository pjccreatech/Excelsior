
namespace HertexCore.Models.Stock.Forms
{
    partial class frmAdjustRollLength
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjustRollLength));
            this.lbl_ProductCode = new System.Windows.Forms.Label();
            this.lbl_OriginalRollLength = new System.Windows.Forms.Label();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.txt_OriginalRollLength = new System.Windows.Forms.TextBox();
            this.lbl_Adjustment = new System.Windows.Forms.Label();
            this.txt_Adjustment = new System.Windows.Forms.TextBox();
            this.lbl_NewRollAdjustment = new System.Windows.Forms.Label();
            this.lbl_DateOfAdjustment = new System.Windows.Forms.Label();
            this.lbl_Reason = new System.Windows.Forms.Label();
            this.pnl_ControlBar = new System.Windows.Forms.Panel();
            this.btnAdjustRollLength = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.de_DateOfAdjustment = new DevExpress.XtraEditors.DateEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.lookupAdjustReason = new DevExpress.XtraEditors.LookUpEdit();
            this.pnl_ControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_DateOfAdjustment.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_DateOfAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupAdjustReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProductCode
            // 
            this.lbl_ProductCode.AutoSize = true;
            this.lbl_ProductCode.Location = new System.Drawing.Point(14, 57);
            this.lbl_ProductCode.Name = "lbl_ProductCode";
            this.lbl_ProductCode.Size = new System.Drawing.Size(72, 13);
            this.lbl_ProductCode.TabIndex = 0;
            this.lbl_ProductCode.Text = "Product Code";
            // 
            // lbl_OriginalRollLength
            // 
            this.lbl_OriginalRollLength.AutoSize = true;
            this.lbl_OriginalRollLength.Location = new System.Drawing.Point(14, 93);
            this.lbl_OriginalRollLength.Name = "lbl_OriginalRollLength";
            this.lbl_OriginalRollLength.Size = new System.Drawing.Size(99, 13);
            this.lbl_OriginalRollLength.TabIndex = 1;
            this.lbl_OriginalRollLength.Text = "Original Roll Length";
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.Location = new System.Drawing.Point(125, 54);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.ReadOnly = true;
            this.txt_ProductCode.Size = new System.Drawing.Size(245, 20);
            this.txt_ProductCode.TabIndex = 2;
            // 
            // txt_OriginalRollLength
            // 
            this.txt_OriginalRollLength.Location = new System.Drawing.Point(125, 90);
            this.txt_OriginalRollLength.Name = "txt_OriginalRollLength";
            this.txt_OriginalRollLength.ReadOnly = true;
            this.txt_OriginalRollLength.Size = new System.Drawing.Size(87, 20);
            this.txt_OriginalRollLength.TabIndex = 3;
            // 
            // lbl_Adjustment
            // 
            this.lbl_Adjustment.AutoSize = true;
            this.lbl_Adjustment.Location = new System.Drawing.Point(218, 93);
            this.lbl_Adjustment.Name = "lbl_Adjustment";
            this.lbl_Adjustment.Size = new System.Drawing.Size(59, 13);
            this.lbl_Adjustment.TabIndex = 4;
            this.lbl_Adjustment.Text = "Adjustment";
            // 
            // txt_Adjustment
            // 
            this.txt_Adjustment.Location = new System.Drawing.Point(283, 90);
            this.txt_Adjustment.Name = "txt_Adjustment";
            this.txt_Adjustment.ReadOnly = true;
            this.txt_Adjustment.Size = new System.Drawing.Size(87, 20);
            this.txt_Adjustment.TabIndex = 5;
            // 
            // lbl_NewRollAdjustment
            // 
            this.lbl_NewRollAdjustment.AutoSize = true;
            this.lbl_NewRollAdjustment.Location = new System.Drawing.Point(14, 129);
            this.lbl_NewRollAdjustment.Name = "lbl_NewRollAdjustment";
            this.lbl_NewRollAdjustment.Size = new System.Drawing.Size(86, 13);
            this.lbl_NewRollAdjustment.TabIndex = 7;
            this.lbl_NewRollAdjustment.Text = "New Roll Length";
            // 
            // lbl_DateOfAdjustment
            // 
            this.lbl_DateOfAdjustment.AutoSize = true;
            this.lbl_DateOfAdjustment.Location = new System.Drawing.Point(14, 164);
            this.lbl_DateOfAdjustment.Name = "lbl_DateOfAdjustment";
            this.lbl_DateOfAdjustment.Size = new System.Drawing.Size(97, 13);
            this.lbl_DateOfAdjustment.TabIndex = 9;
            this.lbl_DateOfAdjustment.Text = "Date of Adjustment";
            // 
            // lbl_Reason
            // 
            this.lbl_Reason.AutoSize = true;
            this.lbl_Reason.Location = new System.Drawing.Point(16, 199);
            this.lbl_Reason.Name = "lbl_Reason";
            this.lbl_Reason.Size = new System.Drawing.Size(44, 13);
            this.lbl_Reason.TabIndex = 11;
            this.lbl_Reason.Text = "Reason";
            // 
            // pnl_ControlBar
            // 
            this.pnl_ControlBar.Controls.Add(this.btnAdjustRollLength);
            this.pnl_ControlBar.Controls.Add(this.btnCancel);
            this.pnl_ControlBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_ControlBar.Location = new System.Drawing.Point(0, 243);
            this.pnl_ControlBar.Name = "pnl_ControlBar";
            this.pnl_ControlBar.Size = new System.Drawing.Size(411, 56);
            this.pnl_ControlBar.TabIndex = 23;
            // 
            // btnAdjustRollLength
            // 
            this.btnAdjustRollLength.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.btnAdjustRollLength.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAdjustRollLength.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustRollLength.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdjustRollLength.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnAdjustRollLength.Appearance.Options.UseBackColor = true;
            this.btnAdjustRollLength.Appearance.Options.UseFont = true;
            this.btnAdjustRollLength.Appearance.Options.UseForeColor = true;
            this.btnAdjustRollLength.AppearanceDisabled.BackColor = System.Drawing.Color.Blue;
            this.btnAdjustRollLength.AppearanceDisabled.BackColor2 = System.Drawing.Color.Blue;
            this.btnAdjustRollLength.AppearanceDisabled.Options.UseBackColor = true;
            this.btnAdjustRollLength.AppearanceHovered.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustRollLength.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnAdjustRollLength.AppearanceHovered.Options.UseFont = true;
            this.btnAdjustRollLength.AppearancePressed.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustRollLength.AppearancePressed.Options.UseFont = true;
            this.btnAdjustRollLength.AutoWidthInLayoutControl = true;
            this.btnAdjustRollLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdjustRollLength.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAdjustRollLength.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdjustRollLength.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnAdjustRollLength.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdjustRollLength.ImageOptions.Image")));
            this.btnAdjustRollLength.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdjustRollLength.Location = new System.Drawing.Point(0, 0);
            this.btnAdjustRollLength.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAdjustRollLength.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdjustRollLength.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnAdjustRollLength.Name = "btnAdjustRollLength";
            this.btnAdjustRollLength.Size = new System.Drawing.Size(128, 56);
            this.btnAdjustRollLength.TabIndex = 15;
            this.btnAdjustRollLength.Text = "Save";
            this.btnAdjustRollLength.Click += new System.EventHandler(this.btnAdjustRollLength_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.btnCancel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.AppearanceDisabled.BackColor = System.Drawing.Color.Blue;
            this.btnCancel.AppearanceDisabled.BackColor2 = System.Drawing.Color.Blue;
            this.btnCancel.AppearanceDisabled.Options.UseBackColor = true;
            this.btnCancel.AppearanceHovered.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnCancel.AppearanceHovered.Options.UseFont = true;
            this.btnCancel.AppearancePressed.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.AppearancePressed.Options.UseFont = true;
            this.btnCancel.AutoWidthInLayoutControl = true;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancel.Location = new System.Drawing.Point(283, 0);
            this.btnCancel.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 56);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // de_DateOfAdjustment
            // 
            this.de_DateOfAdjustment.EditValue = null;
            this.de_DateOfAdjustment.Location = new System.Drawing.Point(125, 161);
            this.de_DateOfAdjustment.Name = "de_DateOfAdjustment";
            this.de_DateOfAdjustment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_DateOfAdjustment.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_DateOfAdjustment.Size = new System.Drawing.Size(131, 20);
            this.de_DateOfAdjustment.TabIndex = 25;
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(125, 129);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Size = new System.Drawing.Size(131, 20);
            this.spinEdit1.TabIndex = 27;
            this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.AllowHtmlString = true;
            this.lblCaption.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lblCaption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCaption.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
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
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblCaption.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblCaption.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.lblCaption.LineVisible = true;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.lblCaption.Size = new System.Drawing.Size(411, 48);
            this.lblCaption.TabIndex = 28;
            this.lblCaption.Text = "Adjust Roll Length";
            // 
            // lookupAdjustReason
            // 
            this.lookupAdjustReason.Location = new System.Drawing.Point(125, 196);
            this.lookupAdjustReason.Name = "lookupAdjustReason";
            this.lookupAdjustReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupAdjustReason.Properties.NullText = "Select Reason";
            this.lookupAdjustReason.Size = new System.Drawing.Size(245, 20);
            this.lookupAdjustReason.TabIndex = 29;
            this.lookupAdjustReason.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.lookupAdjustReason_CustomDisplayText);
            // 
            // frmAdjustRollLength
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 299);
            this.Controls.Add(this.lookupAdjustReason);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.de_DateOfAdjustment);
            this.Controls.Add(this.pnl_ControlBar);
            this.Controls.Add(this.lbl_Reason);
            this.Controls.Add(this.lbl_DateOfAdjustment);
            this.Controls.Add(this.lbl_NewRollAdjustment);
            this.Controls.Add(this.txt_Adjustment);
            this.Controls.Add(this.lbl_Adjustment);
            this.Controls.Add(this.txt_OriginalRollLength);
            this.Controls.Add(this.txt_ProductCode);
            this.Controls.Add(this.lbl_OriginalRollLength);
            this.Controls.Add(this.lbl_ProductCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdjustRollLength";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjust Roll Length";
            this.Load += new System.EventHandler(this.frmAdjustRollLength_Load);
            this.pnl_ControlBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_DateOfAdjustment.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_DateOfAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupAdjustReason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProductCode;
        private System.Windows.Forms.Label lbl_OriginalRollLength;
        private System.Windows.Forms.TextBox txt_ProductCode;
        private System.Windows.Forms.TextBox txt_OriginalRollLength;
        private System.Windows.Forms.Label lbl_Adjustment;
        private System.Windows.Forms.TextBox txt_Adjustment;
        private System.Windows.Forms.Label lbl_NewRollAdjustment;
        private System.Windows.Forms.Label lbl_DateOfAdjustment;
        private System.Windows.Forms.Label lbl_Reason;
        private System.Windows.Forms.Panel pnl_ControlBar;
        public DevExpress.XtraEditors.SimpleButton btnAdjustRollLength;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DateEdit de_DateOfAdjustment;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.LookUpEdit lookupAdjustReason;
    }
}