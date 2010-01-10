using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using EPM.Models;
using EPM.Helpers;
using Common;

namespace EPM.Controllers
{
    public class UserFormViewModel
    {
        // Properties
        public Models.User User { get; private set; }

        // Constructor
        public UserFormViewModel(Models.User user)
        {
            User = user;
        }
    }

    public class UserIndexViewModel
    {
        public List<Models.User> Users { get; set; }
        public List<Models.Role> Roles { get; set; }

        public UserIndexViewModel(List<Models.User> users, List<Models.Role> roles) {
            Users = users;
            Roles = roles;
        }

        public UserIndexViewModel() { }
    }

    public class UserProfileViewModel
    {
        public User user { get; set; }
        public List<Models.Project> projects { get; set; }
        public UserProfileViewModel(User _user, List<Models.Project> _projects) {
            user = _user;
            projects = _projects;
        }
        public UserProfileViewModel() { }
    }

    /// <summary>
    /// Changed on 10/1/2009
    /// by: ToanNM
    /// @description:
    ///  - create user administrator
    /// </summary>

    public class AdminController : Controller
    {
        private UserRepository userRespository = new UserRepository();
        private ProjectRepository projectRespository = new ProjectRepository();

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            Redirect("/admin/useradmin");
            return View();
        }

        //
        // GET: /Admin/useradmin
        public ActionResult UserAdmin(int? page) {            
            List<Models.User> users = new List<User>();
            try
            {
                const int pageSize = 20;
                User currentUser = this.Session["user"] as User;
                if (currentUser != null)
                    //users = userRespository.GetAll().ToList();
                    users = userRespository.GetAllUsers(page ?? 0, pageSize).ToList();

            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }

            UserIndexViewModel viewModel = new UserIndexViewModel();
            viewModel.Users = users;
            return View(viewModel);
        }

        //
        // GET: /Admin/UserView
        public ActionResult UserView(int? id) {
            User user = null;
            PaginatedList<Models.Project> projects = null;
            try
            {
                if (id != null)
                    user = userRespository.getUserById(id.Value);
                else
                    return View();

                projects = new PaginatedList<Project>(projectRespository.GetProjectsByUser(id.Value),
                    0, 10);

                UserProfileViewModel viewModel = new UserProfileViewModel(user, projects);
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View(user);
        }
    }
}
