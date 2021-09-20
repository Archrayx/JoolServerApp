using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IDepartmentService deptService;
        public ProductController(IDocumentService documentService, ICategoryService categoryService, IProductService productService, IDepartmentService deptService, IManufacturerService manufactureService)
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
            List<ProductVM> products = (from product in this.productService.GetAllProducts()
                                        select new ProductVM
                                        {
                                            Product_ID = product.Product_ID,
                                            Product_Name = product.Product_Name,
                                            Series = product.Series,
                                            Model = product.Model,
                                            Series_Info = product.Series_Info,
                                        }).ToList();


            return View("ProductSummary", products);
        }

        [HttpPost]
        public ActionResult ProductSummary(SearchVM obj)
        {
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            List<ProductVM> products = (from product in this.productService.GetAllProducts()
                                        select new ProductVM
                                        {
                                            Product_ID = product.Product_ID,
                                            Product_Name = product.Product_Name,
                                            Series = product.Series,
                                            Model = product.Model,
                                            Series_Info = product.Series_Info,
                                        }).ToList();


            return View("ProductSummary", products);

        }
    }

}