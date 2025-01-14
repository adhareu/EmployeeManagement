using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Get
{
    public record GetDesignationByIdQuery(int Id) : IRequest<DesignationGetDto>;

}
