﻿using EmployeeManagement.API.Features.Designations.Models;

namespace EmployeeManagement.API.Features.Designations.Repositories.Queries
{
    public interface IDesignationQueryRepository
    {

        Task<Designation> Get(int id, CancellationToken cancellationToken);
        Task<List<Designation>> GetAll(CancellationToken cancellationToken);

        Task<bool> IsExists(int? id, string name, CancellationToken cancellationToken);
    }
}
