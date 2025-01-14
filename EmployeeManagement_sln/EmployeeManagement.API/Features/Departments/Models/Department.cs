using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.API.Common.Models;
using EmployeeManagement.API.Features.Employees.Models;


namespace EmployeeManagement.API.Features.Departments.Models
{
    [Table("Department", Schema = "dbo")]
    public class Department : BaseEntity<int>
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
      
    }
}
