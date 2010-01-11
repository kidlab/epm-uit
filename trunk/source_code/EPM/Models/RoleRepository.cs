using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPM.Models
{
    public class RoleRepository : BaseModel, IUserRepository
    {
        EpmDataContext db = new EpmDataContext();
    }
}
