using System;

namespace PassSystem.Domain.EmployeePasses
{
    public class EmployeePass
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime ValidAt { get; set; }
        public DateTime ValidTo { get; set; }
        public Boolean IsAnnuled { get; set; }
    }
}