
using System.Linq;
using System.Threading;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Database;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.API.Features.Designations.Repositories.Queries
{
    public class DesignationQueryRepository : IDesignationQueryRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public DesignationQueryRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }



        public async Task<bool> IsExists(int? id, string name, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return await _context.Designations.AnyAsync(e => !e.IsDeleted && string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase), cancellationToken);
            }
            else
            {
                return await _context.Designations.AnyAsync(e => !e.IsDeleted && e.Id != id && string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase), cancellationToken);

            }
        }

        public async Task<Designation> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Designations.FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == id, cancellationToken);
        }

        public async Task<List<Designation>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Designations.Where(e => !e.IsDeleted).AsNoTracking().ToListAsync(cancellationToken);
        }


    }
}
