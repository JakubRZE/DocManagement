using DocManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocManagement.ViewModels;

namespace DocManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET:  DocumentsReport
        [Authorize]
        public ActionResult DocumentsReport()
        {
            return View();
        }

        // GET: EmployeesReport
        [Authorize]
        public ActionResult EmployeesReport()
        {
            return View();
        }
    }
}