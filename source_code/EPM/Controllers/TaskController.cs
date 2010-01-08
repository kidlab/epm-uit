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
    public class TaskViewModel
    {
        public Task Task { get; private set; }

        public TaskViewModel(Task task)
        {
            Task = task;
        }

        public string GetProjectName()
        {
            string name = String.Empty;

            try
            {
                ITaskRepository taskModel = new TaskRepository();
                Project project = taskModel.GetProject(Task.id);

                if (project != null)
                    name = project.name;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskViewModel), exc);
            }

            return name;
        }
    }

    /// <summary>
    /// TaskController.
    /// </summary>
    /// <remarks>
    /// Added on 2010-01-08
    /// by: ManVHT
    /// </remarks>
    public class TaskController : Controller
    {
        private ITaskRepository _taskRepository;

        public TaskController()
            : this(new TaskRepository())
        {
        }

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //
        // GET: /Task/

        public ActionResult Index(int? page)
        {
            List<TaskViewModel> allTaskVM = new List<TaskViewModel>();

            try
            {
                const int pageSize = 10;

                User currentUser = this.Session["user"] as User;
                if (currentUser != null)
                {
                    List<Task> allTasks = 
                        _taskRepository.GetTasksByUser(currentUser.id, page ?? 0, pageSize).ToList();

                    // Wrap all Task objects in TaskViewModel object and pass them to View.
                    foreach (Task task in allTasks)
                    {
                        allTaskVM.Add(new TaskViewModel(task));
                    }
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectController), exc);
            }

            return View(allTaskVM);
        }

    }
}
