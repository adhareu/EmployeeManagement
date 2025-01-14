using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Database;

namespace EmployeeManagement.API.Features.Designations.Repositories.Commands
{
    public class DesignationCommandRepository : IDesignationCommandRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public DesignationCommandRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Designation> Create(Designation designation, CancellationToken cancellationToken)
        {

            _context.Designations.Add(designation);
            await _context.SaveChangesAsync(cancellationToken);
            return designation;
        }





        public async Task<Designation> Update(Designation designation, CancellationToken cancellationToken)
        {
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync(cancellationToken);
            return designation;
        }

        public async Task<Designation> Delete(int id, CancellationToken cancellationToken)
        {
            var designation = await _context.Designations.FindAsync(new object[] { id }, cancellationToken);
            if (designation == null) throw new ArgumentNullException(nameof(designation));
            designation.IsDeleted = true;
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync(cancellationToken);
            return designation;
        }
    }
}
