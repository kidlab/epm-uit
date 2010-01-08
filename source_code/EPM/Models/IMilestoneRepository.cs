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
    public interface IMilestoneRepository
    {
        IQueryable<Milestone> FindAllMilestones();
        IQueryable<Milestone> FindAllMilestonesByProjectId(int projectId);
        Milestone GetMilestone(int id);

        void Add(Milestone milestone);
        void Delete(Milestone milestone);

        void Save();
    }
}
