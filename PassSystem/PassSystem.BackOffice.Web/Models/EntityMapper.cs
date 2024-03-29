﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PassSystem.BackOffice.Web.Models.EmployeePasses;
using PassSystem.Contracts.DTOs.EmployeePass;

namespace PassSystem.BackOffice.Web.Models
{
    public static class EntityMapper
    {
        public static EmployeePassViewModel[] MapToViewModels(IEnumerable<EmployeePassDto> dtos)
        {
            if (!dtos.Any()) return new EmployeePassViewModel[]{};
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeePassDto, EmployeePassViewModel>())
                .CreateMapper();
            
            var result = mapper.Map<IEnumerable<EmployeePassDto>, List<EmployeePassViewModel>>(dtos);

            return result.ToArray();
        }

        public static EmployeePassDto MapEditModelToDto(EmployeePassEditModel editModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeePassEditModel, EmployeePassDto>())
                .CreateMapper();
            
            var result = mapper.Map<EmployeePassEditModel, EmployeePassDto>(editModel);

            return result;
        }

        public static EmployeePassEditModel MapDtoToEditModel(EmployeePassDto dto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeePassDto, EmployeePassEditModel>())
                .CreateMapper();
            
            var result = mapper.Map<EmployeePassDto, EmployeePassEditModel>(dto);

            return result;
        }
        
    }
}