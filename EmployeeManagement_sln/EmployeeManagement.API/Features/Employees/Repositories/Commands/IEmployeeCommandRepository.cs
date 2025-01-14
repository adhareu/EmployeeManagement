using EmployeeManagement.API.Features.Employees.Models;

namespace EmployeeManagement.API.Features.Employees.Repositories.Commands
{
    public interface IEmployeeCommandRepository
    {
        Task<Employee> Create(Employee employee, CancellationToken cancellationToken);

        Task<Employee> Update(Employee employee, CancellationToken cancellationToken);
        Task<Employee> Delete(long id, CancellationToken cancellationToken);
    }
}
