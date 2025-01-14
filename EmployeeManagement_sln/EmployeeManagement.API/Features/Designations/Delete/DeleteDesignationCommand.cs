using EmployeeManagement.API.Common.DTOS;

using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Delete
{
    public record DeleteDesignationCommand(int id) : IRequest<BasePostResponseDto<int, DesignationPostDto>>
    {
       
    }
}
