using AutoMapper;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Get
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeQueryRepository _EmployeeQueryRepository;
        private readonly IMapper _mapper;
        public GetAllEmployeeQueryHandler(IEmployeeQueryRepository EmployeeQueryRepository, IMapper mapper)
        {
            _EmployeeQueryRepository = EmployeeQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(await _EmployeeQueryRepository.GetAll(cancellationToken));
        }
    }
}
