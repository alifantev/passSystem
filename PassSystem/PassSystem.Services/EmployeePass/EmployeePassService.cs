using System.Collections.Generic;
using PassSystem.Domain.EmployeePasses;
using PassSystem.Domain.Services;
using PassSystem.Repositories.EmployeePasses;

namespace PassSystem.Services.EmployeePass
{
    public class EmployeePassService : IEmployeePassService
    {
        private readonly IEmployeePassRepository _employeePassRepository;

        public EmployeePassService(IEmployeePassRepository employeePassRepository)
        {
            _employeePassRepository = employeePassRepository;
        }

        public void Add(Domain.EmployeePasses.EmployeePass employeePass)
        {
            _employeePassRepository.Create(employeePass);
        }

        public IEnumerable<Domain.EmployeePasses.EmployeePass> GetAll()
        {
            return _employeePassRepository.GetAll();
        }

        public void Dispose()
        {
            _employeePassRepository.Dispose();
        }
    }
}
