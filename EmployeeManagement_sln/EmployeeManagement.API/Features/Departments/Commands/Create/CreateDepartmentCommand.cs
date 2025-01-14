using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommand : IRequest<BasePostResponseDto<int, DepartmentListDto>>
    {

        public string Name { get; set; }
    }
}
