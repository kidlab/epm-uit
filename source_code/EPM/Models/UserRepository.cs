using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    /// <summary>
    /// Added on 2010-01-07
    /// by: ManVHT.
    /// </summary>
    public class UserRepository : BaseModel, IUserRepository
    {
        #region CONSTRUCTOR

        public UserRepository()
            : base()
        {
        }

        public UserRepository(EpmDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region IUserRepository Members

        public User GetAdmin()
        {
            try
            {
                _refreshDataContext();

                return _db.Users.AsEnumerable().SingleOrDefault(user => user.IsAdmin);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<User> GetUsersByProject(int projectID)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from user in _db.Users
                    join project_assigned in _db.Project_Assigneds
                    on user.id equals project_assigned.user_id
                    where project_assigned.project_id == projectID
                    select user;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<User> GetUsersByProject(int projectID, int pageIndex, int pageSize)
        {
            try
            {
                var query = GetUsersByProject(projectID);

                return query.Skip(pageIndex * pageSize).Take(pageSize);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion

        #region IRepository<User> Members

        public IQueryable<User> GetAll()
        {
            try
            {
                _refreshDataContext();
                return _db.Users;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }        

        public User GetOne(int id)
        {
            try
            {
                _refreshDataContext();

                return _db.Users.SingleOrDefault(user => user.id == id);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Add(User obj)
        {
            try
            {
                _db.Users.InsertOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(User obj)
        {
            try
            {
                _db.Users.DeleteOnSubmit(obj);
                _save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(UserRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        #endregion
    }
}
