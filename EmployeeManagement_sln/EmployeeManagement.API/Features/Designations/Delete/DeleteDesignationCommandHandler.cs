
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Designations.Repositories.Commands;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Delete
{
    public class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommand, BasePostResponseDto<int, DesignationPostDto>>
    {
        private readonly IDesignationCommandRepository _DesignationRepository;
        private readonly IDesignationQueryRepository _DesignationQueryRepository;
        private readonly IMapper _mapper;
        public DeleteDesignationCommandHandler(IDesignationCommandRepository DesignationRepository, IDesignationQueryRepository DesignationQueryRepository, IMapper mapper)
        {
            _DesignationRepository = DesignationRepository;
            _DesignationQueryRepository = DesignationQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<int, DesignationPostDto>> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
        {
            var DesignationEntity = await _DesignationQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map<Designation>(DesignationEntity);
            mappedDesignation.IsDeleted = true;
            var savedDesignation = await _DesignationRepository.Update(mappedDesignation, cancellationToken);
            var DesignationResponse = new BasePostResponseDto<int, DesignationPostDto>
            {
                Id = savedDesignation.Id
           ,
                Success = true
           ,
                Message = "Designation Deleted successfully"


            };
            return DesignationResponse;
        }
    }
}
