
namespace Excelsior.Models.AccountsPayable.Transactions.GoodsReceivedVouchers
{
    partial class frmGRV
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
            this.goodsReceivedVoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ppTrxEntity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsReceivedVoucherBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.Size = new System.Drawing.Size(195, 20);
            // 
            // ppTrxEntity
            // 
            this.ppTrxEntity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.goodsReceivedVoucherBindingSource, "ID", true));
            this.ppTrxEntity.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppTrxEntity.Properties.Appearance.Options.UseFont = true;
            this.ppTrxEntity.Properties.NullText = "Select Supplier";
            this.ppTrxEntity.Size = new System.Drawing.Size(244, 22);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Size = new System.Drawing.Size(293, 34);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbon.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbon.SearchEditItem.EditWidth = 150;
            this.ribbon.SearchEditItem.Id = -5000;
            this.ribbon.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(1358, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // goodsReceivedVoucherBindingSource
            // 
            this.goodsReceivedVoucherBindingSource.DataSource = typeof(Excelsior.Models.AccountsPayable.Transactions.GoodsReceivedVouchers.GoodsReceivedVoucher);
            // 
            // frmGRV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 713);
            this.Name = "frmGRV";
            this.Text = "frmGRV";
            ((System.ComponentModel.ISupportInitialize)(this.ppTrxEntity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsReceivedVoucherBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource goodsReceivedVoucherBindingSource;
    }
}