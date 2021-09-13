using JoolServerApp.Data;
using JoolServerApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Web.ViewModels;
using System.Diagnostics;

namespace JoolServerApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly IDocumentService documentService;
        private readonly IManufacturerService manufacturerService;
        private readonly ISaleService saleService;
        private readonly ISubCategoryService subCategoryService;

        public AdminController(IProductService productService, IDocumentService documentService, IManufacturerService manufacturerService, ISaleService saleService, ISubCategoryService subCategoryService)
        {
            this.productService = productService;
            this.documentService = documentService;
            this.manufacturerService = manufacturerService;
            this.saleService = saleService;
            this.subCategoryService = subCategoryService;
        }
        // GET: tblProducts
        public ActionResult Index()
        {
            var tblProducts = this.productService.GetAllProducts();
            return View(tblProducts);
        }

        // GET: tblProducts/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblProduct = this.productService.GetProduct(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: tblProducts/Create
        public ActionResult Create()
        {
            ViewBag.Document_ID = new SelectList(this.documentService.GetAllDocuments(), "Document_ID", "Document_Folder_Path");
            ViewBag.Manufacturer_ID = new SelectList(this.manufacturerService.GetAllManufacturers(), "Manufacturer_ID", "Manufacturer_Name");
            ViewBag.Sales_ID = new SelectList(this.saleService.GetAllSales(), "Sales_ID", "Sales_Name");
            ViewBag.SubCategory_ID = new SelectList(this.subCategoryService.GetAllSubCategories(), "SubCategory_ID", "SubCategory_Name");
            return View();
        }

        // POST: tblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminVM obj, HttpPostedFileBase ImageData)
        {
            Debug.WriteLine(obj.Manufacturer_ID + obj.Sales_ID+obj.Document_ID+obj.SubCategory_ID);
            if (ModelState.IsValid)
            {
                obj.Product_Image = new byte[ImageData.ContentLength];
                ImageData.InputStream.Read(obj.Product_Image, 0, ImageData.ContentLength);
                tblProduct tempProduct = new tblProduct
                {
                    Manufacturer_ID = obj.Manufacturer_ID,
                    Sales_ID = obj.Sales_ID,
                    SubCategory_ID = obj.SubCategory_ID,
                    Product_Name = obj.Product_Name,
                    Product_Image = obj.Product_Image,
                    Series = obj.Series,
                    Model = obj.Model,
                    Model_Year = obj.Model_Year,
                    Series_Info = obj.Series_Info,
                    Document_ID = obj.Document_ID,
                    Featured = obj.Featured
                };
                this.productService.insertProduct(tempProduct);



                ViewBag.Document_ID = new SelectList(this.documentService.GetAllDocuments(), "Document_ID", "Document_Folder_Path");
                ViewBag.Manufacturer_ID = new SelectList(this.manufacturerService.GetAllManufacturers(), "Manufacturer_ID", "Manufacturer_Name");
                ViewBag.Sales_ID = new SelectList(this.saleService.GetAllSales(), "Sales_ID", "Sales_Name");
                ViewBag.SubCategory_ID = new SelectList(this.subCategoryService.GetAllSubCategories(), "SubCategory_ID", "SubCategory_Name");
                return View();
            }
            return View();
        }

        // GET: tblProducts/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblProduct = this.productService.GetProduct(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Document_ID = new SelectList(this.documentService.GetAllDocuments(), "Document_ID", "Document_Folder_Path", tblProduct.Document_ID);
            ViewBag.Manufacturer_ID = new SelectList(this.manufacturerService.GetAllManufacturers(), "Manufacturer_ID", "Manufacturer_Name", tblProduct.Manufacturer_ID);
            ViewBag.Sales_ID = new SelectList(this.saleService.GetAllSales(), "Sales_ID", "Sales_Name", tblProduct.Sales_ID);
            ViewBag.SubCategory_ID = new SelectList(this.subCategoryService.GetAllSubCategories(), "SubCategory_ID", "SubCategory_Name", tblProduct.SubCategory_ID);
            return View(tblProduct);
        }

        // POST: tblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Manufacturer_ID,Sales_ID,SubCategory_ID,Product_Name,Product_Image,Series,Model,Model_Year,Series_Info,Document_ID,Featured")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                this.productService.UpdateProduct(tblProduct);
                return RedirectToAction("Index");
            }
            ViewBag.Document_ID = new SelectList(this.documentService.GetAllDocuments(), "Document_ID", "Document_Folder_Path", tblProduct.Document_ID);
            ViewBag.Manufacturer_ID = new SelectList(this.manufacturerService.GetAllManufacturers(), "Manufacturer_ID", "Manufacturer_Name", tblProduct.Manufacturer_ID);
            ViewBag.Sales_ID = new SelectList(this.saleService.GetAllSales(), "Sales_ID", "Sales_Name", tblProduct.Sales_ID);
            ViewBag.SubCategory_ID = new SelectList(this.subCategoryService.GetAllSubCategories(), "SubCategory_ID", "SubCategory_Name", tblProduct.SubCategory_ID);
            return View(tblProduct);
        }

        // GET: tblProducts/Delete/5
        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = this.productService.GetProduct(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: tblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

       
    }
}