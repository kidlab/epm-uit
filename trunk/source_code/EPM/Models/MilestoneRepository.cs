using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EPM.Models
{
    public class MilestoneRepository : IMilestoneRepository
    {
        EpmDataContext db = new EpmDataContext();

        //
        // Query Methods

        public IQueryable<Milestone> FindAllMilestones()
        {
            return db.Milestones;
        }

        public IQueryable<Milestone> FindAllMilestonesByProjectId(int projectId)
        {
            return from ml in db.Milestones where ml.project_id == projectId select ml;
        }


        public Milestone GetMilestone(int id)
        {
            return db.Milestones.SingleOrDefault(d => d.id == id);
        }

        //
        // Insert/Delete Methods

        public void Add(Milestone milestone)
        {
            db.Milestones.InsertOnSubmit(milestone);
        }

        public void Delete(Milestone milestone)
        {
            db.Milestones.DeleteOnSubmit(milestone);

        }

        //
        // Persistence 

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
