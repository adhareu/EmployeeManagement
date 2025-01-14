using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Create
{
    public class CreateDesignationCommand : IRequest<BasePostResponseDto<int, DesignationDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
