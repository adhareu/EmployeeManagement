
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BasePostResponseDto<long, EmployeeDto>>
    {
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;
        public DeleteEmployeeCommandHandler(IEmployeeCommandRepository employeeRepository, IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeQueryRepository= employeeQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<long, EmployeeDto>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var EmployeeEntity = await _employeeQueryRepository.Get(request.Id, cancellationToken);

            var mappedEmployee = _mapper.Map<Employee>(EmployeeEntity);
            mappedEmployee.IsDeleted = true;
            var savedEmployee= await _employeeRepository.Update(mappedEmployee, cancellationToken);
            var EmployeeResponse = new BasePostResponseDto<long, EmployeeDto>
            {
                Id = savedEmployee.Id
           ,
                Success = true
           ,
                Message = "Employee Deleted successfully"


            };
            return EmployeeResponse;
        }
    }
}
