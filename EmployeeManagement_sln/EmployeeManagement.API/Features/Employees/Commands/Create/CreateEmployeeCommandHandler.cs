using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Commands;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BasePostResponseDTO<long, EmployeeDto>>
    {
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IEmployeeCommandRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDTO<long, EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
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
            var employeeAddResponse = new BasePostResponseDTO<long, EmployeeDto>
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
