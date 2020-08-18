using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Core.Tools.CustomControls
{

    public class cDynamicButton : DevExpress.XtraEditors.SimpleButton
    {

        public object EditValue { get; set; }
        private bool disabled;

        public bool Disabled
        {
            get { return !this.Enabled; }
            set
            {
                disabled = value;
                this.Enabled = !disabled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="SCaptio"></param>
        /// <param name="ShortKey"></param>
        /// <param name="Img"></param>
        /// <param name="eEvent"></param>
        public cDynamicButton(string sName, string sCaption, Keys ShortKey, System.Drawing.Image Img, EventHandler eEvent, DevExpress.XtraLayout.LayoutControlGroup layout, object ClickValue)
        {
            this.EditValue = ClickValue;
            this.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.AppearanceDisabled.Options.UseBackColor = true;
            this.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.Location = new System.Drawing.Point(3, 3);
            this.TabIndex = 18;
            this.Visible = true;
            this.Name = sName;
            this.Image = Img;
            if (ShortKey != Keys.None) this.ShortCutKey = ShortKey;
            this.Text = ShortKey == Keys.None ? $"{sCaption}" : $"{sCaption}\r\n({this.ShortCutKey})";
            //this.Size = new System.Drawing.Size(110, 79);
            Console.WriteLine(sName);
            //using (Graphics cg = this.CreateGraphics())
            //{
            //    SizeF size = cg.MeasureString(this.Text, this.Font);
            //    //this.Padding = ;
            //    int iWidth = (int)size.Width < 100 ? 100 : (int)size.Width + 10;
            //    this.Size = new System.Drawing.Size(iWidth, 50);
            //}
            this.Click += eEvent ;

            //if (parent == null) return;
            //parent.Add(this);

            //layout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { , new DevExpress.XtraLayout.LayoutControlItem() { } });
            layout.Add(new DevExpress.XtraLayout.LayoutControlItem() { Control = this });
            
        }

        public System.Windows.Forms.Keys ShortCutKey { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
