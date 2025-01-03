﻿using EmployeeManagement.API.Features.Departments.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Departments.Queries
{
    public class GetAllDepartmentQuery : IRequest<IEnumerable<DepartmentDto>>
    {
    }
}
