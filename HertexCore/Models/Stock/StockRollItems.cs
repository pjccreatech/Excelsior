
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Stock
{
	public class StockRollItems
	{
		public class StockRollItem
		{
			public StockRollItem()
			{

			}
			public StockRollItem(int id)
			{
				DataTable dt = new DataTable();
				MyApp.CTech.ExecSQL($"SELECT * FROM StockRollHdr WHERE StockRollID = {id}", ref dt);
				if (dt.Rows.Count > 0)
					Reload(dt.Rows[0]);
				else
					throw new Exception($"Unable to load information for roll ID: {id}");
			}

            private void Reload(DataRow dr)
			{           
				this.ID = (int)dr["StockRollID"];
				this.StockCodeID = (int)dr["StockLink"];
				this.StockCode = (string)dr["StockCode"];
				this.StockDescription = (string)dr["StockDescription"];
				this.SupplierID = (int)dr["SupplierID"];
				this.AuditNo = dr["AuditNo"].ToString();
				this.PONumber =(string)dr["PONumber"];
				this.GRVNumber = (string)dr["GRVNumber"];
				this.Barcode  = (string)dr["Barcode"];
				this.UnitCost = (decimal)dr["UnitCost"];
				this.OpenBal =  (double)dr["OpenBal"];
				this.OnHand = (double)dr["OnHand"];
				this.Adjustment =  (double)dr["Adjustment"];
				this.CutCount = (int)dr["CutCount"];
				this.DateUpdated = (DateTime)dr["DateUpdated"];
				this.OriginalRollID = (int)dr["OriginalRollID"];
				this.Quantity = (double)dr["Quantity"];
				this.Weight_gcm = (double)dr["Weight_gcm"];
				this.Location = (string)dr["Location"];
				this.Available = char.Parse( dr["Available"].ToString());
				this.ReservedReason = dr["ReservedReason"] == DBNull.Value ? string.Empty : (string)dr["ReservedReason"];
				this.ReservedDate = dr["ReservedDate"] == DBNull.Value ? CTechCore.Defaults.NullDate : (DateTime)dr["ReservedDate"];
				this.ReserveExpiryDate = dr["ReserveExpiryDate"] == DBNull.Value ? CTechCore.Defaults.NullDate : (DateTime)dr["ReserveExpiryDate"];
				this.Gross = (double)dr["Gross"];
				this.StockTakeQuantity = (int)dr["StockTakeQuantity"];
				this.StockTakeRollValue = (decimal)dr["StockTakeRollValue"];
				this.StockTakeStockValue = (decimal)dr["StockTakeStockValue"];
				this.DyeLot = (string)dr["DyeLot"];
				this.ApproOutLocation = dr["ApproOutLocation"] == DBNull.Value ? string.Empty :  (string)dr["ApproOutLocation"];
				this.Comments = dr["Comments"] == DBNull.Value ? string.Empty : (string)dr["Comments"];
				this.DateFinished = dr["DateFinished"] == DBNull.Value ? CTechCore.Defaults.NullDate: (DateTime)dr["DateFinished"];
				this.Damaged = (double)dr["Damaged"];
				this.TimeUpdated = dr["TimeUpdated"] == DBNull.Value ? string.Empty : (string)dr["TimeUpdated"];
				this.ExclFromOldStkRpt = DBNull.Value ==  dr["ExclFromOldStkRpt"] ? string.Empty : (string)dr["ExclFromOldStkRpt"];
				this.ClientDocHdrID = DBNull.Value == dr["ClientDocHdrID"] ? 0 : (int)dr["ClientDocHdrID"];
				this.DTdone = DBNull.Value == dr["DTdone"]  ? CTechCore.Defaults.NullDate :  (DateTime)dr["DTdone"];
				this.OLDStockTakeDate = DBNull.Value == dr["OLDStockTakeDate"] ? CTechCore.Defaults.NullDate : (DateTime)dr["OLDStockTakeDate"];
				this.GRVDate = DBNull.Value == dr["GRVDate"] ? CTechCore.Defaults.NullDate : (DateTime)dr["GRVDate"];
				this.GRVStockCode = dr["GRVStockCode"] == DBNull.Value ? string.Empty : (string)dr["GRVStockCode"];
				this.CommentDate = DBNull.Value == dr["CommentDate"] ? CTechCore.Defaults.NullDate : (DateTime)dr["CommentDate"];
				this.CommentUser = DBNull.Value == dr["CommentUser"] ? string.Empty : (string)dr["CommentUser"];
				this.SupplierDyeLot = DBNull.Value == dr["SupplierDyeLot"] ? string.Empty : (string)dr["SupplierDyeLot"];
				this.SOHsnap = DBNull.Value == dr["SOHsnap"] ? 0 : (double)dr["SOHsnap"];
				this.SOHsnapDate = DBNull.Value == dr["SOHsnapDate"] ? CTechCore.Defaults.NullDate : (DateTime)dr["SOHsnapDate"];
				this.InWIP = DBNull.Value == dr["InWIP"] ? false: (bool)dr["InWIP"];
				this.Measured = DBNull.Value == dr["Measured"] ? 'N' : char.Parse(dr["Measured"].ToString());
				this.IsEcommerce = DBNull.Value == dr["IsEcommerce"] ? 'N' : char.Parse((dr["IsEcommerce"].ToString() == string.Empty ? "N" : dr["IsEcommerce"].ToString()));
				this.X3_Lot = DBNull.Value == dr["X3_Lot"] ? string.Empty : (string)dr["X3_Lot"];
				this.OnReserve = DBNull.Value == dr["OnReserve"] ? 0 : (double)dr["OnReserve"];
				this.ItemGroup = DBNull.Value == dr["ItemGroup"] ? string.Empty : (string)dr["ItemGroup"];
			}

			public StockRollItem(DataRow dr)
			{
				Reload(dr);
			}


			public int ID { get; set; }
			public string AuditNo { get; set; } = string.Empty;
			public int StockCodeID { get; set; }
			public string StockCode { get; set; } = string.Empty;
			public string StockDescription { get; set; } = string.Empty;
			public int SupplierID { get; set; }
			public string PONumber { get; set; } = string.Empty;
			public string GRVNumber { get; set; } = string.Empty;
			public string Barcode { get; private set; } = string.Empty;
			public decimal UnitCost { get; set; }
			public double OnHand { get; set; }
            public double Adjustment { get; private set; }
            public int CutCount { get; private set; }
            public DateTime DateUpdated { get; private set; }
            public int OriginalRollID { get; private set; }
            public double Quantity { get; set; }
            public double Weight_gcm { get; private set; }
            public double OpenBal { get; set; }
			public string Location { get; set; } = string.Empty;
			public char Available { get; set; }
            public string ReservedReason { get; private set; } = string.Empty;
			public DateTime ReservedDate { get; private set; }
            public DateTime ReserveExpiryDate { get; private set; }
            public double Gross { get; private set; }
            public int StockTakeQuantity { get; private set; }
            public decimal StockTakeRollValue { get; private set; }
            public decimal StockTakeStockValue { get; private set; }
            public string DyeLot { get; set; } = string.Empty;
			public string ApproOutLocation { get; private set; } = string.Empty;
			public string Comments { get; private set; } = string.Empty;
			public DateTime DateFinished { get; private set; }
            public double Damaged { get; private set; }
            public string TimeUpdated { get; private set; } = string.Empty;
			public string ExclFromOldStkRpt { get; private set; } = string.Empty;
			public int ClientDocHdrID { get; private set; }
            public DateTime DTdone { get; private set; }
            public DateTime OLDStockTakeDate { get; private set; }
            public DateTime GRVDate { get; private set; }
            public string GRVStockCode { get; private set; } = string.Empty;
			public DateTime CommentDate { get; private set; }
            public string CommentUser { get; private set; } = string.Empty;
			public string SupplierDyeLot { get; set; } = string.Empty;
			public double SOHsnap { get; private set; }
			public DateTime SOHsnapDate { get; private set; }
            public bool InWIP { get; private set; }
            public char Measured { get; private set; }
            public char IsEcommerce { get; private set; }
            public string X3_Lot { get; private set; } = string.Empty;
			public double OnReserve { get; private set; }

            private string itemgroup; 
			public string ItemGroup
			{
				get { return itemgroup; }
				set
				{
					itemgroup = value;
					DataTable dt = new DataTable();
					MyApp.CTech.ExecSQL($" SELECT * FROM tStockGroupPreferences WITH(NOLOCK) WHERE StockGroupCode = '{itemgroup}'", ref dt);
					if (dt.Rows.Count > 0)
						this.GRVType = (CTechCore.Enums.StockItem.StockRollItem.GRVType)Convert.ToChar(dt.AsEnumerable().FirstOrDefault().Field<string>("GRVType"));
					else
						this.GRVType = CTechCore.Enums.StockItem.StockRollItem.GRVType.Each;
				}
			}
			public CTechCore.Enums.StockItem.StockRollItem.GRVType GRVType { get; private set; }

			public void Save()
			{
				StockRollItems.Save(new List<StockRollItem>() { this });
			}
		}
		public static DataSet Save(List<StockRollItem> rolls)
		{
			try
			{
				int i = 0;
				List<Con.Params> parms = new List<CTechCore.Con.Params>();
				string sSQL = string.Empty;
				foreach (StockRollItem roll in rolls)
				{
					if (roll.OpenBal <= 0) continue;
					if (roll.GRVType == CTechCore.Enums.StockItem.StockRollItem.GRVType.Each)
					{
						for (int ii = 0; ii < roll.OpenBal; ii++)
						{
							sSQL += $"\rEXEC sp_XR_StockRoll_InsUpd @StockRollID{i}, @AuditNo{i}, @StockCodeID{i}, @SupplierID{i}, @PONumber{i}, @GRVNumber{i}, @UnitCost{i}, @OpenBal{i}, @Location{i}, @Available{i}, @DyeLot{i}, @SupplierDyeLot{i}, @ItemGroup{i}";
							parms.AddRange(new List<CTechCore.Con.Params>()
							{
								new CTechCore.Con.Params() { Name = $"StockRollID{i}", Value = roll.ID },
								new CTechCore.Con.Params() { Name = $"AuditNo{i}", Value = roll.AuditNo },
								new CTechCore.Con.Params() { Name = $"StockCodeID{i}", Value = roll.StockCodeID },
								new CTechCore.Con.Params() { Name = $"SupplierID{i}", Value = roll.SupplierID },
								new CTechCore.Con.Params() { Name = $"PONumber{i}", Value = roll.PONumber },
								new CTechCore.Con.Params() { Name = $"GRVNumber{i}", Value = roll.GRVNumber },
								new CTechCore.Con.Params() { Name = $"UnitCost{i}", Value = roll.UnitCost },
								new CTechCore.Con.Params() { Name = $"OpenBal{i}", Value = 1 },
								new CTechCore.Con.Params() { Name = $"Location{i}", Value = roll.Location },
								new CTechCore.Con.Params() { Name = $"Available{i}", Value = roll.Available },
								new CTechCore.Con.Params() { Name = $"DyeLot{i}", Value = roll.DyeLot },
								new CTechCore.Con.Params() { Name = $"SupplierDyeLot{i}", Value = roll.SupplierDyeLot },
								new CTechCore.Con.Params() { Name = $"ItemGroup{i}", Value = roll.ItemGroup }
							});
							i++;
						}
					}
					else if (roll.GRVType == CTechCore.Enums.StockItem.StockRollItem.GRVType.Length)
					{
						sSQL += $"\rEXEC sp_XR_StockRoll_InsUpd @StockRollID{i}, @AuditNo{i}, @StockCodeID{i}, @SupplierID{i}, @PONumber{i}, @GRVNumber{i}, @UnitCost{i}, @OpenBal{i}, @Location{i}, @Available{i}, @DyeLot{i}, @SupplierDyeLot{i}, @ItemGroup{i}";
						parms.AddRange(new List<CTechCore.Con.Params>()
						{
							new CTechCore.Con.Params() { Name = $"StockRollID{i}", Value = roll.ID },
							new CTechCore.Con.Params() { Name = $"AuditNo{i}", Value = roll.AuditNo },
							new CTechCore.Con.Params() { Name = $"StockCodeID{i}", Value = roll.StockCodeID },
							new CTechCore.Con.Params() { Name = $"SupplierID{i}", Value = roll.SupplierID },
							new CTechCore.Con.Params() { Name = $"PONumber{i}", Value = roll.PONumber },
							new CTechCore.Con.Params() { Name = $"GRVNumber{i}", Value = roll.GRVNumber },
							new CTechCore.Con.Params() { Name = $"UnitCost{i}", Value = roll.UnitCost },
							new CTechCore.Con.Params() { Name = $"OpenBal{i}", Value = roll.OpenBal },
							new CTechCore.Con.Params() { Name = $"Location{i}", Value = roll.Location },
							new CTechCore.Con.Params() { Name = $"Available{i}", Value = roll.Available },
							new CTechCore.Con.Params() { Name = $"DyeLot{i}", Value = roll.DyeLot },
							new CTechCore.Con.Params() { Name = $"SupplierDyeLot{i}", Value = roll.SupplierDyeLot },
							new CTechCore.Con.Params() { Name = $"ItemGroup{i}", Value = roll.ItemGroup }
						});
						i++;
					}
				}


				DataSet ds = new DataSet();
				MyApp.CTech.ExecSQL(sSQL, ref ds, parms);
				return ds;
			}
			catch (Exception ex)
			{
				string msg = $"Error saving stock roll header: {ex.Message}.\r\n {ex.StackTrace}";
				if (ex.InnerException != null) msg += ex.InnerException.ToString();
				MessageBox.Show(msg);
				MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
				return null;
			}

		}
		public static void PrintBarcodes(List<int> rolls)
		{
			DevExpress.XtraReports.UI.XtraReport rpt = new DevExpress.XtraReports.UI.XtraReport();
			rpt.CreateDocument();
			rpt.PrintingSystem.ContinuousPageNumbering = false;
			foreach (int r in rolls)
			{
				Models.Stock.Reports.rptStockRollBarcode frm = new Models.Stock.Reports.rptStockRollBarcode();
				frm.Parameters["StockRollID"].Value = r;
				frm.CreateDocument();
				rpt.Pages.AddRange(frm.Pages);
			}
			DevExpress.XtraReports.UI.ReportPrintTool print = new DevExpress.XtraReports.UI.ReportPrintTool(rpt);
			print.ShowPreview();
		}
		public static void AdjustRollLength(object sender, CTechCore.WaitForms.WaitWindowEventArgs e)
		{
			StockRollItem roll = (StockRollItem)e.Arguments[0];
			double AdjustmentQty = (double)e.Arguments[1];
			string Reference = (string)e.Arguments[2];
			string Reference2 = (string)e.Arguments[3];
			string Description = (string)e.Arguments[4];

			try
			{
				MyApp.PastelHlpr.CreateCommonDBConnection("uid=" + MyApp.Common.Username + ";pwd=" + MyApp.Common.Password + ";Initial Catalog=" + MyApp.Common.Database + ";server=" + MyApp.Common.Server + ";Persist Security Info=True;");
				MyApp.PastelHlpr.SetLicense(MyApp.serialNumber, MyApp.AuthorizationKey);
				MyApp.PastelHlpr.CreateConnection("server=" + MyApp.Evo.Server + ";initial catalog=" + MyApp.Evo.Database + ";User ID=" + MyApp.Evo.Username + ";Password=" + MyApp.Evo.Password + ";Persist Security Info=True");


				Pastel.Evolution.InventoryOperation operation = AdjustmentQty < 0 ? Pastel.Evolution.InventoryOperation.Decrease : Pastel.Evolution.InventoryOperation.Increase;
				//Create a instance of the InventoryTransaction class
				Pastel.Evolution.InventoryTransaction ItemInc = new Pastel.Evolution.InventoryTransaction();
				ItemInc.TransactionCode = new Pastel.Evolution.TransactionCode(Pastel.Evolution.Module.Inventory, "ADJ");// specify a inventory transaction type generally this will be ADJ
				ItemInc.InventoryItem = new Pastel.Evolution.InventoryItem(roll.StockCodeID);
				ItemInc.WarehouseID = 3;
				ItemInc.Operation = operation;//Select the necessary enumerator increase , decrease or cost adjustment
				ItemInc.Quantity = Math.Abs(AdjustmentQty);
				ItemInc.Reference = Reference;
				ItemInc.Reference2 = Reference2;
				ItemInc.Description = Description;
				if (ItemInc.Post())
				{
					e.Window.Message = $"Evolution adjustment successful, audit number {ItemInc.Audit}";
					DataTable dt = new DataTable();
					List<Con.Params> parms = new List<CTechCore.Con.Params>()
					{
						new CTechCore.Con.Params() { Name = "stockRollID", Value = roll.ID},
						new CTechCore.Con.Params() { Name = "newOnHandValue", Value = roll.OnHand + (AdjustmentQty)},
						new CTechCore.Con.Params() { Name = "adjustment", Value = AdjustmentQty},
						new CTechCore.Con.Params() { Name = "staffID", Value = MyApp.Login.User.Username},
						new CTechCore.Con.Params() { Name = "stkAdjDescription", Value = Description},
						new CTechCore.Con.Params() { Name = "originalLength", Value = roll.OnHand},
						new CTechCore.Con.Params() { Name = "AuditNumber", Value = ItemInc.Audit},
					};
					MyApp.CTech.ExecSQL("EXEC sp_XR_RollLengthAdjust @stockRollID, @newOnHandValue, @adjustment, @staffID, @stkAdjDescription, @originalLength, @AuditNumber", ref dt, parms);
					if (dt.Rows.Count > 0)
					{
						e.Window.Message = $"Roll {roll.ID} successfully adjusted.";
						e.Result = dt.Rows[0];
					}
					else
						throw new Exception("Failed to adjust roll stock details");
				}
			}
			catch (Exception ex)
			{
				e.Window.ProcessFailure = true;
				e.Window.Caption = "Error";
				e.Window.ForeColor = System.Drawing.Color.Red;
				string msg = $"Error attempting to adjust roll ID {roll.ID}: {ex.Message}.\r\n {ex.StackTrace}";
				e.Window.Message = msg;
				if (ex.InnerException != null) msg += ex.InnerException.ToString();
				MessageBox.Show(msg);
				MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
				e.Window.ForeColor = System.Drawing.Color.Black;
			}
		}

		public static DataRow AdjustRollLength
			(
				StockRollItem roll,
				double AdjustmentQty,
				string Reference,
				string Reference2,
				string Description
			)
		{
			return (DataRow)CTechCore.WaitForms.cWaitWindow.Show(AdjustRollLength,"xxxxxx", new object[] { roll, AdjustmentQty, Reference, Reference2, Description });
		}
	}
}
