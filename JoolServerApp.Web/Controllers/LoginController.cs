﻿using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using JoolServerApp.Web.ViewModels;
using System.Web.Security;
using JoolServerApp.Service;

namespace JoolServerApp.Web.Controllers
 
{
    public class LoginController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();
        
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }




        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            List<CreateVM> model = new List<CreateVM>();
            this.userService.GetAllUsers().ToList().ForEach(u =>
            {
                CreateVM user = new CreateVM
                {
                    User_Email = u.User_Email,
                    User_Name = u.User_Name,
                    user_Password = u.user_Password
                };
                model.Add(user);

            });
            return View(model);
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CreateVM obj)
        {
            if (obj.user_Password == obj.confirm_Password && obj.user_Password != null)
            {
                tblUser tempUSR = new tblUser
                {
                    User_Name = obj.User_Name,
                    User_Email = obj.User_Email,
                    user_Password = obj.user_Password,
                    Credential_ID = 1
                };
                if (ModelState.IsValid)
                {
                    db.tblUsers.Add(tempUSR);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(CreateVM obj)
        {
            var userDetails = db.tblUsers.Where(x => x.User_Name == obj.User_Name && x.user_Password == obj.user_Password).FirstOrDefault();
            if (userDetails == null)
            {
                userDetails = db.tblUsers.Where(x => x.User_Email == obj.User_Name && x.user_Password == obj.user_Password).FirstOrDefault();
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