using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTechCore.Tools
{
    public static class Forms
    {
        public static List<Form> IsFormInstantiated(Type tpe)
        {
            List<Form> lst = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == tpe) lst.Add(frm);
            }
            return lst;
        }

        public static List<Form> IsFormInstantiatedByType(Type tpe)
        {
            List<Form> lst = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType().GetProperty("BaseType") != null)  lst.Add(frm);
            }
            return lst;
        }

        public static List<Form> IsFormInstantiated(string name)
        {
            List<Form> lst = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == name) lst.Add(frm);
            }
            return lst;
        }
       
        public static IEnumerable<System.Windows.Forms.Control> GetControls(this System.Windows.Forms.Control root)
        {
            var queue = new Queue<System.Windows.Forms.Control>();

            queue.Enqueue(root);

            do
            {
                var control = queue.Dequeue();

                yield return control;

                foreach (System.Windows.Forms.Control child in control.Controls)
                    queue.Enqueue(child);

            } while (queue.Count > 0);
        }

        public static IEnumerable<System.Windows.Forms.Control> GetControlsOfType(this System.Windows.Forms.Control root)
        {
            var queue = new Queue<System.Windows.Forms.Control>();

            queue.Enqueue(root);

            do
            {
                var control = queue.Dequeue();

                yield return control;

                foreach (var child in control.Controls.OfType<System.Windows.Forms.Control>())
                    queue.Enqueue(child);

            } while (queue.Count > 0);
        }

        public static void InitializeControlsFocus(Form frm)
        {

            List<Control> cntrls = CTechCore.Tools.Forms.GetControls(frm).ToList();
            foreach (Control ctrl in cntrls)
            {

                ctrl.GotFocus += (o, args) =>
                {
                    var c = o as Control;
                    Console.WriteLine(c.GetType().ToString());
                    c.BackColor = System.Drawing.Color.Silver;
                    System.Reflection.MethodInfo theMethod = c.GetType().GetMethod("SelectAll");

                    if (theMethod != null && !(c is DevExpress.XtraEditors.TextBoxMaskBox))
                        theMethod.Invoke(c, null);
                };
                ctrl.LostFocus += (o, args) =>
                {
                    var c = o as Control;
                    ctrl.BackColor = System.Drawing.Color.Empty;
                };

                ctrl.MouseUp += (o, args) =>
                {
                    var c = o as Control;
                    System.Reflection.MethodInfo theMethod = c.GetType().GetMethod("SelectAll");

                    if (theMethod != null && !(c is DevExpress.XtraEditors.TextBoxMaskBox))
                        theMethod.Invoke(c, null);
                };

            }
        }
    }

    public static class Helpers
    {

    }

}
