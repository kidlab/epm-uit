﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPM.Models
{
    public partial class Role
    {
        public List<Module_Action> ModuleActions { get; set; }
    }
}
