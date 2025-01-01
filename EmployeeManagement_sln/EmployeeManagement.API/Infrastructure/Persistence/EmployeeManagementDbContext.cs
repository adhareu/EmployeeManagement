using System.Reflection;
using EmployeeManagement.API.Features.Departments.Models;
using EmployeeManagement.API.Features.Designations.Models;
using EmployeeManagement.API.Features.Employees.Models;
using EmployeeManagement.API.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Infrastructure.Persistence
{
    public class EmployeeManagementDbContext:DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var cascadeFKs = builder.Model.GetEntityTypes()
       .SelectMany(t => t.GetForeignKeys())
       .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.ClientNoAction;

            base.OnModelCreating(builder);
        }

    }
}
