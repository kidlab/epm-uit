using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace EPM.Models
{
    public partial class Task
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(title))
                yield return new RuleViolation("Task Name required", "Name");

            if (end.CompareTo(start) < 0)
                yield return new RuleViolation("Deadline must less than or equal to start datetime", "Deadline");

            yield break;
        }
    }
}
