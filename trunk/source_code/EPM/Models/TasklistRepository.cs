using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    /// <summary>
    /// Change on 2010-01-11
    /// by: ManVHT.
    /// </summary>
    public class TasklistRepository : BaseModel, ITasklistRepository
    {
        #region CONSTRUCTOR

        public TasklistRepository()
            : base()
        {
        }

        public TasklistRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region ITasklistRepository Members

        public IQueryable<Tasklist> GetTasklistsByProject(int userID, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetTasklistsByProject(userID);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Tasklist> GetTasklistsByProject(int projectId)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from tasklist in _db.Tasklists
                    where tasklist.project_id == projectId                       
                    select tasklist;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Project GetProject(int tasklistId)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from tasklist in _db.Tasklists
                    join project in _db.Projects on tasklist.project_id equals project.id
                    where tasklist.id == tasklistId
                    select project;

                return query.SingleOrDefault();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion

        #region IRepository<Tasklist> Members

        public IQueryable<Tasklist> GetAll()
        {
            try
            {
                _refreshDataContext();
                return _db.Tasklists;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Tasklist GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Tasklists.SingleOrDefault(tasklist => tasklist.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Add(Tasklist obj)
        {
            try
            {
                _db.Tasklists.InsertOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Tasklist obj)
        {
            try
            {
                _db.Tasklists.DeleteOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TasklistRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion
    }
}
