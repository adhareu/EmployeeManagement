using AutoMapper;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;

using EmployeeManagement.API.Infrastructure.Repositories.Designations.Queries;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Queries
{
    public class GetDesignationByIdHandler : IRequestHandler<GetDesignationByIdQuery, DesignationDto>
    {
        private readonly IDesignationQueryRepository _DesignationQueryRepository;
        private readonly IMapper _mapper;

        public GetDesignationByIdHandler(IDesignationQueryRepository DesignationQueryRepository, IMapper mapper)
        {
            _DesignationQueryRepository = DesignationQueryRepository;
            _mapper = mapper;
        }
        public async Task<DesignationDto> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Designation, DesignationDto>(await _DesignationQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
