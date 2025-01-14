using AutoMapper;
using EmployeeManagement.API.Features.Employees.Create;
using EmployeeManagement.API.Features.Employees.Delete;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Update;

namespace EmployeeManagement.API.Common.Mappings.Employees
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeePostDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}

