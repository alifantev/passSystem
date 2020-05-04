using System;
using PassSystem.Contracts.DTOs.EmployeePass;
using PassSystem.Domain.EmployeePasses;

namespace PassSystem.BackOffice.Web.Models.EmployeePasses
{
    public class EmployeePassViewModel
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public EmployeePositionDto Position { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public String DateOfBirthdayView => DateOfBirthday.ToShortDateString();
        public string PhotoPath { get; set; }

        public int PassId { get; set; }
        public DateTime ValidAt { get; set; }
        public DateTime ValidTo { get; set; }
        public String ValidAtView => ValidAt.ToShortDateString();
        public String ValidToView => ValidTo.ToShortDateString();
        public Boolean IsAnnuled { get; set; }

        public String LastNameAndInitials => $"{LastName} {FirstName.ToUpper()[0]}. {Patronymic.ToUpper()[0]}.";
        
        
    }
}