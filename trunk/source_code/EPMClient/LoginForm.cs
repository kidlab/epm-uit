using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtUserName.Text))
            {
                Utilities.Warning("Vui lòng nhập tên đăng nhập.");
                this.txtUserName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(this.txtPassWord.Text))
            {
                Utilities.Warning("Vui lòng nhập mật khẩu.");
                this.txtPassWord.Focus();
                return;
            }
            if (this.ValidateData())
                this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateData()
        {
            Connector connector = new Connector();
            string passWord = "";
            string query = String.Format("SELECT * FROM GIAOVIEN WHERE MAGV = '{0}'", this.txtUserName.Text);
            int row = connector.ExecQuery(query);
            if (row > 0)
            {
                passWord = connector.dataSet.Tables[0].Rows[0][SMConsts.TBL_ATTRIB_MATKHAU].ToString();
                if (Utilities.VerifyPassword(txtPassWord.Text, passWord))
                {
                    return true;
                }
                else
                {
                    Utilities.Error(SMException.WRONG_PASSWORD_MSG);
                    this.txtPassWord.SelectAll();
                    return false;
                }
            }
            Utilities.Error(String.Format(SMException.INVALID_USER_MSG, this.txtUserName.Text));
            this.txtUserName.SelectAll();
            return false;
        }
    }
}