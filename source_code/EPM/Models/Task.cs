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
    [Bind(Include = "id,tasklist_id,start,end,title,desc,status")]
    public partial class Task
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(title))
                yield return new RuleViolation("Task Title required", "name");

            if (end.CompareTo(start) < 0)
                yield return new RuleViolation("Deadline must less than or equal to start datetime", "Deadline");

            yield break;
        }
    }
}
