using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using Common;

namespace EPM.Models
{
    //[Bind(Include = "id, name, email, phone, password, company, gender, address, country, admin")]
    public partial class User
    {
        public bool IsFemale
        {
            get { return gender == EpmConst.FEMALE; }
        }

        public bool IsAdmin
        {
            get { return admin == EpmConst.ADMIN; }
        }

        public bool IsValid
		{
			get { return (GetRuleViolations().Count() == 0); }
		}

        public IEnumerable<RuleViolation> GetRuleViolations()
        {

            if (String.IsNullOrEmpty(name))
                yield return new RuleViolation("Name required", "Name");

            if (String.IsNullOrEmpty(email))
                yield return new RuleViolation("Email required", "Email");

            if (String.IsNullOrEmpty(password))
                yield return new RuleViolation("Password required", "Password");
            if (gender < 0)
                yield return new RuleViolation("Gender required", "Gender");

            if (admin < 0)
                yield return new RuleViolation("IsAdmin required", "IsAdmin");

            yield break;
        }
    }
}
