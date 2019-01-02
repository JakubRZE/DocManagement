using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocManagement.Models;
using DocManagement.ViewModels;
using Microsoft.AspNet.Identity;

namespace DocManagement.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activity
        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var upload = db.Documents.Where(u => u.ApplicationUserId == userId).ToList();
            var download =  db.Downloads.Include(x => x.Document).Where(u => u.ApplicationUserId == userId).Select(x => x.Document).ToList();

            var ActivityVM= new ActivityViewModel();
            ActivityVM.Uploads = upload;
            ActivityVM.Downloads = download;

            return View(ActivityVM);
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
