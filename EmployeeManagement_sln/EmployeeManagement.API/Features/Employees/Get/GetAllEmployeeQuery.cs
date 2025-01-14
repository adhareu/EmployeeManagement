using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Get
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeListDto>>
    {
    }
}
