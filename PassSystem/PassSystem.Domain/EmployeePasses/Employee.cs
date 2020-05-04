using System;

namespace PassSystem.Domain.EmployeePasses
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public EmployeePosition Position { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string PhotoPath { get; set; }
    }
}
