using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Update
{
    public record UpdateDesignationCommand : IRequest<BasePostResponseDto<int, DesignationPostDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
