using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Get
{
    public record GetEmployeeByIdQuery(long Id) : IRequest<EmployeeGetDto>;

}
