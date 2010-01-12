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
using Common;

namespace EPM.Models
{
    /// <summary>
    /// Changed on 2010-01-10
    /// By: HaiLD.
    /// @description: 
    ///    - Add GetMilestone_AssignedsByUserProjectId
    /// </summary>
    public class Milestone_AssignedRepository : BaseModel, IMilestone_AssignedRepository
    {
        /**
         * Add on 2010-01-07
         * by: ManVHT.
         * @description:
         *      Constructor region.
         */
        #region CONSTRUCTOR

        public Milestone_AssignedRepository()
            : base()
        {
        }

        public Milestone_AssignedRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        /** End changes */

        //
        // Query Methods

        public IQueryable<Milestone_Assigned> GetAll()
        {
            /**
             * Changed on 2010-01-07
             * By: ManVHT.
             * @description:
             *      Because LINQ doesn't update changes until DataContext refreshes, we should refresh to get new data.
             */
            _refreshDataContext();

            /* End changes */

            return _db.Milestone_Assigneds;
        }


        public Milestone_Assigned GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Milestone_Assigneds.SingleOrDefault(d => d.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Milestone_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        

        public IQueryable<Milestone_Assigned> GetMilestone_AssignedsByUser(int userID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from milestoneAssigned in _db.Milestone_Assigneds
                    where milestoneAssigned.user_id == userID
                    select milestoneAssigned;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Milestone_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

       

        public IQueryable<Milestone_Assigned> GetMilestone_Assigneds(int pageIndex, int pageSize)
        {
            try
            {
                _refreshDataContext();

                return _db.Milestone_Assigneds.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Milestone_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        //
        // Insert/Delete Methods

        public void Add(Milestone_Assigned milestoneAssigned)
        {
            try
            {
                _db.Milestone_Assigneds.InsertOnSubmit(milestoneAssigned);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Milestone_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Milestone_Assigned milestoneAssigned)
        {
            try
            {
                _db.Milestone_Assigneds.DeleteOnSubmit(milestoneAssigned);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Milestone_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }
    }
}
