using System;

namespace PassSystem.BackOffice.Web.Models.EmployeePasses
{
    public class EmployeePassesIndexModel
    {
        public String ErrorMessage { get; set; }
        public PaginationModel Pagination { get; set; }
        public EmployeePassViewModel[] EmployeePasses { get; set; }
    }
}