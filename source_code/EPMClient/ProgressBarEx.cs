using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EPMClient
{
    /// <summary>
    /// The extended ProgressBar that can show a tool tip text or a balloon tip. 
    /// </summary>
    public class ProgressBarEx : ProgressBar
    {
        #region VARIABLES

        /// <summary>
        /// The tool tip will be shown whenever the mouse hovers the ProgressBarEx control.
        /// </summary>
        protected ToolTip _toolTip;

        /// <summary>
        /// Determines if the tool tip will be shown when the mouse hovers the ProgressBarEx control.
        /// </summary>
        protected bool _showToolTip;

        /// <summary>
        /// The string format for the caption of the tooltip.
        /// </summary>
        protected readonly string TOOLTIP_FORMAT = "{0:F1} %";

        /// <summary>
        /// Gets or sets the value determining whether the tool tip will be shown whenever the mouse hovers the ProgressBarEx control.
        /// </summary>
        public bool AutoShowValueToolTip
        {
            get { return _showToolTip; }
            set
            {
                _showToolTip = value;

                if (_showToolTip)
                {
                    this.initToolTip();
                    //this.MouseLeave += new EventHandler(ProgressBarEx_MouseLeave);
                    this.MouseMove += new MouseEventHandler(ProgressBarEx_MouseMove);
                }
                else
                    _toolTip = null;
            }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initialize a new instance of ProgressBarEx as a normal ProgressBar without showing the ToolTip whenever the mouse hovers the ProgressBarEx control.
        /// </summary>
        public ProgressBarEx()
            : base()
        {
            _showToolTip = false;
            this.Minimum = 0;
            this.Maximum = 100;
        }

        /// <summary>
        /// Initialize a new instance of ProgressBarEx and specify whether the ToolTip will be shown whenever the mouse hovers the ProgressBarEx control.
        /// </summary>
        /// <param name="autoShowToolTip">The value indicating whether the ToolTip will be shown whenever the mouse hovers the ProgressBarEx control.</param>
        public ProgressBarEx(bool autoShowToolTip)
            : base()
        {
            this.AutoShowValueToolTip = autoShowToolTip;
            this.Minimum = 0;
            this.Maximum = 100;
        }

        #endregion

        #region INTERNAL EVENTS

        private void ProgressBarEx_MouseMove(object sender, MouseEventArgs e)
        {
            if (_showToolTip && this._toolTip != null)
            {
                string text = String.Format(TOOLTIP_FORMAT, this.Value);
                _toolTip.SetToolTip(this, text);
            }
        }

        private void ProgressBarEx_MouseLeave(object sender, EventArgs e)
        {
            if (_showToolTip && this._toolTip != null)
            {
                this._toolTip.Hide(this.Parent);
            }
        }

        #endregion

        #region UTILITY METHODS

        protected virtual void initToolTip()
        {
            _toolTip = new ToolTip();
            //_toolTip.AutomaticDelay = 400;
            //_toolTip.AutoPopDelay = 3000;
            //bool canExtend = _toolTip.CanExtend(this);
            //bool b = canExtend;
            //_toolTip.InitialDelay = 400;
            //_toolTip.ReshowDelay = 400;
            //_toolTip.ToolTipTitle = "Total Progress";
            //_toolTip.ToolTipIcon = ToolTipIcon.Info;
        }

        #endregion

    }
}
