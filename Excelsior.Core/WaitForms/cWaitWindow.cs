using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsior.Core.WaitForms
{
    /// <summary>
    /// Displays a window telling the user to wait while a process is executing.
    /// </summary>
    public sealed class cWaitWindow
    {

        /// <summary>
        /// Shows a wait window with the text 'Please wait...' while executing the passed method.
        /// </summary>
        /// <param name = "workerMethod" > Pointer to the method to execute while displaying the wait window.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<WaitWindowEventArgs> workerMethod)
        {
            return cWaitWindow.Show(workerMethod, null);
        }

        /// <summary>
        /// Shows a wait window with the specified text while executing the passed method.
        /// </summary>
        /// <param name="workerMethod">Pointer to the method to execute while displaying the wait window.</param>
        /// <param name="message">The text to display.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<WaitWindowEventArgs> workerMethod, string message)
        {
            cWaitWindow instance = new cWaitWindow();
            System.Drawing.Font font = new System.Drawing.Font("", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            return instance.Show(workerMethod, message, font, new System.Drawing.Color(), new List<object>());
        }

        /// <summary>
        /// Shows a wait window with the specified text while executing the passed method.
        /// </summary>
        /// <param name="workerMethod">Pointer to the method to execute while displaying the wait window.</param>
        /// <param name="message">The text to display.</param>
        /// <param name="args">Arguments to pass to the worker method.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<WaitWindowEventArgs> workerMethod, string message, params object[] args)
        {
            List<object> arguments = new List<object>();
            arguments.AddRange(args);

            cWaitWindow instance = new cWaitWindow();

            System.Drawing.Font font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            return instance.Show(workerMethod, message, font, new System.Drawing.Color(), arguments);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="workerMethod"></param>
        /// <param name="message"></param>
        /// <param name="font"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object Show(EventHandler<WaitWindowEventArgs> workerMethod, string message, System.Drawing.Font font, params object[] args)
        {
            List<object> arguments = new List<object>();
            arguments.AddRange(args);

            cWaitWindow instance = new cWaitWindow();

            System.Drawing.Color color = new System.Drawing.Color();
            return instance.Show(workerMethod, message, font, color, arguments);
        }

        #region Instance implementation

        private cWaitWindow() { }

        private frmWaitMemo _GUI;
        internal delegate void MethodInvokerText<T1, T2, T3>(T1 parameter1, T2 parameter2, T3 parameter3);
        internal delegate void MethodInvoker<T>(T parameter1);
        internal EventHandler<WaitWindowEventArgs> _WorkerMethod;
        internal List<object> _Args;


        /// <summary>
        /// Updates the message displayed in the wait window.
        /// </summary>
        /// 
        public string Message
        {
            set
            {
                this._GUI.Invoke(new MethodInvokerText<string, System.Drawing.Font, System.Drawing.Color>(this._GUI.SetMessage), value, this.Font, this.ForeColor);
            }
        }

        public string Caption
        {
            set
            {
                this._GUI.Invoke(new MethodInvoker<string>(this._GUI.SetCaption), value);
            }
        }

        public string Description
        {
            set
            {
                this._GUI.Invoke(new MethodInvoker<string>(this._GUI.SetDescription), value);
            }
        }

        public System.Drawing.Color ForeColor { get; set; }
        public System.Drawing.Font Font { get; set; }

        /// <summary>
        /// Cancels the work and exits the wait windows immediately
        /// </summary>
        public void Cancel()
        {
            this._GUI.Invoke(new MethodInvoker(this._GUI.Cancel), null);
        }

        private object Show(EventHandler<WaitWindowEventArgs> workerMethod, string message, System.Drawing.Font font, System.Drawing.Color forecolor, List<object> args)
        {
            this.Font = font;
            this.ForeColor = forecolor;

            //	Validate Parameters
            if (workerMethod == null)
            {
                throw new ArgumentException("No worker method has been specified.", "workerMethod");
            }
            else
            {
                this._WorkerMethod = workerMethod;
            }

            this._Args = args;

            if (message != null)
            {
                message = "Please wait...";
            }

            //	Set up the window
            this._GUI = new frmWaitMemo(this);
            //this._GUI.MessageLabel.Text = message;

            //	Call it
            this._GUI.ShowDialog();

            object result = this._GUI._Result;

            //	clean up
            Exception _Error = this._GUI._Error;
            this._GUI.Dispose();

            //	Return result or throw and exception
            if (_Error != null)
            {
                throw _Error;
            }
            else
            {
                return result;
            }
        }

        #endregion Instance implementation

    }
}