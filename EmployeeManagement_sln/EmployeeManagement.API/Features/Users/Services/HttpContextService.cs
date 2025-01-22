using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.API.Features.Users.Services
{

    public class HttpContextService : IHttpContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public HttpContextService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetRefreshTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,   // Prevents JavaScript access (XSS protection)
                Secure = true,     // Use Secure flag for HTTPS
                SameSite = SameSiteMode.Strict, // Restrict cross-site requests
                Expires = DateTime.UtcNow.AddDays(7) // Set expiration for the refresh token
            };

            _httpContextAccessor.HttpContext?.Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);
        }
        public string GetRefreshTokenFromCookie()
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies["refresh_token"];
        }
        public string GenerateAccessToken(string username)
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

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            // Create a new refresh token (using GUID in this example)
            var refreshToken = Guid.NewGuid().ToString();
            return refreshToken;
        }

    }
}
