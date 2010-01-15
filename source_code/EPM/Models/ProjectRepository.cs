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
    /// Changed on 2010-01-06
    /// By: ManVHT.
    /// @description: 
    ///     - Inherit from BaseModel.
    ///     - Add try{}catch{}
    /// </summary>
    public class ProjectRepository : BaseModel, IProjectRepository
    {
        /**
         * Add on 2010-01-07
         * by: ManVHT.
         * @description:
         *      Constructor region.
         */
        #region CONSTRUCTOR

        public ProjectRepository()
            : base()
        {
        }

        public ProjectRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        /** End changes */

        //
        // Query Methods

        public IQueryable<Project> GetAll()
        {
            /**
             * Changed on 2010-01-07
             * By: ManVHT.
             * @description:
             *      Because LINQ doesn't update changes until DataContext refreshes, we should refresh to get new data.
             */
            _refreshDataContext();

            /* End changes */

            return _db.Projects;
        }

      
        public Project GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Projects.SingleOrDefault(d => d.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Project> GetProjectsByUser(int userID, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetProjectsByUser(userID);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Project> GetProjectsByUser(int userID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from project in _db.Projects
                    join project_assigned in _db.Project_Assigneds
                    on project.id equals project_assigned.project_id
                    where project_assigned.user_id == userID
                    select project;                

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Project> GetProjects(int pageIndex, int pageSize)
        {
            try
            {
                _refreshDataContext();

                return _db.Projects.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        //
        // Insert/Delete Methods

        public void Add(Project project)
        {
            try
            {
                _db.Projects.InsertOnSubmit(project);
                
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Project project)
        {
            try
            {
                _db.Projects.DeleteOnSubmit(project);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ProjectRepository), exc);
                throw new DbAccessException(exc);
            }
        }
    }
}
