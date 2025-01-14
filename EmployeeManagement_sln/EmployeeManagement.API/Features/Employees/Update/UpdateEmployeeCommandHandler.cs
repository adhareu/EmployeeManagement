using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Repositories.Commands;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BasePostResponseDto<long, EmployeePostDto>>
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
        public async Task<BasePostResponseDto<long, EmployeePostDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = await _employeeQueryRepository.Get(request.Id, cancellationToken);

            var mappedDesignation = _mapper.Map(request, employeeEntity);
            var savedDesignation = await _employeeRepository.Update(mappedDesignation, cancellationToken);
            var employeeResponse = new BasePostResponseDto<long, EmployeePostDto>
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
