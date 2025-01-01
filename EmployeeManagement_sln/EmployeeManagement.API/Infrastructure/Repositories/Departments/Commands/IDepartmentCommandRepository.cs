using EmployeeManagement.API.Features.Departments.Models;

namespace EmployeeManagement.API.Infrastructure.Repositories.Departments.Commands
{
    public interface IDepartmentCommandRepository
    {
        Task<Department> Create(Department Department, CancellationToken cancellationToken);
       
        Task<Department> Update(Department Department, CancellationToken cancellationToken);
        Task<Department> Delete(int id, CancellationToken cancellationToken);
       
    }
}
