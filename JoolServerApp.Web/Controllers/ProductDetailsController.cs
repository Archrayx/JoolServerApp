using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Service;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;

namespace JoolServerApp.Web.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductService productService;

        public ProductDetailsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: ProductDetails
        public ActionResult ProductDetails(int id)
        {
            var item = this.productService.GetProduct(id);

            ProductDetailsVM product = new ProductDetailsVM();
            product.Product_ID = item.Product_ID;
            product.Product_Name = item.Product_Name;
            product.Series = item.Series;
            product.Model = item.Model;
            product.Manufacturer_ID = item.Manufacturer_ID;
            product.Sales_ID = item.Sales_ID;
            product.Series_Info = item.Series_Info;
            product.SubCategory_ID = item.SubCategory_ID;


            return View("ProductDetails", product);
        }
    }
}