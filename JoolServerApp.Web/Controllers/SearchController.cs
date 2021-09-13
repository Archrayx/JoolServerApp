using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;
using JoolServerApp.Service;

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

        public ActionResult GetProducts(SearchVM obj)
        {

            var ProductsResult = from products in productService.GetAllProducts()
                                 from subcategory in subCategoryService.GetAllSubCategories()
                                 from category in categoryService.GetAllCategories()
                                 where obj.Category_Name == category.Category_Name && category.Category_ID == subcategory.Category_ID && obj.Product_Name == products.Product_Name
                                 select new { TblProduct = this.productService.GetProduct(products.Product_ID) };
                                        
            return RedirectToAction("ProductSummary", "Product", ProductsResult.ToList());
        }




    }
}