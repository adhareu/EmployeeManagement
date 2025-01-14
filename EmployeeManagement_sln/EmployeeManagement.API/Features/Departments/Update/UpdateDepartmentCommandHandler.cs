
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Repositories.Commands;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Update
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BasePostResponseDto<int, DepartmentDto>>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;
        public UpdateDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository, IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentQueryRepository = departmentQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<int, DepartmentDto>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentEntity = await _departmentQueryRepository.Get(request.Id, cancellationToken);

            var mappeddepartment = _mapper.Map(request, departmentEntity);
            var savedDepartment = await _departmentRepository.Update(mappeddepartment, cancellationToken);
            var departmentResponse = new BasePostResponseDto<int, DepartmentDto>
            {
                Id = savedDepartment.Id
           ,
                Success = true
           ,
                Message = "Department Updated successfully"


            };
            return departmentResponse;
        }
    }
}
