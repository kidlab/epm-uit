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

    public class ajaxProjectsByUserViewModel { 
        
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
        private RoleRepository roleRepository = new RoleRepository();
        private Role_AssignedRepository raRepository = new Role_AssignedRepository();

        // ERROR
        private string ERR_NAME_REQUIRE = "Name require";
        private string ERR_EMAIl_REQUIRE = "Email require";
        private string ERR_PHONE_REQUIRE = "Phone number require";
        private string ERR_PHONE_INVALID = "Phone number invalid";
        private string ERR_ADDRESS_REQUIRE = "Address require";
        private string ERR_PASSWORD_NOT_MATCH = "Password does not match";
        private string ERR_OLD_PASSWORD_INVALID = "Wrong Old password";
        private string ERR_ROLE_REQUIRE = "Role Require";

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            Redirect("/admin/useradmin");
            return View();
        }

        #region USER_ADMIN

        //
        // GET: /Admin/useradmin
        public ActionResult UserAdmin(int? page) {
            IQueryable<User> users = null;
            PaginatedList<Models.User> resultUsers = null;
            try
            {
                const int pageSize = 20;
                User currentUser = this.Session["user"] as User;
                if (currentUser != null)
                {
                    //users = userRespository.GetAll().ToList();
                    resultUsers = new PaginatedList<User>(userRespository.GetAllUsers(page ?? 0, pageSize),
                            0, 10);
                          
                        return View(resultUsers);
                }
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View();
        }

        //
        // GET: /Admin/UserView
        public ActionResult UserView(int? id) {
            User user = null;
            PaginatedList<Models.Project> projects = null;
            UserProfileViewModel viewModel = null;
            try
            {
                if (id != null)
                {
                    user = userRespository.getUserById(id.Value);
                    projects = new PaginatedList<Project>(projectRespository.GetProjectsByUser(id.Value),
                        0, 10);

                    viewModel = new UserProfileViewModel(user, projects);
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View(viewModel);
        }     

        //
        // GET /Admin/AjaxProjectView
        public ActionResult AjaxProjectsByUserView(int? id) {
            PaginatedList<Models.Project> projects = null;
            try
            {
                if (id != null)
                {
                    projects = new PaginatedList<Project>(projectRespository.GetProjectsByUser(id.Value),
                        0, 10);
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View(projects);
        }

        //
        // GET /Admin/AjaxUserAdd
        public ActionResult UserAdd()
        {
            List<Role> roles = new List<Role>();
            try
            {
                roles = roleRepository.GetGlobalRoles().ToList<Role>();
                ViewData["roles"] = roles;
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View();
        }

        //
        // GET /Admin/AjaxUserAdd
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserAdd(FormCollection form){
            Models.User user = new User();
            List<Role> roles = new List<Role>();
            string password = "";
            string repeatPassword = "";
            List<String> errorMessage = new List<string>();
            errorMessage.Clear();
            try
            {
                // get role list first
                roles = roleRepository.GetGlobalRoles().ToList<Role>();
                ViewData["roles"] = roles;

                // then get user information
                user.name = Request.Form["username"];
                user.company = Request.Form["company"];
                user.email = Request.Form["email"];
                user.phone = Request.Form["phone"];
                user.address = Request.Form["address"];
                user.country = Request.Form["country"];
                user.gender = Byte.Parse(Request.Form["gender"]);
                password = Request.Form["password"];
                repeatPassword = Request.Form["repeatpassword"];
                user.password = password;
                //validate
                if (user.name == null || user.name == "")
                    errorMessage.Add("Name require");
                if (user.email == null || user.email == "")
                    errorMessage.Add("Email require");
                if (user.phone == null || user.phone == "")
                    errorMessage.Add("Phone number require");
                if (user.address == null || user.address == "")
                    errorMessage.Add("Address require");
                if (password == null || password != repeatPassword || password == "")
                    errorMessage.Add("Password does not match");

                // summary
                if (errorMessage.Count == 0)
                {
                    userRespository.Add(user);
                    userRespository.Save();
                    return Redirect("/Admin/UserAdmin");
                }
                else {
                    ViewData["errors"] = errorMessage;
                }
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View(user);
        }

        //
        // GET /Admin/UserEdit/id/
        public ActionResult UserEdit(int? id) {
            User user = new User();
            List<Role> roles = new List<Role>();
            if (id != null && userRespository.getUserById(id.Value) != null) {
                user = userRespository.getUserById(id.Value);

                roles = roleRepository.GetGlobalRoles().ToList<Role>();
                ViewData["roles"] = roles;
                
                return View(user);
            }
            return View();
        }

        //
        // GET /Admin/UserEdit/id/
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserEdit(int? id,FormCollection form) {
            Models.User user = new User();
            List<Role> roles = new List<Role>();
            Role_Assigned ra = new Role_Assigned();
            string oldpassword      = "";
            string password         = "";
            string repeatPassword   = "";
            int newRole = 0;
            List<String> errorMessage = new List<string>();
            errorMessage.Clear();
            try
            {
                // get role list
                roles = roleRepository.GetGlobalRoles().ToList<Role>();
                ViewData["roles"] = roles;

                // find user
                user.id         = int.Parse(Request.Form["id"]);
                user            = userRespository.getUserById(user.id);
                user.name       = Request.Form["username"];
                user.company    = Request.Form["company"];
                user.email      = Request.Form["email"];
                user.phone      = Request.Form["phone"];
                user.address    = Request.Form["address"];
                user.country    = Request.Form["country"];
                user.gender     = Byte.Parse(Request.Form["gender"]);
                oldpassword     = Request.Form["oldpassword"];
                password        = Request.Form["password"];
                repeatPassword  = Request.Form["repeatpassword"];
                user.password   = password;
                ra              = raRepository.GetAssignGlobal(user.id);
                if (int.TryParse(Request.Form["role"], out newRole)) {
                    //newRole = int.Parse(Request.Form["role"]);
                    ra.role_id = newRole;
                }
                //validate
                if (user.name == null || user.name == "")
                    errorMessage.Add(ERR_NAME_REQUIRE);
                if (user.email == null || user.email == "")
                    errorMessage.Add(ERR_EMAIl_REQUIRE);
                if (user.phone == null || user.phone == "")
                    errorMessage.Add(ERR_PHONE_REQUIRE);
                if (user.address == null || user.address == "")
                    errorMessage.Add(ERR_EMAIl_REQUIRE);
                if (oldpassword != "" && oldpassword != user.password)
                    errorMessage.Add(ERR_OLD_PASSWORD_INVALID);
                if (oldpassword != "" && (password == null || password != repeatPassword || password == ""))
                    errorMessage.Add(ERR_PASSWORD_NOT_MATCH);
                if (int.TryParse(Request.Form["role"], out newRole)
                    errorMessage.Add(ERR_ROLE_REQUIRE);

                
                // summary
                if (errorMessage.Count == 0)
                {
                    userRespository.Save();

                    raRepository.Save();
                    return Redirect("/Admin/UserAdmin");
                }
                else
                {
                    ViewData["errors"] = errorMessage;
                }
            }
            catch (Exception ex)
            {
                Tracer.Log(typeof(AdminController), ex);
            }
            return View(user);
        }

        #endregion

        #region ROLE ADMIN


        #endregion

        private bool isNumber(String str) {
            while (str.Contains(" "))
            {
                str.Replace(" ", "");
            }
            int no;
            return int.TryParse(str, out no);
        }
    }
}
