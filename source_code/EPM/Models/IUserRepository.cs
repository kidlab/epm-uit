﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets the administrator of the system.
        /// </summary>
        /// <returns></returns>
        User GetAdmin();

        /// <summary>
        /// Gets users of a project with paginating.
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<User> GetUsersByProject(int projectID, int pageIndex, int pageSize);

        /// <summary>
        /// Gets users of a project without paginating.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        IQueryable<User> GetUsersByProject(int projectId);

        /// <summary>
        /// Gets users by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetUserByName(string name);

        bool IsExistName(string name);


        User getExistUser(string username, string password);


        User getUserById(int id);

        IQueryable<User> GetUserNotInProject(int? id);

    }
}
