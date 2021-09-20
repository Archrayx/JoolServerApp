using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Service;
using JoolServerApp.Repo;
using JoolServerApp.Web.ViewModels;
using JoolServerApp.Data;
using System.Net;

namespace JoolServerApp.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly ICityService cityService;
        private readonly IStateService stateService;
        // GET: Project
        public ProjectController(IProjectService projectService,IUserService userService,ICityService cityService,IStateService stateService)
        {
            this.projectService = projectService;
            this.userService = userService;
            this.cityService = cityService;
            this.stateService = stateService;
        }
        public ActionResult Project()
        {
            List<ProjectVM> ProjectResults = (from project in projectService.GetAllProjects()
                                 join city in cityService.GetAllCities() on project.Project_City equals city.City_ID
                                 join state in stateService.GetAllStates() on project.Project_State equals state.State_ID
                                 where (string)Session["UserName"] == project.User_Id.ToString()
                                 select new ProjectVM{
                                     Project_ID=project.Project_ID,
                                     Project_Name=project.Project_Name,
                                     Project_Address1=project.Project_Address1,
                                     Project_Address2=project.Project_Address2,
                                     Project_City=city.City_Name,
                                     Project_State=state.State_Name,
                                     Project_Size=project.Project_Size,
                                     Client_Name=project.Client_Name,
                                     
                                    }).ToList();

            return View("Project",ProjectResults);
        }
        public ActionResult ProjectClick(ProjectVM project) 
        {
            
            return View("ProjectItemDisplay",project);
        }

        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblProject = this.projectService.GetProject(id);
            if (tblProject == null)
            {
                return HttpNotFound();
            }
           
            return View(tblProject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectEdit([Bind(Include = "Project_ID,Project_Name,User_ID,Project_Address1,Project_Address2,Project_City,Project_State,Project_Size,Client_Name")] tblProject tblProject)
        {
            if (ModelState.IsValid)
            {
                this.projectService.UpdateProject(tblProject);
                return RedirectToAction("Project");
            }
            List<ProjectVM> ProjectResults = (from project in projectService.GetAllProjects()
                                              join city in cityService.GetAllCities() on project.Project_City equals city.City_ID
                                              join state in stateService.GetAllStates() on project.Project_State equals state.State_ID
                                              where (string)Session["UserName"] == project.User_Id.ToString()
                                              select new ProjectVM
                                              {
                                                  Project_ID = project.Project_ID,
                                                  Project_Name = project.Project_Name,
                                                  Project_Address1 = project.Project_Address1,
                                                  Project_Address2 = project.Project_Address2,
                                                  Project_City = city.City_Name,
                                                  Project_State = state.State_Name,
                                                  Project_Size = project.Project_Size,
                                                  Client_Name = project.Client_Name,

                                              }).ToList();

            return View("Project", ProjectResults);
        }
        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProject tblProject = this.projectService.GetProject(id);
            if (tblProject == null)
            {
                return HttpNotFound();
            }
            return View(tblProject);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.projectService.DeleteProject(id);
            return RedirectToAction("Project");
        }



 
    }
}