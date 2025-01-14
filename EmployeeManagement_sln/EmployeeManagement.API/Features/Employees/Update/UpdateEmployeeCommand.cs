using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Update
{
    public class UpdateEmployeeCommand : IRequest<BasePostResponseDto<long, EmployeeDto>>
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;



        public DateTime JoiningDate { get; set; } = DateTime.Now.Date;
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;

        public bool IsActive { get; set; }


        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}
