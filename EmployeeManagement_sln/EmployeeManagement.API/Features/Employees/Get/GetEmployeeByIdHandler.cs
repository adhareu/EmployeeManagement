using AutoMapper;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Get
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeGetDto>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeQueryRepository = employeeQueryRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeGetDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Employee, EmployeeGetDto>(await _employeeQueryRepository.Get(request.Id, cancellationToken));

        }
    }
}
