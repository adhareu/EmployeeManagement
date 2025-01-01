using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Queries
{
    public record GetDesignationByIdQuery(int Id):IRequest<DesignationDto>;
    
}
