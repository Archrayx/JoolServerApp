using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Data;
using JoolServerApp.Repo;
using JoolServerApp.Service;
using JoolServerApp.Web.Models;
using Microsoft.Ajax.Utilities;
//using Microsoft.Extensions.DependencyInjection;

namespace JoolServerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }
        private readonly IUserService userService;


        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            Repo.JoolServerEntities db = new Repo.JoolServerEntities();
            IRepository<tblUser> userRepo = new Repository<tblUser>(db);
            var userDetails = db.tblUsers;
            IUserService tblService = new UserService(userRepo);
            IEnumerable<tblUser> Users = tblService.GetAllUsers();

            /*
            List<UserViewModel> model = new List<UserViewModel>();
            
             tblService.GetAllUsers().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.User_ID,
                    FirstName = $"{u.User_Name}",

                };
                model.Add(user);
            });
            */
            Debug.WriteLine(Users);

            return View(Users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}