
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Queries;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Delete
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BasePostResponseDto<int, DepartmentListDto>>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;
        public DeleteDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository, IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentQueryRepository= departmentQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<int, DepartmentListDto>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentEntity = await _departmentQueryRepository.Get(request.Id, cancellationToken);

            var mappeddepartment = _mapper.Map<Department>(departmentEntity);
            mappeddepartment.IsDeleted = true;
            var savedDepartment= await _departmentRepository.Update(mappeddepartment, cancellationToken);
            var departmentResponse = new BasePostResponseDto<int, DepartmentListDto>
            {
                Id = savedDepartment.Id
           ,
                Success = true
           ,
                Message = "Department Deleted successfully"


            };
            return departmentResponse;
        }
    }
}
