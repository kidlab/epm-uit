using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMClient
{
    class ErrorMsg
    {
        public const string ERR_NO_USERNAME = "Please enter username";
        public const string ERR_NO_PASSWORD = "Please enter password";
        public const string ERR_CONNECT_FAILED = "Cannot connect to the service";
        public const string ERR_LOGIN_FAILED = "Cannot login to the service. Check your username and password";

        public const string ERR_LOAD_PROJECTS_FAILED = "Cannot load your projects";
        public const string ERR_LOAD_TASKS_FAILED = "Cannot load your tasks";
    }
}
