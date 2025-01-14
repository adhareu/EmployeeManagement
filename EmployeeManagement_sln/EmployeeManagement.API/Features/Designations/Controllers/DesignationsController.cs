using EmployeeManagement.API.Common.DTOS;
using EmployeeManagement.API.Features.Designations.Delete;
using EmployeeManagement.API.Features.Designations.DTOS;


using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using EmployeeManagement.API.Features.Designations.Get;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagement.API.Features.Designations.Create;
using EmployeeManagement.API.Features.Designations.Update;

namespace EmployeeManagement.API.Features.Designations.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DesignationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DesignationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DesignationDto>> GetAll()
        {
            var response = await _mediator.Send(new GetAllDesignationQuery());
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<BasePostResponseDto<int,DesignationDto>>> Create([FromBody] CreateDesignationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationDto>> Get(int id)
        {
            var Designation = await _mediator.Send(new GetDesignationByIdQuery(id));

            if (Designation == null)
                return NotFound();

            return Ok(Designation);
        }
        [HttpPut]

        public async Task<ActionResult<BasePostResponseDto<int, DesignationDto>>> Update([FromBody] UpdateDesignationCommand command)
        {

            var response = await _mediator.Send(command);
            return Ok(response);


        }
        [HttpDelete]

        public async Task<ActionResult<BasePostResponseDto<int, DesignationDto>>> Delete(int Id)
        {

            var response = await _mediator.Send(new DeleteDesignationCommand(Id));
            return Ok(response);


        }
    }
}
