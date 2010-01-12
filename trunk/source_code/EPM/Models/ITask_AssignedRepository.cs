using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    public interface ITask_AssignedRepository : IRepository<Task_Assigned>
    {
        /// <summary>
        /// Gets all task of a user with paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<Task_Assigned> GetTaskAssignedByUser(int userID, int pageIndex, int pageSize);

        /// <summary>
        /// Gets all task of a user without paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IQueryable<Task_Assigned> GetTaskAssignedByUser(int userID);

        /// <summary>
        /// Gets all task of a user without paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="projectID"></param>
        /// <returns></returns>
        IQueryable<Task_Assigned> GetTaskByUserProjectId(int userID, int projectID);

        /// <summary>
        /// Gets the project associate with this task.
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns>An instance of Project.</returns>
      
    }
}
