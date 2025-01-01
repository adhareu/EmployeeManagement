using EmployeeManagement.API.Features.Departments.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Queries
{
    public record GetDepartmentByIdQuery(int Id):IRequest<DepartmentDto>;
    
}
