using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EPM.Models;
using EPM.Helpers;
using Common;

namespace EPM.web_service
{
    /// <summary>
    /// Summary description for EPMservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EPMservice : System.Web.Services.WebService
    {

        [WebMethod]
        public User login(string username, string password)
        {
            IUserRepository userModel = new UserRepository();
            User user = userModel.getExistUser(username, password);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            } 
        }

        [WebMethod]
        public List<Project> getProjects(int userId)
        {
            IProjectRepository model = new ProjectRepository();
            List<Project> data = model.GetProjectsByUser(userId).ToList();

            return data;
        }

        [WebMethod]
        public List<Milestone> getMilestones(int userId, int projectId)
        {
            IMilestoneRepository model = new MilestoneRepository();
            List<Milestone> data = model.GetMilestonesByUserProjectId(userId,projectId).ToList();

            return data;
        }

        [WebMethod]
        public List<Tasklist> getTasklists(int projectId)
        {
            ITasklistRepository model = new TasklistRepository();
            List<Tasklist> data = model.GetTasklistsByProject(projectId).ToList();

            return data;
        }

        [WebMethod]
        public List<Task> getTasksByProject(int userId, int projectId)
        {
            ITaskRepository model = new TaskRepository();
            List<Task> data = model.GetTaskByUserProjectId(userId, projectId).ToList();

            return data;
        }

        [WebMethod]
        public List<Task> getTasks(int userId)
        {
            ITaskRepository model = new TaskRepository();
            List<Task> data = model.GetTasksByUser(userId).ToList();

            return data;
        }
    }
}
