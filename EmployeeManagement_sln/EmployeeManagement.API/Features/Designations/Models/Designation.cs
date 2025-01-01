using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.API.Common.Models;
using EmployeeManagement.API.Features.Employees.Models;


namespace EmployeeManagement.API.Features.Designations.Models
{
    [Table("Designation", Schema = "dbo")]
    public class Designation : BaseEntity<int>
    {
       
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
      
    }
}
