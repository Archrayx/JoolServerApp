using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IDepartmentService deptService;
        private readonly IUserService userService;

        public ProductController(IUserService userService,IDocumentService documentService, ICategoryService categoryService, IProductService productService, IDepartmentService deptService, IManufacturerService manufactureService)
        {
            this.userService = userService;
            this.categoryService = categoryService;
            this.productService = productService;
            this.deptService = deptService;
            ViewBag.userIMG = from user in this.userService.GetAllUsers()
                                   where user.User_Name == Session["UserName"].ToString()
                                   select user.User_Image;

        }

        // GET: Product
        public ActionResult ProductSummary()
        {
            Debug.WriteLine(Session["UserName"]);
            
            ViewBag.userIMG = (from user in this.userService.GetAllUsers()
                              where user.User_Name == Session["UserName"].ToString()
                              select user.User_Image).FirstOrDefault();
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            List<ProductVM> products = (from product in this.productService.GetAllProducts()
                                        select new ProductVM
                                        {
                                            Product_ID = product.Product_ID,
                                            Product_Name = product.Product_Name,
                                            Product_Image = product.Product_Image,
                                            Series = product.Series,
                                            Model = product.Model,
                                            Series_Info = product.Series_Info,
                                        }).ToList();


            return View("ProductSummary", products);
        }

        [HttpPost]
        public ActionResult ProductSummary(SearchVM obj)
        {
            Debug.WriteLine(Session["UserName"]);
            ViewBag.userIMG = (from user in this.userService.GetAllUsers()
                              where user.User_Name == Session["UserName"].ToString()
                              select user.User_Image).FirstOrDefault();
            ViewBag.Category_Name = new SelectList(this.categoryService.GetAllCategories(), "Category_ID", "Category_Name");
            ViewBag.Product_Name = new SelectList(this.productService.GetAllProducts(), "Product_ID", "Product_Name");
            List<ProductVM> products = (from product in this.productService.GetAllProducts()
                                        select new ProductVM
                                        {
                                            Product_Image = product.Product_Image,
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