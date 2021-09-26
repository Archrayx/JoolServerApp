using JoolServerApp.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class tblSubCategoriesController : Controller
    {
        private JoolServerEntities db = new JoolServerEntities();

        // GET: tblSubCategories
        public ActionResult Index()
        {
            var tblSubCategories = db.tblSubCategories.Include(t => t.tblCategory);
            return View(tblSubCategories.ToList());
        }

        // GET: tblSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubCategory tblSubCategory = db.tblSubCategories.Find(id);
            if (tblSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblSubCategory);
        }

        // GET: tblSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            return View();
        }

        // POST: tblSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategory_ID,Category_ID,SubCategory_Name")] tblSubCategory tblSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.tblSubCategories.Add(tblSubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblSubCategory.Category_ID);
            return View(tblSubCategory);
        }

        // GET: tblSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubCategory tblSubCategory = db.tblSubCategories.Find(id);
            if (tblSubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblSubCategory.Category_ID);
            return View(tblSubCategory);
        }

        // POST: tblSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategory_ID,Category_ID,SubCategory_Name")] tblSubCategory tblSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblSubCategory.Category_ID);
            return View(tblSubCategory);
        }

        // GET: tblSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubCategory tblSubCategory = db.tblSubCategories.Find(id);
            if (tblSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblSubCategory);
        }

        // POST: tblSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSubCategory tblSubCategory = db.tblSubCategories.Find(id);
            db.tblSubCategories.Remove(tblSubCategory);
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
