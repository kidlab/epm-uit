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
    ///    - Add GetMilestonesByUserProjectId
    /// </summary>
    public class MilestoneRepository : BaseModel, IMilestoneRepository
    {
        /**
         * Add on 2010-01-07
         * by: ManVHT.
         * @description:
         *      Constructor region.
         */
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

        /** End changes */

        //
        // Query Methods

        public IQueryable<Milestone> GetAll()
        {
            /**
             * Changed on 2010-01-07
             * By: ManVHT.
             * @description:
             *      Because LINQ doesn't update changes until DataContext refreshes, we should refresh to get new data.
             */
            _refreshDataContext();

            /* End changes */

            return _db.Milestones;
        }


        public Milestone GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Milestones.SingleOrDefault(d => d.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Milestone GetOneByName(string name)
        {
            try
            {
                _refreshDataContext();
                return _db.Milestones.SingleOrDefault(d => d.name == name);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Milestone> GetMilestonesByUserProjectId(int userID,int projectId, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetMilestonesByUserProjectId(userID,projectId);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }
        public IQueryable<Milestone> GetMilestonesByProjectId(int projectId)
        {
            try
            {
                var query = from milestone in _db.Milestones
                            where milestone.project_id == projectId
                            select milestone;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Milestone> GetMilestonesByUser(int userID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from milestone in _db.Milestones
                    join milestone_assigned in _db.Milestone_Assigneds
                    on milestone.id equals milestone_assigned.milestone_id
                    where milestone_assigned.user_id == userID
                    select milestone;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Milestone> GetMilestonesByUserProjectId(int userID, int projectId)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from milestone in _db.Milestones
                    join milestone_assigned in _db.Milestone_Assigneds
                    on milestone.id equals milestone_assigned.milestone_id
                    where milestone_assigned.user_id == userID 
                    && milestone.project_id == projectId
                    select milestone;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Milestone> GetMilestones(int pageIndex, int pageSize)
        {
            try
            {
                _refreshDataContext();

                return _db.Milestones.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        //
        // Insert/Delete Methods

        public void Add(Milestone milestone)
        {
            try
            {
                _db.Milestones.InsertOnSubmit(milestone);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Milestone milestone)
        {
            try
            {
                _db.Milestones.DeleteOnSubmit(milestone);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(MilestoneRepository), exc);
                throw new DbAccessException(exc);
            }
        }
    }
}
