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
    public class MileStoneFormViewModel
    {
        // Properties
        public Milestone MileStone { get; private set; }

        // Constructor
        public MileStoneFormViewModel(Milestone mileStone)
        {
            MileStone = mileStone;

        }
    }
    public class MilestoneController : Controller
    {

        IMilestoneRepository mileStoneRepository;

        //
        // GET: /MileStone/

        public ActionResult Index(int? page, int? projectId)
        {

            const int pageSize = 10;

            var allMileStones = mileStoneRepository.FindAllMilestones(); 
            var paginatedMileStones = new PaginatedList<Milestone>(allMileStones, page ?? 0, pageSize);

            return View(paginatedMileStones);
        }

        public MilestoneController()
            : this(new MilestoneRepository())
        {
        }

        public MilestoneController(IMilestoneRepository repository)
        {
            mileStoneRepository = repository;
        }


        /// <summary>
        ///  nedd for login  [Authorize]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {

            Milestone mileStone = mileStoneRepository.GetMilestone(id);

            return View(new MileStoneFormViewModel(mileStone));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Milestone mileStone = mileStoneRepository.GetMilestone(id);

            try
            {
                UpdateModel(mileStone);

                mileStoneRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                //ModelState.AddModelErrors(mileStone.GetRuleViolations());

                return View(new MileStoneFormViewModel(mileStone));
            }
        }

        //
        // GET: /Dinners/Create


        public ActionResult Create()
        {

            Milestone mileStone = new Milestone();


            return View(new MileStoneFormViewModel(mileStone));
        }

        //
        // POST: /Dinners/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Milestone mileStone)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    mileStoneRepository.Add(mileStone);
                    mileStoneRepository.Save();

                    return RedirectToAction("Index");
                }
                catch
                {
                    // ModelState.AddModelErrors(mileStone.GetRuleViolations());
                }
            }

            return View(new MileStoneFormViewModel(mileStone));
        }


        //
        // HTTP GET: /Dinners/Delete/1


        public ActionResult Delete(int id)
        {

            Milestone mileStone = mileStoneRepository.GetMilestone(id);

            if (mileStone == null)
                return View("NotFound");

            mileStoneRepository.Delete(mileStone);
            mileStoneRepository.Save();

            return View("Index");
        }

        // 
        // HTTP POST: /Dinners/Delete/1
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            MileStone mileStone = mileStoneRepository.GetMileStone(id);

            if (mileStone == null)
                return View("NotFound"); 
                
            mileStoneRepository.Delete(mileStone);
            mileStoneRepository.Save();

            return View("Index");
        }
         */
    }

}
