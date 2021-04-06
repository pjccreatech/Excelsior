namespace CTechCore.WaitForms
{
    partial class frmWaitMemo
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutedtMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutpnlButtons = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutedtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutpnlButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoSize = true;
            this.layoutControl1.Controls.Add(this.panel2);
            this.layoutControl1.Controls.Add(this.richEditControl1);
            this.layoutControl1.Controls.Add(this.progressPanel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(1, 1);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(1);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(406, 262);
            this.layoutControl1.TabIndex = 14;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Location = new System.Drawing.Point(4, 218);
            this.panel2.MinimumSize = new System.Drawing.Size(391, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(398, 40);
            this.panel2.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(327, 5);
            this.btnOK.LookAndFeel.SkinName = "DevExpress Style";
            this.btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // richEditControl1
            // 
            this.richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControl1.Location = new System.Drawing.Point(4, 96);
            this.richEditControl1.MinimumSize = new System.Drawing.Size(391, 120);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.ReadOnly = true;
            this.richEditControl1.Size = new System.Drawing.Size(398, 120);
            this.richEditControl1.TabIndex = 12;
            // 
            // progressPanel1
            // 
            this.progressPanel1.AnimationSpeed = 1F;
            this.progressPanel1.AnimationToTextDistance = 10;
            this.progressPanel1.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.progressPanel1.ImageHorzOffset = 30;
            this.progressPanel1.Location = new System.Drawing.Point(4, 4);
            this.progressPanel1.MinimumSize = new System.Drawing.Size(391, 86);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(398, 90);
            this.progressPanel1.TabIndex = 4;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutedtMessage,
            this.layoutpnlButtons});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(406, 262);
            this.Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.progressPanel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(391, 92);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Size = new System.Drawing.Size(400, 92);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutedtMessage
            // 
            this.layoutedtMessage.Control = this.richEditControl1;
            this.layoutedtMessage.Location = new System.Drawing.Point(0, 92);
            this.layoutedtMessage.Name = "layoutedtMessage";
            this.layoutedtMessage.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutedtMessage.Size = new System.Drawing.Size(400, 122);
            this.layoutedtMessage.TextSize = new System.Drawing.Size(0, 0);
            this.layoutedtMessage.TextVisible = false;
            this.layoutedtMessage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutpnlButtons
            // 
            this.layoutpnlButtons.Control = this.panel2;
            this.layoutpnlButtons.Location = new System.Drawing.Point(0, 214);
            this.layoutpnlButtons.MinSize = new System.Drawing.Size(400, 42);
            this.layoutpnlButtons.Name = "layoutpnlButtons";
            this.layoutpnlButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutpnlButtons.Size = new System.Drawing.Size(400, 42);
            this.layoutpnlButtons.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutpnlButtons.TextSize = new System.Drawing.Size(0, 0);
            this.layoutpnlButtons.TextVisible = false;
            this.layoutpnlButtons.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmWaitMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(408, 262);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWaitMemo";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMemoWait";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutedtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutpnlButtons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutedtMessage;
        private DevExpress.XtraLayout.LayoutControlItem layoutpnlButtons;
    }
}