using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Queries
{
    public class GetAllDesignationQuery : IRequest<IEnumerable<DesignationDto>>
    {
    }
}
