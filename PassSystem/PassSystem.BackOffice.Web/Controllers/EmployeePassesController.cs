using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PassSystem.BackOffice.Web.Models;
using PassSystem.BackOffice.Web.Models.EmployeePasses;
using PassSystem.Contracts.DTOs.EmployeePass;
using PassSystem.Contracts.Services;
using PassSystem.Tools;

namespace PassSystem.BackOffice.Web.Controllers
{
    public class EmployeePassesController : Controller
    {
        private readonly IEmployeePassService _employeePassService;
        public EmployeePassesController(IEmployeePassService employeePassService)
        {
            _employeePassService = employeePassService;
        }

        private String ErrorMessage = nameof(ErrorMessage);
        private String SuccessMessage = nameof(SuccessMessage);
        private int PageSize = 30;
        
        public ActionResult Index(int page = 1)
        {
            var model = GetEmployeePassesIndexModel(page);
            
            return View(model);
        }
        
        [HttpGet]
        public PartialViewResult EmployeePassesTable(int page, String lastName = null, int? passId = null)
        {
            var model = GetEmployeePassesIndexModel(page, lastName, passId);
            
            return PartialView(model);
        }

        private EmployeePassesIndexModel GetEmployeePassesIndexModel(int page, String lastName = null, int? passId = null)
        {
            var pagedData = _employeePassService.FindPaged(page, PageSize, lastName, passId);

            var model = new EmployeePassesIndexModel()
            {
                EmployeePasses = EntityMapper.MapToViewModels(pagedData.Items),
                Pagination = new PaginationModel()
                {
                    ActivePage = page,
                    PagesCount = (int) Math.Ceiling((decimal) pagedData.TotalRows / PageSize)
                }
            };
            
            return model;
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeePassEditModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var photoRelativePath = SaveFileAndGetUrl(file);
            model.PhotoPath = photoRelativePath;
            
            var result = _employeePassService.Add(EntityMapper.MapEditModelToDto(model));
            if (result.IsFailed)
            {
                TempData[ErrorMessage] = result.Errors;
                return View(model);
            }
            
            TempData[SuccessMessage] = $"Добавлен новый пропуск №{result.Data} для {model.LastName} {model.FirstName} {model.Patronymic}";
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employeePass = _employeePassService.Get(id);
            if (employeePass == null)
            {
                TempData[ErrorMessage] = $"Пропуск под номером {id} не найден";
                return RedirectToAction("Index");
            }

            var editModel = EntityMapper.MapDtoToEditModel(employeePass);
            
            return View(editModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeePassEditModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (file != null)
            {
                model.PhotoPath = SaveFileAndGetUrl(file);
            }

            var result = _employeePassService.Update(EntityMapper.MapEditModelToDto(model));
            if (result.IsFailed)
            {
                TempData[ErrorMessage] = result.Errors;
                return View(model);
            }

            TempData[SuccessMessage] = $"Пропуск под номером №{result.Data} был изменен";
            
            return RedirectToAction("Index");
        }

        private String SaveFileAndGetUrl(HttpPostedFileBase file)
        {
            string relativePath = String.Empty;
            try
            {
                var fileName = String.Concat(Guid.NewGuid(), Path.GetExtension(file.FileName));
                relativePath = Path.Combine("/Uploads/Images", fileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/Images"), fileName);  
                file.SaveAs(path);

                return relativePath;
            }  
            catch (Exception ex)
            {
                //write to log
                return String.Empty;
            }
        }

        [HttpPost]
        public JsonResult AnnulatePass(int passId)
        {
            var dto = _employeePassService.Get(passId);
            if (dto == null)
            {
                return Json(Result<bool>.Failed("Пропуск не найден"));
            }

            dto.IsAnnuled = true;
            dto.AnnuledDateTime = DateTime.Now;

            var result = _employeePassService.Update(dto);
            if (result.IsFailed) return Json(result);

            return Json(new {Message = $"Пропуск №{passId} аннулирован"});
        }

        public ActionResult GeneratePass(int count = 1)
        {
            for (int i = 1; i <= count; i++)
            {
                var pass = new EmployeePassDto()
                {
                    LastName = $"Иванов_{i}",
                    FirstName = $"Иван_{i}",
                    Patronymic = $"Иванович_{i}",
                    Position = (EmployeePositionDto) new Random().Next(1,5),
                    PhotoPath = @"/Uploads/Images/4f985267-7170-4ea8-97f8-215d87a5e30d.jpg",
                    DateOfBirthday = DateTime.Now.AddYears(-new Random().Next(30)).Date,
                    ValidAt = DateTime.Now.AddDays(-new Random().Next(30)).Date,
                    ValidTo = DateTime.Now.AddDays(new Random().Next(30)).Date,
                    IsAnnuled = false
                };

                _employeePassService.Add(pass);
            }

            return RedirectToAction("Index");
        }
    }
}