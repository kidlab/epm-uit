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
        public static List<int> epm_action = new List<int>();
        public static List<int> epm_module = new List<int>();

        public static void validAuth(int user_id, int project_id, int action, int module)
        {
            List<Role> roles = getRole(user_id, project_id);

            foreach (Role role in roles)
            {
                validModule(role, module);
                validAction(role, action);
            }
        }

        private static List<Role> getRole(int user_id, int project_id)
        {
            return new List<Role>();
        }

        private static void validModule(Role role, int module)
        {
        }

        private static void validAction(Role role, int action)
        {
        }
    }
}
