using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarcomSurvey
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MyRoute",
                url: "{action}/{brand}/{surveyName}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    brand = UrlParameter.Optional,
                    surveyName = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{brand}/{surveyName}",
                defaults: new { controller = "Home", action = "Index", 
                    brand = UrlParameter.Optional,
                    surveyName = UrlParameter.Optional}
            );


        }
    }
}