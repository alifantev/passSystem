using System.ComponentModel.DataAnnotations;

namespace PassSystem.Contracts.DTOs.EmployeePass
{
    public enum EmployeePositionDto
    {
        [Display(Name = "Рабочий")]
        Working = 1,
        
        [Display(Name = "Бригадир")]
        BrigadeLeader = 2,
        
        [Display(Name = "Офисный сотрудник")]
        OfficeWorker = 3,
        
        [Display(Name = "Начальник отдела")]
        DepartmentHead = 4,
        
        [Display(Name = "Генеральный директор")]
        GeneralDirector = 5
    }
}