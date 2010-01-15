using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using EPMClient.EPMWebService;

namespace EPMClient
{
    public partial class EPMAgent : Form
    {
        private bool _isExit = false;

        private User _user;
        private EPMserviceSoapClient _epmClient;

        private List<Project> _projects;
        private List<Task> _tasks;

        public bool IsExit
        {
            get { return _isExit; }
        }

        #region CONSTRUCTOR

        public EPMAgent()
        {
            InitializeComponent();

            this.notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);
            this.notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);
            this.FormClosing += new FormClosingEventHandler(EPMAgent_FormClosing);
        }

        public EPMAgent(User user)
            : this()
        {
            if (user == null)
                return;

            _user = user;
        }

        #endregion

        #region UI EVENTS

        private void EPMAgent_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void EPMAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If these condition are missed, the computer can not shut down! 
            if (e.CloseReason == CloseReason.WindowsShutDown 
                    || e.CloseReason == CloseReason.ApplicationExitCall)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _logout();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _isExit = true;
            Application.Exit();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs mea)
        {
            if (mea.Button != MouseButtons.Right)
                return;

            if (!this.Visible)
            {
                showToolStripMenuItem.Enabled = true;
                hideToolStripMenuItem.Enabled = false;
            }
            else
            {
                showToolStripMenuItem.Enabled = false;
                hideToolStripMenuItem.Enabled = true;
            }
            this.notifyContextMenu.Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logout();
        }

        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            try
            {
                _epmClient = new EPMserviceSoapClient();
                _loadProjects();
                _loadTasks();
            }
            catch (Exception exc)
            {
                UIUtils.Error(exc.Message);
            }
        }

        private void _loadProjects()
        {
            try
            {
                _projects = _epmClient.getProjects(_user.id).ToList();

                lvProjects.Items.Clear();

                foreach(Project project in _projects)
                {
                    ListViewItem item = new ListViewItem(new string[]{
                        project.name,
                        "",
                        project.start.Value.ToShortDateString()
                    });
                    item.Tag = project.id;

                    lvProjects.Items.Add(item);

                    ProgressBarEx pb = new ProgressBarEx(true);
                    pb.Value = _calculateProjectStatus(project);

                    // Embed the ProgressBar in the liat view
                    this.lvProjects.AddEmbeddedControl(pb, colDone.Index, item.Index);
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(EPMAgent), exc);
                throw new Exception(
ErrorMsg.ERR_LOAD_PROJECTS_FAILED);
            }
        }

        private void _loadTasks()
        {
            try
            {
                _tasks = _epmClient.getTasks(_user.id).ToList();

                lvTasks.Items.Clear();
                foreach (Task task in _tasks)
                {
                    ListViewItem item = new ListViewItem(new string[]{
                        task.title,
                        "",
                        task.end.ToShortDateString()
                    });
                    
                    item.Tag = task.id;
                    lvTasks.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(EPMAgent), exc);
                throw new Exception(
ErrorMsg.ERR_LOAD_TASKS_FAILED);
            }
        }

        private void _logout()
        {
            _user = null;
            this.Close();
        }

        #endregion

        #region UTILITY METHODS

        private int _getDayLeft(Project project)
        {
            if (project.start == null || project.end == null)
                return 0;

            return (int)project.start.Value.Subtract(project.end.Value).TotalDays;
        }

        public int _calculateProjectStatus(Project project)
        {
            if (project == null)
                return 0;

            List<Task> tasks = _epmClient.getTasksByProject(_user.id, project.id).ToList();

            if (tasks == null || tasks.Count <= 0)
                return 0;

            int iDoneTasks = 0;
            foreach (Task task in tasks)
            {
                if (task.status == EpmConst.STATUS_CLOSED
                        || task.status == EpmConst.STATUS_RESOLVED)
                    iDoneTasks++;
            }

            int percent = percent = (iDoneTasks / tasks.Count) * 100;

            return percent;            
        }

        #endregion
    }
}
