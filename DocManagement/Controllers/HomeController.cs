using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET:  DocumentsReport
        public ActionResult DocumentsReport()
        {
            return View();
        }

        // GET: EmployeesReport
        public ActionResult EmployeesReport()
        {
            return View();
        }
    }
}