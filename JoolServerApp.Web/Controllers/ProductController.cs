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
        private readonly IDepartmentService deptService;

        public ProductController(ICategoryService categoryService, IProductService productService, IDepartmentService deptService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.deptService = deptService;
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

        public ActionResult ProductContact(SearchVM obj)
        {
            var result = from products in productService.GetAllProducts()
                         where products.Product_ID.ToString() == obj.Product_Name
                         select products;
            var departmentIDs = from ids in result.ToList()
                                  from deptids in deptService.GetAllDepartments()
                                  where ids.Manufacturer_ID == deptids.Manufacturer_ID
                                  select deptids;
            TempData["Product_ID"] = departmentIDs.ToList();
            return RedirectToAction("Contact", "Contact");
        }


    }
}