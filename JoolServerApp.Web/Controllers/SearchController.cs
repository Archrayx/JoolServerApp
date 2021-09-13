using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;
using JoolServerApp.Service;
using System.Diagnostics;

namespace JoolServerApp.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly ISubCategoryService subCategoryService;

        public SearchController(ICategoryService categoryService, IProductService productService, ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
            this.categoryService = categoryService;
            this.productService = productService;
        }
      
        // GET: Search
        public ActionResult Search()
        {
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchVM obj)
        {
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            return View();
        }
        [HttpPost]
        public ActionResult GetProducts(SearchVM obj)
        {

            var ProductResults = from products in productService.GetAllProducts()
                                 from subcat in subCategoryService.GetAllSubCategories()
                                 join cat in categoryService.GetAllCategories() on subcat.Category_ID equals cat.Category_ID
                                 where obj.Product_Name == products.Product_ID.ToString() && obj.Category_Name == cat.Category_ID.ToString()
                                 select products;

            ProductResults = ProductResults.ToList();

            return RedirectToAction("ProductSummary", "Product", ProductResults);
        }




    }
}