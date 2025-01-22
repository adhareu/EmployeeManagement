using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.API.Features.Users.DTOS;
using EmployeeManagement.API.Features.Users.Services;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.API.Features.Users.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextService _httpContextService;
        public RefreshTokenCommandHandler(IConfiguration configuration, IHttpContextService httpContextService)
        {
            _configuration = configuration;
            _httpContextService = httpContextService;
        }

        public async Task<RefreshTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the refresh token from the request (in the cookie)
            var refreshToken = _httpContextService.GetRefreshTokenFromCookie();
            // Generate new Access Token
            var newAccessToken = _httpContextService.GenerateAccessToken(request.UserName); // You'd typically pull the username from the claims or cookie

            // Optionally, you can rotate the refresh token here (issue a new one)
            var newRefreshToken = _httpContextService.GenerateRefreshToken();
            _httpContextService.SetRefreshTokenCookie(newRefreshToken);
            return new RefreshTokenDto
            {
                AccessToken = newAccessToken,
                RefreshToken = refreshToken
            };

        }
      



        
    }
}
