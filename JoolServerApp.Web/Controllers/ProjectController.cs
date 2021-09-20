using JoolServerApp.Data;
using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly ICityService cityService;
        private readonly IStateService stateService;

        // GET: Project
        public ProjectController(IProjectService projectService, IUserService userService, ICityService cityService, IStateService stateService)
        {
            this.projectService = projectService;
            this.userService = userService;
            this.cityService = cityService;
            this.stateService = stateService;
        }
        public ActionResult Project()
        {
            int user_id = (from user in this.userService.GetAllUsers()
             where user.User_Name == Session["UserName"].ToString()
             select user.User_ID).FirstOrDefault();
            List<ProjectVM> ProjectResults = (from project in projectService.GetAllProjects()
                                              join city in cityService.GetAllCities() on project.Project_City equals city.City_ID
                                              join state in stateService.GetAllStates() on project.Project_State equals state.State_ID
                                              where user_id == project.User_Id
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
        public ActionResult ProjectClick(long id)
        {
            return RedirectToAction("ProjectItemDisplay", "ProjectItemDisplay", id);
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
            ViewBag.User_Id = new SelectList(this.userService.GetAllUsers(), "User_Id", "User_Name", tblProject.User_Id);
            ViewBag.City_ID = new SelectList(this.cityService.GetAllCities(), "Project_City", "City_Name", tblProject.Project_City);
            ViewBag.State_ID = new SelectList(this.stateService.GetAllStates(), "Project_State", "State_Name", tblProject.Project_State);

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
            ViewBag.User_Id = new SelectList(this.userService.GetAllUsers(), "User_Id", "User_Name", tblProject.User_Id);
            ViewBag.City_ID = new SelectList(this.cityService.GetAllCities(), "Project_City", "City_Name", tblProject.Project_City);
            ViewBag.State_ID = new SelectList(this.stateService.GetAllStates(), "Project_State", "State_Name", tblProject.Project_State);

            return View(tblProject);
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