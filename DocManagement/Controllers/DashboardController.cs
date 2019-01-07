using DocManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocManagement.ViewModels;

namespace DocManagement.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET:  ActiveEmployees
        [Authorize]
        public ActionResult ActiveEmployees()
        {
            var users = db.Users.Select( x => new DashboardViewModel
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Email = x.Email,
                            UploadsCount = x.Documents.Count()
                        }).Take(10).ToList();
            return View(users.OrderByDescending(x=>x.UploadsCount));
        }

        // GET:  ActiveEmployees
        [Authorize]
        public ActionResult ActiveEmployeesDetails(string userId)
        {
            var documents = db.Documents.Where(x => x.ApplicationUserId == userId).OrderBy(x => x.UploadDate);
            return View(documents.ToList());
        }

        // GET: DownloadedDocuments
        [Authorize]
        public ActionResult DownloadedDocuments(int amount = 10)
        {
            var documents = db.Documents.Select(x => new DashboardViewModel
            {
                Description = x.Description,
                UploadDate = x.UploadDate,
                File = x.Name,
                Downloads = x.Download.Count()
            }).ToList().Take(amount);

            ViewBag.CurrentFilter = amount;

            return View(documents.OrderByDescending(x => x.Downloads));
        }

        // GET: AllEmployees
        [Authorize]
        public ActionResult AllEmployees(string searchString)
        {
            var users = from m in db.Users
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FirstName.Contains(searchString));
                ViewBag.CurrentFilter = searchString;
            }

            var list = users.Select(x => new DashboardViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Address = x.Address,
                UploadsCount = x.Documents.Count(),
                Downloads = x.Downloads.Count()
            }).ToList();

            return View(list);
        }
    }
}