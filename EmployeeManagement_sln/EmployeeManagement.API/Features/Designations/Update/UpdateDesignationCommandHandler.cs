
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Repositories.Commands;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Update
{
    public class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommand, BasePostResponseDto<int, DesignationPostDto>>
    {
        private readonly IDesignationCommandRepository _designationRepository;
        private readonly IDesignationQueryRepository _designationQueryRepository;
        private readonly IMapper _mapper;
        public UpdateDesignationCommandHandler(IDesignationCommandRepository designationRepository, IDesignationQueryRepository designationQueryRepository, IMapper mapper)
        {
            _designationRepository = designationRepository;
            _designationQueryRepository = designationQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<int, DesignationPostDto>> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
        {
            var designationEntity = await _designationQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map(request, designationEntity);
            var savedDesignation = await _designationRepository.Update(mappedDesignation, cancellationToken);
            var DesignationResponse = new BasePostResponseDto<int, DesignationPostDto>
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
