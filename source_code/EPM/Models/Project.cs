﻿using System;
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
using System.Web.Mvc;
using System.Collections.Generic;

namespace EPM.Models
{
    [Bind(Include = "id,name,start,end,status,desc,budget")]
    public partial class Project
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(name))
                yield return new RuleViolation("Name required", "Name");
            yield break;
        }

        public int GetDayLeft()
        {
            if (start == null || end == null)
                return 0;

            return (int)start.Value.Subtract(end.Value).TotalDays;
        }
    } 
}
 
   
 
   

