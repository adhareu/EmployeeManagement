using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;


using MediatR;

namespace EmployeeManagement.API.Features.Departments.Delete
{
    public record DeleteDepartmentCommand(int id) : IRequest<BasePostResponseDto<int, DepartmentPostDto>>
    {
      
    }
}
