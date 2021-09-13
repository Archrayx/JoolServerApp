using JoolServerApp.Data;
using JoolServerApp.Service;
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
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        // GET: Product
        public ActionResult ProductSummary()
        {
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            return View();
        }

        [HttpPost]
        public ActionResult ProductSummary(SearchVM obj)
        {
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");

            return View();
        }


    }
}