using EmployeeManagement.API.Features.Users.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Users.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenDto>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
