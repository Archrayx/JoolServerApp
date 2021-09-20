using JoolServerApp.Data;
using JoolServerApp.Repo;
using JoolServerApp.Service;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
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
            IEnumerable<tblUser> Users = userRepo.GetAll();
            Debug.WriteLine(Users);
            IUserService tblService = new UserService(userRepo);
            IEnumerable<tblUser> usertwo = tblService.GetAllUsers();
            foreach (var item in usertwo)
            {
                Debug.WriteLine(item.User_Name);
            }

            //Debug.WriteLine(Users);
            //Debug.WriteLine(tblService.GetUser(1));
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