using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<BasePostResponseDto<long, EmployeeDto>>
    {
       public long Id { get; set; }
        public DeleteEmployeeCommand(long id)
        {
            Id = id;
        }
    }
}
