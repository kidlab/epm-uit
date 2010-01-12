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
    public class ProjectFormViewModel
    {
        // Properties
        public Project Project { get; private set; }

        // Constructor
        public ProjectFormViewModel(Project project)
        {
            Project = project;
        }
    }

    /// <summary>
    /// Changed on 2010-01-06
    /// By: ManVHT.
    /// @description: 
    ///     - Stop using PaginatedList.
    ///     - Paging right in DB :D
    /// </summary>
    public class ProjectController : Controller
    {
        private IProjectRepository projectRepository;
        private IUserRepository userRepository;

        public ProjectController()
            : this(new ProjectRepository())
        {
        }

        public ProjectController(IProjectRepository repository)
        {
            projectRepository = repository;
        }

        //
        // GET: /Project/

        public ActionResult Index(int? page)
        {
            List<Project> allProjects = new List<Project>();

            try
            {
                const int pageSize = 10;

                /**
                * Changed on 2010-01-06
                * By: ManVHT.
                * @description:
                *      - Stop using PaginatedList.
                 *     - User should be stored in session.
                */
                /* Start changes */
                User currentUser =  HttpContext.Session["user"] as User;

                if (currentUser != null)
                    allProjects = projectRepository.GetProjectsByUser(currentUser.id, page ?? 0, pageSize).ToList();
                //var paginatedProjects = new PaginatedList<Project>(allProjects, page ?? 0, pageSize);
                /* End changes.*/

            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectController), exc);
            }

            return View(allProjects);
        }

        /// <summary>
        ///  Need for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {

            Project project = projectRepository.GetOne(id);
            return View(new ProjectFormViewModel(project));
        }

        [ValidateInput(false)] 
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Project project = projectRepository.GetOne(id);

            try
            {
                UpdateModel(project);

                projectRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                //ModelState.AddModelErrors(project.GetRuleViolations());

                return View(new ProjectFormViewModel(project));
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create()
        {

            Project project = new Project();


            return View(new ProjectFormViewModel(project));
        }

        //
        // POST: /Dinners/Create
        [ValidateInput(false)] 
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Project project)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    projectRepository.Add(project);
                    projectRepository.Save();

                    return RedirectToAction("Index");
                }
                catch
                {
                    // ModelState.AddModelErrors(project.GetRuleViolations());
                }
            }

            return View(new ProjectFormViewModel(project));
        }

        //
        // HTTP GET: /Project/Delete/1


        public ActionResult Delete(int id)
        {

            Project project = projectRepository.GetOne(id);

            if (project == null)
                return View("NotFound");

            projectRepository.Delete(project);
            projectRepository.Save();

            return RedirectToAction("Project");
        }

        // 
        // HTTP POST: /Dinners/Delete/1
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            Project project = projectRepository.GetProject(id);

            if (project == null)
                return View("NotFound"); 
                
            projectRepository.Delete(project);
            projectRepository.Save();

            return View("Index");
        }
        */

        //
        // GET: /Project/ManageProject/1

        public ActionResult ManageProject(int id)
        {
            /**
             * Changed on 2010-01-07
             * By: ManVHT.
             * @description:
             *     - Always store admin in session (test only :D)
             */
            IUserRepository userModel = new UserRepository();
            User user = userModel.GetAdmin(); // May be logging in here ...      
            this.Session["user"] = user;
            ViewData["user_id"] = user.id;
            ViewData["project_id"] = id;

            Project project = projectRepository.GetOne(id);
            return View(new ProjectFormViewModel(project));
        }

        //
        // GET: /Project/User/
        public ActionResult User(int? id) {
            userRepository = new UserRepository();

            List<User> users = userRepository.GetAll().ToList();
            List<User> usersNotAssign = new List<User>();
            if (id != null)
            {
                usersNotAssign = userRepository.GetUserNotInProject(id).ToList();
            }
            ViewData["canAdd"] = true;
            ViewData["usersNotAssign"] = usersNotAssign;
            return View(users);
        }

        //
        // GET /Project/UserAdd/
        public ActionResult UserAdd() {
            int id = int.Parse(Request.Form["user"]);

            return Redirect("/Admin/User");
        }
    }
}
