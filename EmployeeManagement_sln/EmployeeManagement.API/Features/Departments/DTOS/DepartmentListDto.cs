

namespace EmployeeManagement.API.Features.Departments.DTOS
{
    public record DepartmentListDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
