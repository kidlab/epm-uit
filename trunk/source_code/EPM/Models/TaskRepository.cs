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
    public class TaskRepository : BaseModel, ITaskRepository
    {
        #region CONSTRUCTOR

        public TaskRepository()
            : base()
        {
        }

        public TaskRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region ITaskRepository Members

        public IQueryable<Task> GetTasksByUser(int userID, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetTasksByUser(userID);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Task> GetTasksByUser(int userID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from task in _db.Tasks
                    join task_assigned in _db.Task_Assigneds
                    on task.id equals task_assigned.task_id
                    where task_assigned.user_id == userID
                    select task;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Project GetProject(int taskID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from task in _db.Tasks
                    join tasklist in _db.Tasklists on task.tasklist_id equals tasklist.id
                    join project in _db.Projects on tasklist.project_id equals project.id
                    where task.id == taskID
                    select project;

                return query.SingleOrDefault();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Task> GetTaskByUserProjectId(int userID, int projectID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from task in _db.Tasks
                    join task_assigned in _db.Task_Assigneds
                    on task.id equals task_assigned.task_id
                    join tasklist in _db.Tasklists                    
                    on task.tasklist_id equals tasklist.id
                    where (task_assigned.user_id == userID)
                        && (tasklist.project_id == projectID)
                    select task;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Task> GetTaskByTasklist(int taskListId)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from task in _db.Tasks
                    where (task.tasklist_id == taskListId)
                    select task;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion

        #region IRepository<Task> Members

        public IQueryable<Task> GetAll()
        {
            try
            {
                _refreshDataContext();
                return _db.Tasks;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Task GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                return _db.Tasks.SingleOrDefault(task => task.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Task GetTaskByTitle(string title)
        {
            try
            {
                _refreshDataContext();
                return _db.Tasks.SingleOrDefault(task => task.title == title);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Add(Task obj)
        {
            try
            {
                _db.Tasks.InsertOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Task obj)
        {
            try
            {
                _db.Tasks.DeleteOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion
    }
}
