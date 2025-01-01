using AutoMapper;
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Commands;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BasePostResponseDTO<int, DepartmentDto>>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;

        }
        public async Task<BasePostResponseDTO<int, DepartmentDto>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Name

            };
            var savedDepartment = await _departmentRepository.Create(department, cancellationToken);
            var departmentAddResponse = new BasePostResponseDTO<int, DepartmentDto>
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
