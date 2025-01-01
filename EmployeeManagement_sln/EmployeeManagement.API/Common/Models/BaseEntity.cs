namespace EmployeeManagement.API.Common.Models
{
    public class BaseEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
       
        public bool IsDeleted { get; set; } = false;
    }
}
