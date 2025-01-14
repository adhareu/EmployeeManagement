using AutoMapper;
using EmployeeManagement.API.Features.Designations.DTOS;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Designations.Get
{
    public class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, IEnumerable<DesignationListDto>>
    {
        private readonly IDesignationQueryRepository _designationQueryRepository;
        private readonly IMapper _mapper;
        public GetAllDesignationQueryHandler(IDesignationQueryRepository designationQueryRepository, IMapper mapper)
        {
            _designationQueryRepository = designationQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DesignationListDto>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Designation>, IEnumerable<DesignationListDto>>(await _designationQueryRepository.GetAll(cancellationToken));
        }
    }
}

