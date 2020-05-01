using PassSystem.Domain.EmployeePasses;
using PassSystem.Repositories.Interfaces;

namespace PassSystem.Repositories.EmployeePasses
{
    public interface IEmployeePassRepository : IEntityRepository<EmployeePass>
    {
    }
}
