﻿using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using JoolServerApp.Web.ViewModels;

namespace JoolServerApp.Web.Controllers
{
    public class LoginController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
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
    }
}