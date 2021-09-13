using System;
using JoolServerApp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;

namespace JoolServerApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();
        // GET: Product
        public ActionResult ProductSummary()
        {

            List<ProductVM> products = (from product in db.tblProducts
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