using AutoMapper;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Get
{
    public class GetDesignationByIdHandler : IRequestHandler<GetDesignationByIdQuery, DesignationGetDto>
    {
        private readonly IDesignationQueryRepository _DesignationQueryRepository;
        private readonly IMapper _mapper;

        public GetDesignationByIdHandler(IDesignationQueryRepository DesignationQueryRepository, IMapper mapper)
        {
            _DesignationQueryRepository = DesignationQueryRepository;
            _mapper = mapper;
        }
        public async Task<DesignationGetDto> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Designation, DesignationGetDto>(await _DesignationQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
