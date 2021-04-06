using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Models.Document
{
    public partial class frmEntityBase : Form
    {
        UserControl uc = new UserControl();
        public Type BaseType { get; set; }
        public object EditValue { get; set; }

        public frmEntityBase(Models.Navigation.MenuItem mnu, object obj)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(mnu.UserControl)) return;
            Type tpe = Type.GetType($"{mnu.UserControl.Trim()}, {mnu.UserControl.Split('.')[0]}");
            uc = (UserControl)Activator.CreateInstance(tpe, new object[] { mnu, obj });

            System.Reflection.PropertyInfo propCode = (mnu.RuntimeObjectType).GetProperty("Code");
            System.Reflection.PropertyInfo propDescr = (mnu.RuntimeObjectType).GetProperty("Description");

            //var prop = obj.GetType().GetProperty("CreatedBy");
            //if (prop != null)
            //{
            //    if (prop.GetValue(obj) == null) prop.SetValue(obj, MyApp.Login.User);
            //}

            if (propCode != null && propDescr != null)
            {
                this.Text = $"{mnu.Text} - {Convert.ToString(propCode.GetValue(obj))}: {Convert.ToString(propDescr.GetValue(obj))}";
            }

            this.Controls.Add(uc);
            this.Controls.SetChildIndex(uc, 0);
            uc.Dock = DockStyle.Fill;
            this.BaseType = mnu.RuntimeObjectType;
            this.EditValue = obj;
        }
        
        
        private void frmEntityBase_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            try
            {

                List<string> results = new List<string>();
                var ValidateEntity = (this.BaseType).GetMethod("Validate");
                if (ValidateEntity != null)
                {
                    results = (List<string>)ValidateEntity.Invoke(this.EditValue, null);
                }

                if (results.Count == 0)
                {
                    System.Reflection.MethodInfo saveevent = this.EditValue.GetType().GetMethod("Save");
                    if (saveevent != null)
                    {
                        saveevent.Invoke(this.EditValue, null);
                        this.DialogResult = DialogResult.OK;
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                    MessageBox.Show($"Please correct the follwoing issues:\r\n\r\n {string.Join("\r\n", results)}", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }   
            catch (Exception ex)
            {
                string msg = $"Error attempting to save {this.BaseType.ToString()}: {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                string msg = $"Error attempting to save {this.BaseType.ToString()}: {ex.Message}.\r\n {ex.StackTrace}";
                if (ex.InnerException != null) msg += ex.InnerException.ToString();
                MessageBox.Show(msg);
                MyApp.Log.WriteEntry(msg, System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
