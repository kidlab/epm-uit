using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPM.Models;
using System.Web.Mvc; 

namespace EPM.Helpers
{
    public static class EPM_Auth
    {
        private static List<int> epm_action = new List<int>();
        private static List<int> epm_module = new List<int>();

        private static Role_Assigned role_assigned { get; set; }
        private static IRole_AssignedRepository _roleAssignedRepository = new Role_AssignedRepository();

        public static bool validAuth(int user_id, int project_id, string action, string module)
        {
            List<Role_Assigned> role_assigneds = getRole(user_id, project_id);
            bool error = true;
            foreach (Role_Assigned role_assigned in role_assigneds)
            {
                if (!isAllowedModule(role_assigned.role_id, module))
                {
                    error = false;
                }
                if (!isAllowedAction(role_assigned.role_id, action))
                {
                    error = false;
                }
            }
            return error;
        }

        private static List<Role_Assigned> getRole(int user_id, int project_id)
        {
            return _roleAssignedRepository.GetRolesByUserAndProject(user_id, project_id).ToList();
        }

        private static bool isAllowedModule(int role_id, string module)
        {
            List<Module> modules = _roleAssignedRepository.GetModuleByRole(role_id).ToList();
            bool isNotAllow = true;
            foreach(Module _module in modules)
            {
                if (_module.name.Equals(module))
                    isNotAllow = false;
            }

            return !isNotAllow;
        }

        private static bool isAllowedAction(int role_id, string action)
        {
            List<EPM.Models.Action> actions = _roleAssignedRepository.GetActionByRole(role_id).ToList();
            bool isNotAllow = true;
            foreach (EPM.Models.Action _action in actions)
            {
                if (_action.name.Equals(action))
                    isNotAllow = false;
            }

            return !isNotAllow;
        }
    }
}
