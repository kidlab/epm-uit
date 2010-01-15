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
        public bool login(string username, string password)
        {
            IUserRepository userModel = new UserRepository();
            User user = userModel.getExistUser(username, password);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            } 
        }

        [WebMethod]
        public List<Project> getProjects(int userId, int projectId)
        {
            return "Hello World1";
        }

        [WebMethod]
        public List<Milestone> getMilestones(int userId, int projectId)
        {
            return "Hello World1";
        }

        [WebMethod]
        public List<> getTasklists(int userId, int projectId)
        {
            return "Hello World1";
        }

        [WebMethod]
        public List getTasks(int userId, int projectId)
        {
            return "Hello World1";
        }
    }
}
