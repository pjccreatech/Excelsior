namespace Excelsior.Core.Tools
{
    partial class ucDropdownButtons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMain = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnMain.Appearance.BackColor2 = System.Drawing.SystemColors.HotTrack;
            this.btnMain.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnMain.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnMain.Appearance.Options.UseBackColor = true;
            this.btnMain.Appearance.Options.UseFont = true;
            this.btnMain.Appearance.Options.UseForeColor = true;
            this.btnMain.AppearanceDisabled.BackColor = System.Drawing.Color.Blue;
            this.btnMain.AppearanceDisabled.BackColor2 = System.Drawing.Color.Blue;
            this.btnMain.AppearanceDisabled.Options.UseBackColor = true;
            this.btnMain.AppearanceHovered.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMain.AppearanceHovered.BackColor2 = System.Drawing.SystemColors.Highlight;
            this.btnMain.AppearanceHovered.Options.UseBackColor = true;
            this.btnMain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMain.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnMain.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(183, 77);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "Main";
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // ucDropdownButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMain);
            this.Name = "ucDropdownButtons";
            this.Size = new System.Drawing.Size(183, 77);
            this.Load += new System.EventHandler(this.ucDropdownButtons_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnMain;
    }
}
