﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EPMClient
{
    /// <summary>
    /// This is the base text box auto-changing background color whenever it is enterred or leaved.
    /// </summary>
    public class BaseTextBox : TextBox
    {
        /// <summary>
        /// Used to store the original background color of the textbox.
        /// </summary>
        private Color _previousColor;

        public BaseTextBox()
        {
            this.Enter += new EventHandler(BaseTextBox_Enter);
            this.Leave += new EventHandler(BaseTextBox_Leave);
        }

        protected void BaseTextBox_Enter(object sender, EventArgs e)
        {
            _previousColor = this.BackColor;
            this.BackColor = Color.LightYellow;
        }

        protected void BaseTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = _previousColor;
        }
    }
}
