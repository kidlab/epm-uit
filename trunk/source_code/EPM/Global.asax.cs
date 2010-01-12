using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration; 


namespace EPM
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Changed on 2010-01-10
    /// By: HaiLD.
    /// @description: 
    ///     - configure route url with two parameters.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          
         
            routes.MapRoute(
                "Milestone",
                "Milestone/{action}/{projectId}/{id}",
                new { controller = "Milestone", action = "Index", projectId="", id = "" }
             );
            routes.MapRoute(
               "Tasklist",
               "Tasklist/{action}/{projectId}/{id}",
               new { controller = "Tasklist", action = "Index", projectId = "", id = "" }
            );

            routes.MapRoute(
               "ProjectUser",
               "Project/UserRemove/{projectId}/{id}",
               new { controller = "Project", action = "UserRemove", projectId = "", id = "" }
            );         
           
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", projectId="", id = "" }  // Parameter defaults
            );
             
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}