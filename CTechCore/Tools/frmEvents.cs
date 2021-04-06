using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace CTechCore.Tools
{
    public partial class frmEvents : Form
    {
        public delegate void UIUpdateDelegate(string sText);
        public frmEvents()
        {
            InitializeComponent();
        }

        public new string Text
        {
            get { return mmoMsg.Text; }
            set {
                try
                {
                    if(this.IsHandleCreated) this.Invoke(new UIUpdateDelegate(UIUpdate), new object[] { value });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Events error: {ex.ToString()}");
                }
            }
        }
        void UIUpdate(string sText)
        {
            mmoMsg.Text = DateTime.Now.ToString("yyyyMMdd HHmmss") + ": " + sText + "\r\n" + mmoMsg.Text;
        }

        private void frmEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void frmEvents_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            try
            {

                this.Text = MyApp.Name;
                toolStripStatusLabel1.Text = MyApp.Version;
                toolStripStatusLabel3.Text = $"Evolution: {MyApp.Evo.Server}  [{MyApp.Evo.Database}] & RollStock: { MyApp.CTech.Server}  [{MyApp.CTech.Database}]";
                toolStripStatusLabel4.Text = MyApp.ExePath;
            }
            catch (Exception ex)
            {
                mmoMsg.Text = ex.ToString() + "\r\n" + mmoMsg.Text;
            }
        }
    }
}
