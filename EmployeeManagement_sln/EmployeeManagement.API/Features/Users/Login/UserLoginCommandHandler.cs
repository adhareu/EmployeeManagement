using Azure.Core;
using Azure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using EmployeeManagement.API.Features.Users.DTOS;
using EmployeeManagement.API.Features.Users.Services;

namespace EmployeeManagement.API.Features.Users.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, LoginDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextService _httpContextService;
        public UserLoginCommandHandler(IConfiguration configuration, IHttpContextService httpContextService)
        {
            _configuration = configuration;
            _httpContextService = httpContextService;
        }
        public async Task<LoginDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            // Generate JWT token
            var token = _httpContextService.GenerateAccessToken(request.UserName);
            // Generate Refresh Token
            var refreshToken = _httpContextService.GenerateRefreshToken();

            // Store the refresh token securely in a cookie (with HttpOnly flag)
            _httpContextService.SetRefreshTokenCookie(refreshToken);
            return new LoginDto
            {
                AccessToken = token,
                RefreshToken = refreshToken
            };
        }
      
    }
}
