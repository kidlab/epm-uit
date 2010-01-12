using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    public class Role_AssignedRepository: BaseModel, IRole_AssignedRepository
    {
        EpmDataContext db = new EpmDataContext();

        public List<Role> GetRoleByUser(int? id)
        {
            //get role assign match by user id
            IQueryable<Role_Assigned> ra = from RoleAssigned in db.Role_Assigneds
                            where RoleAssigned.user_id == id
                            select RoleAssigned;

            // find role match by each role assigns found
            Role_Assigned[] raList = ra.ToArray();
            List<Role> roleList = new List<Role>();
            RoleRepository roleRepository = new RoleRepository();
            foreach (var item in raList)
            {
                Role singleRole = roleRepository.GetOne(item.role_id);
                roleList.Add(singleRole);
            }
            return roleList;
        }

        public bool IsUserAssigned(int? userId, int? roleId) {
            IQueryable<Role_Assigned> ra = from role_assign in db.Role_Assigneds
                                           where role_assign.user_id == userId && role_assign.role_id == roleId
                                           select role_assign;
            return ra.ToList().Count > 0;
        }

        public Role_Assigned GetAssign(int? userId, int? roleId) {
            return db.Role_Assigneds.SingleOrDefault(ra => ra.user_id == userId && ra.role_id == roleId);
        }
        public Role_Assigned GetAssignGlobal(int? userId)
        {
            return db.Role_Assigneds.SingleOrDefault(ra => ra.user_id == userId);
        }

        //
        // from IRepository

        public Role_Assigned GetOne(int id) {
            return db.Role_Assigneds.SingleOrDefault(ra => ra.id == id);
        }

        public IQueryable<Role_Assigned> GetAll() {
            return db.Role_Assigneds;
        }

        public IQueryable<Role_Assigned> GetRolesByUserAndProject(int? user_id, int? project_id)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from role_assigned in _db.Role_Assigneds
                    join role in _db.Roles
                    on role_assigned.role_id equals role.id
                    where (role_assigned.user_id == user_id)
                        && (role.project_id == project_id)
                    select role_assigned;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Action> GetActionByRole(int role_id)
        {
            try
            {
                _refreshDataContext();

                var query =
                    from action in _db.Actions
                    join module_action in _db.Module_Actions
                    on action.id equals module_action.action_id
                    where (module_action.role_id == role_id)
                    select action;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public IQueryable<Module> GetModuleByRole(int role_id)
        {
            try
            {
                _refreshDataContext();

                var query =
                     from module in _db.Modules
                     join module_action in _db.Module_Actions
                     on module.id equals module_action.module_id
                     where (module_action.role_id == role_id)
                     select module;

                return query;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(TaskRepository), exc);
                throw new DbAccessException(exc);
            }
        }

        public void Add(Role_Assigned role_assigned) {
            db.Role_Assigneds.InsertOnSubmit(role_assigned);
        }

        public void Delete(Role_Assigned role_assigned) {
            db.Role_Assigneds.DeleteOnSubmit(role_assigned);
        }

        public void Save() {
            db.SubmitChanges();
        }

        //
        //
        //

    }
}
