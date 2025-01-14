using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Get
{
    public class GetAllDesignationQuery : IRequest<IEnumerable<DesignationDto>>
    {
    }
}
