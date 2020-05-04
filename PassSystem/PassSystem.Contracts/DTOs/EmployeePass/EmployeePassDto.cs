using System;

namespace PassSystem.Contracts.DTOs.EmployeePass
{
    public class EmployeePassDto
    {
        public int PassId { get; set; }
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public EmployeePositionDto Position { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string PhotoPath { get; set; }

        public DateTime ValidAt { get; set; }
        public DateTime ValidTo { get; set; }
        public Boolean IsAnnuled { get; set; }
    }
}