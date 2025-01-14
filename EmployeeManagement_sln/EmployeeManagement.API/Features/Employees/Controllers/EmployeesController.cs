
using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Employees.Delete;
using EmployeeManagement.API.Features.Employees.Create;
using EmployeeManagement.API.Features.Employees.DTOS;
using EmployeeManagement.API.Features.Employees.Get;
using EmployeeManagement.API.Features.Employees.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Features.Employees.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeDto>> GetAll()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<BasePostResponseDto<long, EmployeeDto>>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(long id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [HttpPut]

        public async Task<ActionResult<BasePostResponseDto<long, EmployeeDto>>> Update([FromBody] UpdateEmployeeCommand command)
        {

            var response = await _mediator.Send(command);
            return Ok(response);


        }
        [HttpDelete]

        public async Task<ActionResult<BasePostResponseDto<long, EmployeeDto>>> Delete(long Id)
        {

            var response = await _mediator.Send(new DeleteEmployeeCommand(Id));
            return Ok(response);


        }
    }
}
