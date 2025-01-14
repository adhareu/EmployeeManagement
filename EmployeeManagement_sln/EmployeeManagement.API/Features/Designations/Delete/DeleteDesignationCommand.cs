using EmployeeManagement.API.Common.DTOS;

using EmployeeManagement.API.Features.Designations.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Delete
{
    public record DeleteDesignationCommand : IRequest<BasePostResponseDto<int, DesignationPostDto>>
    {
        public int Id { get; set; }
        public DeleteDesignationCommand(int id)
        {
            Id = id;
        }
    }
}
