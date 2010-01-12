using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPM.Models
{
    public class Project_AssignedRepository : IProject_AssignedRepository
    {
        EpmDataContext db = new EpmDataContext();

        public Project_Assigned GetByProjectAndUser(int projectId, int userId)
        {
            return db.Project_Assigneds.SingleOrDefault(pa => pa.user_id == userId && pa.project_id == projectId);
        }

        //
        public IQueryable<Project_Assigned> GetAll()
        {
            return db.Project_Assigneds;
        }

        public Project_Assigned GetOne(int id) {
            return db.Project_Assigneds.SingleOrDefault(pa => pa.id == id);
        }

        public void Add(Project_Assigned obj)
        {
            db.Project_Assigneds.InsertOnSubmit(obj);
        }
        public void Delete(Project_Assigned obj)
        {
            db.Project_Assigneds.DeleteOnSubmit(obj);
        }
        public void Save() {
            db.SubmitChanges();
        }
    }
}
