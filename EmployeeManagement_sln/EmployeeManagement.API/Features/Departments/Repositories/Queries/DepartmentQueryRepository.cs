using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Database;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.API.Features.Departments.Repositories.Queries
{
    public class DepartmentQueryRepository : IDepartmentQueryRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public DepartmentQueryRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }



        public async Task<bool> IsExists(int? id, string name, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return await _context.Departments.AnyAsync(e => !e.IsDeleted && string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase), cancellationToken);
            }
            else
            {
                return await _context.Departments.AnyAsync(e => !e.IsDeleted && e.Id != id && string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase), cancellationToken);

            }
        }

        public async Task<Department> Get(int id, CancellationToken cancellationToken) => await _context.Departments.FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == id, cancellationToken);

        public async Task<List<Department>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Departments.Where(e => !e.IsDeleted).AsNoTracking().ToListAsync(cancellationToken);
        }


    }
}
