using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Data;
using JoolServerApp.Repo;
using JoolServerApp.Service;
using JoolServerApp.Web.Models;
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
            IEnumerable<tblUser> Users = userService.GetAllUsers();
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetAllUsers().ToList().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.User_ID,
                    FirstName = $"{u.User_Name}",

                };
                model.Add(user);
            });

            return View();
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