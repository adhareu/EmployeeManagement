using EmployeeManagement.API.Common.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.API.Features.Users
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity<long>
    {
        public string Login { get; set; }
        public string Name{ get; set; }
        public string Password{ get; set; }
    
    }
}
