using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    /// <summary>
    /// Author: ToanNM
    /// Class: Interface Role Assigned
    /// </summary>
    public interface IRole_AssignedRepository : IRepository<Role_Assigned>
    {
        //IQueryable<User> GetUsersAssignedByProject(int? id);

        List<Role> GetRoleByUser(int? id);

        bool IsUserAssigned(int? userId, int? projectId);

        Role_Assigned GetAssign(int? userId, int? roleId);

        Role_Assigned GetAssignGlobal(int? userId);

        /// <summary>
        /// get all Roles by User's id and Project's id
        /// </summary>
        /// <returns>Role_Assigned</returns>
        IQueryable<Role_Assigned> GetRolesByUserAndProject(int? user_id, int? project_id);

        /// <summary>
        /// get all Action by User's id and Project's id
        /// </summary>
        /// <returns>Role_Assigned</returns>
        IQueryable<Action> GetActionByRole(int role_id);

        /// <summary>
        /// get all Module by User's id and Project's id
        /// </summary>
        /// <returns>Role_Assigned</returns>
        IQueryable<Module> GetModuleByRole(int role_id);

    }
}
