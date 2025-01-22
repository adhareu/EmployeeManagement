using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using EmployeeManagement.API.Features.Users.Commands.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var token = GenerateAccessToken(loginRequest.UserName);
            // Generate Refresh Token
            var refreshToken = GenerateRefreshToken();

            // Store the refresh token securely in a cookie (with HttpOnly flag)
            SetRefreshTokenCookie(refreshToken);

            return Ok(new { AccessToken = token, RefreshToken = refreshToken });

        }
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] UserLoginCommand loginRequest)
        {
            // Retrieve the refresh token from the request (in the cookie)
            var refreshToken = GetRefreshTokenFromCookie();

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("No refresh token found.");
            }

            // Validate the refresh token (this example assumes it's valid if present)
            // Normally, you would validate the refresh token's integrity (via a hash or by expiration date).
            if (refreshToken == "InvalidToken")
            {
                return Unauthorized("Invalid refresh token.");
            }

            // Generate new Access Token
            var newAccessToken = GenerateAccessToken(loginRequest.UserName); // You'd typically pull the username from the claims or cookie

            // Optionally, you can rotate the refresh token here (issue a new one)
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshTokenCookie(newRefreshToken);

            return Ok(new { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
        }
        private string GenerateAccessToken(string username)
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
                expires: DateTime.Now.AddMinutes(Convert.ToInt64(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: creds
            );
            _logger.LogInformation("Generated JWT for {Username} with roles: {Roles}", username, string.Join(", ", claims.Select(c => c.Value)));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GenerateRefreshToken()
        {
            // Create a new refresh token (using GUID in this example)
            var refreshToken = Guid.NewGuid().ToString();
            return refreshToken;
        }

        private void SetRefreshTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(7),
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);
        }

        private string GetRefreshTokenFromCookie()
        {
            return Request.Cookies["refresh_token"];
        }
    }
}
