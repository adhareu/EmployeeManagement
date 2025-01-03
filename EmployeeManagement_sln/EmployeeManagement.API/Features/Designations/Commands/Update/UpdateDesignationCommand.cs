﻿using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.DTOS;

using MediatR;

namespace EmployeeManagement.API.Features.Designations.Commands.Update
{
    public class UpdateDesignationCommand : IRequest<BasePostResponseDTO<int, DesignationDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
