using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EPMClient.EPMWebService;

namespace EPMClient
{
    static class Program
    {
        private static User _user;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            while (_login())
            {                
                EPMAgent frmMain = new EPMAgent(_user);
                //Application.Run(frmMain);
                frmMain.ShowDialog();
                if (frmMain.IsExit)
                    return;
            }
        }

        private static bool _login()
        {
            LoginForm frmLogin = new LoginForm();
            if (frmLogin.ShowDialog() != DialogResult.OK)
                return false;

            _user = frmLogin.CurrentUser;
            return true;
        }
    }
}
