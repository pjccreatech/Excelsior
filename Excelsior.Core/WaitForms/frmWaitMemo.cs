﻿using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Core.WaitForms
{
    public partial class frmWaitMemo : Form
    {


        public frmWaitMemo(cWaitWindow parent)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            this._Parent = parent;
            btnOK.Visible = false;
            this.BackColor = Color.Fuchsia;
            this.TransparencyKey = Color.Fuchsia;

        }

        private cWaitWindow _Parent;
        private delegate T FunctionInvoker<T>();
        internal object _Result;
        internal Exception _Error;
        private IAsyncResult threadResult;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //   Create Delegate
            FunctionInvoker<object> threadController = new FunctionInvoker<object>(this.DoWork);

            //   Execute on secondary thread.
            this.threadResult = threadController.BeginInvoke(this.Complete, threadController);
            this.UseWaitCursor = true;
        }

        internal object DoWork()
        {
            //	Invoke the worker method and return any results.
            WaitWindowEventArgs e = new WaitWindowEventArgs(this._Parent, this._Parent._Args);
            if ((this._Parent._WorkerMethod != null))
            {
                this._Parent._WorkerMethod(this, e);
            }
            return e.Result;
        }

        private void Complete(IAsyncResult results)
        {
            if (!this.IsDisposed)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new cWaitWindow.MethodInvoker<IAsyncResult>(this.Complete), results);
                }
                else
                {
                    //	Capture the result
                    try
                    {
                        this._Result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);

                        this.progressPanel1.Caption = "Completed";
                        this.progressPanel1.Description = string.Empty;
                        //this.progressPanel1.
                        this.UseWaitCursor = false;
                    }
                    catch (Exception ex)
                    {
                        //	Grab the Exception for rethrowing after the WaitWindow has closed.
                        this._Error = ex;
                    }
                    btnOK.Visible = true;
                }
            }
        }

        //internal void SetMessage(string message)
        //{
        //    richEditControl1.Document.CaretPosition = richEditControl1.Document.Range.Start;

        //    richEditControl1.Document.InsertText(richEditControl1.Document.CaretPosition, message + "\r\n");
        //}
        internal void SetMessage(string message, System.Drawing.Font Font, System.Drawing.Color acolor)
        {

            var richText = new DevExpress.XtraRichEdit.RichEditDocumentServer();
            richText.Text = message;
            CharacterProperties cp = richText.Document.BeginUpdateCharacters(richText.Document.Range);
            cp.FontName = Font.Name;
            cp.FontSize = Font.Size;
            cp.Bold = Font.Bold;
            cp.Italic = Font.Italic;
            cp.Strikeout = Font.Strikeout ? StrikeoutType.Single : StrikeoutType.None;
            cp.Underline = Font.Underline ? UnderlineType.Single : UnderlineType.None;
            cp.ForeColor = acolor;
            richText.Document.EndUpdateCharacters(cp);
            richEditControl1.Document.CaretPosition = richEditControl1.Document.Range.Start;
            richEditControl1.Document.InsertDocumentContent(richEditControl1.Document.CaretPosition, richText.Document.Range);

        }





        internal void SetCaption(string Caption)
        {
            this.progressPanel1.Caption = Caption;
        }

        internal void SetDescription(string Description)
        {
            this.progressPanel1.Description = Description;
        }


        internal void Cancel()
        {
            this.Invoke(new MethodInvoker(this.Close), null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
