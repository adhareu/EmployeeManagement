using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Departments.Repositories.Commands;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Create
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BasePostResponseDto<int, DepartmentPostDto>>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDto<int, DepartmentPostDto>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Name

            };
            var savedDepartment = await _departmentRepository.Create(department, cancellationToken);
            var departmentAddResponse = new BasePostResponseDto<int, DepartmentPostDto>
            {
                Id = savedDepartment.Id
           ,
                Success = true
           ,
                Message = "Department created successfully"


            };
            return departmentAddResponse;
        }
    }
}
