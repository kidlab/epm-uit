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

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           /* routes.Add(
                new Route
                {
                    Url = "Milestone/[projectId]",
                    Defaults = new { controller = "Milestone", action = "Index", projectId = 0 },
                    RouteHandler = typeof(MvcRouteHandler)
                }
                ); */
            /*
            routes.MapRoute(
                "Milestone",
                "Milestone/Index/[projectId]",
                new { controller = "Milestone", action = "Index", projectId="" }
             );
            routes.MapRoute(
               "Milestone",
               "Milestone/{action}/{id}",
               new { controller = "Milestone", action = "Edit", id = "" }
           );
             */
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{projectId}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", projectId="", id = "" }  // Parameter defaults
            );
             
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}