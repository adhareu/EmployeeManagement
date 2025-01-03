﻿using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Departments.Commands.Create;
using EmployeeManagement.API.Features.Departments.Commands.Delete;
using EmployeeManagement.API.Features.Departments.Commands.Update;
using EmployeeManagement.API.Features.Departments.DTOS;
using EmployeeManagement.API.Features.Departments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Features.Departments.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DepartmentsController> _logger;
        public DepartmentsController(IMediator mediator, ILogger<DepartmentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DepartmentDto>> GetAll()
        {
            _logger.LogInformation("Get All Departments");
            var response = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            _logger.LogInformation("Get All Departments by {Id}",id);
            var department = await _mediator.Send(new GetDepartmentByIdQuery(id));

            if (department == null)
                return NotFound();

            return Ok(department);
        }
        [HttpPost]
        public async Task<ActionResult<BasePostResponseDTO<int,DepartmentDto>>> Create([FromBody] CreateDepartmentCommand command)
        {
            _logger.LogInformation("Creating Department with name {Name}", command.Name);
            var response = await _mediator.Send(command);
            _logger.LogInformation("Created Department with name {Name}", command.Name);
            return Ok(response);
        }
       
        [HttpPut]
      
        public async Task<ActionResult<BasePostResponseDTO<int, DepartmentDto>>> Update([FromBody] UpdateDepartmentCommand command)
        {
            _logger.LogInformation("Updating Department with name {Name}", command.Name);
            var response = await _mediator.Send(command);
            _logger.LogInformation("Updated Department with name {Name}", command.Name);
            return Ok(response);


        }
        [HttpDelete]

        public async Task<ActionResult<BasePostResponseDTO<int, DepartmentDto>>> Delete(int Id)
        {
            _logger.LogInformation("Deleting Department with id {Id}", Id);
            var response = await _mediator.Send(new DeleteDepartmentCommand(Id));
            _logger.LogInformation("Deleted Department with id {Id}", Id);
            return Ok(response);


        }
    }
}
