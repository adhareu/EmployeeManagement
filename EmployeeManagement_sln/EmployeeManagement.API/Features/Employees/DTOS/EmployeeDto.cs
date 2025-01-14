namespace EmployeeManagement.API.Features.Employees.DTOS
{
    public record EmployeeDto
    {
        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string EmployeeCode { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}
