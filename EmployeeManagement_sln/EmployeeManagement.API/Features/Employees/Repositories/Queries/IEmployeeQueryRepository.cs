using EmployeeManagement.API.Features.Employees.Models;

namespace EmployeeManagement.API.Features.Employees.Repositories.Queries
{
    public interface IEmployeeQueryRepository
    {

        Task<Employee> Get(long id, CancellationToken cancellationToken);
        Task<List<Employee>> GetAll(CancellationToken cancellationToken);
        Task<string> GenerateEmployeeCodeAsync(DateTime joiningDate);
    }
}
