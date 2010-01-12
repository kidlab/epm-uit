using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    public interface ITasklistRepository : IRepository<Tasklist>
    {
        /// <summary>
        /// Gets all task of a user with paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<Tasklist> GetTasklistsByProject(int projectId, int pageIndex, int pageSize);

        /// <summary>
        /// Gets all task of a user without paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IQueryable<Tasklist> GetTasklistsByProject(int projectId);

        /// <summary>
        /// Gets the project associate with this task.
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns>An instance of Project.</returns>
        Project GetProject(int taskListId);
    }
}
