using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Core.WaitForms
{
    public class cWaitBase: System.Windows.Forms.Form
    {
        public delegate void UIUpdateDelegate(string sText);
        
        public delegate void UIOnComplete(IAsyncResult res);
        public UIOnComplete OnComplete { get; set; }
        

        public cWaitBase(cWaitWindow parent)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //

            this._Parent = parent;

        }
        private WaitForms.cWaitWindow _Parent;
        public WaitForms.cWaitWindow WaitParent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
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

        public virtual void Complete(IAsyncResult results)
        {
            if (!this.IsDisposed)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new cWaitWindow.MethodInvoker<IAsyncResult>(this.Complete), results);
                    this.OnComplete(results);
                }
                else
                {
                    //	Capture the result
                    try
                    {
                        this._Result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);
                        this.OnComplete(results);
                        this.UseWaitCursor = false;
                    }
                    catch (Exception ex)
                    {
                        //	Grab the Exception for rethrowing after the WaitWindow has closed.
                        this._Error = ex;
                    }
                }
            }
        }

        internal void SetMessage(string message)
        {

            try
            {
                if (this.IsHandleCreated) this.Invoke(new UIUpdateDelegate(UIUpdate), new object[] { message });
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Events error: {ex.ToString()}");
            }

        }
        void UIUpdate(string sText)
        {
            //List<string> msg = this.memoEdit1.Lines.ToList<string>();
            //msg.Insert(0, sText);
            //this.memoEdit1.Lines = msg.ToArray();
        }

        internal void SetCaption(string Caption)
        {
        }

        internal void SetDescription(string Description)
        {
        }


        internal void Cancel()
        {
            this.Invoke(new System.Windows.Forms.MethodInvoker(this.Close), null);
        }
    }
}
