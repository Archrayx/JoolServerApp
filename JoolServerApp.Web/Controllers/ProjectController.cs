using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Service;
using JoolServerApp.Repo;

namespace JoolServerApp.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        // GET: Project
        public ProjectController(IProjectService projectService,IUserService userService)
        {
            this.projectService = projectService;
            this.userService = userService;
        }
        public ActionResult Project()
        {
            
            return View();
        }

 
    }
}