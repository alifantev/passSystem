using System;
using System.Collections.Generic;
using System.Linq;
using PassSystem.Contracts.Services;
using PassSystem.Repositories.EmployeePasses;
using PassSystem.Tools;
using PassSystem.Contracts.DTOs.EmployeePass;

namespace PassSystem.Services.EmployeePass
{
    public class EmployeePassService : IEmployeePassService
    {
        private readonly IEmployeePassRepository _employeePassRepository;

        public EmployeePassService(IEmployeePassRepository employeePassRepository)
        {
            _employeePassRepository = employeePassRepository;
        }

        public Result<int?> Add(EmployeePassDto employeePass)
        {
            try
            {
                var domainModel = EntityMapper.MapEmployeePassToDomain(employeePass);
                var passId = _employeePassRepository.Create(domainModel);
                
                return Result<int?>.Success(passId);
            }
            catch (Exception e)
            {
                //write to log error
                return Result<int?>.Failed("Ошибка при создании нового пропуска");
            }
        }

        public IEnumerable<EmployeePassDto> GetAll()
        {
            return _employeePassRepository.GetAll().Select(x => EntityMapper.MapEmployeePassToDto(x));
        }

        public EmployeePassDto Get(int id)
        {
            return EntityMapper.MapEmployeePassToDto(_employeePassRepository.Get(id));
        }

        public IEnumerable<EmployeePassDto> Find(String lastname, int? passId = null)
        {
            return _employeePassRepository
                .Find(x => 
                    (String.IsNullOrWhiteSpace(lastname) && !passId.HasValue) ||
                    (passId.HasValue && x.Id == passId) ||
                    (!String.IsNullOrWhiteSpace(lastname) && x.Employee.LastName.Contains(lastname)))
                .Select(x => EntityMapper.MapEmployeePassToDto(x));
        }

        public PagedData<EmployeePassDto> FindPaged(int page, int countInPage, String lastname, int? passId = null)
        {
            var pagedResult = _employeePassRepository
                .FindPaged(page, countInPage, x =>
                    (String.IsNullOrWhiteSpace(lastname) && !passId.HasValue) ||
                    (passId.HasValue && x.Id == passId) ||
                    (!String.IsNullOrWhiteSpace(lastname) && x.Employee.LastName.ToLower().Contains(lastname.ToLower())));
            
            return new PagedData<EmployeePassDto>()
                {
                    TotalRows = pagedResult.TotalRows,
                    Items = pagedResult.Items.Select(x => EntityMapper.MapEmployeePassToDto(x))
                };
        }

        public Result<Boolean> Update(EmployeePassDto item)
        {
            var currentPass = _employeePassRepository.Get(item.PassId);
            if (currentPass == null) return Result<bool>.Failed($"Пропуск под номером {item.PassId} не найден");
                
            //validation

            var domainModel = EntityMapper.MapEmployeePassToDomain(item);
            _employeePassRepository.Update(domainModel);
            
            return Result<bool>.Success(true);
        }

        public Result<bool> Delete(int id)
        {
            var currentPass = _employeePassRepository.Get(id);
            if (currentPass == null) return Result<bool>.Failed($"Пропуск под номером {id} не найден");
            //validation
            _employeePassRepository.Delete(id);
            
            return Result<bool>.Success(true);
        }

        public void Dispose()
        {
            _employeePassRepository.Dispose();
        }
    }
}
