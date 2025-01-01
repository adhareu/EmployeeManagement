
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.API.Infrastructure.Repositories.Employees.Queries
{
    public class EmployeeQueryRepository : IEmployeeQueryRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeQueryRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

     

      

        public async Task<Employee> Get(long id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(e => e.IsDeleted == false && e.Id == id, cancellationToken);
        }

        public async Task<List<Employee>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Employees.Where(x=>x.IsDeleted == false).AsNoTracking()
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .ToListAsync(cancellationToken);
        }

        public async Task<string> GenerateEmployeeCodeAsync(DateTime joiningDate)
        {
            string datePart = joiningDate.ToString("yyyyMMdd");
            int count = await _context.Employees.CountAsync(e => e.IsDeleted==false && e.JoiningDate.Date == joiningDate.Date);
            return $"{datePart}-{count + 1:D4}";
        }
    }
}
