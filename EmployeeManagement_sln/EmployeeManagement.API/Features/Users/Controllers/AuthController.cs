using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.API.Features.Users.Commands.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.API.Features.Users.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginCommand loginRequest)
        {
            // Here, validate the user credentials from the database (this is just a mock)
            if (loginRequest.UserName != "admin" || loginRequest.Password != "admin")
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate JWT token
            var token = GenerateJwtToken(loginRequest.UserName);

            return Ok(new { token });
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")  // You can add roles or other claims
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToInt64(_configuration["Jwt:ExpiryHours"])),
                signingCredentials: creds
            );
            _logger.LogInformation("Generated JWT for {Username} with roles: {Roles}", username, string.Join(", ", claims.Select(c => c.Value)));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
