using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using EmployeeManagement.API.Features.Users.Login;
using EmployeeManagement.API.Features.Users.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeManagement.API.Features.Users.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;
        public AuthController( ILogger<AuthController> logger, IMediator mediator)
        {
           
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand loginRequest)
        {
            // Here, validate the user credentials from the database (this is just a mock)
            if (loginRequest.UserName != "admin" || loginRequest.Password != "admin")
            {
                return Unauthorized("Invalid username or password.");
            }
            try
            {
                var response = await _mediator.Send(loginRequest);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }

        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand loginRequest)
        {
            try
            {
                var response = await _mediator.Send(loginRequest);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }
      
    }
}
