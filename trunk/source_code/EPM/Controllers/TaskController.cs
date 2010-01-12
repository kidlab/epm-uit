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
    public class TaskFormViewModel
    {
        public Task Task { get; private set; }
        public List<User> Users { get; private set; }
        //public List<User> Users { get; private set; }
        public TaskFormViewModel(Task task)
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
                Tracer.Log(typeof(TaskFormViewModel), exc);
            }

            return name;
        }
    }

    /// <summary>
    /// TaskController.
    /// </summary>
    /// <remarks>
    /// Update on 2010-01-10
    /// by: HaiLD
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
            List<TaskFormViewModel> allTaskVM = new List<TaskFormViewModel>();

            try
            {
                
                const int pageSize = 10;

                User currentUser = HttpContext.Session["user"] as User;
                if (currentUser != null)
                {
                    List<Task> allTasks = 
                        _taskRepository.GetTasksByUser(currentUser.id, page ?? 0, pageSize).ToList();

                    // Wrap all Task objects in TaskViewModel object and pass them to View.
                    foreach (Task task in allTasks)
                    {
                        allTaskVM.Add(new TaskFormViewModel(task));
                    }
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskController), exc);
            }

            return View(allTaskVM);
        }

        /// <summary>
        ///  Need for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {

            Task task = _taskRepository.GetOne(id);
            //Tracer.Log("Task", " ml_id " + id, "F:\\error.log");
            return View(new TaskFormViewModel(task));
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Task task = _taskRepository.GetOne(id);


            try
            {
                UpdateModel(task);

                _taskRepository.Save();

                return RedirectToAction("Index/" + task.tasklist_id);
            }
            catch
            {
                //ModelState.AddModelErrors(task.GetRuleViolations());

                return View(new TaskFormViewModel(task));
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create()
        {

            Task task = new Task();


            return View(new TaskFormViewModel(task));
        }

        //
        // POST: /Dinners/Create
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Task task)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    _taskRepository.Add(task);
                    _taskRepository.Save();

                    return RedirectToAction("Index");
                }
                catch
                {
                    // ModelState.AddModelErrors(task.GetRuleViolations());
                }
            }

            return View(new TaskFormViewModel(task));
        }

        //
        // HTTP GET: /Task/Delete/1


        public ActionResult Delete(int id)
        {

            Task task = _taskRepository.GetOne(id);

            if (task == null)
                return View("NotFound");

            _taskRepository.Delete(task);
            _taskRepository.Save();

            return RedirectToAction("Task");
        }

        // 
        // HTTP POST: /Dinners/Delete/1
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            Task task = taskRepository.GetTask(id);

            if (task == null)
                return View("NotFound"); 
                
            taskRepository.Delete(task);
            taskRepository.Save();

            return View("Index");
        }
        */

        //
        // GET: /Task/ManageTask/1

        public ActionResult ManageTask(int id)
        {
            Task task = _taskRepository.GetOne(id);
            return View(new TaskFormViewModel(task));
        }
    }
}
