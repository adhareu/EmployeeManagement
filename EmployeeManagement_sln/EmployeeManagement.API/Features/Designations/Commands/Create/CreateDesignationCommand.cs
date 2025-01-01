using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Commands.Create
{
    public class CreateDesignationCommand : IRequest<BasePostResponseDTO<int, DesignationDto>>
    {
        public string Name { get; set; }
    }
}
