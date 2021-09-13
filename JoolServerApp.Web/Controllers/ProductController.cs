using JoolServerApp.Data;
using JoolServerApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();

        // GET: Product
        public ActionResult ProductSummary()
        {
            ViewBag.Category_Name = new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(db.tblProducts, "Product_ID", "Product_Name");
            return View();
        }

        [HttpPost]
        public ActionResult ProductSummary(SearchVM obj)
        {
            ViewBag.Product_Name = new SelectList(db.tblProducts, "Product_ID", "Product_Name");
            ViewBag.Category_Name = new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            return View();
        }
    }
}