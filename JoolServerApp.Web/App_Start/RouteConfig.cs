using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JoolServerApp.Service;
namespace JoolServerApp.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "tblSubCategories/Index",
                url: "tblSubCategories",
                defaults: new { controller = "tblSubCategories", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblSubCategories/Create",
                url: "tblSubCategories/Create",
                defaults: new { controller = "tblSubCategories", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblSubCategories/Delete",
                url: "tblSubCategories/Delete",
                defaults: new { controller = "tblSubCategories", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblSubCategories/Details",
                url: "tblSubCategories/Details",
                defaults: new { controller = "tblSubCategories", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblSubCategories/Edit",
                url: "tblSubCategories/Edit",
                defaults: new { controller = "tblProducts", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblProducts/Index",
                url: "tblProducts",
                defaults: new { controller = "tblProducts", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblProducts/Create",
                url: "tblProducts/Create",
                defaults: new { controller = "tblProducts", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblProducts/Delete",
                url: "tblProducts/Delete",
                defaults: new { controller = "tblProducts", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblProducts/Details",
                url: "tblProducts/Details",
                defaults: new { controller = "tblProducts", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tblProducts/Edit",
                url: "tblProducts/Edit",
                defaults: new { controller = "tblProducts", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register/Create",
                url: "Register/Create",
                defaults: new { controller = "Register", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register/Delete",
                url: "Register/Delete",
                defaults: new { controller = "Register", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register/Details",
                url: "Register/Details",
                defaults: new { controller = "Register", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register/Edit",
                url: "Register/Edit",
                defaults: new { controller = "Register", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register/Index",
                url: "Register",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductSummary",
                url: "ProductSummary",
                defaults: new { controller = "Product", action = "ProductSummary", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
        }
       
    }
}
