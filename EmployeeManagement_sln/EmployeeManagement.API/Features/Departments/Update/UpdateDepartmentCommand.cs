using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Update
{
    public class UpdateDepartmentCommand : IRequest<BasePostResponseDto<int, DepartmentPostDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
