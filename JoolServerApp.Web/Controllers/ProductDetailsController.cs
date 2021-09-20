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

            ProductDetailsVM product = new ProductDetailsVM
            {
                Product_ID = item.Product_ID,
                Product_Name = item.Product_Name,
                Series = item.Series,
                Model = item.Model,
                Manufacturer_ID = item.Manufacturer_ID,
                Sales_ID = item.Sales_ID,
                Series_Info = item.Series_Info,
                SubCategory_ID = item.SubCategory_ID,
                Document_ID = item.Document_ID
                
            };


            return View("ProductDetails", product);
        }
    }
}