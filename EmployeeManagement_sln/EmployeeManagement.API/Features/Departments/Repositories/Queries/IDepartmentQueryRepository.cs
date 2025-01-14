using EmployeeManagement.API.Features.Departments.Models;

namespace EmployeeManagement.API.Features.Departments.Repositories.Queries
{
    public interface IDepartmentQueryRepository
    {

        Task<Department> Get(int id, CancellationToken cancellationToken);
        Task<List<Department>> GetAll(CancellationToken cancellationToken);

        Task<bool> IsExists(int? id, string name, CancellationToken cancellationToken);
    }
}
