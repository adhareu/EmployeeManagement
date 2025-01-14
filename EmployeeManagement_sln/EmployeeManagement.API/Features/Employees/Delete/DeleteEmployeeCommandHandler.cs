
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Repositories.Commands;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BasePostResponseDto<long, EmployeePostDto>>
    {
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;
        public DeleteEmployeeCommandHandler(IEmployeeCommandRepository employeeRepository, IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeQueryRepository = employeeQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<long, EmployeePostDto>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var EmployeeEntity = await _employeeQueryRepository.Get(request.Id, cancellationToken);

            var mappedEmployee = _mapper.Map<Employee>(EmployeeEntity);
            mappedEmployee.IsDeleted = true;
            var savedEmployee = await _employeeRepository.Update(mappedEmployee, cancellationToken);
            var EmployeeResponse = new BasePostResponseDto<long, EmployeePostDto>
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
