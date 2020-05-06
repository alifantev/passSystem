using System.Collections.Generic;
using System.Web.Mvc;
using PassSystem.BackOffice.Web.Models.Sidebar;

namespace PassSystem.BackOffice.Web.Controllers
{
    public class InfrastructureController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View(GenerateMenu());
        }

        private LeftMenuModel GenerateMenu()
        {
            return new LeftMenuModel()
            {
                Title = "Пропускная система v1.0.0",
                MainItems = new List<LeftMenuItem>()
                {
                    //new LeftMenuItem(){Text = "Сотрудники", Class = "", Controller = "EmployeePasses", Action = "Index"},
                    new LeftMenuItem(){Text = "Пропуска", Class = "", Controller = "EmployeePasses", Action = "Index"},
                }
            };
        }
    }
}