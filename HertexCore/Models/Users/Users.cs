using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HertexCore.Models.Users
{
    public class User: INotifyPropertyChanged
    {
        public DataTable Permissions { get; private set; }
        public int ID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Location { get; set; }
        public bool IsManager { get; set; }
        public string DefaultBin { get; set; }
        public string Dept { get; set; }
        public string RepCode { get; set; }
        public bool IsShowroom { get; set; }
        public bool RepHasCustomers { get; set; }
        public int SecurityLevel { get; set; }
        public int DeptLevel { get; set; }
        public string CRMType { get; set; }
        public bool CanInvoice { get; set; }
        public bool PPProcessing { get; set; }
        public bool KPAMain { get; set; }
        public bool SalesRepBreakDownMain { get; set; }
        public bool ProductSplitMain { get; set; }
        public int POSlevel { get; set; }
        public bool ManMaintainBOM { get; set; }
        public bool ManRequest { get; set; }
        public bool ManWIP { get; set; }
        public bool ManAssemble { get; set; }
        public bool ShowRoomSales { get; set; }
        public bool CostPriceAccess { get; set; }
        public bool SupplierAccess { get; set; }
        public bool BudgetAccess { get; set; }
        public bool ClearReserves { get; set; }
        public string BudgetReportAccessGrp { get; set; }

        public  bool Save()
        {
            try
            {

                List<Con.Params> parms = new List<CTechCore.Con.Params>();
                string sSQL = string.Empty;
                DataTable dt = new DataTable();
                parms.AddRange(new List<Con.Params>()
                {
                    new CTechCore.Con.Params() { Name = $"IDX", Value = this.ID },
                    new CTechCore.Con.Params() { Name = $"UserID", Value = this.Username },
                    new CTechCore.Con.Params() { Name = $"Password", Value = this.Password },
                    new CTechCore.Con.Params() { Name = $"IsActive", Value = this.Active },
                    new CTechCore.Con.Params() { Name = $"SecurityLevel", Value = this.SecurityLevel },
                    new CTechCore.Con.Params() { Name = $"Location", Value = this.Location },
                    new CTechCore.Con.Params() { Name = $"DefaultBin", Value = this.DefaultBin },
                    new CTechCore.Con.Params() { Name = $"Dept", Value = this.Dept },
                    new CTechCore.Con.Params() { Name = $"DeptLevel", Value = this.DeptLevel },                      
                    new CTechCore.Con.Params() { Name = $"RepCode", Value = this.RepCode },
                    new CTechCore.Con.Params() { Name = $"IsShowroom", Value = this.IsShowroom },
                    new CTechCore.Con.Params() { Name = $"CRMType", Value = this.CRMType },             
                    new CTechCore.Con.Params() { Name = $"RepHasCustomers", Value = this.RepHasCustomers },
                    new CTechCore.Con.Params() { Name = $"CanInvoice", Value = this.CanInvoice },
                    new CTechCore.Con.Params() { Name = $"PPProcessing", Value = this.PPProcessing },
                    new CTechCore.Con.Params() { Name = $"KPAMain", Value = this.KPAMain },
                    new CTechCore.Con.Params() { Name = $"SalesRepBreakDownMain", Value = this.SalesRepBreakDownMain },
                    new CTechCore.Con.Params() { Name = $"ProductSplitMain", Value = this.ProductSplitMain },
                    new CTechCore.Con.Params() { Name = $"POSlevel", Value = this.POSlevel },
                    new CTechCore.Con.Params() { Name = $"uManMaintainBOM", Value = this.ManMaintainBOM },
                    new CTechCore.Con.Params() { Name = $"uManRequest", Value = this.ManRequest },
                    new CTechCore.Con.Params() { Name = $"uManWIP", Value = this.ManWIP },
                    new CTechCore.Con.Params() { Name = $"uManAssemble", Value = this.ManAssemble },
                    new CTechCore.Con.Params() { Name = $"ShowRoomSales", Value = this.ShowRoomSales },
                    new CTechCore.Con.Params() { Name = $"bCostPriceAccess", Value = this.CostPriceAccess },
                    new CTechCore.Con.Params() { Name = $"bSupplierAccess", Value = this.SupplierAccess },
                    new CTechCore.Con.Params() { Name = $"bBudgetAccess", Value = this.BudgetAccess },
                    new CTechCore.Con.Params() { Name = $"bClearReserves", Value = this.ClearReserves },
                    new CTechCore.Con.Params() { Name = $"BudgetReportAccessGrp", Value = this.BudgetReportAccessGrp },
                });
                sSQL = $"\rEXEC sp_XR_User_InsUpd @IDX, @UserID, @Password, @IsActive, @SecurityLevel, @Location, @DefaultBin, @Dept, @DeptLevel,";
			    sSQL += " @RepCode, @IsShowroom, @CRMType, @RepHasCustomers, @CanInvoice, @PPProcessing, @KPAMain, @SalesRepBreakDownMain,";
                sSQL += " @ProductSplitMain, @POSlevel, @uManMaintainBOM, @uManRequest, @uManWIP,";
                sSQL += " @uManAssemble, @ShowRoomSales, @bCostPriceAccess, @bSupplierAccess, @bBudgetAccess, @bClearReserves, @BudgetReportAccessGrp";
                MyApp.CTech.ExecSQL(sSQL, ref dt, parms);

                if (dt.Rows.Count > 0)
                {
                    sSQL = string.Empty;
                    sSQL += $"DELETE FROM XR_UserPermissions WHERE UserID = {this.ID} ";
                    parms.Clear();
                    int i = 0;
                    foreach (var module in this.Modules)
                    {
                        parms.AddRange(new List<Con.Params>()
                            {
                                new CTechCore.Con.Params() { Name = $"UserID{i}", Value = this.ID },
                                new CTechCore.Con.Params() { Name = $"ModuleName{i}", Value = module.Key.Name },
                                new CTechCore.Con.Params() { Name = $"PermissionKey{i}", Value = "Access" },
                                new CTechCore.Con.Params() { Name = $"PermissionValue{i}", Value = "1" },
                                new CTechCore.Con.Params() { Name = $"IsActive{i}", Value = "1" }
                            });
                        sSQL += $"\rEXEC sp_XR_UserPermisssion_InsUpd @UserID{i}, @ModuleName{i}, @PermissionKey{i}, @PermissionValue{i}, @IsActive{i}";
                        i++;
                        foreach (Permission permission in module.Value)
                        {
                            parms.AddRange(new List<Con.Params>()
                            {
                                new CTechCore.Con.Params() { Name = $"UserID{i}", Value = this.ID },
                                new CTechCore.Con.Params() { Name = $"ModuleName{i}", Value = module.Key.Name },
                                new CTechCore.Con.Params() { Name = $"PermissionKey{i}", Value = permission.PermissionKey },
                                new CTechCore.Con.Params() { Name = $"PermissionValue{i}", Value = permission.PermissionValue },
                                new CTechCore.Con.Params() { Name = $"IsActive{i}", Value = "1" }
                            });
                            sSQL += $"\rEXEC sp_XR_UserPermisssion_InsUpd @UserID{i}, @ModuleName{i}, @PermissionKey{i}, @PermissionValue{i}, @IsActive{i}";
                            i++;
                        }
                    }

                    MyApp.CTech.ExecSQL(sSQL, ref dt, parms);
                    return true;
                }
                else
                    throw new Exception("Error saving data");

            }
            catch (Exception ex)
            {
                string msg = $"Error saving user details: {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public List<KeyValuePair<Module, Permissions>> Modules { get; set; } = new List<KeyValuePair<Module, Permissions>>();

        public User(int id)
        {
            Reload(HertexData.Users.GetUserInfo(id).Table);


        }

        private void Reload(DataTable dt)
        {
            try
            {
                this.ID = dt.Rows[0].Field<int>("AutoIndex");
                this.Username = dt.Rows[0].Field<string>("UserID");
                this.Password = dt.Rows[0].Field<string>("Password");
                this.Active = dt.Rows[0].Field<bool>("IsActive");
                this.Location = dt.Rows[0]["Location"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("Location");
                this.DefaultBin = dt.Rows[0]["DefaultBin"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("DefaultBin");
                this.Dept = dt.Rows[0]["Dept"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("Dept");
                this.RepCode = dt.Rows[0]["RepCode"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("RepCode");
                this.IsShowroom = dt.Rows[0]["IsShowroom"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("IsShowroom");
                this.RepHasCustomers = dt.Rows[0]["RepHasCustomers"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("RepHasCustomers");
                this.SecurityLevel = dt.Rows[0]["SecurityLevel"] == DBNull.Value ? 9 : dt.Rows[0].Field<int>("SecurityLevel");

                this.DeptLevel = dt.Rows[0]["DeptLevel"] == DBNull.Value ? 9 : dt.Rows[0].Field<int>("DeptLevel");
                this.CRMType = dt.Rows[0]["CRMType"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("CRMType");
                this.CanInvoice = dt.Rows[0]["CanInvoice"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("CanInvoice");
                this.PPProcessing = dt.Rows[0]["PPProcessing"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("PPProcessing");
                this.KPAMain = dt.Rows[0]["KPAMain"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("KPAMain");
                this.SalesRepBreakDownMain = dt.Rows[0]["SalesRepBreakDownMain"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("SalesRepBreakDownMain");
                this.ProductSplitMain = dt.Rows[0]["ProductSplitMain"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("ProductSplitMain");
                this.POSlevel = dt.Rows[0]["POSlevel"] == DBNull.Value ? 0 : dt.Rows[0].Field<int>("POSlevel");
                this.ManMaintainBOM = dt.Rows[0]["uManMaintainBOM"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("uManMaintainBOM");
                this.ManRequest = dt.Rows[0]["uManRequest"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("uManRequest");
                this.ManWIP = dt.Rows[0]["uManWIP"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("uManWIP");
                this.ManAssemble = dt.Rows[0]["uManAssemble"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("uManAssemble");
                this.ShowRoomSales = dt.Rows[0]["ShowRoomSales"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("ShowRoomSales");
                this.CostPriceAccess = dt.Rows[0]["bCostPriceAccess"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("bCostPriceAccess");
                this.SupplierAccess = dt.Rows[0]["bSupplierAccess"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("bSupplierAccess");
                this.BudgetAccess = dt.Rows[0]["bBudgetAccess"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("bBudgetAccess");
                this.ClearReserves = dt.Rows[0]["bClearReserves"] == DBNull.Value ? false : dt.Rows[0].Field<bool>("bClearReserves");
                this.BudgetReportAccessGrp = dt.Rows[0]["BudgetReportAccessGrp"] == DBNull.Value ? string.Empty : dt.Rows[0].Field<string>("BudgetReportAccessGrp");


                foreach (DataRow dr in dt.Select("PermissionKey = 'Access'"))
                {
                    KeyValuePair<Module, Permissions> usermodulecontext = this.Modules.Find(m => m.Key.Name == (string)dr["ModuleName"]);
                    Permissions XR_permissions = new Permissions();
                    if (usermodulecontext.Key == null)
                    {
                        Module module = new Modules((string)dr["ModuleName"]);
                        dt.Select($"PermissionKey <> 'Access' And ModuleName = '{module.Name}'").ToList().ForEach(r => XR_permissions.Add(new Permission(r)));
                        this.Modules.Add(new KeyValuePair<Module, Permissions>(module, XR_permissions));
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error loading user information : {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }



        }

        private void Modules_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged("Modules");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class LoginState : INotifyPropertyChanged
    {
        public System.Windows.Forms.Form frmLogin;

        public User User { get; set; }

        public LoginState(HertexCore.Module module, string Uname, string Pword)
        {
            List<Con.Params> parms = new List<Con.Params>()
            {
                new Con.Params() {Name = "ModuleIDX", Value = module.ID},
                new Con.Params() {Name = "username", Value = Uname},
                new Con.Params() {Name = "password", Value = Pword}
            };

            DataTable dtUsers = new DataTable();
            if (MyApp.CTech.ExecSQL("EXEC dbo.sp_XR_UserLogin @ModuleIDX, @username, @password", ref dtUsers, parms))
            {
                if (dtUsers.Rows.Count > 0)
                    this.User = new User((int)dtUsers.Rows[0]["AutoIndex"]);
                else
                {
                    MessageBox.Show("Username or password were not recognised locally!");
                }
            }
        }

        public void LogOut()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
    public enum PasswordOverrrideType
    {
        BigAdjustment = 0,
        BulkAdjust = 1,
        BulkBinTransfer = 2,
        BulkReserve = 3,
        CutNewOrder = 4,
        ExportOrder = 5,
        GRVOverride = 6,
        LongReserve = 7,
        NewRoll = 8,
        PIAReserve = 9,
        PrintBarcode = 10,
        ShortEnd = 11,
        Unreserve = 12
    }
}
