using JoolServerApp.Data;
using JoolServerApp.Repo;
using JoolServerApp.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModel;

namespace JoolServerApp.Web.Controllers
{
    public class SearchController : Controller
    {
        private Data.JoolServerEntities db = new Data.JoolServerEntities();

        // GET: Search
        public ActionResult Search()
        {
            ViewBag.Category_Name = new SelectList(db.tblCategories, "Category_Name");
            return View();
        }

        // GET: Get Categories from DB
        [HttpGet]
        public ActionResult Search(SearchVM obj)
        {
            
            //IRepository<tblCategory> categoryRepo = new Repository<tblCategory>(db);
            //ICategoryService tblService = new CategoryService(categoryRepo);
            //IEnumerable<tblCategory> Categories = tblService.GetAllCategories();
            //foreach (var item in Categories)
            //{
            //    Debug.WriteLine(item.Category_Name);
            //}
            ViewBag.Category_Name = new SelectList(db.tblCategories, "Category_Name");
            return View("Search");
        }
    }
}