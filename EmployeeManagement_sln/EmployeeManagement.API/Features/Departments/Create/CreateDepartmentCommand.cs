using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Create
{
    public class CreateDepartmentCommand : IRequest<BasePostResponseDto<int, DepartmentPostDto>>
    {

        public string Name { get; set; } = string.Empty;
    }
}
