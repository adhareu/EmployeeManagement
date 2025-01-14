using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Employees.Repositories.Commands;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BasePostResponseDto<long, EmployeeDto>>
    {
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IEmployeeCommandRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDto<long, EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

                JoiningDate = request.JoiningDate,
                IsActive = request.IsActive,
                IsDeleted = false,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                DesignationId = request.DesignationId

            };
            var savedemployee = await _employeeRepository.Create(employee, cancellationToken);
            var employeeAddResponse = new BasePostResponseDto<long, EmployeeDto>
            {
                Id = savedemployee.Id
           ,
                Success = true
           ,
                Message = "Employee created successfully"


            };
            return employeeAddResponse;
        }
    }
}
