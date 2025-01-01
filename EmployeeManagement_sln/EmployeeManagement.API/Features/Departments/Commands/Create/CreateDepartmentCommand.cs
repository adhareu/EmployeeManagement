using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommand : IRequest<BasePostResponseDTO<int, DepartmentDto>>
    {

        public string Name { get; set; }
    }
}
