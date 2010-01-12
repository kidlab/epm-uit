using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using EPM.Models;
using EPM.Helpers;
using Common;

namespace EPM.Controllers
{
    public class LoginController : Controller 
    {
        public User user { get; private set; }
        public IUserRepository userModel = new UserRepository();

        public ActionResult index()
        {           
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            User user = userModel.getExistUser(username,password) ;
            if (user == null)
            {
                return View();
            }
            else
            {
                HttpContext.Session["user"] = user;
                return this.Redirect("/");
            }            
        }
        public ActionResult logout()
        {
            HttpContext.Session["user"] = null;
            return this.Redirect("/Login");
           
        }
        
    }
}
