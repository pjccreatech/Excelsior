﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CTechCore.Tools.ControlHelpers
{
    public static class AutoSelectAllHelper
    {
        static object lastEdit;
        public static void EnableAutoSelectAllOnFirstMouseUp(this TextEdit edit)
        {
            edit.MaskBox.MouseUp += MaskBox_MouseUp;
            edit.MaskBox.Enter += new EventHandler(MaskBox_Enter);
        }

        static void MaskBox_Enter(object sender, EventArgs e)
        {
            lastEdit = sender;
        }


        static void MaskBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (lastEdit == sender)
                (sender as TextBox).SelectAll();
            lastEdit = null;
        }

    }
}
