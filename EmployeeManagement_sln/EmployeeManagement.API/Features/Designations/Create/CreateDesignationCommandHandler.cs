
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Designations.Repositories.Commands;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Create
{
    public class CreateDesignationCommandHandler : IRequestHandler<CreateDesignationCommand, BasePostResponseDto<int, DesignationDto>>
    {
        private readonly IDesignationCommandRepository _DesignationRepository;
        private readonly IMapper _mapper;
        public CreateDesignationCommandHandler(IDesignationCommandRepository designationRepository, IMapper mapper)
        {
            _DesignationRepository = designationRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDto<int, DesignationDto>> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
        {
            var Designation = new Designation
            {
                Name = request.Name

            };
            var savedDesignation = await _DesignationRepository.Create(Designation, cancellationToken);
            var DesignationAddResponse = new BasePostResponseDto<int, DesignationDto>
            {
                Id = savedDesignation.Id
           ,
                Success = true
           ,
                Message = "Designation created successfully"


            };
            return DesignationAddResponse;
        }
    }
}
