using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTechCore.Tools
{
    public partial class ucDropdownButtons : UserControl
    {
        public Dictionary<int, string> ItemList { get; set; }
        private object val;
        public object EditValue
        {
            get { return val; }
            set
            {
                val = value;
                if( val != null)btnMain.Text = ((KeyValuePair<int, string>)val).Value;
            }
        }



        public ucDropdownButtons()
        {
            InitializeComponent();
        }

        private Point GetRelativeLocation(object obj)
        {
            Form frm = (Form)obj;
            frm.Size = new Size(475, 200);


            int x = PointToScreen(this.Location).X;
            int y = PointToScreen(this.Location).Y + this.Height ;

            if ((x + frm.Size.Width > Screen.FromControl(this).Bounds.Width) && (y + frm.Size.Height > Screen.FromControl(this).Bounds.Height))
            {
                x = (Screen.GetWorkingArea(this)).Right - frm.Size.Width;
                y = PointToScreen(this.Location).Y - frm.Size.Height;
            }
            else if ((Screen.FromControl(this).Bounds.Width + x < 0) && (y + frm.Size.Height > Screen.FromControl(this).Bounds.Height))
            {
                x = 0 - Screen.FromControl(this).Bounds.Width;
                y = PointToScreen(this.Location).Y - frm.Size.Height;
            }
            else if ((x + frm.Size.Width) > (Screen.GetWorkingArea(this)).Right)
            {
                x = (Screen.GetWorkingArea(this)).Right- frm.Size.Width;
            }
            else if ((Screen.FromControl(this).Bounds.Width + x < 0))
            {
                x = 0-Screen.FromControl(this).Bounds.Width;
            }
            else if (y + frm.Size.Height > Screen.FromControl(this).Bounds.Height)
            {
                y = PointToScreen(this.Location).Y - frm.Size.Height;
            }
            //btnMain.Text = $"x:{x}/{Screen.FromControl(this).WorkingArea.Width}, y:{y}/{Screen.FromControl(this).WorkingArea.Height}";
            return  new Point( x, y);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            try
            {
                CTechCore.Tools.frmBorderlessForm frm = new CTechCore.Tools.frmBorderlessForm();
                //frm.TopLevel = false;
                //frm.Parent = this;
                frm.StartPosition = FormStartPosition.Manual;
                frm.Padding = new Padding(2);
                frm.Deactivate += delegate (object obj, EventArgs arg)
                {
                    ((Form)obj).FindForm().Close();
                };
                frm.Location = GetRelativeLocation(frm);
                FlowLayoutPanel flw = new FlowLayoutPanel();
                flw.Padding = new Padding(0);
                flw.Dock = DockStyle.Fill;
                flw.FlowDirection = FlowDirection.LeftToRight;
                flw.AutoScroll = true;
                if (ItemList != null)
                {
                    foreach (var item in this.ItemList)
                    {
                        DevExpress.XtraEditors.SimpleButton btn = new DevExpress.XtraEditors.SimpleButton();
                        btn.Appearance.BackColor = btnMain.Appearance.BackColor;
                        btn.Appearance.BackColor2 = btnMain.Appearance.BackColor2;
                        btn.Appearance.Font = btnMain.Appearance.Font;
                        btn.Appearance.ForeColor = btnMain.Appearance.ForeColor;
                        btn.Appearance.GradientMode = btnMain.Appearance.GradientMode;
                        btn.Appearance.Options.UseBackColor = btnMain.Appearance.Options.UseBackColor;
                        btn.Appearance.Options.UseFont = btnMain.Appearance.Options.UseFont;
                        btn.Appearance.Options.UseForeColor = btnMain.Appearance.Options.UseForeColor;
                        btn.AppearanceDisabled.BackColor = btnMain.AppearanceDisabled.BackColor;
                        btn.AppearanceDisabled.BackColor2 = btnMain.AppearanceDisabled.BackColor2;
                        btn.AppearanceDisabled.Options.UseBackColor = btnMain.AppearanceDisabled.Options.UseBackColor;
                        btn.AppearanceHovered.BackColor = btnMain.AppearanceHovered.BackColor;
                        btn.AppearanceHovered.BackColor2 = btnMain.AppearanceHovered.BackColor2;
                        btn.AppearanceHovered.Options.UseBackColor = btnMain.AppearanceHovered.Options.UseBackColor;
                        btn.ButtonStyle = btnMain.ButtonStyle;
                        btn.ImageOptions.AllowGlyphSkinning = btnMain.ImageOptions.AllowGlyphSkinning;
                        btn.ImageOptions.ImageToTextAlignment = btnMain.ImageOptions.ImageToTextAlignment;
                        btn.Size = new System.Drawing.Size(150, 80);
                        btn.Name = item.Key.ToString();
                        btn.Text = item.Value;
                        btn.Click += delegate (object btnSent, EventArgs arg)
                        {
                            this.EditValue = item;
                            ((DevExpress.XtraEditors.SimpleButton)btnSent).FindForm().Close();
                            this.FindForm().SelectNextControl(this, true, false, true, false);
                        };
                        flw.Controls.Add(btn);
                    }
                }
                frm.Controls.Add(flw);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading paynet types: " + ex.ToString());
            }

        }

        private void ucDropdownButtons_Load(object sender, EventArgs e)
        {
        }
    }
}
