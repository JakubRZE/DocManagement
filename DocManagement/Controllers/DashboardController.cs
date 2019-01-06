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
            var users = from m in db.Users
            select m;


            return View(users);
        }

        // GET: DownloadedDocuments
        [Authorize]
        public ActionResult DownloadedDocuments()
        {
            return View();
        }

        // GET: AllEmployees
        [Authorize]
        public ActionResult AllEmployees()
        {
            return View();
        }
    }
}