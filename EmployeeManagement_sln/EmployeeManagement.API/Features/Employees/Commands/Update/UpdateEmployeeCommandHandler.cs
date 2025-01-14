using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BasePostResponseDto<long, EmployeeDto>>
    {
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;
        public UpdateEmployeeCommandHandler(IEmployeeCommandRepository employeeRepository, IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeQueryRepository = employeeQueryRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDto<long, EmployeeDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = await _employeeQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map(request, employeeEntity);
            var savedDesignation = await _employeeRepository.Update(mappedDesignation, cancellationToken);
            var employeeResponse = new BasePostResponseDto<long, EmployeeDto>
            {
                Id = savedDesignation.Id
           ,
                Success = true
           ,
                Message = "Employee Updated successfully"


            };
            return employeeResponse;
        }
    }
}
