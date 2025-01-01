using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.API.Common.Models;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Designations.Models;


namespace EmployeeManagement.API.Features.Employees.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee : BaseEntity<long>
    {
       
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeCode { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool IsActive { get; set; }
       
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Required]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation Designation { get; set; }
        //[ForeignKey("CreatedBy")]
        //public User CreatedByUser { get; set; }
        //[ForeignKey("LastModifiedBy")]
        //public User? LastModifiedByUser { get; set; }
    }
}
