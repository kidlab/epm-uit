using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EPM.Models
{
    /// <summary>
    /// IProjectRepository.
    /// </summary>
    /// <remarks>
    /// Changed on 2010-01-06
    /// By: ManVHT.
    /// @description:
    ///     - Add 2 methods: GetProjectsByUser and GetProjects.
    ///     
    /// Changed on 2010-01-07
    /// By: ManVHT.
    /// @description:
    ///     - Inherit from the generic interface IRepository<T>.
    /// </remarks>
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Gets projects of a user with paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<Project> GetProjectsByUser(int userID, int pageIndex, int pageSize);

        /// <summary>
        /// Gets all projects of a user without paginating.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IQueryable<Project> GetProjectsByUser(int userID);

        IQueryable<Project> GetProjects(int pageIndex, int pageSize);
    }
}
