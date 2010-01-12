using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    /// <summary>
    /// Added on 2010-01-08
    /// by: ManVHT.
    /// </summary>
    public class Task_AssignedRepository : BaseModel, ITask_AssignedRepository
    {
        #region CONSTRUCTOR

        public Task_AssignedRepository()
            : base()
        {
        }

        public Task_AssignedRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region ITask_AssignedRepository Members

        public IQueryable<Task_Assigned> GetTask_AssignedsByUser(int userID, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetTask_AssignedsByUser(userID);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Task_Assigned> GetTask_AssignedsByUser(int userID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from taskAssigned in _db.Task_Assigneds
                    where taskAssigned.user_id == userID
                    select taskAssigned;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        

       

        #endregion

        #region IRepository<Task_Assigned> Members

        public IQueryable<Task_Assigned> GetAll()
        {
            try
            {
                _refreshDataContext();
                return _db.Task_Assigneds;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Task_Assigned GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Task_Assigneds.SingleOrDefault(taskAssigned => taskAssigned.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Add(Task_Assigned obj)
        {
            try
            {
                _db.Task_Assigneds.InsertOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Task_Assigned obj)
        {
            try
            {
                _db.Task_Assigneds.DeleteOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(Task_AssignedRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion

        #region ITask_AssignedRepository Members

        IQueryable<Task_Assigned> ITask_AssignedRepository.GetTaskAssignedByUser(int userID, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        IQueryable<Task_Assigned> ITask_AssignedRepository.GetTaskAssignedByUser(int userID)
        {
            throw new NotImplementedException();
        }

        IQueryable<Task_Assigned> ITask_AssignedRepository.GetTaskByUserProjectId(int userID, int projectID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository<Task_Assigned> Members

        IQueryable<Task_Assigned> IRepository<Task_Assigned>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task_Assigned IRepository<Task_Assigned>.GetOne(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Task_Assigned>.Add(Task_Assigned obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<Task_Assigned>.Delete(Task_Assigned obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<Task_Assigned>.Save()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
