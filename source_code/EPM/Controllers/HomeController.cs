using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPM.Models;
using Common;

namespace EPM.Controllers
{
    public class HomeViewModel
    {
        public List<Project> Projects { get; private set; }
        public List<TaskFormViewModel> Tasks { get; private set; }
        // List<Message> Messages{get;set;}

        public HomeViewModel(List<Project> projects, List<TaskFormViewModel> tasks)
        {
            Projects = projects;
            Tasks = tasks;
        }
    }

    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Used for paginating: the number of items per page.
        /// </summary>
        private const int PAGE_SIZE = 5;

        public ActionResult Index()
        {
            /**
             * Changed on 2010-01-07
             * By: ManVHT.
             * @description:
             *     - Always store admin in session (test only :D)
             */
            IUserRepository userModel = new UserRepository();
            User user = userModel.GetAdmin(); // May be logging in here ...      
            //this.Session["user"] = user;
            HttpContext.Session["user"] = user;
            /** End changes */

            /**
             * Changed on 2010-01-08
             * By: ManVHT.
             * @description:
             *     - Show projects on home pages.
             */
            //return RedirectToAction("index", "Project");
            HomeViewModel model = _getViewModel(user);
            return View(model);
            /** End changes */
            
        }

        public ActionResult About()
        {
            return View();
        }

        private HomeViewModel _getViewModel(User user)
        {
            HomeViewModel viewModel = null;
            
            try
            {
                List<Project> projects = _getProjects(user, 0);
                List<TaskFormViewModel> tasks = _getTasks(user, 0);
                viewModel = new HomeViewModel(projects, tasks);
            }
            catch (DbAccessException exc)
            {
                Tracer.Log(typeof(HomeController), exc);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeController), exc);
            }

            return viewModel;
        }

        private List<Project> _getProjects(User user, int? page)
        {
            IProjectRepository projectRepository = new ProjectRepository();
            return projectRepository.GetProjectsByUser(user.id, page ?? 0, PAGE_SIZE).ToList();
        }

        private List<TaskFormViewModel> _getTasks(User user, int? page)
        {
            ITaskRepository _taskRepository = new TaskRepository();
            List<TaskFormViewModel> allTaskVM = new List<TaskFormViewModel>();

            List<Task> allTasks =
                        _taskRepository.GetTasksByUser(user.id, page ?? 0, PAGE_SIZE).ToList();

            // Wrap all Task objects in TaskViewModel object and pass them to View.
            foreach (Task task in allTasks)
            {
                allTaskVM.Add(new TaskFormViewModel(task));
            }

            return allTaskVM;
        }
    }
}
