using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Commands.Delete
{
    public class DeleteDesignationCommand : IRequest<BasePostResponseDTO<int, DesignationDto>>
    {
       public int Id { get; set; }
        public DeleteDesignationCommand(int id)
        {
            Id = id;
        }
    }
}
