using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassSystem.Domain.EmployeePasses;
using PassSystem.Domain.Services;

namespace PassSystem.BackOffice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeePassService _employeePassService;

        public HomeController(IEmployeePassService employeePassService)
        {
            _employeePassService = employeePassService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}