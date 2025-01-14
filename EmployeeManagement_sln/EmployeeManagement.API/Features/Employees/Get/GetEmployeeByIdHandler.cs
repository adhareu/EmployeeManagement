using AutoMapper;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Get
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeQueryRepository = employeeQueryRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Employee, EmployeeDto>(await _employeeQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
