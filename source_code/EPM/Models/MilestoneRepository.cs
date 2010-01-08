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
    /// <summary>
    /// MilestoneRepository
    /// </summary>
    /// <remarks>  
    /// Changed on 2010-01-09
    /// By: ManVHT.
    /// @description:
    ///     - Inherit from the generic interface IMilestoneRepository and BaseModel.
    /// </remarks>
    public class MilestoneRepository : BaseModel, IMilestoneRepository
    {
        #region CONSTRUCTOR

        public MilestoneRepository()
            : base()
        {
        }

        public MilestoneRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        //
        // Query Methods

        public IQueryable<Milestone> GetAll()
        {
            return _db.Milestones;
        }

        public IQueryable<Milestone> FindAllMilestonesByProjectId(int projectId)
        {
            return from ml in _db.Milestones where ml.project_id == projectId select ml;
        }


        public Milestone GetOne(int id)
        {
            return _db.Milestones.SingleOrDefault(d => d.id == id);
        }

        //
        // Insert/Delete Methods

        public void Add(Milestone milestone)
        {
            _db.Milestones.InsertOnSubmit(milestone);
        }

        public void Delete(Milestone milestone)
        {
            _db.Milestones.DeleteOnSubmit(milestone);

        }
    }
}
