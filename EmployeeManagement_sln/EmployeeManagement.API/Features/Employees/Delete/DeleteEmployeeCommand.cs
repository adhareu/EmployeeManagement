using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Employees.Delete
{
    public record DeleteEmployeeCommand(long id) : IRequest<BasePostResponseDto<long, EmployeePostDto>>
    {
       
    }
}
