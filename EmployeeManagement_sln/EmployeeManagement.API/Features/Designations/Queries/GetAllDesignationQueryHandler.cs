using AutoMapper;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Queries
{
    public class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, IEnumerable<DesignationDto>>
    {
        private readonly IDesignationQueryRepository _designationQueryRepository;
        private readonly IMapper _mapper;
        public GetAllDesignationQueryHandler(IDesignationQueryRepository designationQueryRepository, IMapper mapper)
        {
            _designationQueryRepository = designationQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DesignationDto>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Designation>, IEnumerable<DesignationDto>>(await _designationQueryRepository.GetAll(cancellationToken));
        }
    }
}

