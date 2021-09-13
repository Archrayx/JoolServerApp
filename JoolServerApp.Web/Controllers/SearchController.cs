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

            
            ViewBag.Category_Name += new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            ViewBag.Product_Name += new SelectList(db.tblProducts, "Product_ID", "Product_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchVM obj)
        {
            ViewBag.Product_Name = "Search";
            ViewBag.Category_Name = "Category";
            ViewBag.Product_Name += new SelectList(db.tblProducts, "Product_ID", "Product_Name");
            ViewBag.Category_Name += new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            return View();
        }
    }
}