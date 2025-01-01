
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Commands.Update
{
    public class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommand, BasePostResponseDTO<int, DesignationDto>>
    {
        private readonly IDesignationCommandRepository _designationRepository;
        private readonly IDesignationQueryRepository _designationQueryRepository;
        private readonly IMapper _mapper;
        public UpdateDesignationCommandHandler(IDesignationCommandRepository designationRepository, IDesignationQueryRepository designationQueryRepository, IMapper mapper)
        {
            _designationRepository = designationRepository;
            _designationQueryRepository= designationQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDTO<int, DesignationDto>> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
        {
            var designationEntity = await _designationQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map(request, designationEntity);
            var savedDesignation= await _designationRepository.Update(mappedDesignation, cancellationToken);
            var DesignationResponse = new BasePostResponseDTO<int, DesignationDto>
            {
                Id = savedDesignation.Id
           ,
                Success = true
           ,
                Message = "Designation Updated successfully"


            };
            return DesignationResponse;
        }
    }
}
