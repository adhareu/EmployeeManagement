﻿using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Departments.Commands.Update
{
    public class UpdateDepartmentCommand : IRequest<BasePostResponseDTO<int, DepartmentDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
