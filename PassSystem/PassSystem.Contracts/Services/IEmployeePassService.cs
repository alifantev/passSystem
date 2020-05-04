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
        int Add(EmployeePass employeePass);
        IEnumerable<EmployeePass> GetAll();
        EmployeePass Get(int id);
        IEnumerable<EmployeePass> Find(Func<EmployeePass, Boolean> predicate);
        IEnumerable<EmployeePass> FindPaged(int page, int countInPage, Func<EmployeePass, Boolean> predicate);
        void Update(EmployeePass item);
        void Delete(int id);
    }
}
