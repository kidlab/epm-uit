using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// get Role list by Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<Role> GetRolesByProject(int? id);

        /// <summary>
        /// get all global Roles
        /// </summary>
        /// <returns></returns>
        IQueryable<Role> GetGlobalRoles();        
    }
}
