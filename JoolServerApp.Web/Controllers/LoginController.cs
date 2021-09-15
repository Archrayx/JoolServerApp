using JoolServerApp.Data;
using System.Linq;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;
using System.Web.Security;
using JoolServerApp.Service;
using System.Web;
using System.IO;

namespace JoolServerApp.Web.Controllers

{
    public class LoginController : Controller
    {
        
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }




        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CreateVM obj, HttpPostedFileBase ImageData)
        {
            if (obj.user_Password == obj.confirm_Password && obj.user_Password != null)
            {               

                obj.User_Image = new byte[ImageData.ContentLength];
                ImageData.InputStream.Read(obj.User_Image,0,ImageData.ContentLength);
                tblUser tempUSR = new tblUser
                {
                    User_Name = obj.User_Name,
                    User_Email = obj.User_Email,
                    User_Image = obj.User_Image,
                    user_Password = obj.user_Password,
                    Credential_ID = 1
                };
                if (ModelState.IsValid)
                {
                    this.userService.insertUser(tempUSR);
                    return RedirectToAction("Login");
                }
            }
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(CreateVM obj)
        {
            var userDetails = this.userService.GetAllUsers().Where(x => x.User_Name == obj.User_Name && x.user_Password == obj.user_Password).FirstOrDefault();
            if (userDetails == null)
            {
                userDetails = this.userService.GetAllUsers().Where(x => x.User_Email == obj.User_Name && x.user_Password == obj.user_Password).FirstOrDefault();
            }
            if (userDetails == null)
            {
                return View("Login");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.User_Name, true);
                return RedirectToAction("Search", "Search");
            }
               
        }
    }
}