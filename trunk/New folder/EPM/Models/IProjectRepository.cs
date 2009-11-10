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
    public interface IProjectRepository
    {
        IQueryable<Project> FindAllProjects();
        Project GetProject(int id);

        void Add(Project project);
        void Delete(Project project);

        void Save();
    }
}
