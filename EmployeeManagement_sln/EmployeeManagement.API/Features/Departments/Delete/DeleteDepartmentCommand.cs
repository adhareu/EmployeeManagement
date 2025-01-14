using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;


using MediatR;

namespace EmployeeManagement.API.Features.Departments.Delete
{
    public record DeleteDepartmentCommand : IRequest<BasePostResponseDto<int, DepartmentPostDto>>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
