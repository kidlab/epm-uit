using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPM.Models
{
    public class RoleRepository : IRoleRepository
    {
        private EpmDataContext db = new EpmDataContext();

        //query method
        public IQueryable<Role> GetAll() {
            return db.Roles;
        }
        public IQueryable<Role> GetGlobalRoles() {
            return from role in db.Roles
                   where role.project_id == null
                   select role;
        }        
        public IQueryable<Role> GetRolesByProject(int? id)
        {
            return from role in db.Roles
                   where role.project_id == id
                   select role;
        }
        public Role GetOne(int id)
        {
            return db.Roles.SingleOrDefault(r => r.id == id);
        }


        // insert/delete method
        public void Add(Role role) {
            db.Roles.InsertOnSubmit(role);
        }

        public void Delete(Role role) {
            db.Roles.DeleteOnSubmit(role);
        }

        public void DeleteById(int? id) {
            Role role = db.Roles.SingleOrDefault(r => r.id == id);
            db.Roles.DeleteOnSubmit(role);
        }

        //save
        public void Save() {
            db.SubmitChanges();
        }
    }
}
