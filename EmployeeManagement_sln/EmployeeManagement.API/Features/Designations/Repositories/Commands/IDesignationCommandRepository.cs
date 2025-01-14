using EmployeeManagement.API.Features.Designations.Models;

namespace EmployeeManagement.API.Features.Designations.Repositories.Commands
{
    public interface IDesignationCommandRepository
    {
        Task<Designation> Create(Designation Designation, CancellationToken cancellationToken);

        Task<Designation> Update(Designation Designation, CancellationToken cancellationToken);
        Task<Designation> Delete(int id, CancellationToken cancellationToken);

    }
}
