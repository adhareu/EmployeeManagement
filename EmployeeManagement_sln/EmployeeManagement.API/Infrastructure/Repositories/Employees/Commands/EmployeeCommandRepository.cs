
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.API.Infrastructure.Repositories.Employees.Commands
{
    public class EmployeeCommandRepository : IEmployeeCommandRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeCommandRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee, CancellationToken cancellationToken)
        {
            employee.EmployeeCode = await GenerateEmployeeCodeAsync(employee.JoiningDate);
           
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        private async Task<string> GenerateEmployeeCodeAsync(DateTime joiningDate)
        {
            string datePart = joiningDate.ToString("yyyyMMdd");
            int count = await _context.Employees.CountAsync(e => e.IsDeleted == false && e.JoiningDate.Date == joiningDate.Date);
            return $"{datePart}-{count + 1:D4}";
        }

     

        public async Task<Employee> Update(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        public async Task<Employee> Delete(long id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(new object[] { id }, cancellationToken);
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            employee.IsDeleted = true;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }
    }
}
