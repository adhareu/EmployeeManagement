using AutoMapper;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Queries
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;
        public GetAllDepartmentQueryHandler(IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentQueryRepository = departmentQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(await _departmentQueryRepository.GetAll(cancellationToken));
        }
    }
}
