using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;


using MediatR;

namespace EmployeeManagement.API.Features.Departments.Delete
{
    public class DeleteDepartmentCommand : IRequest<BasePostResponseDto<int, DepartmentDto>>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
