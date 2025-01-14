

namespace EmployeeManagement.API.Features.Designations.DTOS
{
    public record DesignationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
