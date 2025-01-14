using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Create
{
    public record CreateDesignationCommand : IRequest<BasePostResponseDto<int, DesignationPostDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
