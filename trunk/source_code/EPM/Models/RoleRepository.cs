using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    public class RoleRepository : BaseModel, IRoleRepository
    {
        //query method
        public IQueryable<Role> GetAll()
        {
            return _db.Roles;
        }
        public IQueryable<Role> GetGlobalRoles()
        {
            return from role in _db.Roles
                   where role.project_id == null
                   select role;
        }
        public IQueryable<Role> GetRolesByProject(int? id)
        {
            return from role in _db.Roles
                   where role.project_id == id
                   select role;
        }

        public Role GetOne(int id)
        {
            return _db.Roles.SingleOrDefault(r => r.id == id);
        }

        // insert/delete method
        public void Add(Role role)
        {
            try
            {
                _db.Roles.InsertOnSubmit(role);
                Save();
                foreach (Module_Action ma in role.ModuleActions)
                {
                    ma.role_id = role.id;
                }

                _db.Module_Actions.InsertAllOnSubmit(role.ModuleActions.AsEnumerable());
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RoleRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Delete(Role role)
        {
            _db.Roles.DeleteOnSubmit(role);
        }

        public void DeleteById(int? id)
        {
            Role role = _db.Roles.SingleOrDefault(r => r.id == id);
            _db.Roles.DeleteOnSubmit(role);
        }

        public Module GetModuleByName(string moduleName)
        {
            try
            {
                _refreshDataContext();
                return _db.Modules.SingleOrDefault(m => m.name == moduleName);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RoleRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public Action GetActionByName(string actionName)
        {
            try
            {
                _refreshDataContext();
                return _db.Actions.SingleOrDefault(a => a.name == actionName);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RoleRepository), exc);
                throw new DbAccessException(exc);
            }
        }
    }
}