using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Delete
{
    public class DeleteDepartmentCommand : IRequest<BasePostResponseDTO<int, DepartmentDto>>
    {
       public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
