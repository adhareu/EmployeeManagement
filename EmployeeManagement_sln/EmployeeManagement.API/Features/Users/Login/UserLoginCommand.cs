using EmployeeManagement.API.Features.Users.DTOS;
using MediatR;

namespace EmployeeManagement.API.Features.Users.Login
{
    public record UserLoginCommand : IRequest<LoginDto>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
