using AutoMapper;
using EmployeeManagement.API.Features.Employees.Commands.Create;
using EmployeeManagement.API.Features.Employees.Commands.Delete;
using EmployeeManagement.API.Features.Employees.Commands.Update;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;

namespace EmployeeManagement.API.Common.Mappings.Employees
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}

