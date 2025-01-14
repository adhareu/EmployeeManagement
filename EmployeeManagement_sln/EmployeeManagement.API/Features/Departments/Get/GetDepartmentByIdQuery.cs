using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Get
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentGetDto>;

}
