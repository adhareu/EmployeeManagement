namespace EmployeeManagement.API.Features.Departments.DTOS
{
    public record DepartmentGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
