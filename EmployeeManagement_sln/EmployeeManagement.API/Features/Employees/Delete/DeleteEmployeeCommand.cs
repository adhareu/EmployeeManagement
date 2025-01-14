using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Employees.Delete
{
    public record DeleteEmployeeCommand : IRequest<BasePostResponseDto<long, EmployeePostDto>>
    {
        public long Id { get; set; }
        public DeleteEmployeeCommand(long id)
        {
            Id = id;
        }
    }
}
