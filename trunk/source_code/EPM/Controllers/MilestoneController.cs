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
    public class MilestoneFormViewModel
    {
        // Properties
        public Milestone Milestone { get; private set; }

        // Constructor
        public MilestoneFormViewModel(Milestone milestone)
        {
            Milestone = milestone;
        }
    }

    /// <summary>
    /// Changed on 2010-01-09
    /// By: HaiLD.
    /// @description: 
    ///     - Stop using PaginatedList.
    /// </summary>
    public class MilestoneController : Controller
    {
        private IMilestoneRepository milestoneRepository;

        public MilestoneController()
            : this(new MilestoneRepository())
        {
        }

        public MilestoneController(IMilestoneRepository repository)
        {
            milestoneRepository = repository;
        }

        //
        // GET: /Milestone/
        
        public ActionResult Index(int? page, int? projectId, int? id)
        {
            List<Milestone> allMilestones = new List<Milestone>();

            try
            {
                const int pageSize = 10;

                /**
                * Changed on 2010-01-10
                * By: HaiLD.
                * @description:
                *      - Stop using PaginatedList.
                 *     - User should be stored in session.
                */
                /* Start changes */
                User currentUser = this.Session["user"] as User;
               // Tracer.Log("Milestone", "projectId " + projectId + " ml_id" + id, "F:\\error.log");
               
                if (currentUser != null)
                    allMilestones = milestoneRepository.GetMilestonesByUserProjectId(currentUser.id,projectId ?? 0, page ?? 0, pageSize).ToList();
                //var paginatedMilestones = new PaginatedList<Milestone>(allMilestones, page ?? 0, pageSize);
                /* End changes.*/

            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneController), exc);
            }

            return View(allMilestones);
        }

        /// <summary>
        ///  Need for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {

            Milestone milestone = milestoneRepository.GetOne(id);
            //Tracer.Log("Milestone", " ml_id " + id, "F:\\error.log");
            return View(new MilestoneFormViewModel(milestone));
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Milestone milestone = milestoneRepository.GetOne(id);
           

            try
            {
                UpdateModel(milestone);

                milestoneRepository.Save();
                
                return RedirectToAction("Index/" + milestone.project_id);
            }
            catch
            {
                //ModelState.AddModelErrors(milestone.GetRuleViolations());

                return View(new MilestoneFormViewModel(milestone));
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create(int? projectId)
        {

            Milestone milestone = new Milestone();
            
            return View(new MilestoneFormViewModel(milestone));
        }

        //
        // POST: /Milestone/Create
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Milestone milestone)
        {
            try
            {
              
                Milestone_AssignedRepository milestoneAssignedRepo = new Milestone_AssignedRepository();
                MilestoneRepository mlRepo = new MilestoneRepository();

                milestone.start = (DateTime?) DateTime.Now;
             
                milestoneRepository.Add(milestone);
                milestoneRepository.Save();

                /*IUserRepository userModel = new UserRepository();
                User user = userModel.GetAdmin(); // May be logging in here ...      
                this.Session["user"] = user;
                */
                User currentUser = HttpContext.Session["user"] as User;
                //Tracer.Log("", "userID " + currentUser.id , "F:\\error.log");

                Milestone_Assigned milestoneAssign = new Milestone_Assigned();
                Milestone newMilestone =  mlRepo.GetOneByName(milestone.name);
                milestoneAssign.milestone_id = newMilestone.id;
                milestoneAssign.user_id = currentUser.id;
                               
                milestoneAssignedRepo.Add(milestoneAssign);
                milestoneAssignedRepo.Save();
                return RedirectToAction("/Index/" + milestone.project_id);
            }
            catch (Exception exc)
            {
                Tracer.Log("", exc.Message, "F:\\error.log");
            }
           

            return View(new MilestoneFormViewModel(milestone));
        }

        //
        // HTTP GET: /Milestone/Delete/1


        public ActionResult Delete(int id)
        {

            Milestone milestone = milestoneRepository.GetOne(id);

            if (milestone == null)
                return View("NotFound");

            milestoneRepository.Delete(milestone);
            milestoneRepository.Save();

            return RedirectToAction("Milestone");
        }

        // 
        // HTTP POST: /Dinners/Delete/1
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            Milestone milestone = milestoneRepository.GetMilestone(id);

            if (milestone == null)
                return View("NotFound"); 
                
            milestoneRepository.Delete(milestone);
            milestoneRepository.Save();

            return View("Index");
        }
        */

        //
        // GET: /Milestone/ManageMilestone/1

        public ActionResult ManageMilestone(int id)
        {
            Milestone milestone = milestoneRepository.GetOne(id);
            return View(new MilestoneFormViewModel(milestone));
        }
    }
}
