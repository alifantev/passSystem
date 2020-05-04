using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PassSystem.Contracts.DTOs.EmployeePass;
using PassSystem.Domain.EmployeePasses;

namespace PassSystem.BackOffice.Web.Models.EmployeePasses
{
    public class EmployeePassEditModel
    {
        public int? PassId { get; set; }
        public int? EmployeeId { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        
        [Required]
        [Display(Name = "Позиция")]
        public EmployeePositionDto Position { get; set; }
        
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirthday { get; set; }
        
        [Display(Name = "Фотография")]
        public string PhotoPath { get; set; }

        [Required]
        [Display(Name = "Действие пропуска от")]
        public DateTime ValidAt { get; set; }
        
        [Required]
        [Display(Name = "Действие пропуска до")]
        public DateTime ValidTo { get; set; }
    }
}