
namespace HertexCore.Models.Stock.Reports
{
    partial class rptStockRollBarcode
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptStockRollBarcode));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_TopCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_BottomCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_BottomMeterage = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbl_DyeLot = new DevExpress.XtraReports.UI.XRLabel();
            this.StockRollID = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.calcQtyUOM = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.lbl_TopCode});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 318.6828F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left;
            this.xrLabel2.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.BorderWidth = 2F;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockDescription]")});
            this.xrLabel2.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100.7533F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(949.9999F, 217.9295F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "S-Papyrus Limited Edition Wallpapers Lizzo";
            this.xrLabel2.TextTrimming = System.Drawing.StringTrimming.Word;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockRollID]")});
            this.xrLabel1.Font = new System.Drawing.Font("Free 3 of 9 Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(381.1458F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(562.9792F, 100.7533F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel1.TextFormatString = "*{0}*";
            // 
            // lbl_TopCode
            // 
            this.lbl_TopCode.CanGrow = false;
            this.lbl_TopCode.Dpi = 254F;
            this.lbl_TopCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockCode]")});
            this.lbl_TopCode.Font = new System.Drawing.Font("Bahnschrift Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TopCode.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_TopCode.Name = "lbl_TopCode";
            this.lbl_TopCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.lbl_TopCode.SizeF = new System.Drawing.SizeF(381.1458F, 98.17001F);
            this.lbl_TopCode.StylePriority.UseFont = false;
            this.lbl_TopCode.StylePriority.UsePadding = false;
            this.lbl_TopCode.StylePriority.UseTextAlignment = false;
            this.lbl_TopCode.Text = "CODE";
            this.lbl_TopCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.lbl_TopCode.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel1_BeforePrint);
            // 
            // lbl_BottomCode
            // 
            this.lbl_BottomCode.CanGrow = false;
            this.lbl_BottomCode.Dpi = 254F;
            this.lbl_BottomCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockRollID]")});
            this.lbl_BottomCode.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BottomCode.LocationFloat = new DevExpress.Utils.PointFloat(487.8333F, 49.60146F);
            this.lbl_BottomCode.Name = "lbl_BottomCode";
            this.lbl_BottomCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_BottomCode.SizeF = new System.Drawing.SizeF(462.1666F, 75.33009F);
            this.lbl_BottomCode.StylePriority.UseFont = false;
            this.lbl_BottomCode.StylePriority.UseTextAlignment = false;
            this.lbl_BottomCode.Text = "ID";
            this.lbl_BottomCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbl_BottomMeterage
            // 
            this.lbl_BottomMeterage.CanGrow = false;
            this.lbl_BottomMeterage.Dpi = 254F;
            this.lbl_BottomMeterage.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BottomMeterage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 49.60146F);
            this.lbl_BottomMeterage.Name = "lbl_BottomMeterage";
            this.lbl_BottomMeterage.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_BottomMeterage.SizeF = new System.Drawing.SizeF(436.5626F, 75.33012F);
            this.lbl_BottomMeterage.StylePriority.UseFont = false;
            this.lbl_BottomMeterage.StylePriority.UseTextAlignment = false;
            this.lbl_BottomMeterage.Text = "[Quantity][GRVType]";
            this.lbl_BottomMeterage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.lbl_BottomMeterage.TextFormatString = "{0}m";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_DyeLot,
            this.lbl_BottomCode,
            this.lbl_BottomMeterage});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 140.73F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbl_DyeLot
            // 
            this.lbl_DyeLot.CanGrow = false;
            this.lbl_DyeLot.Dpi = 254F;
            this.lbl_DyeLot.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DyeLot]")});
            this.lbl_DyeLot.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DyeLot.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_DyeLot.Name = "lbl_DyeLot";
            this.lbl_DyeLot.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_DyeLot.SizeF = new System.Drawing.SizeF(949.9999F, 60.875F);
            this.lbl_DyeLot.StylePriority.UseFont = false;
            this.lbl_DyeLot.StylePriority.UseTextAlignment = false;
            this.lbl_DyeLot.Text = "DyeLot";
            this.lbl_DyeLot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // StockRollID
            // 
            this.StockRollID.Name = "StockRollID";
            this.StockRollID.Type = typeof(int);
            this.StockRollID.ValueInfo = "2133550";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_HertexRollStk_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "StockRollID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?StockRollID", typeof(int));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = "\r\nSELECT * FROM StockRollHdr h WITH(NOLOCK) \r\nLEFT JOIN tStockGroupPreferences G " +
    "WITH(NOLOCK) ON G.StockGroupCode = h.itemgroup\r\nWHERE StockRollID = @StockRollID" +
    "";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // calcQtyUOM
            // 
            this.calcQtyUOM.DataMember = "Query";
            this.calcQtyUOM.Name = "calcQtyUOM";
            // 
            // rptStockRollBarcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calcQtyUOM});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(30, 20, 0, 0);
            this.PageHeight = 480;
            this.PageWidth = 1000;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PaperName = "Custom";
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.StockRollID});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbl_TopCode;
        private DevExpress.XtraReports.UI.XRLabel lbl_BottomMeterage;
        private DevExpress.XtraReports.UI.XRLabel lbl_BottomCode;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lbl_DyeLot;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.Parameters.Parameter StockRollID;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.CalculatedField calcQtyUOM;
    }
}
