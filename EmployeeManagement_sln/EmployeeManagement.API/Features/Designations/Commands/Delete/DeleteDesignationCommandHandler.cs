﻿
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Commands.Delete
{
    public class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommand, BasePostResponseDTO<int, DesignationDto>>
    {
        private readonly IDesignationCommandRepository _DesignationRepository;
        private readonly IDesignationQueryRepository _DesignationQueryRepository;
        private readonly IMapper _mapper;
        public DeleteDesignationCommandHandler(IDesignationCommandRepository DesignationRepository, IDesignationQueryRepository DesignationQueryRepository, IMapper mapper)
        {
            _DesignationRepository = DesignationRepository;
            _DesignationQueryRepository= DesignationQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDTO<int, DesignationDto>> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
        {
            var DesignationEntity = await _DesignationQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map<Designation>(DesignationEntity);
            mappedDesignation.IsDeleted = true;
            var savedDesignation= await _DesignationRepository.Update(mappedDesignation, cancellationToken);
            var DesignationResponse = new BasePostResponseDTO<int, DesignationDto>
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
