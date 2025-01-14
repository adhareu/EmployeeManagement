
using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Departments.Repositories.Commands;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Delete
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BasePostResponseDto<int, DepartmentPostDto>>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        private readonly IMapper _mapper;
        public DeleteDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository, IDepartmentQueryRepository departmentQueryRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentQueryRepository = departmentQueryRepository;
            _mapper = mapper;
        }
        public async Task<BasePostResponseDto<int, DepartmentPostDto>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentEntity = await _departmentQueryRepository.Get(request.Id, cancellationToken);

            var mappeddepartment = _mapper.Map<Department>(departmentEntity);
            mappeddepartment.IsDeleted = true;
            var savedDepartment = await _departmentRepository.Update(mappeddepartment, cancellationToken);
            var departmentResponse = new BasePostResponseDto<int, DepartmentPostDto>
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
