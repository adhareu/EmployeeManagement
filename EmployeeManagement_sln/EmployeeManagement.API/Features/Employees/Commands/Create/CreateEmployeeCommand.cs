using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<BasePostResponseDto<long, EmployeeDto>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }



        public DateTime JoiningDate { get; set; } = DateTime.Now.Date;
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;

        public bool IsActive { get; set; }


        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}
