namespace CTechCore.Tools
{
    partial class frmSearch
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
            this.cntrlSearch1 = new CTechCore.Tools.cntrlSearch();
            this.SuspendLayout();
            // 
            // cntrlSearch1
            // 
            this.cntrlSearch1.BackColor = System.Drawing.Color.White;
            this.cntrlSearch1.DataSource = null;
            this.cntrlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlSearch1.EditValue = null;
            this.cntrlSearch1.FocusedRow = null;
            this.cntrlSearch1.Location = new System.Drawing.Point(7, 6);
            this.cntrlSearch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cntrlSearch1.Name = "cntrlSearch1";
            this.cntrlSearch1.NewButtonVisible = false;
            this.cntrlSearch1.OnRowCellStyle = null;
            this.cntrlSearch1.OnRowClick = null;
            this.cntrlSearch1.ShowButtonPanel = true;
            this.cntrlSearch1.ShowSummary = false;
            this.cntrlSearch1.Size = new System.Drawing.Size(786, 492);
            this.cntrlSearch1.TabIndex = 0;
            this.cntrlSearch1.Load += new System.EventHandler(this.cntrlSearch1_Load);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.cntrlSearch1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSearch";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Text = "frmAccounts";
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccounts_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public cntrlSearch cntrlSearch1;
    }
}