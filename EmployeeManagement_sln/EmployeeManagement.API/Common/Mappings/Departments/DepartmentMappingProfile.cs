using AutoMapper;
using EmployeeManagement.API.Features.Departments.Create;
using EmployeeManagement.API.Features.Departments.Delete;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Departments.Update;



namespace EmployeeManagement.API.Common.Mappings.Departments
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentListDto>().ReverseMap();
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
            CreateMap<Department, DepartmentPostDto>().ReverseMap();
            CreateMap<Department,CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department,UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department,DeleteDepartmentCommand>().ReverseMap();
        }
    }
}

