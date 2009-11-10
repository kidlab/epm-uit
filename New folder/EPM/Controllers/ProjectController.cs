using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using EPM.Models;
using EPM.Helpers;

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
    public class ProjectController : Controller
    {

        IProjectRepository projectRepository;

        //
        // GET: /Project/

        public ActionResult Index(int? page)
        {

            const int pageSize = 10;

            var allProjects = projectRepository.FindAllProjects(); ;
            var paginatedProjects = new PaginatedList<Project>(allProjects, page ?? 0, pageSize);

            return View(paginatedProjects);
        }

         public ProjectController()
                : this(new ProjectRepository())
        {
        }

         public ProjectController(IProjectRepository repository)
        {
            projectRepository = repository;
        }


        /// <summary>
         ///  nedd for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
         public ActionResult Edit(int id)
         {

             Project project = projectRepository.GetProject(id);

             return View(new ProjectFormViewModel(project));
         }

         [AcceptVerbs(HttpVerbs.Post)]
         public ActionResult Edit(int id, FormCollection collection)
         {

             Project project = projectRepository.GetProject(id);

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
    }
}
