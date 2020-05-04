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
                Title = "Пропускная система",
                MainItems = new List<LeftMenuItem>()
                {
                    new LeftMenuItem(){Text = "Сотрудники", Class = "fas fa-address-card", Controller = "Employees", Action = "Index"},
                    new LeftMenuItem(){Text = "Пропуска", Class = "fas fa-address-card", Controller = "EmployeePasses", Action = "Index"},
                }
            };
        }
    }
}