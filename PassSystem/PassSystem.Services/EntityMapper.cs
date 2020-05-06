using PassSystem.Contracts.DTOs.EmployeePass;
using PassSystem.Domain.EmployeePasses;

namespace PassSystem.Services
{
    public static class EntityMapper
    {
        public static Domain.EmployeePasses.EmployeePass MapEmployeePassToDomain(EmployeePassDto dto)
        {
            return new Domain.EmployeePasses.EmployeePass()
            {
                Id = dto.PassId,
                ValidAt = dto.ValidAt,
                ValidTo = dto.ValidTo,
                IsAnnuled = dto.IsAnnuled,
                AnnuledDateTime = dto.AnnuledDateTime,
                Employee = new Employee()
                {
                    Id = dto.EmployeeId,
                    LastName = dto.LastName,
                    FirstName = dto.FirstName,
                    Patronymic = dto.Patronymic,
                    DateOfBirthday = dto.DateOfBirthday,
                    Position = (EmployeePosition)dto.Position,
                    PhotoPath = dto.PhotoPath,
                }
            };
        }

        public static EmployeePassDto MapEmployeePassToDto(Domain.EmployeePasses.EmployeePass model)
        {
            return new EmployeePassDto()
            {
                PassId = model.Id,
                ValidAt = model.ValidAt,
                ValidTo = model.ValidTo,
                IsAnnuled = model.IsAnnuled,
                AnnuledDateTime = model.AnnuledDateTime,
                
                EmployeeId = model.Employee.Id,
                LastName = model.Employee.LastName,
                FirstName = model.Employee.FirstName,
                Patronymic = model.Employee.Patronymic,
                Position = (EmployeePositionDto)model.Employee.Position,
                PhotoPath = model.Employee.PhotoPath,
                DateOfBirthday = model.Employee.DateOfBirthday
            };
        }
    }
}