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
    public class TasklistFormViewModel
    {
        public Tasklist Tasklist { get; private set; }
        public List<User> Users { get; private set; }
        public List<Milestone> Milestones { get; private set; }
        //public List<User> Users { get; private set; }
        public TasklistFormViewModel(Tasklist tasklist)
        {
            Tasklist = tasklist;
        }
        public TasklistFormViewModel(Tasklist tasklist,List<Milestone> milestones)
        {
            Tasklist = tasklist;
            Milestones = milestones;
        }
        public Project GetProject()
        {
            Project project = new Project();

            try
            {
                ITasklistRepository tasklistModel = new TasklistRepository();
                project = tasklistModel.GetProject(Tasklist.id);

                
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistFormViewModel), exc);
            }

            return project;
        }
       
    }

    /// <summary>
    /// TasklistController.
    /// </summary>
    /// <remarks>
    /// Update on 2010-01-10
    /// by: HaiLD
    /// </remarks>
    public class TasklistController : Controller
    {
        private ITasklistRepository _tasklistRepository;

        public TasklistController()
            : this(new TasklistRepository())
        {
        }

        public TasklistController(ITasklistRepository tasklistRepository)
        {
            _tasklistRepository = tasklistRepository;
        }

        //
        // GET: /Tasklist/

        public ActionResult Index(int? page, int? projectId, int? id)
        {
            List<TasklistFormViewModel> allTasklistVM = new List<TasklistFormViewModel>();

            try
            {

                
                const int pageSize = 10;

                User currentUser = HttpContext.Session["user"] as User;
                ViewData["projectId"] = projectId;
                ViewData["userId"] = currentUser.id;
                if (currentUser != null)
                {
                    List<Tasklist> allTasklists = 
                        _tasklistRepository.GetTasklistsByProject(projectId ?? 0, page ?? 0, pageSize).ToList();

                    //Tracer.Log("Tasklist", "projectId " + projectId + " tl_id" + id, "F:\\error.log");
                   // Tracer.Log("Tasklist", "count tl " + allTasklists.Count.ToString() , "F:\\error.log");
                    // Wrap all Tasklist objects in TasklistViewModel object and pass them to View.
                    foreach (Tasklist tasklist in allTasklists)
                    {
                        allTasklistVM.Add(new TasklistFormViewModel(tasklist));
                    }
                }
                //return View();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistController), exc);
            }

            return View(allTasklistVM);
        }

        /// <summary>
        ///  Need for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {

            Tasklist tasklist = _tasklistRepository.GetOne(id);
            //Tracer.Log("Tasklist", " ml_id " + id, "F:\\error.log");
            return View(new TasklistFormViewModel(tasklist));
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Tasklist tasklist = _tasklistRepository.GetOne(id);


            try
            {
                UpdateModel(tasklist);

                _tasklistRepository.Save();

                return RedirectToAction("Index/" + tasklist.project_id);
            }
            catch
            {
                //ModelState.AddModelErrors(tasklist.GetRuleViolations());

                return View(new TasklistFormViewModel(tasklist));
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create(int? projectId)
        {

            Tasklist tasklist = new Tasklist();

            tasklist.project_id = (int)projectId;

            //Tracer.Log("Tasklist", " projectId " + projectId, "F:\\error.log");

            return View(new TasklistFormViewModel(tasklist));
        }

        //
        // POST: /Dinners/Create
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Tasklist tasklist)
        {
           try
                {
                    
                    _tasklistRepository.Add(tasklist);
                    _tasklistRepository.Save();
                    
                    return RedirectToAction("/Index/" + tasklist.project_id);
                }
                catch (Exception exc)
                {
                    // ModelState.AddModelErrors(tasklist.GetRuleViolations());
                   
                    Tracer.Log("Taslist", exc.Message,"F:\\error.log");
                }
            

            return View(new TasklistFormViewModel(tasklist));
        }

        //
        // HTTP GET: /Tasklist/Delete/1


        public ActionResult Delete(int id)
        {

            Tasklist tasklist = _tasklistRepository.GetOne(id);

            if (tasklist == null)
                return View("NotFound");

            _tasklistRepository.Delete(tasklist);
            _tasklistRepository.Save();

            return RedirectToAction("Tasklist");
        }

        // 
        // HTTP POST: /Dinners/Delete/1
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            Tasklist tasklist = tasklistRepository.GetTasklist(id);

            if (tasklist == null)
                return View("NotFound"); 
                
            tasklistRepository.Delete(tasklist);
            tasklistRepository.Save();

            return View("Index");
        }
        */

        //
        // GET: /Tasklist/ManageTasklist/1

        public ActionResult ManageTasklist(int id)
        {
            Tasklist tasklist = _tasklistRepository.GetOne(id);
            return View(new TasklistFormViewModel(tasklist));
        }
    }
}
