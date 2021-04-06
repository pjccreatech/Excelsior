namespace HertexCore.Models.Stock.Reports
{
    public partial class rptStockRollBarcode : DevExpress.XtraReports.UI.XtraReport
    {


        public rptStockRollBarcode()
        {
            InitializeComponent();
            sqlDataSource1.Connection.ConnectionString = CTechCore.MyApp.CTech.ConnectionString;
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {



        }
    }
}
