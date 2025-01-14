using AutoMapper;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Get
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentGetDto>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdHandler(IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentQueryRepository = departmentQueryRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentGetDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Department, DepartmentGetDto>(await _departmentQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
