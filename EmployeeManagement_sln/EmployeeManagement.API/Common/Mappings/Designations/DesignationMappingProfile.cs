using AutoMapper;
using EmployeeManagement.API.Features.Designations.Commands.Create;
using EmployeeManagement.API.Features.Designations.Commands.Delete;
using EmployeeManagement.API.Features.Designations.Commands.Update;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;


namespace EmployeeManagement.API.Common.Mappings.Designations
{
    public class DesignationMappingProfile : Profile
    {
        public DesignationMappingProfile()
        {
            CreateMap<Designation, DesignationDto>().ReverseMap();
            CreateMap<Designation, CreateDesignationCommand>().ReverseMap();
            CreateMap<Designation, UpdateDesignationCommand>().ReverseMap();
            CreateMap<Designation, DeleteDesignationCommand>().ReverseMap();
        }
    }
}

