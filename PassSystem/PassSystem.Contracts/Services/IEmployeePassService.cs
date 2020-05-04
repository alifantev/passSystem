using System;
using System.Collections.Generic;
using PassSystem.Contracts.DTOs.EmployeePass;
using PassSystem.Tools;

namespace PassSystem.Contracts.Services
{
    public interface IEmployeePassService : IDisposable
    {
        Result<int?> Add(EmployeePassDto employeePass);
        IEnumerable<EmployeePassDto> GetAll();
        EmployeePassDto Get(int id);
        IEnumerable<EmployeePassDto> Find(String lastName, int? passId = null);
        PagedData<EmployeePassDto> FindPaged(int page, int countInPage, String lastName = null, int? passId = null);
        Result<bool> Update(EmployeePassDto item);
        Result<bool> Delete(int id);
    }
}
