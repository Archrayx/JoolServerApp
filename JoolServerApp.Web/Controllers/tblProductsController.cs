﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Data;


namespace JoolServerApp.Web.Controllers
{
    public class tblProductsController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();

        // GET: tblProducts
        public ActionResult Index()
        {
            var tblProducts = db.tblProducts.Include(t => t.tblDocument).Include(t => t.tblManufacturer).Include(t => t.tblSale).Include(t => t.tblSubCategory);
            return View(tblProducts.ToList());
        }

        // GET: tblProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: tblProducts/Create
        public ActionResult Create()
        {
            ViewBag.Document_ID = new SelectList(db.tblDocuments, "Document_ID", "Document_Folder_Path");
            ViewBag.Manufacturer_ID = new SelectList(db.tblManufacturers, "Manufacturer_ID", "Manufacturer_Name");
            ViewBag.Sales_ID = new SelectList(db.tblSales, "Sales_ID", "Sales_Name");
            ViewBag.SubCategory_ID = new SelectList(db.tblSubCategories, "SubCategory_ID", "SubCategory_Name");
            return View();
        }

        // POST: tblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Manufacturer_ID,Sales_ID,SubCategory_ID,Product_Name,Product_Image,Series,Model,Model_Year,Series_Info,Document_ID,Featured")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.tblProducts.Add(tblProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Document_ID = new SelectList(db.tblDocuments, "Document_ID", "Document_Folder_Path", tblProduct.Document_ID);
            ViewBag.Manufacturer_ID = new SelectList(db.tblManufacturers, "Manufacturer_ID", "Manufacturer_Name", tblProduct.Manufacturer_ID);
            ViewBag.Sales_ID = new SelectList(db.tblSales, "Sales_ID", "Sales_Name", tblProduct.Sales_ID);
            ViewBag.SubCategory_ID = new SelectList(db.tblSubCategories, "SubCategory_ID", "SubCategory_Name", tblProduct.SubCategory_ID);
            return View(tblProduct);
        }

        // GET: tblProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Document_ID = new SelectList(db.tblDocuments, "Document_ID", "Document_Folder_Path", tblProduct.Document_ID);
            ViewBag.Manufacturer_ID = new SelectList(db.tblManufacturers, "Manufacturer_ID", "Manufacturer_Name", tblProduct.Manufacturer_ID);
            ViewBag.Sales_ID = new SelectList(db.tblSales, "Sales_ID", "Sales_Name", tblProduct.Sales_ID);
            ViewBag.SubCategory_ID = new SelectList(db.tblSubCategories, "SubCategory_ID", "SubCategory_Name", tblProduct.SubCategory_ID);
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
                db.Entry(tblProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Document_ID = new SelectList(db.tblDocuments, "Document_ID", "Document_Folder_Path", tblProduct.Document_ID);
            ViewBag.Manufacturer_ID = new SelectList(db.tblManufacturers, "Manufacturer_ID", "Manufacturer_Name", tblProduct.Manufacturer_ID);
            ViewBag.Sales_ID = new SelectList(db.tblSales, "Sales_ID", "Sales_Name", tblProduct.Sales_ID);
            ViewBag.SubCategory_ID = new SelectList(db.tblSubCategories, "SubCategory_ID", "SubCategory_Name", tblProduct.SubCategory_ID);
            return View(tblProduct);
        }

        // GET: tblProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: tblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            db.tblProducts.Remove(tblProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
