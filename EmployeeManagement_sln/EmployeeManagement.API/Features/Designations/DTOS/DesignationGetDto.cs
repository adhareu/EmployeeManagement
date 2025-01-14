

namespace EmployeeManagement.API.Features.Designations.DTOS
{
    public record DesignationListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
