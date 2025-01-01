using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Queries
{
    public record GetEmployeeByIdQuery(long Id):IRequest<EmployeeDto>;
    
}
