
namespace HertexCore.Models.Users.Forms
{
    partial class frmManagerOverride
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagerOverride));
            this.pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnl.Controls.Add(this.pnlLeft);
            this.pnl.Controls.Add(this.label1);
            this.pnl.Controls.Add(this.textEdit1);
            this.pnl.Controls.Add(this.btnAccept);
            this.pnl.Location = new System.Drawing.Point(8, 30);
            this.pnl.Name = "pnl";
            this.pnl.Padding = new System.Windows.Forms.Padding(15);
            this.pnl.Size = new System.Drawing.Size(922, 69);
            this.pnl.TabIndex = 15;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(15, 15);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 40);
            this.pnlLeft.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(215, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 40);
            this.label1.TabIndex = 17;
            this.label1.Text = "PASSWORD:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(388, 15);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Mask.BeepOnError = true;
            this.textEdit1.Properties.Mask.PlaceHolder = '*';
            this.textEdit1.Properties.PasswordChar = '*';
            this.textEdit1.Size = new System.Drawing.Size(349, 40);
            this.textEdit1.TabIndex = 18;
            // 
            // btnAccept
            // 
            this.btnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnAccept.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnAccept.Appearance.Options.UseBackColor = true;
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.Appearance.Options.UseForeColor = true;
            this.btnAccept.AppearanceDisabled.BackColor = System.Drawing.Color.Silver;
            this.btnAccept.AppearanceDisabled.Options.UseBackColor = true;
            this.btnAccept.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.AppearanceHovered.Options.UseFont = true;
            this.btnAccept.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAccept.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.ImageOptions.Image")));
            this.btnAccept.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAccept.Location = new System.Drawing.Point(747, 15);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 40);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "OK";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmManagerOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 107);
            this.Controls.Add(this.pnl);
            this.KeyPreview = true;
            this.Name = "frmManagerOverride";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmManagerOverride";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManagerOverride_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManagerOverride_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmManagerOverride_KeyPress);
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        public DevExpress.XtraEditors.SimpleButton btnAccept;
    }
}