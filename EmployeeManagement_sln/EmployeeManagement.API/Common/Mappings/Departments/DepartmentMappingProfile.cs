using AutoMapper;
using EmployeeManagement.API.Features.Departments.Commands.Create;
using EmployeeManagement.API.Features.Departments.Commands.Delete;
using EmployeeManagement.API.Features.Departments.Commands.Update;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;


namespace EmployeeManagement.API.Common.Mappings.Departments
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department,CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department,UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department,DeleteDepartmentCommand>().ReverseMap();
        }
    }
}

