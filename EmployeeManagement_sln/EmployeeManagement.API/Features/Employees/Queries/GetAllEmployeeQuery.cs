using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
