﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace EPMClient
{
    public class UIUtils
    {
        /// <summary>
        /// Shows an error message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Error(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show an information message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Info(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a caution message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Warning(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a confirm dialog with two options: Yes, No.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Shows a confirm dialog with three options: Yes, No and Cancel.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ConfirmYesNoCancel(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a confirm dialog with three options: OK and Cancel.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ConfirmOKCancel(string msg)
        {
            return MessageBox.Show(msg, EpmConst.EPM_AGENT, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}