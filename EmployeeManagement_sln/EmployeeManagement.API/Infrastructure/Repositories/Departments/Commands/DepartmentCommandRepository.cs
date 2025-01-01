
using EmployeeManagement.API.Features.Departments.Models;

using EmployeeManagement.API.Infrastructure.Persistence;


namespace EmployeeManagement.API.Infrastructure.Repositories.Departments.Commands
{
    public class DepartmentCommandRepository : IDepartmentCommandRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public DepartmentCommandRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Create(Department department, CancellationToken cancellationToken)
        {
           
            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);
            return department;
        }

       

      
      
        public async Task<Department> Update(Department department, CancellationToken cancellationToken)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync(cancellationToken);
            return department;
        }

        public async Task<Department> Delete(int id, CancellationToken cancellationToken)
        {
            var department = await _context.Departments.FindAsync(new object[] { id }, cancellationToken);
            if (department == null) throw new ArgumentNullException(nameof(department));
            department.IsDeleted = true;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync(cancellationToken);
            return department;
        }
    }
}
