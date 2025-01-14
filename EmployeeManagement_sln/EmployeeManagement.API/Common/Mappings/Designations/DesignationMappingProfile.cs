using AutoMapper;
using EmployeeManagement.API.Features.Designations.Create;
using EmployeeManagement.API.Features.Designations.Delete;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Designations.Update;


namespace EmployeeManagement.API.Common.Mappings.Designations
{
    public class DesignationMappingProfile : Profile
    {
        public DesignationMappingProfile()
        {
            CreateMap<Designation, DesignationListDto>().ReverseMap();
            CreateMap<Designation, CreateDesignationCommand>().ReverseMap();
            CreateMap<Designation, UpdateDesignationCommand>().ReverseMap();
            CreateMap<Designation, DeleteDesignationCommand>().ReverseMap();
        }
    }
}

