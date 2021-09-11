using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;

namespace JoolServerApp.Web.Controllers
{
    public class SearchController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();
        // GET: Search
        public ActionResult Search()
        {

            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchVM obj)
        {

            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_Name");
            return View();
        }
    }
}