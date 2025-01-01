namespace EmployeeManagement.API.Features.Employees.DTOS
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string EmployeeCode { get; set; }

        public DateTime JoiningDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}
