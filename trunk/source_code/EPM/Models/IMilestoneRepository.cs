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
    /// IMilestoneRepository
    /// </summary>
    /// <remarks>  
    /// Changed on 2010-01-09
    /// By: ManVHT.
    /// @description:
    ///     - Inherit from the generic interface IRepository<T>.
    ///     - Changed names of methods.
    /// </remarks>
    public interface IMilestoneRepository : IRepository<Milestone>
    {
        IQueryable<Milestone> FindAllMilestonesByProjectId(int projectId);
    }
}
