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
    public class ProjectRepository : IProjectRepository
    {
        EpmDataContext db = new EpmDataContext();

        //
        // Query Methods

        public IQueryable<Project> FindAllProjects()
        {
            return db.Projects;
        }

      
        public Project GetProject(int id)
        {
            return db.Projects.SingleOrDefault(d => d.id == id);
        }

        //
        // Insert/Delete Methods

        public void Add(Project project)
        {
            db.Projects.InsertOnSubmit(project);
        }

        public void Delete(Project project)
        {
           db.Projects.DeleteOnSubmit(project);

        }

        //
        // Persistence 

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
