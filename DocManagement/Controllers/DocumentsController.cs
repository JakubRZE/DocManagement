using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocManagement.Models;
using DocManagement.ViewModels;
using Microsoft.AspNet.Identity;

namespace DocManagement.Controllers
{
    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Documents
        [Authorize]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.DiscSortParm = sortOrder == "Disc_desc" ? "Disc_asc" : "Disc_desc";
            ViewBag.UpSortParm = sortOrder == "Up_desc" ? "Up_asc" : "Up_desc";
            ViewBag.DownSortParm = sortOrder == "Down_desc" ? "Down_asc" : "Down_desc";

            var documents = from m in db.Documents
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(s => s.Description.Contains(searchString));
                ViewBag.CurrentFilter = searchString;
            }

            var list = (from doc in documents
                        select new DocumentViewModel
                        {
                            Id = doc.Id,
                            Description = doc.Description,
                            UploadDate = doc.UploadDate,
                            Name = doc.Name,
                            Downloads = doc.Download.Count()
                        });

            switch (sortOrder)
            {
                case "Disc_desc":
                    list = list.OrderByDescending(s => s.Description);
                    break;
                case "Disc_asc":
                    list = list.OrderBy(s => s.Description);
                    break;
                case "Up_desc":
                    list = list.OrderByDescending(s => s.UploadDate);
                    break;
                case "Up_asc":
                    list = list.OrderBy(s => s.UploadDate);
                    break;
                case "Down_desc":
                    list = list.OrderByDescending(s => s.Downloads);
                    break;
                case "Down_asc":
                    list = list.OrderBy(s => s.Downloads);
                    break;

                default:
                    list = list.OrderBy(s => s.UploadDate);
                    break;
            }
            return View(list.ToList());
        }

        // GET: Documents/DownloadFile
        [Authorize]
        public ActionResult DownloadFile(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }

            db.Downloads.Add(new Download
            {
                DocumentId = id.Value,
                ApplicationUserId = User.Identity.GetUserId()
            });
            db.SaveChanges();

            return File(document.File, document.ContentType, document.Name);

        }

        // GET: Documents/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }

            var downloads = db.Downloads.Count(x => x.DocumentId == document.Id);

            var user = db.Users.FirstOrDefault(x => x.Id == document.ApplicationUserId);

            var viewModel = new DetailsDocumentViewModel
            {
                Id = document.Id,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                Description = document.Description,
                UploadDate = document.UploadDate,
                Name = document.Name,
                ContentType = document.ContentType,
                Downloads = downloads
            };


            return View(viewModel);
        }

        // GET: Documents/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description")]  CreateDocumentViewModel model, HttpPostedFileBase postedFile)
        {

            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                    {
                        bytes = br.ReadBytes(postedFile.ContentLength);
                    }

                    db.Documents.Add(new Document
                    {
                        Description = model.Description,
                        Name = Path.GetFileName(postedFile.FileName),
                        ContentType = postedFile.ContentType,
                        File = bytes,
                        ApplicationUserId = User.Identity.GetUserId()
                    });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            //return View(document);
            return RedirectToAction("Index");
        }

        // GET: Documents/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,UploadDate,File,Name,ContentType,ApplicationUserId")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }

            var downloads = db.Downloads.Count(x => x.DocumentId == document.Id);

            var user = db.Users.FirstOrDefault(x => x.Id == document.ApplicationUserId);

            var viewModel = new DetailsDocumentViewModel
            {
                Id = document.Id,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                Description = document.Description,
                UploadDate = document.UploadDate,
                Name = document.Name,
                ContentType = document.ContentType,
                Downloads = downloads
            };


            return View(viewModel);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
