using JoolServerApp.Data;
using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };
                obj.User_Image = ImageData.ToString();
                var fileName = Path.GetFileName(ImageData.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(ImageData.FileName); //getting the extension(ex-.jpg)  
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name + "_" + obj.User_Name + ext; //appending the name with id  
                                                               // store the file inside ~/project folder(Img)  
                    var path = Path.Combine(Server.MapPath("~/Document/UserIMG"), myfile);
                    tblUser tempUSR = new tblUser
                    {
                        User_Name = obj.User_Name,
                        User_Email = obj.User_Email,
                        User_Image = path,
                        user_Password = obj.user_Password,
                        Credential_ID = 1
                    };
                }
                
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
                Session["UserID"] = userDetails.User_ID;
                Session["Role"] = userDetails.Credential_ID;
                Session["UserName"] = userDetails.User_Name;
                FormsAuthentication.SetAuthCookie(userDetails.User_Name, true);
                return RedirectToAction("Search", "Search");
            }

        }
    }
}