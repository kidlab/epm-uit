using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using EPMClient.EPMWebService;

namespace EPMClient
{
    public partial class LoginForm : Form
    {  
        private EPMserviceSoapClient _epmClient;
        private User _user;

        public User CurrentUser
        {
            get{return _user;}
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_validateData())
                    return;

                if (!_login())
                {
                    UIUtils.Warning(ErrorMsg.ERR_LOGIN_FAILED);
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(LoginForm), exc);
                UIUtils.Warning(ErrorMsg.ERR_CONNECT_FAILED);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool _login()
        {
            if (_epmClient == null)
            {
                _epmClient = new EPMserviceSoapClient();
            }

            _user = _epmClient.login(txtUserName.Text.Trim(), txtPassWord.Text.Trim());

            return _user != null;
        }

        private bool _validateData()
        {
            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                _setErrorToolTip(txtUserName, ErrorMsg.ERR_NO_USERNAME);
                return false;
            }

            if(String.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                _setErrorToolTip(txtPassWord, ErrorMsg.ERR_NO_PASSWORD);
                return false;
            }

            return true;
        }

        private void _setErrorToolTip(Control control, string message)
        {
            this.errorToolTip.SetToolTip(control, message);
            this.errorToolTip.Show(message, control, 3000);
        }
    }
}