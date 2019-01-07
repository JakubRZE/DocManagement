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
                        }).ToList();
            return View(users);
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
            }).ToList().OrderBy(x => x.Downloads).Take(amount);

            ViewBag.CurrentFilter = amount;

            return View(documents);
        }

        // GET: AllEmployees
        [Authorize]
        public ActionResult AllEmployees()
        {
            return View();
        }
    }
}