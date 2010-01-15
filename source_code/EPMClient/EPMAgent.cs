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
        private bool _isLogout = false;

        private User _user;
        private EPMserviceSoapClient _epmClient;

        private List<Project> _projects;
        private List<Task> _tasks;

        public bool IsLogout
        {
            get { return _isLogout; }
        }

        #region CONSTRUCTOR

        public EPMAgent()
        {
            InitializeComponent();
        }

        public EPMAgent(User user)
        {
            if (user == null)
                return;

            _user = user;
            InitializeComponent();
        }

        #endregion

        #region UI EVENTS

        private void EPMAgent_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _isLogout = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        #endregion

        #region UTILITY METHODS

        

        #endregion
    }
}
