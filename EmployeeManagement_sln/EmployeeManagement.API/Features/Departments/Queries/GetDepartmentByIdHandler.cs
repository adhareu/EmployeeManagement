using AutoMapper;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;

using EmployeeManagement.API.Infrastructure.Repositories.Departments.Queries;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Queries
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdHandler(IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentQueryRepository = departmentQueryRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Department, DepartmentDto>(await _departmentQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
