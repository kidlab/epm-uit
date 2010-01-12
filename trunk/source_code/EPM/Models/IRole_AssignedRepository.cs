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
    }
}
