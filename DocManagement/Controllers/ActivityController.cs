using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocManagement.Models;

namespace DocManagement.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activity
        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.ApplicationUser).Include(d => d.Download);
            return View(documents.ToList());
        }

        //// GET: Activity/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Document document = db.Documents.Find(id);
        //    if (document == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(document);
        //}

        //// GET: Activity/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
        //    return View();
        //}

        //// POST: Activity/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Description,UploadDate,File,Views,ApplicationUserId")] Document document)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Documents.Add(document);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", document.ApplicationUserId);
        //    return View(document);
        //}

        //// GET: Activity/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Document document = db.Documents.Find(id);
        //    if (document == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", document.ApplicationUserId);
        //    return View(document);
        //}

        //// POST: Activity/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Description,UploadDate,File,Views,ApplicationUserId")] Document document)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(document).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", document.ApplicationUserId);
        //    return View(document);
        //}

        //// GET: Activity/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Document document = db.Documents.Find(id);
        //    if (document == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(document);
        //}

        //// POST: Activity/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Document document = db.Documents.Find(id);
        //    db.Documents.Remove(document);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
