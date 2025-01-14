using EmployeeManagement.API.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.API.Features.Users.Models
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity<long>
    {
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
