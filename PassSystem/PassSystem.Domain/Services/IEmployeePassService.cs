using PassSystem.Domain.EmployeePasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSystem.Domain.Services
{
    public interface IEmployeePassService : IDisposable
    {
        void Add(EmployeePass employeePass);
        IEnumerable<EmployeePass> GetAll();
    }
}
